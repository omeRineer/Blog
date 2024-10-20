using Core.Utilities.BusinessRules;
using Core.Utilities.ResultTool;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using IO = System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs.File;
using Business.Extensions;
using Entities.DTOs.Article;
using Entities.DTOs.Attachment;

namespace Business.FileProvider
{
    public static class FileService
    {
        public static IDataResult<FileInfo> UploadFile(List<AttachmentCreateDto> files, FileOptionsParameter fileOptionsParameter)
        {

            var fileInfoList = CreateFileInfo(files, fileOptionsParameter);

            foreach (var fileInfo in fileInfoList)
            {
                using (var fileStream = new IO.FileStream(fileInfo.FullPath, IO.FileMode.Create))
                {
                    try
                    {
                        fileStream.Write(fileInfo.ByteContent, 0, fileInfo.ByteContent.Length);
                    }
                    catch (Exception ex)
                    {
                        return new ErrorDataResult<FileInfo>(message: ex.Message);
                    }
                    finally
                    {
                        fileStream.Close();
                    }
                }
            }

            return new SuccessDataResult<FileInfo>();


        }

        public static IDataResult<FileInfo> GetFile(string fileName, string directory)
        {
            var fullPath = $"./wwwroot/Main/{directory}/{fileName}";

            var businessRules = BusinessTool.Run(IsFileExist(fullPath));
            if (!businessRules.Success) return new ErrorDataResult<FileInfo>(businessRules.Message);

            return new SuccessDataResult<FileInfo>(new FileInfo
            {
                FullPath = fullPath,
                FileName = fileName,
                Extension = IO.Path.GetExtension(fileName),
                ByteContent = IO.File.ReadAllBytes(fullPath)
            });

        }


        private static List<FileInfo> CreateFileInfo(List<AttachmentCreateDto> files, FileOptionsParameter fileOptionsParameter)
        {
            var destinationDirectory = $"./wwwroot/Main/{fileOptionsParameter.Directory}";

            if (!IO.Directory.Exists(destinationDirectory)) IO.Directory.CreateDirectory(destinationDirectory);

            var result = files.Select(s => new FileInfo
            {
                FullPath = $"{destinationDirectory}/{s.FileName}",
                FileName = s.FileName,
                Extension = IO.Path.GetExtension(s.FileName),
                ByteContent = Convert.FromBase64String(s.Base64)
            }).ToList();
            return result;
        }

        //private static IResult ExtensionValidate(string extension)
        //{
        //    if (!FileOptions.Extensions.Contains(extension.ToUpper())) return new ErrorResult("Geçersiz Uzantı");

        //    return new SuccessResult();
        //}

        private static IResult IsFileExist(string fullPath)
        {
            var isExist = IO.File.Exists(fullPath);

            if (!isExist) return new ErrorResult("Dosya Bulunamadı");

            return new SuccessResult();
        }

        private static string CreateFileName(IFormFile file, string extension, FileOptionsParameter fileOptionsParameter)
        {
            var fileName = !string.IsNullOrEmpty(fileOptionsParameter.NameTemplate) ? $"{fileOptionsParameter.NameTemplate}{extension}"
                                                                                   : $"{file.FileName}";

            return fileName;
        }
    }
}
