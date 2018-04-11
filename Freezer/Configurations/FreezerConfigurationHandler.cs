using System;
using System.Configuration;
using System.IO;

namespace Freezer.Configurations
{
    internal class FreezerConfigurationHandler : ConfigurationSection, IFreezerConfigurationHolder
    {
        [ConfigurationProperty("minimumWorkerCount", DefaultValue = 2, IsRequired = false)]
        public int MinimumWorkerCount
        {
            get { return (int) this["minimumWorkerCount"]; }
            set { this["minimumWorkerCount"] = value; }
        }

        [ConfigurationProperty("maximumWorkerCount", DefaultValue = 5, IsRequired = false)]
        public int MaximumWorkerCount
        {
            get
            {
                return (int) this["maximumWorkerCount"];
            }
            set { this["maximumWorkerCount"] = value; }
        }

        [ConfigurationProperty("defaultUserAgent", DefaultValue = null, IsRequired = false)]
        public string DefaultUserAgent
        {
            get { return (string) this["defaultUserAgent"]; }
            set { this["defaultUserAgent"] = value; }
        }

        [ConfigurationProperty("defaultAcceptLanguageHeader", DefaultValue = "en", IsRequired = false)]
        public string AcceptLanguages
        {
            get { return (string) this["defaultAcceptLanguageHeader"]; }
            set { this["defaultAcceptLanguageHeader"] = value; }
        }

        [ConfigurationProperty("defaultBrowserWidth", DefaultValue = 1366, IsRequired = false)]
        public int DefaultWidth
        {
            get { return (int) this["defaultBrowserWidth"]; }
            set { this["defaultBrowserWidth"] = value; }
        }

        [ConfigurationProperty("defaultBrowserHeight", DefaultValue = 768, IsRequired = false)]
        public int DefaultHeight
        {
            get { return (int)this["defaultBrowserHeight"]; }
            set { this["defaultBrowserHeight"] = value; }
        }

        [ConfigurationProperty("defaultCaptureTimeoutSeconds", DefaultValue = 60, IsRequired = false)]
        public int CaptureTimeoutSeconds
        {
            get { return (int)this["defaultCaptureTimeoutSeconds"]; }
            set { this["defaultCaptureTimeoutSeconds"] = value; }
        }

        [ConfigurationProperty("xulLocation", DefaultValue = null, IsRequired = false)]
        public string XulLocation
        {
            get
            {
                var result = (string) this["xulLocation"];

                if (string.IsNullOrWhiteSpace(result))
                {
                    result = Path.Combine(
                           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                           "Freezer", "XUL");
                }

                return result;
            }
            set { this["xulLocation"] = value; }
        }

    }
}
