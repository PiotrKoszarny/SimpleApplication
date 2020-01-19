namespace SimpleApp.Settings
{
    public class AppSettings : IFileSettings
    {
        public string Secret { get; set; }
        public string PhotoPath { get; set; }
    }

    public interface IFileSettings
    {
        public string PhotoPath { get; set; }
    }
}
