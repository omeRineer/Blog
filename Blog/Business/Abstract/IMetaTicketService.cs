using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.DTOs.MetaTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMetaTicketService
    {
        IDataResult<MetaTicketReadDto> GetMetaTicketByArticleId(Guid articleId);
        IDataResult<MetaTicketReadDto> GetByArticleId(Guid articleId);
        IDataResult<List<MetaTicketReadDto>> GetMetaTickets();
        IResult Add(MetaTicketCreateDto metaTicket);
        IResult Delete(MetaTicketDeleteDto metaTicket);
        IResult Update(MetaTicketUpdateDto metaTicket);
    }
}
