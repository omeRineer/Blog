using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MVCUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenController : ControllerBase
    {
        readonly IAuthService _authService;
        readonly IArticleService _articleService;
        readonly ICategoryService _categoryService;
        public OpenController(IAuthService authService, IArticleService articleService, ICategoryService categoryService)
        {
            _authService = authService;
            _articleService = articleService;
            _categoryService = categoryService;
        }


        [HttpPost("[action]")]
        public IActionResult Login(UserLoginDto model)
        {
            var result = _authService.Login(model);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetArticlesByCategoryId(int categoryId)
        {
            var result = _articleService.GetAllByCategoryId(categoryId);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetArticleById(Guid articleId)
        {
            var result = _articleService.GetArticle(articleId);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetArticles()
        {
            var result = _articleService.GetAll();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddArticle(Article article)
        {
            var result = _articleService.Add(article);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult UpdateArticle(Article article)
        {
            var result = _articleService.Update(article);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult DeleteArticle(Article article)
        {
            var result = _articleService.Delete(article);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetAll();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
