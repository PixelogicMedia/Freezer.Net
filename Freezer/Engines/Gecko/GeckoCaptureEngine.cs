using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Freezer.Core;
using Freezer.Utils.Threading;
using Gecko;
using Gecko.Utils;

namespace Freezer.Engines.Gecko
{
    internal class GeckoCaptureEngine : CaptureEngine
    {
        class LocalInitializer: MarshalByRefObject
        {
            public void Init()
            {
                GeckoPreferences.User["browser.cache.disk.enable"] = false;
                GeckoPreferences.User["places.history.enabled"] = false;

                PromptFactory.PromptServiceCreator = () => new GeckoPromptServiceMock();
            }
        }
        
        public GeckoCaptureEngine(Size browserSize, Trigger trigger, CaptureZone captureZone)
            : base(browserSize, trigger, captureZone)
        {
            new ThreadLocal<LocalInitializer>(() => new LocalInitializer()).Value.Init();
        }
        
        public override Image CaptureUrl(string baseUrl, TimeSpan timeOut)
        {
            return InnerCaptureUrl(baseUrl, timeOut);
        }

        private Image InnerCaptureUrl(string baseUrl, TimeSpan timeOut)
        {
            Image result = null;

            object lockThread = new object();

            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                using (GeckoWebBrowser webBrowser = new GeckoWebBrowser() {
                    Size = BrowserSize,
                    Visible = true,
                    TabIndex = 0,
                    UseHttpActivityObserver = false
                })
                {


                    using (GeckoTriggerInstaller installer = new GeckoTriggerInstaller(webBrowser))
                    {
                        Exception readException = null;

                        installer.FireEvent += delegate
                        {
                            try
                            {
                                result = ReadBitmap(webBrowser, CaptureZone, new GeckoDocumentAdapter(webBrowser));
                                
                                webBrowser.Stop();
                            }
                            catch (Exception exception)
                            {

                                // Rethrow in principal
                                readException = exception;
                            }
                            finally
                            {

                                lock (lockThread)
                                {
                                    // Release the lock
                                    Monitor.Pulse(lockThread);
                                }
                            }
                        };

                        webBrowser.NavigationError += (sender, args) =>
                        {
                            readException = new CaptureEngineException($"Navigation error : {((GeckoWebBrowser) sender).StatusText}", CaptureEngineState.NavigationError);

                            lock (lockThread)
                            {
                                // Release the lock as loading sends an error
                                Monitor.Pulse(lockThread);
                            }
                        };
                        
                        Trigger.Install(installer);
                        
                        InitializeLanguage();
                        
                        InitializeCookies();
                        
                        InitializeUserAgent();


                        webBrowser.Navigate(baseUrl);

                        ApplicationExtensions.Run(applicationContext, webBrowser, lockThread, timeOut);

                        if (readException != null)
                        {
                            throw readException;
                        }

                        if (result == null)
                            throw new CaptureEngineException("Time out exception", CaptureEngineState.Timeout);
                    }
                }
            }

            return result;
        }

        private void InitializeUserAgent()
        {
            if (!string.IsNullOrWhiteSpace(UserAgent))
                GeckoPreferences.User["general.useragent.override"] = UserAgent;
        }

        private void InitializeCookies()
        {
            CookieManager.RemoveAll();

            if (Cookies != null)
            {
                foreach (var cookie in Cookies)
                {
                    CookieManager.Add(
                        cookie.Domain, cookie.Path,
                        cookie.Name, cookie.Value, cookie.Secure,
                        cookie.HTTPOnly, cookie.IsSession,
                        (long)
                            (cookie.Expires.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
                }
            }
        }

        private void InitializeLanguage()
        {
            if (!string.IsNullOrWhiteSpace(AcceptLanguages))
                GeckoPreferences.User["intl.accept_languages"] = AcceptLanguages;
        }

        private static Image ReadBitmap(GeckoWebBrowser webBrowser, CaptureZone captureZone, IActiveDocument activeDocument)
        {
            webBrowser.Stop();

            var rectangle = captureZone.GetZone(activeDocument);

            if (rectangle.Width == 0 || rectangle.Height == 0)
                throw new CaptureEngineException($"Selected zone is 0 area {rectangle}", CaptureEngineState.InvalidCaptureZone);

            try
            {
                return webBrowser.GetBitmap(
                    (uint) rectangle.X,
                    (uint) rectangle.Y,
                    (uint) rectangle.Width,
                    (uint) rectangle.Height);
            }
            catch (InvalidOperationException)
            {
                throw new CaptureEngineException("Out of memory. Result bitmap size is too large",
                    CaptureEngineState.InternalError);
            }
        }
    }

    //internal class RectangleUtils
    //{
    //    internal static IEnumerable<Rectangle> Split(Rectangle original, long maxSurface)
    //    {
    //        long currentSurface = original.Width * original.Height;

    //        if (currentSurface < maxSurface)
    //        {
    //            yield return original;
    //            yield break;
    //        }

    //        int slicingHeight = (int) (maxSurface/original.Width);

    //        List<int> allHeight = new List<int>();

    //        int totalheight = 0;

    //        while ((totalheight + slicingHeight) < original.Height)
    //        {
    //            allHeight.Add(slicingHeight);
    //            totalheight += slicingHeight;
    //        }

    //        var remainderHeight = (original.Height - totalheight);

    //        if (remainderHeight > 0)
    //        {
    //            allHeight.Add(remainderHeight);
    //        }

    //        int currentY = original.Y; 

    //        foreach (int height in allHeight)
    //        {
    //            yield return new Rectangle(original.X, 
    //                currentY, original.Width, height);

    //            currentY += height;
    //        }
    //    }

    //    internal static Bitmap BuildBitmap(GeckoWebBrowser webBrowser, Rectangle original, IEnumerable<Rectangle> parts)
    //    {
    //        System.GC.Collect();
    //        System.GC.WaitForPendingFinalizers();

    //        var  bitmapResult = new Bitmap(original.Width, original.Height, PixelFormat.Format16bppArgb1555 );

    //        using (Graphics g = Graphics.FromImage(bitmapResult))
    //        {
    //            int currentY = 0;
    //            foreach (var part in parts)
    //            {
    //                using (var currentPart = webBrowser.GetBitmap(
    //                    (uint)part.X,
    //                    (uint)part.Y,
    //                    (uint)part.Width,
    //                    (uint)part.Height))
    //                {
    //                    g.DrawImage(currentPart, new Rectangle(0, currentY, bitmapResult.Width,
    //                        currentPart.Height));

    //                    currentY += currentPart.Height;
    //                }
    //            }
    //        }

    //        return bitmapResult; 
    //    }
    //}
}
