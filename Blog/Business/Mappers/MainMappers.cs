using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class MainMappers : Profile
    {
        public MainMappers()
        {
            CreateMap<Article, ArticleReadDto>()
                .ForMember(x => x.CategoryId, y=>y.MapFrom(s=>s.CategoryId))
                .ForMember(x => x.CategoryName, y=>y.MapFrom(s=>s.Category.Name))
                .ForMember(x => x.Image, y=>y.MapFrom(s=>s.Category.Image));

            CreateMap<ArticleCreateDto, Article>().ReverseMap();
        }
    }
}
