using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Helpers
{
    public static class FileManager
    {
       

        public static string Save(string root, string folder, IFormFile file)
        {
            var guid = Guid.NewGuid().ToString();


            //string path = _env.WebRootPath+@"\upload\sliders\" +guid+slider.ImageFile.FileName.Substring(slider.ImageFile.FileName.Length-64,64);
            string path = Path.Combine(root, "upload/sliders", guid + file.FileName.Substring(file.FileName.Length - 64, 64));
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
                return guid + file.FileName.Substring(file.FileName.Length - 64, 64);
        }
    }
}
