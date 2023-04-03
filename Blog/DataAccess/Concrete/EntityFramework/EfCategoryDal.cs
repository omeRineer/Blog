using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Category;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, Context>, ICategoryDal
    {
        public IList<CategoryReadDto> GetListByCategoryReadDto()
        {
            using (Context context = new Context())
            {
                var result = (from article in context.Articles where article.Status == true
                             join category in context.Categories on article.CategoryId equals category.Id
                             group article by new {article.CategoryId, article.Category.Name } into g
                             select new CategoryReadDto
                             {
                                 Id = g.Key.CategoryId,
                                 Name = g.Key.Name,
                                 ArticleCount = g.Count()
                             }).ToList();

                return result;
            }
        }
    }
}
