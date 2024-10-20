using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.DTOs.Category;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(CategoryCreateDto category);
        IResult Delete(CategoryDeleteDto category);
        IResult Update(CategoryUpdateDto category);
        IDataResult<IList<CategoryReadDto>> GetAll();
        IDataResult<CategoryReadDto> GetById(int id);

        IDataResult<IList<CategoryReadDto>> GetAllByCategoryReadDto();
        IDataResult<IList<KeyValuePair<int, string>>> GetAllByDropdown();

    }
}
