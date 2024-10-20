using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Category;
using Microsoft.EntityFrameworkCore;
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

        public IResult Add(CategoryCreateDto category)
        {
            var entity = new Category
            {
                Name = category.Name,
                Image = category.Image
            };
            _categoryDal.Add(entity);

            return new SuccessResult();
        }

        public IResult Delete(CategoryDeleteDto category)
        {
            var entity = _categoryDal.Get(f => f.Id == category.Id);
            _categoryDal.Delete(entity);

            return new SuccessResult();
        }

        public IDataResult<IList<CategoryReadDto>> GetAll()
        {

            var result = _categoryDal.GetAll(includes: i => i.Include(x => x.Articles), isGetPaging: false).Select(s => new CategoryReadDto
            {
                Id = s.Id,
                Name = s.Name,
                Image = s.Image,
                ArticleCount = s.Articles.Count
            }).ToList();

            return new SuccessDataResult<IList<CategoryReadDto>>(result);
        }

        public IDataResult<IList<CategoryReadDto>> GetAllByCategoryReadDto()
        {
            var categories = _categoryDal.GetListByCategoryReadDto();

            return new SuccessDataResult<IList<CategoryReadDto>>(categories);
        }

        public IDataResult<IList<KeyValuePair<int, string>>> GetAllByDropdown()
        {
            var result = _categoryDal.GetAll().Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();

            return new SuccessDataResult<IList<KeyValuePair<int, string>>>(result);
        }

        public IDataResult<CategoryReadDto> GetById(int id)
        {
            var entity = _categoryDal.Get(x => x.Id == id, i => i.Include(x => x.Articles));

            var result = new CategoryReadDto
            {
                Id = entity.Id,
                ArticleCount = entity.Articles.Count,
                Name = entity.Name,
                Image = entity.Image
            };

            return new SuccessDataResult<CategoryReadDto>(result);
        }

        public IResult Update(CategoryUpdateDto category)
        {
            var entity = _categoryDal.Get(x => x.Id == category.Id);

            entity.Name = category.Name;
            entity.Image = category.Image;
            _categoryDal.Update(entity);

            return new SuccessResult();
        }
    }
}
