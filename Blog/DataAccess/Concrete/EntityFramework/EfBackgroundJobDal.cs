using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBackgroundJobDal : EfRepositoryBase<BackgroundJob, Context>, IBackgroundJobDal
    {
        public EfBackgroundJobDal(Context context) : base(context)
        {
        }
    }
}
