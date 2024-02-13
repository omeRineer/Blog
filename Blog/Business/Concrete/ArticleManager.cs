using Business.Abstract;
using Business.FileProvider;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Article;
using Entities.DTOs.Attachment;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        readonly IArticleDal _articleDal;
        readonly IMemoryCache _memoryCache;
        readonly IAttachmentService _attachmentService;

        public ArticleManager(IArticleDal articleDal, IMemoryCache memoryCache, IAttachmentService attachmentService)
        {
            _articleDal = articleDal;
            _memoryCache = memoryCache;
            _attachmentService = attachmentService;
        }

        public IResult Add(ArticleCreateDto article)
        {
            var entity = new Article
            {
                CategoryId = article.CategoryId,
                Header = article.Header,
                Content = article.Content
            };

            _articleDal.Add(entity);
            _articleDal.Save();

            return new SuccessResult();

        }

        public IResult AddReaderCount(Guid articleId)
        {
            var article = _articleDal.Get(x => x.Id == articleId);
            article.ReaderCount++;
            _articleDal.Update(article);
            _articleDal.Save();
            return new SuccessResult();
        }

        public IResult Delete(ArticleDeleteDto article)
        {
            var entity = _articleDal.Get(f => f.Id == article.ArticleId);

            _articleDal.Delete(entity);
            _articleDal.Save();

            return new SuccessResult();
        }

        public IDataResult<IList<Article>> GetAll(int page)
        {
            var result = _articleDal.GetAll(filter: f => f.Status == true,
                                            includes: x => x.Include(s => s.Category),
                                            orderBy: o => o.OrderByDescending(s => s.CreateDate),
                                            page: page);
            return new SuccessDataResult<IList<Article>>(result);
        }
        public IDataResult<IList<ArticleReadDto>> GetAll(bool isGetPaging = true)
        {
            var result = _articleDal.GetAll(includes: i => i.Include(x => x.Category).Include(x => x.Attachments), isGetPaging:isGetPaging).Select(s => new ArticleReadDto
            {
                Id = s.Id,
                Header = s.Header,
                CategoryId = s.CategoryId,
                Content = s.Content,
                ReaderCount = s.ReaderCount,
                CreateDate = s.CreateDate,
                CategoryName = s.Category.Name,
                Attachments = s.Attachments.Select(x => new Entities.DTOs.Attachment.AttachmentReadDto
                {
                    ArticleId = x.ArticleId,
                    Id = x.Id,
                    FileName = x.FileName
                }).ToList()
            }).ToList();

            return new SuccessDataResult<IList<ArticleReadDto>>(result);
        }
        public IDataResult<IList<Article>> GetAllByCategoryId(int categoryId, int page)
        {
            var result = _articleDal.GetAll(filter: x => x.CategoryId == categoryId
                                                      && x.Status == true,
                                            includes: x => x.Include(s => s.Category),
                                            orderBy: o => o.OrderByDescending(x => x.CreateDate),
                                            page: page);

            return new SuccessDataResult<IList<Article>>(result);
        }
        public IDataResult<IList<ArticleReadDto>> GetAllByCategoryId(int categoryId)
        {
            var result = _articleDal.GetAll(x => x.CategoryId == categoryId, i => i.Include(x => x.Category).Include(x => x.Attachments)).Select(s => new ArticleReadDto
            {
                Id = s.Id,
                Header = s.Header,
                CategoryId = s.CategoryId,
                Content = s.Content,
                ReaderCount = s.ReaderCount,
                CreateDate = s.CreateDate,
                CategoryName = s.Category.Name,
                Attachments = s.Attachments.Select(x => new Entities.DTOs.Attachment.AttachmentReadDto
                {
                    ArticleId = x.ArticleId,
                    Id = x.Id,
                    FileName = x.FileName
                }).ToList()
            }).ToList();

            return new SuccessDataResult<IList<ArticleReadDto>>(result);
        }
        public IDataResult<ArticleReadDto> GetArticle(Guid articleId)
        {
            var entity = _articleDal.Get(x => x.Id == articleId, i => i.Include(x => x.Category).Include(x => x.Attachments));

            var result = new ArticleReadDto
            {
                Id = entity.Id,
                Header = entity.Header,
                CategoryId = entity.CategoryId,
                Content = entity.Content,
                ReaderCount = entity.ReaderCount,
                CreateDate = entity.CreateDate,
                Status = entity.Status,
                CategoryName = entity.Category.Name,
                Attachments = entity.Attachments.Select(x => new Entities.DTOs.Attachment.AttachmentReadDto
                {
                    ArticleId = x.ArticleId,
                    Id = x.Id,
                    FileName = x.FileName
                }).ToList()
            };

            return new SuccessDataResult<ArticleReadDto>(result);
        }
        public IDataResult<int> GetArticlesCount(int? categoryId = null)
        {
            int articlesCount = 0;
            if (categoryId is not null) articlesCount = _articleDal.GetDataCount(f => f.CategoryId == categoryId
                                                                                      && f.Status == true);
            else articlesCount = _articleDal.GetDataCount(f => f.Status == true);

            return new SuccessDataResult<int>(articlesCount);
        }
        public IDataResult<Article> GetById(Guid id)
        {
            var result = _articleDal.Get(x => x.Id == id && x.Status == true, x => x.Include(y => y.Category));

            return new SuccessDataResult<Article>(result);
        }
        public IDataResult<IList<Article>> GetLastArticles(int length)
        {
            var result = _articleDal.GetAll(filter: f => f.Status == true,
                                            includes: i => i.Include(s => s.Category),
                                            orderBy: o => o.OrderByDescending(s => s.CreateDate),
                                            length: length);

            return new SuccessDataResult<IList<Article>>(result);
        }
        public IResult Update(ArticleUpdateDto article)
        {
            var entity = _articleDal.Get(f => f.Id == article.Id);
            entity.Header = article.Header;
            entity.Status = article.Status;
            entity.Content = article.Content;
            entity.CategoryId = article.CategoryId;

            _articleDal.Update(entity);
            _articleDal.Save();

            return new SuccessResult();
        }
    }
}
