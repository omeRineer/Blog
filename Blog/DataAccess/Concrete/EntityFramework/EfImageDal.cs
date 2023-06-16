using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageDal : EfRepositoryBase<Image, Context>, IImageDal
    {
        public EfImageDal(Context context) : base(context)
        {

        }
    }
}
