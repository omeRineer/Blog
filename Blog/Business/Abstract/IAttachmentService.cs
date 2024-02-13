using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.DTOs.Attachment;
using Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAttachmentService
    {
        IResult Add(AttachmentCreateDto attachment);
        IResult BulkAdd(List<AttachmentCreateDto> attachments);
        IResult Delete(AttachmentDeleteDto attachment);
        IResult Update(AttachmentUpdateDto attachment);
        IResult UploadFiles(List<AttachmentCreateDto> attachments);
        IDataResult<IList<AttachmentReadDto>> GetAll();
        IDataResult<AttachmentReadDto> GetById(int id);

        IDataResult<IList<AttachmentReadDto>> GetAllByArticleId(Guid articleId);
    }
}
