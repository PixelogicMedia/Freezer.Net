namespace Freezer.Configurations
{
    internal interface IFreezerConfigurationHolder
    {
        int MinimumWorkerCount { get; set; }

        int MaximumWorkerCount { get; set; }

        string DefaultUserAgent { get; set; }

        string AcceptLanguages { get; set; }

        int DefaultWidth { get; set; }

        int DefaultHeight { get; set; }

        int CaptureTimeoutSeconds { get; set; }

        string XulLocation { get; set; }
    }
}