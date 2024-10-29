using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Article;
using Entities.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleReadDto>()
                .ForMember(x => x.CategoryId, y=>y.MapFrom(s=>s.CategoryId))
                .ForMember(x => x.CategoryName, y=>y.MapFrom(s=>s.Category.Name))
                .ForMember(x => x.Image, y=>y.MapFrom(s=>s.Category.Image));

            CreateMap<ArticleCreateDto, Article>().ReverseMap();

            CreateMap<CommentRead_Article, Article>().ReverseMap();
        }
    }
}
