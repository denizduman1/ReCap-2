using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName(); //geçici dosya oluşturuldu.
            if (file.Length>0)
            {
                using (var uploading = new FileStream(sourcePath,FileMode.Create))
                {
                    file.CopyTo(uploading); //oluşan geçici dosyaya kopyalandı.
                }
            }
            var result = NewPath(file);
            File.Move(sourcePath, result); //taşındı
            return result;
        }
        public static string NewPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension; //uzantı

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }

        public static IResult Delete(string imagePath)
        {
            try
            {
                File.Delete(imagePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string Update(string sourcePath,IFormFile file)
        {
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
    }
}
