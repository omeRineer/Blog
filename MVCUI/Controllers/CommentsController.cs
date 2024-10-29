using Business.Abstract;
using Entities.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class CommentsController : Controller
    {
        readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("Send")]
        public IActionResult Send([FromBody] CommentCreateDto req)
        {
            var result = _commentService.Create(req);

            return Json(result);
        }
    }
}
