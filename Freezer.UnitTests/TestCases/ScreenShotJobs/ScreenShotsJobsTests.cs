using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Freezer.Core;
using Freezer.Engines;
using Freezer.UnitTests.HttpMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freezer.UnitTests.TestCases.ScreenShotJobs
{
    [TestClass]
    public class ScreenShotsJobsTests
    {
        private static StaticHttpServer _httpServer;

        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            _httpServer = new StaticHttpServer(FreezerTestPathSolver.GetDirectory("WebPages"));
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            _httpServer.Dispose();
        }

        #region Zone Tests

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_Visible_Screen()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1600, 900)
                .SetCaptureZone(CaptureZone.VisibleScreen);

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(1600, 900), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_Visible_Screen_Long_Page_With_Scroll()
        {
            var url = $"{_httpServer.BoundURL}/Global/longpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen);

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(800, 600), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_Full_Document()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1600, 900)
                .SetCaptureZone(CaptureZone.FullPage);

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(1584, 97), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_Full_Document_Long_Page_With_Scroll()
        {
            var url = $"{_httpServer.BoundURL}/Global/longpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.FullPage);
             
            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(1080, 2500), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_Full_Document_Short_Page()
        {
            var url = $"{_httpServer.BoundURL}/Global/shortpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.FullPage);

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(784, 250), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_JQuery_Selector_Short_Page()
        {
            var url = $"{_httpServer.BoundURL}/Global/shortpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new JQuerySelectedZone("body"));

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(784, 250), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_JQuery_Selector_Long_Page()
        {
            var url = $"{_httpServer.BoundURL}/Global/longpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new JQuerySelectedZone("div"));

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(1080, 2500), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_JQuery_Selector_Out_Of_Scroll_Block()
        {
            var url = $"{_httpServer.BoundURL}/Global/outofscroll.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new JQuerySelectedZone("#greenblock"));

            using (var result = (Image) screenShotJob.Freeze())
            {
                AssertExtensions.BitmapEquals("ExpectedBitmapsResults/Out_Of_Scroll.png",
                    result);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Crop_Zone()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1600, 900)
                .SetCaptureZone(new CroppedZone(0,0,25,156));

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(25, 156), result.Size);
            }
        }
        
        [TestMethod]
        public void ScreenshotJob_Validate_UserDefinedJavascriptZone()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new UserDefinedJavascriptZone("readcoordinate",
                @"function readcoordinate() {
                      return  {x: 5, y: 25, width: 231, height: 425}; 
                }"));

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(231, 425), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_UserDefinedJavascriptZone_SecondaryFunction()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new UserDefinedJavascriptZone("readcoordinate",
                @"function readcoordinate() {
                      return  {x: 5, y: 25, width: getwidth(), height: 425}; 
                }
              
                function getwidth() { 
                      return 454;
                }
"));

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(454, 425), result.Size);
            }
        }

        #endregion

        #region Error Handling

        [TestMethod]
        public void ScreenshotJob_Validate_Document_With_Alert()
        {
            var url = $"{_httpServer.BoundURL}/Global/alertpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1600, 900)
                .SetCaptureZone(CaptureZone.FullPage)
                .SetTrigger(new WindowLoadTrigger(100)); // Make sure alert pop up before capture

            using (var result = (Image) screenShotJob.Freeze())
            {
                Assert.AreEqual(new Size(1584, 20), result.Size);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Check_Handling_Of_Connection_Refused()
        {
            var url = "http://127.0.0.8:1";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1600, 900)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger());

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.NavigationError);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Check_Handling_Of_Invalid_DNS()
        {
            var url = "http://ishouldnotitdomainnameppm.biz:8152";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1600, 900)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger());

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.NavigationError);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Check_Handling_Of_Timeout()
        {
            var url = $"{_httpServer.BoundURL}/Global/shortpage.html";

            try
            {
                _httpServer.WaitingTime = TimeSpan.FromSeconds(2.5D);

                var screenShotJob = ScreenshotJobBuilder.Create(url)
                    .SetCaptureZone(CaptureZone.VisibleScreen)
                    .SetTrigger(new WindowLoadTrigger())
                    .SetTimeout(TimeSpan.FromSeconds(2D));

                try
                {
                    using ((Image) screenShotJob.Freeze())
                    {
                        Assert.Fail("Freeze() should have thrown an error");
                    }
                }
                catch (CaptureEngineException exception)
                {
                    Assert.AreEqual(exception.State, CaptureEngineState.Timeout);
                }
            }
            finally 
            {
                _httpServer.WaitingTime = TimeSpan.Zero;
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Crop_Zone_Out_Of_Bounds()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(1024, 768)
                .SetCaptureZone(new CroppedZone(900, 0, 400, 156));

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.InvalidCaptureZone);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_JQuery_Zero_Width_Container()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/freezerfiredispatched.html";
            
            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetCaptureZone(new JQuerySelectedZone("#zerowidthcontainer"));

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.InvalidCaptureZone);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Bitmap_Size_JQuery_Selector_Invalid_Container()
        {
            var url = $"{_httpServer.BoundURL}/Global/shortpage.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new JQuerySelectedZone("#nonexistentcontainer"));

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.InvalidCaptureZone);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_UserDefinedJavascriptZone_Missing_Field()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new UserDefinedJavascriptZone("readcoordinate",
                @"function readcoordinate() {
                      return  {x: 5,  width: 231, height: 425}; 
                }"));

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.InvalidCaptureZone);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_UserDefinedJavascriptZone_UndefinedFunctionName()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new UserDefinedJavascriptZone("readcoordinatebadname",
                @"function readcoordinate() {
                      return  {x: 5, y:9,  width: 231, height: 425}; 
                }"));

            try
            {
                using ((Image) screenShotJob.Freeze())
                {
                    Assert.Fail("Freeze() should have thrown an error");
                }
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.InvalidCaptureZone);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_UserDefinedJavascriptZone_BadJavascriptImplementation()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/simpledocumentload.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(new UserDefinedJavascriptZone("readcoordinate",
                @"bad function readcoordinate() {
                      return  {x: 5, y: 56, width: 231, height: 425}; 
                }"));

            try
            {
                using ((Image) screenShotJob.Freeze()) { }

                Assert.Fail("Freeze() should have thrown an error");
            }
            catch (CaptureEngineException exception)
            {
                Assert.AreEqual(exception.State, CaptureEngineState.InvalidCaptureZone);
            }
        }

        #endregion

        [TestMethod]
        public void ScreenshotJob_Validate_Trigger_FreezerFire()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/freezerfiredispatched.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new FreezerJsEventTrigger());

            using (var result = (Image) screenShotJob.Freeze())
            {
                AssertExtensions.BitmapEquals(
                    "ExpectedBitmapsResults/Validate_FreezerFire_Dispatch_Event_With_Single_Page.png",
                    result);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Trigger_DomReady()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/freezerfiredispatched.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new DomReadyTrigger());

            using (var result = (Image) screenShotJob.Freeze())
            {
                AssertExtensions.BitmapEquals(
                    "ExpectedBitmapsResults/Validate_DomReady_Event_With_Single_Page.png",
                    result);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Trigger_WindowLoad()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/freezerfiredispatched.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger(50));

            using (var result = (Image) screenShotJob.Freeze())
            {
                AssertExtensions.BitmapEquals("ExpectedBitmapsResults/Validate_WindowLoad_Event_With_Single_Page.png",
                    result);
            }
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Cookie_Transfert()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/cookieprinter.html";
     
            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger())
                .AddCookie(new Cookie("127.0.0.1", "/", "FreezerCookie", "FreezerCookieValue"));

            using ((Image) screenShotJob.Freeze()) { }
           
            var cookieValue = _httpServer.LastCookies
                .First(c => c.Name == "FreezerCookie").Value;

            Assert.AreEqual("FreezerCookieValue", cookieValue);
        }

        [TestMethod]
        public void ScreenshotJob_Validate_User_Agent()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/cookieprinter.html";
           
            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger())
                .SetUserAgent("FakeBrowser");

            using ((Image) screenShotJob.Freeze()) { }

            Assert.AreEqual("FakeBrowser", _httpServer.LastUserAgent);
        }

        [TestMethod]
        public void ScreenshotJob_Validate_Accept_Languages()
        {
            var url = $"{_httpServer.BoundURL}/Triggers/cookieprinter.html";

            var screenShotJob = ScreenshotJobBuilder.Create(url)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger())
                .SetAcceptLanguages("mg,fr;q=0.5");

            using ((Image) screenShotJob.Freeze()) { }

            Assert.AreEqual("mg,fr;q=0.5", string.Join(",", _httpServer.LastAcceptLanguages));
        }

        [TestMethod]
        public void ScreenshotJob_Validate_LocalFile()
        {
            var localFile = new FileInfo("WebPages/Triggers/freezerfiredispatched.html");

            var screenShotJob = ScreenshotJobBuilder.Create(localFile.FullName)
                .SetBrowserSize(800, 600)
                .SetCaptureZone(CaptureZone.VisibleScreen)
                .SetTrigger(new WindowLoadTrigger(50));

            using (var result = (Image) screenShotJob.Freeze())
            {
                AssertExtensions.BitmapEquals("ExpectedBitmapsResults/Validate_WindowLoad_Event_With_Single_Page.png",
                    result);
            }
        }
    }
}
