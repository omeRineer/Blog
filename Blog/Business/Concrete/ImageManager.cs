using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using MeArch.Module.File.Model;
using MeArch.Module.File.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        readonly IArticleService _articleService;
        readonly IImageDal _imageDal;
        readonly IFileService _fileService;

        public ImageManager(IImageDal imageDal, IFileService fileService, IArticleService articleService)
        {
            _imageDal = imageDal;
            _fileService = fileService;
            _articleService = articleService;
        }

        public IResult Add(Image image, IFormFile file)
        {
            var article = _articleService.GetById(image.ArticleId);

            var uploadResult = _fileService.UploadFile(file, new FileOptionsParameter
            {
                Directory = $"{article.Data.Id}",
                NameTemplate = image.ImageName
            });

            if (!uploadResult.Success) return new ErrorResult(uploadResult.Message);

            _imageDal.Add(image);

            return new SuccessResult();
        }
    }
}
