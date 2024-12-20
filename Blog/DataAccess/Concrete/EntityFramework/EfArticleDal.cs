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
    public class EfArticleDal : EfRepositoryBase<Article, Context>, IArticleDal
    {
        public EfArticleDal(Context context) : base(context)
        {
            
        }
    }
}
