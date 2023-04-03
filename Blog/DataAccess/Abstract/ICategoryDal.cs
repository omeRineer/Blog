using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Category;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        IList<CategoryReadDto> GetListByCategoryReadDto();
    }
}
