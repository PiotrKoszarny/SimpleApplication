﻿using Microsoft.AspNetCore.Hosting;
using SimpleApp.Models;
using SimpleApp.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SimpleApp.BusinessLogicLayer.Services
{
    public interface IFileService
    {
        void SavePhotos(IEnumerable<AddImgFileDto> photos, int carId);
    }

    public class FileService : IFileService
    {
        private readonly IFileSettings _fileSettings;

        public FileService(IFileSettings fileSettings)
        {
            _fileSettings = fileSettings;
        }

        public void SavePhotos(IEnumerable<AddImgFileDto> photos, int carId)
        {
            foreach (var item in photos)
            {
                var path = $"{_fileSettings.PhotoPath}\\{carId}";
                using (var stream = new MemoryStream(item.PhotoBytes))
                using (var image = Image.FromStream(stream))
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    image.Save($"{path}\\{item.FileName}", ImageFormat.Png);
                }
            }
        }
    }
}
