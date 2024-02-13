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

        IResult Add(ArticleCreateDto article);
        IResult Delete(ArticleDeleteDto article);
        IResult Update(ArticleUpdateDto article);
        IDataResult<ArticleReadDto> GetArticle(Guid articleId);
        IDataResult<IList<ArticleReadDto>> GetAllByCategoryId(int categoryId);
        IDataResult<IList<ArticleReadDto>> GetAll(bool isGetPaging = true);

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
