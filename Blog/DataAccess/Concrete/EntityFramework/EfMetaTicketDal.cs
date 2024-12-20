﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMetaTicketDal : EfRepositoryBase<MetaTicket, Context>, IMetaTicketDal
    {
        public EfMetaTicketDal(Context context) : base(context)
        {
        }
    }
}
