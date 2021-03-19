using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string sourcePath = Path.GetTempFileName();
            string destFileNameForDb = CreateNewFilePathForDB(file);
            string destFileNameForLocalFolder = CreateNewFilePathForLocalFolder(destFileNameForDb);

            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            
            File.Move(sourcePath, destFileNameForLocalFolder);
            return destFileNameForDb;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            string result = CreateNewFilePathForLocalFolder(CreateNewFilePathForDB(file));
            
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

        public static string CreateNewFilePathForDB(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"Images\{newPath}";
            return result;
        }

        public static string CreateNewFilePathForLocalFolder(string pathForLocalFolder) 
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\" + pathForLocalFolder;
            return path;
        }
    }
}