namespace WatchList.Core.Models
{
    public class SmtpSettings
    {
        public string SmtpHost { get; set; } = string.Empty;

        public string SmtpPassword { get; set; } = string.Empty;

        public string SmtpSender { get; set; } = string.Empty;

        public bool SmtpUsePickupDirectory { get; set; } = false;

        public string SmtpPickupDirectory { get; set; } = string.Empty;
    }
}