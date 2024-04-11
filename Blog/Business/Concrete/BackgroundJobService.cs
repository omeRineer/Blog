using AutoMapper;
using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.BackgroundJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BackgroundJobService : IBackgroundJobService
    {
        readonly IBackgroundJobDal _backgroundJobDal;
        readonly IMapper _mapper;

        public BackgroundJobService(IBackgroundJobDal backgroundJobDal, IMapper mapper)
        {
            _backgroundJobDal = backgroundJobDal;
            _mapper = mapper;
        }

        public IResult Add(BackgroundJobCreateDto backgroundJobCreateDto)
        {
            var entity = _mapper.Map<BackgroundJob>(backgroundJobCreateDto);

            _backgroundJobDal.Add(entity);
            _backgroundJobDal.Save();

            return new SuccessResult();
        }

        public IResult Delete(BackgroundJobDeleteDto backgroundJobDeleteDto)
        {
            var entity = _backgroundJobDal.Get(f => f.Id == backgroundJobDeleteDto.Id);

            _backgroundJobDal.Delete(entity);
            _backgroundJobDal.Save();

            return new SuccessResult();
        }

        public IDataResult<BackgroundJobReadDto> GetById(int id)
        {
            var entity = _backgroundJobDal.Get(f => f.Id == id);
            var result = _mapper.Map<BackgroundJobReadDto>(entity);

            return new SuccessDataResult<BackgroundJobReadDto>(result);
        }

        public IDataResult<List<BackgroundJobReadDto>> GetList()
        {
            var entites = _backgroundJobDal.GetAll(isGetPaging: false);
            var result = _mapper.Map<List<BackgroundJobReadDto>>(entites);

            return new SuccessDataResult<List<BackgroundJobReadDto>>(result);
        }

        public IResult Update(BackgroundJobUpdateDto backgroundJobUpdateDto)
        {
            var entity = _mapper.Map<BackgroundJob>(backgroundJobUpdateDto);

            _backgroundJobDal.Update(entity);
            _backgroundJobDal.Save();

            return new SuccessResult();
        }
    }
}
