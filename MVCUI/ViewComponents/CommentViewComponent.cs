using Entities.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVCUI.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<CommentReadDto> comments)
        {
            return View(comments);
        }
    }
}
