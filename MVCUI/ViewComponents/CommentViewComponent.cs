using Entities.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MVCUI.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<CommentReadDto> comments, Guid ArticleId)
        {
            var result = (comments, ArticleId);

            return View(result);
        }
    }
}
