using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public IResult Add(Article article)
        {
            _articleDal.Add(article);
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

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
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

        public IDataResult<IList<Article>> GetAllByCategoryId(int categoryId, int page)
        {
            var result = _articleDal.GetAll(filter: x => x.CategoryId == categoryId
                                                      && x.Status == true, 
                                            includes: x => x.Include(s => s.Category),
                                            orderBy: o => o.OrderByDescending(x => x.CreateDate),
                                            page: page);

            return new SuccessDataResult<IList<Article>>(result);
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
            var result = _articleDal.Get(x => x.Id == id, x => x.Include(y => y.Category));

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

        public IResult Update(Article article)
        {
            _articleDal.Update(article);

            return new SuccessResult();
        }
    }
}
