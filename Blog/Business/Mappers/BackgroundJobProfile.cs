using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.BackgroundJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class BackgroundJobProfile : Profile
    {
        public BackgroundJobProfile()
        {
            CreateMap<BackgroundJobCreateDto, BackgroundJob>().ReverseMap();

            CreateMap<BackgroundJobUpdateDto, BackgroundJob>().ReverseMap();

            CreateMap<BackgroundJob, BackgroundJobReadDto>().ReverseMap();
        }
    }
}
