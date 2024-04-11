using Core.Utilities.ResultTool;
using Entities.DTOs.BackgroundJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBackgroundJobService
    {
        IResult Add(BackgroundJobCreateDto backgroundJobCreateDto);
        IResult Delete(BackgroundJobDeleteDto backgroundJobDeleteDto);
        IResult Update(BackgroundJobUpdateDto backgroundJobUpdateDto);
        IDataResult<List<BackgroundJobReadDto>> GetList();
        IDataResult<BackgroundJobReadDto> GetById(int id);
    }
}
