using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Cookie = Freezer.Core.Cookie;

namespace Freezer.UnitTests.HttpMock
{
    /// <summary>
    /// This is a static and very unsecure web server for testing purpose only 
    /// </summary>
    public class StaticHttpServer : IDisposable
    {
        private readonly string _serveDirectory;
        private HttpListener _listener = new HttpListener();
        private readonly Guid _uniqueIdentifier = Guid.NewGuid();
        private readonly List<Cookie> _cookies = new List<Cookie>();

        /// <summary>
        /// Allows serveDirectory to be a static HttpServer bound in BoundURL
        /// </summary>
        /// <param name="serveDirectory"></param>
        public StaticHttpServer(string serveDirectory)
        {
            _serveDirectory = serveDirectory;
            
            BoundURL = $"http://127.0.0.1:45132/FreezerHttpListener/{_uniqueIdentifier}/";

            _listener.Prefixes.Add(BoundURL);
            _listener.Start();

            Listen(); 
        }

        /// <summary>
        /// Add waiting time to current server
        /// </summary>
        public TimeSpan WaitingTime { get; set; }

        public string LastUserAgent { get; private set; }

        public string [] LastAcceptLanguages { get; private set; }

        private void Listen()
        {
            _listener.BeginGetContext(OnBeginContext, _listener);
           
        }

        private  void OnBeginContext(IAsyncResult ar)
        {
            HttpListener listener = (HttpListener) ar.AsyncState;

            try
            {
                if (!listener.IsListening)
                    return; 

                HttpListenerContext context = listener.EndGetContext(ar);
                HttpListenerRequest request = context.Request;

                LastUserAgent = request.UserAgent;
                LastAcceptLanguages = request.UserLanguages?.ToArray();

                foreach (System.Net.Cookie cookie in request.Cookies)
                {
                   _cookies.Add(new Cookie()
                   {
                       Path = cookie.Path,
                       HTTPOnly = cookie.HttpOnly,
                       Value = cookie.Value,
                       Secure = cookie.Secure,
                       IsSession = true,
                       Expires = cookie.Expires,
                       Name = cookie.Name,
                       Domain = cookie.Domain
                   });
                }

               string requestedPath = Regex.Replace(request.Url.ToString(), $"^.*{_uniqueIdentifier}", String.Empty, RegexOptions.Singleline)
                    .TrimStart("/\\".ToCharArray());

                var expectedPath = Path.Combine(_serveDirectory, requestedPath);

                if (WaitingTime > TimeSpan.Zero)
                    Thread.Sleep(WaitingTime);

                if (!File.Exists(expectedPath))
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    context.Response.OutputStream.Write($"The path {expectedPath} file was not found on this web server");
                }
                else
                {
                    var mimeType = MimeMapping.GetMimeMapping(expectedPath);
                    var fileBytes = File.ReadAllBytes(expectedPath);

                    context.Response.StatusCode = 200;
                    context.Response.ContentType = mimeType;
                    context.Response.OutputStream.Write(fileBytes, 0, fileBytes.Length);
                }

                context.Response.Close();

                listener.BeginGetContext(OnBeginContext, listener);
            }
            catch (ObjectDisposedException)
            {

            }
        }

        public string BoundURL { get;  }


        public IReadOnlyCollection<Cookie> LastCookies
        {
            get
            {
                return _cookies.AsReadOnly();
            }
        }

        public void ClearCookie()
        {
            _cookies.Clear();
        }

        public void Dispose()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener = null; 
            }
        }
        
    }

    internal static class HttpListenerExtensions
    {
        public static void Write(this Stream stream, string text)
        {
            using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8, 8192, true))
            {
                streamWriter.Write(text);
            }
        }
    }

    internal static class FreezerTestPathSolver
    {
        public static string GetDirectory(string relativePath)
        {
            return new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, relativePath)).FullName; 
        }
    }
}
