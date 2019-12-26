using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class ImgFileDto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Value { get; set; }
    }
}
