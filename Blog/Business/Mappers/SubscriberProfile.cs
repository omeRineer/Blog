using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class SubscriberProfile : Profile
    {
        public SubscriberProfile()
        {
            CreateMap<SubscriberCreateDto, Subscriber>().ReverseMap();
            CreateMap<SubscriberUpdateDto, Subscriber>().ReverseMap();

            CreateMap<Subscriber, SubscriberReadDto>().ReverseMap();
        }
    }
}
