using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class FileUploade : IFileUploader
    {
        private IWebHostEnvironment _webHostEnvironment;

        public FileUploade(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var pathDirectory = $"{_webHostEnvironment.WebRootPath}//ProductPicture//{path}";
            if (!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);
            }

            var filename = DateTime.Now.ToFileName() + "-" + file.FileName;

            var filePath = $"{pathDirectory}//{filename}";
            using (var output = System.IO.File.Create(filePath))
            {
                file.CopyTo(output);
            }
            return $"{path}/{filename}";

        }
    }
}
