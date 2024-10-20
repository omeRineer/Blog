using AutoMapper;
using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SubscriberService : ISubscriberService
    {
        readonly ISubscriberDal _subscriberDal;
        readonly IMapper _mapper;

        public SubscriberService(ISubscriberDal subscriberDal, IMapper mapper)
        {
            _subscriberDal = subscriberDal;
            _mapper = mapper;
        }

        public IResult Add(SubscriberCreateDto subscriberCreateDto)
        {
            var entity = _mapper.Map<Subscriber>(subscriberCreateDto);

            _subscriberDal.Add(entity);
            _subscriberDal.Save();

            return new SuccessResult();
        }

        public IResult Delete(SubscriberDeleteDto subscriberDeleteDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<SubscriberReadDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<SubscriberReadDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(SubscriberUpdateDto subscriberDeleteDto)
        {
            throw new NotImplementedException();
        }
    }
}
