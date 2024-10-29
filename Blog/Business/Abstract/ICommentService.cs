using Core.Utilities.ResultTool;
using Entities.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Create(CommentCreateDto req);
        IResult Reply(CommentReplyDto req);
        IDataResult<List<CommentReadDto>> GetAll();
        IResult UpdateState(CommentUpdateStateDto req);
    }
}
