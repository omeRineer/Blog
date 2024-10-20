using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Article;
using Entities.DTOs.Attachment;
using Entities.DTOs.Auth;
using Entities.DTOs.BackgroundJob;
using Entities.DTOs.MetaTicket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MVCUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenController : ControllerBase
    {
        readonly IAuthService _authService;
        readonly IArticleService _articleService;
        readonly ICategoryService _categoryService;
        readonly IMetaTicketService _metaTicketService;
        readonly IBackgroundJobService _backgroundJobService;
        readonly IAttachmentService _attachmentService;
        public OpenController(IAuthService authService, IArticleService articleService, ICategoryService categoryService, IMetaTicketService metaTicketService, IAttachmentService attachmentService, IBackgroundJobService backgroundJobService)
        {
            _authService = authService;
            _articleService = articleService;
            _categoryService = categoryService;
            _metaTicketService = metaTicketService;
            _attachmentService = attachmentService;
            _backgroundJobService = backgroundJobService;
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
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetAll();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        #region Articles
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetArticlesByCategoryId(int categoryId)
        {
            var result = _articleService.GetAllByCategoryId(categoryId, false);

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
            var result = _articleService.GetAll(false);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddArticle(ArticleCreateDto article)
        {
            var result = _articleService.Add(article);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult UpdateArticle(ArticleUpdateDto article)
        {
            var result = _articleService.Update(article);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult DeleteArticle(ArticleDeleteDto article)
        {
            var result = _articleService.Delete(article);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
        #endregion

        #region Meta Tickets
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetSeo(Guid articleId)
        {
            var result = _metaTicketService.GetByArticleId(articleId);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetSeoList()
        {
            var result = _metaTicketService.GetMetaTickets();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddSeo(MetaTicketCreateDto meta)
        {
            var result = _metaTicketService.Add(meta);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult DeleteSeo(MetaTicketDeleteDto meta)
        {
            var result = _metaTicketService.Delete(meta);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult UpdateSeo(MetaTicketUpdateDto meta)
        {
            var result = _metaTicketService.Update(meta);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
        #endregion


        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddAttachments(List<AttachmentCreateDto> attachments)
        {
            var result = _attachmentService.UploadFiles(attachments);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetAttachmentsByArticleId(Guid articleId)
        {
            var result = _attachmentService.GetAllByArticleId(articleId);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }


        #region Background Job
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetBackgroundJob(int id)
        {
            var result = _backgroundJobService.GetById(id);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetBackgroundJobList()
        {
            var result = _backgroundJobService.GetList();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddBackgroundJob(BackgroundJobCreateDto backgroundJobCreateDto)
        {
            var result = _backgroundJobService.Add(backgroundJobCreateDto);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult DeleteBackgroundJob(BackgroundJobDeleteDto backgroundJobDeleteDto)
        {
            var result = _backgroundJobService.Delete(backgroundJobDeleteDto);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult UpdateBackgroundJob(BackgroundJobUpdateDto backgroundJobUpdateDto)
        {
            var result = _backgroundJobService.Update(backgroundJobUpdateDto);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
        #endregion
    }
}
