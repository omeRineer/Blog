using AutoMapper;
using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Comment;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
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
        readonly IMapper _mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }

        public IResult Create(CommentCreateDto req)
        {
            _commentDal.Add(new Comment
            {
                ArticleId = Guid.Parse(req.ArticleId),
                Name = req.Name,
                ParentId = req.ParentId != null ? Guid.Parse(req.ParentId) : null,
                Content = req.Content,
                IsOnline = null
            });

            _commentDal.Save();


            return new SuccessResult("Yorumunuz işleme alındı");
        }

        public IDataResult<List<CommentReadDto>> GetAll()
        {
            var entities = _commentDal.GetAll(includes: i => i.Include(x => x.Article), isGetPaging: false);

            var result = _mapper.Map<List<CommentReadDto>>(entities);

            return new SuccessDataResult<List<CommentReadDto>>(result);
        }

        public IResult Remove(Guid id)
        {
            var comment = _commentDal.Get(f => f.Id == id);

            if (comment == null)
                return new ErrorResult("Yorum bilgisi bulunamadı!");


            _commentDal.Delete(comment);
            _commentDal.Save();

            return new SuccessResult();
        }

        public IResult Reply(CommentReplyDto req)
        {
            var parentComment = _commentDal.Get(f=> f.Id == Guid.Parse(req.ParentId));

            if (parentComment == null)
                return new ErrorResult("Yorum bilgisi bulunamadı!");

            _commentDal.Add(new Comment
            {
                ArticleId = parentComment.ArticleId,
                Name = req.Name,
                ParentId = Guid.Parse(req.ParentId),
                Content = req.Content,
                IsOnline = req.IsOnline
            });

            _commentDal.Save();

            return new SuccessResult();
        }

        public IResult UpdateState(CommentUpdateStateDto req)
        {
            var comment = _commentDal.Get(f => f.Id == Guid.Parse(req.Id));

            comment.IsOnline = req.State;

            _commentDal.Update(comment);
            _commentDal.Save();

            return new SuccessResult();
        }
    }
}
