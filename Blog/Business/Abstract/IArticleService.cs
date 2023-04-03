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
        IResult Add(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);
        IResult AddReaderCount(Guid articleId);
        IDataResult<IList<Article>> GetAll(int page);
        IDataResult<IList<Article>> GetAllByCategoryId(int categoryId, int page);
        IDataResult<int> GetArticlesCount(int? categoryId = null);
        IDataResult<Article> GetById(Guid articleId);

        IDataResult<IList<Article>> GetLastArticles(int length);
    }
}
