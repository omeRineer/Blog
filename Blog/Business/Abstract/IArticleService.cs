using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.DTOs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        #region Admin

        IResult Add(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);
        IDataResult<Article> GetArticle(Guid articleId);
        IDataResult<IList<Article>> GetAllByCategoryId(int categoryId);
        IDataResult<IList<Article>> GetAll();

        #endregion



        #region Client

        IResult AddReaderCount(Guid articleId);
        IDataResult<IList<Article>> GetAll(int page);
        IDataResult<Article> GetById(Guid articleId);
        IDataResult<IList<Article>> GetAllByCategoryId(int categoryId, int page);
        IDataResult<int> GetArticlesCount(int? categoryId = null);
        IDataResult<IList<Article>> GetLastArticles(int length);

        #endregion

    }
}
