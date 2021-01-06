using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace BusinessLogicalLayer.Utils
{
    public static class ImageService
    {
        public static string InsertImageAndReturnPath(IFormFile image)
        {
            var imageId = Guid.NewGuid().ToString().ToLower().Replace("-", "");

            string path = Path.Combine(@"C:\Users\Luiz\Desktop\PastaDeFotos\" + imageId + ".png");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return path;
        }
    }
}
