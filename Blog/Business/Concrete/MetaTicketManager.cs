using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MetaTicketManager : IMetaTicketService
    {
        readonly IMetaTicketDal _metaTicketDal;
        readonly IMemoryCache _memoryCache;

        public MetaTicketManager(IMetaTicketDal metaTicketDal, IMemoryCache memoryCache)
        {
            _metaTicketDal = metaTicketDal;
            _memoryCache = memoryCache;
        }

        public IResult Add(MetaTicket metaTicket)
        {
            _metaTicketDal.Add(metaTicket);
            _metaTicketDal.Save();
            return new SuccessResult();
        }

        public IResult Delete(MetaTicket metaTicket)
        {
            _metaTicketDal.Delete(metaTicket);
            _metaTicketDal.Save();
            return new SuccessResult();
        }

        public IDataResult<MetaTicket> GetByArticleId(Guid articleId)
        {
            var result = _metaTicketDal.Get(x => x.ArticleId == articleId);

            return new SuccessDataResult<MetaTicket>(result);
        }

        public IDataResult<MetaTicket> GetMetaTicketByArticleId(Guid articleId)
        {
            string cacheKey = $"article:{articleId}";
            if (_memoryCache.TryGetValue(cacheKey, out MetaTicket value))
            {
                return new SuccessDataResult<MetaTicket>(value);
            }

            var result = _metaTicketDal.Get(x => x.ArticleId == articleId);

            _memoryCache.Set(cacheKey, result, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(1),
                Priority = CacheItemPriority.Normal,
            });

            return new SuccessDataResult<MetaTicket>(result);
        }

        public IDataResult<List<MetaTicket>> GetMetaTickets()
        {
            var result = _metaTicketDal.GetAll();

            return new SuccessDataResult<List<MetaTicket>>(result);
        }

        public IResult Update(MetaTicket metaTicket)
        {
            _metaTicketDal.Update(metaTicket);
            _metaTicketDal.Save();
            return new SuccessResult();
        }
    }
}
