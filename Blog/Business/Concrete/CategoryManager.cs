using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Category;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        readonly ICategoryDal _categoryDal;
        readonly IMemoryCache _memoryCache;

        public CategoryManager(ICategoryDal categoryDal, IMemoryCache memoryCache)
        {
            _categoryDal = categoryDal;
            _memoryCache = memoryCache;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);

            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);

            return new SuccessResult();
        }

        public IDataResult<IList<Category>> GetAll()
        {

            var result= _categoryDal.GetAll(length: 1000);

            return new SuccessDataResult<IList<Category>>(result);
        }

        public IDataResult<IList<CategoryReadDto>> GetAllByCategoryReadDto()
        {
            var categories = _categoryDal.GetListByCategoryReadDto();

            return new SuccessDataResult<IList<CategoryReadDto>>(categories);
        }

        public IDataResult<IList<KeyValuePair<int, string>>> GetAllByDropdown()
        {
            var result = _categoryDal.GetAll().Select(x=> new KeyValuePair<int, string>(x.Id, x.Name)).ToList();

            return new SuccessDataResult<IList<KeyValuePair<int, string>>>(result);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(x => x.Id == id);

            return new SuccessDataResult<Category>(result);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);

            return new SuccessResult();
        }
    }
}
