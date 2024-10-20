using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Create(CommentCreateDto req)
        {
            _commentDal.Add(new Comment
            {
                ArticleId = req.ArticleId,
                Name = req.Name,
                ParentId = req.ParentCommentId,
                Content = req.Content,
                IsOnline = null
            });

            _commentDal.Save();


            return new SuccessResult("Yorum talebi alındı");
        }
    }
}
