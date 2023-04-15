﻿using AutoMapper;
using Business.Abstract;
using Entities.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using MVCUI.ActionFilters;
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
        [ReadCounter]
        public IActionResult GetArticle(Guid id)
        {
            var article = _articleService.GetById(id).Data;

            var result = _mapper.Map<ArticleReadDto>(article);

            ViewData["Title"] = result.Header;
            ViewData["ThemeColor"] = result.Image;

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
