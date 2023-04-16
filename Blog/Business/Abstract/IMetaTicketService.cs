using Core.Utilities.ResultTool;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMetaTicketService
    {
        IDataResult<MetaTicket> GetMetaTicketByArticleId(Guid articleId);
    }
}
