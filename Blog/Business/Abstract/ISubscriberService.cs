using Core.Utilities.ResultTool;
using Entities.DTOs.BackgroundJob;
using Entities.DTOs.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubscriberService
    {
        IResult Add(SubscriberCreateDto subscriberCreateDto);
        IResult Delete(SubscriberDeleteDto subscriberDeleteDto);
        IResult Update(SubscriberUpdateDto subscriberDeleteDto);
        IDataResult<List<SubscriberReadDto>> GetList();
        IDataResult<SubscriberReadDto> GetById(int id);
    }
}
