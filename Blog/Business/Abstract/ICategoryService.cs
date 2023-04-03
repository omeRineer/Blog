using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.DTOs.Category;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IDataResult<IList<Category>> GetAll();
        IDataResult<Category> GetById(int id);

        IDataResult<IList<CategoryReadDto>> GetAllByCategoryReadDto();
        IDataResult<IList<KeyValuePair<int, string>>> GetAllByDropdown();

    }
}
