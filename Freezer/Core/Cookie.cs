using System;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a HTTP cookie
    /// </summary>
    [Serializable]
    public class Cookie
    {
        internal Cookie()
        {
            HTTPOnly = false;
            Secure = false;
            Expires = DateTime.Now.AddDays(1D);
            IsSession = true; 
        }

        /// <summary>
        /// Build a cookie from domain, path, name and value
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Cookie(string domain, string path, string name, string value)
            : this()
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Domain = domain;
            Path = path;
            Name = name;
            Value = value;  
        }

        /// <summary>
        /// Gets the domain of the cookie
        /// </summary>
        public string Domain { get; internal set; }

        /// <summary>
        /// Gets the path of the cookie 
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// Gets the name of cookie
        /// </summary>
        public string Name { get; internal set;  }

        /// <summary>
        /// Gets the value of the cookie
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this cookie is secure
        /// </summary>
        public bool Secure { get; set; }

        /// <summary>
        /// Get or sets a value indicating if this cookie should only be used in a HTTP context
        /// </summary>
        public bool HTTPOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this cookie carries sessions. 
        /// </summary>
        public bool IsSession { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of this cookie
        /// </summary>
        public DateTime Expires { get; set; }
    }
    
}