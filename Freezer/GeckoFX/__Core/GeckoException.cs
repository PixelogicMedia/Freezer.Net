using System;

// Mozilla error lookup utility is located here
// http://james-ross.co.uk/mozilla/misc/nserror

namespace Gecko
{
    /// <summary>
    /// Base exception class for all xullrunner exceptions
    /// General errors may be mapped here
    /// </summary>
    [Serializable]
    internal class GeckoException
        : Exception
    {
        internal GeckoException()
            : base()
        {
        }

        internal GeckoException(string message)
            : base(message)
        {
        }

        internal GeckoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// nsIException wrapper
    /// </summary>
    internal sealed class GeckoNativeException
        : GeckoException
    {
        private nsIException _exception;

        private GeckoNativeException(nsIException exception)
            : base(nsString.Get(exception.GetMessageAttribute))
        {
            _exception = exception;
        }

        public string Name
        {
            get { return nsString.Get(_exception.GetNameAttribute); }
        }


// see firefox bug 1229664
#if NO_LONGER_EXISTS_IN_GEKCO45
		public GeckoNativeException Inner
		{
			get { return Create(_exception.GetInnerAttribute()); }
		}
#endif

        internal static GeckoNativeException Create(nsIException exception)
        {
            return exception == null ? null : new GeckoNativeException(exception);
        }
    }

    /// <summary>
    /// File Errors
    /// </summary>
    internal class GeckoFileException
        : GeckoException
    {
    }

    /// <summary>
    /// Stream Errors
    /// </summary>
    internal class GeckoStreamException
        : GeckoException
    {
    }

    /// <summary>
    /// Document and Node Errors
    /// </summary>
    internal class GeckoDomException
        : GeckoException
    {
        public GeckoDomException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Network Errors
    /// </summary>
    internal class GeckoNetworkException
        : GeckoException
    {
    }

    /// <summary>
    /// JavaScript Errors
    /// </summary>
    internal class GeckoJavaScriptException
        : GeckoException
    {
        public GeckoJavaScriptException(string msg) : base(msg)
        {
        }
    }

    /// <summary>
    /// XPath Errors
    /// </summary>
    internal class GeckoXPathException
        : GeckoException
    {
    }

    /// <summary>
    /// XSLT Errors
    /// </summary>
    internal class GeckoXsltException
        : GeckoException
    {
    }

    /// <summary>
    /// Miscellaneous Errors
    /// </summary>
    internal class GeckoMiscellaneousException
        : GeckoException
    {
    }
}