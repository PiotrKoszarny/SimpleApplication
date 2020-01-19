namespace SimpleApp.Models
{
    public class AddImgFileDto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] PhotoBytes { get; set; }
    }
}
