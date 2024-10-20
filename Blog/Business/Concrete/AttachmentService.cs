using Business.Abstract;
using Business.FileProvider;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Attachment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AttachmentService : IAttachmentService
    {
        readonly IAttachmentDal _attachmentDal;

        public AttachmentService(IAttachmentDal attachmentDal)
        {
            _attachmentDal = attachmentDal;
        }

        public IResult Add(AttachmentCreateDto attachment)
        {
            var entity = new Attachment
            {
                FileName = attachment.FileName,
                ArticleId = attachment.ArticleId,
                Meta = attachment.Meta
            };

            _attachmentDal.Add(entity);

            return new SuccessResult();
        }

        public IResult BulkAdd(List<AttachmentCreateDto> attachments)
        {
            var entities = attachments.Select(s => new Attachment
            {
                ArticleId = s.ArticleId,
                FileName = s.FileName,
                Meta = s.Meta
            }).ToList();

            _attachmentDal.BulkAdd(entities);
            _attachmentDal.Save();

            return new SuccessResult();
        }

        public IResult Delete(AttachmentDeleteDto attachment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<AttachmentReadDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<AttachmentReadDto>> GetAllByArticleId(Guid articleId)
        {
            var entities = _attachmentDal.GetAll(f => f.ArticleId == articleId).Select(s => new AttachmentReadDto
            {
                ArticleId = s.ArticleId,
                FileName = s.FileName,
                Meta = s.Meta
            }).ToList();

            entities.ForEach(attachment =>
            {
                var fileInfoResult = FileService.GetFile(attachment.FileName, attachment.ArticleId.ToString());

                if (fileInfoResult.Data != null)
                    attachment.Base64 = Convert.ToBase64String(fileInfoResult.Data.ByteContent.ToArray());
            });

            return new SuccessDataResult<IList<AttachmentReadDto>>(entities);
        }
        public IDataResult<AttachmentReadDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(AttachmentUpdateDto attachment)
        {
            throw new NotImplementedException();
        }

        public IResult UploadFiles(List<AttachmentCreateDto> attachments)
        {
            _attachmentDal.BulkAdd(attachments.Select(s => new Attachment
            {
                FileName = s.FileName,
                ArticleId = s.ArticleId
            }).ToList());

            FileService.UploadFile(attachments, new Entities.DTOs.File.FileOptionsParameter
            {
                Directory = $"{attachments.First().ArticleId}",
                NameTemplate = $"{attachments.First().FileName}"
            });

            return new SuccessResult();
        }
    }
}
