using AutoMapper;
using Business.Abstract;
using Entities.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCUI.Controllers
{
    public class ArticlesController : Controller
    {

        readonly IArticleService _articleService;
        readonly ICategoryService _categoryService;
        
        readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper, ICategoryService categoryService)
        {
            _articleService = articleService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("[action]")]
        public IActionResult Index(int page = 0)
        {
            var articles = _articleService.GetAll(page).Data;
            var articlesCount = _articleService.GetArticlesCount().Data;
            var articlesReadDto = _mapper.Map<IList<ArticleReadDto>>(articles);

            ViewData["IsCategoryClick"] = false;
            ViewData["LinkActive"] = "Blog";
            ViewData["Title"] = "Articles";
            ViewData["ArticlesCount"] = articlesCount;
            ViewData["CurrentPage"] = page;

            return View(articlesReadDto);
        }

        [HttpGet("[action]")]
        public IActionResult GetArticle(Guid id)
        {
            var isVisitor = HttpContext.Request.Cookies["HitBlog"];
            if (isVisitor == null)
            {
                _articleService.AddReaderCount(id);
                HttpContext.Response.Cookies.Append("HitBlog", JsonConvert.SerializeObject(new List<string> { id.ToString() }), new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(5)
                });
            }
            else
            {
                if (!isVisitor.Contains(id.ToString()))
                {
                    _articleService.AddReaderCount(id);
                    var cookieList = JsonConvert.DeserializeObject<List<string>>(isVisitor);
                    cookieList.Add(id.ToString());
                    HttpContext.Response.Cookies.Append("HitBlog", JsonConvert.SerializeObject(cookieList), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(5)
                    });
                }
            }

            var article = _articleService.GetById(id).Data;

            var result = _mapper.Map<ArticleReadDto>(article);

            ViewData["Title"] = article.Header;

            return View(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetArticlesByCategoryId(int id, int page = 0)
        {
            var articles = _articleService.GetAllByCategoryId(id, page).Data;
            var articlesCount = _articleService.GetArticlesCount(id).Data;
            var articlesReadDto = _mapper.Map<IList<ArticleReadDto>>(articles);

            ViewData["CategoryId"] = id;
            ViewData["IsCategoryClick"] = true;
            ViewData["Title"] = "Articles";
            ViewData["ArticlesCount"] = articlesCount;
            ViewData["CurrentPage"] = page;
            ViewData["CategoryTheme"] = _categoryService.GetById(id).Data.Image;

            return View("Index", articlesReadDto);
        }
    }
}
