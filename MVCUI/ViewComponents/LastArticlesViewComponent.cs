using AutoMapper;
using Business.Abstract;
using Entities.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVCUI.ViewComponents
{
    public class LastArticlesViewComponent : ViewComponent
    {
        readonly IArticleService _articeService;
        readonly IMapper _mapper;

        public LastArticlesViewComponent(IArticleService articeService, IMapper mapper)
        {
            _articeService = articeService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int length)
        {
            var articles = _articeService.GetLastArticles(length);
            var result = _mapper.Map<IList<ArticleReadDto>>(articles.Data);

            return View(result);
        }
    }
}
