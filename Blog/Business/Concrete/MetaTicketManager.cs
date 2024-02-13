using Business.Abstract;
using Core.Entities.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.MetaTicket;
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

        public IResult Add(MetaTicketCreateDto metaTicket)
        {
            var entity = new MetaTicket
            {
                ArticleId = metaTicket.ArticleId,
                KeyWords = metaTicket.KeyWords,
                Title = metaTicket.Title,
                Description = metaTicket.Description
            };

            _metaTicketDal.Add(entity);
            _metaTicketDal.Save();
            return new SuccessResult();
        }

        public IResult Delete(MetaTicketDeleteDto metaTicket)
        {
            var entity = _metaTicketDal.Get(f => f.Id == metaTicket.Id);
            _metaTicketDal.Delete(entity);
            _metaTicketDal.Save();
            return new SuccessResult();
        }

        public IDataResult<MetaTicketReadDto> GetByArticleId(Guid articleId)
        {
            var entity = _metaTicketDal.Get(x => x.ArticleId == articleId);

            var result = new MetaTicketReadDto
            {
                Id = entity.Id,
                ArticleId = entity.ArticleId,
                CreateDate = entity.CreateDate,
                Description = entity.Description,
                KeyWords = entity.KeyWords,
                Title = entity.Title
            };

            return new SuccessDataResult<MetaTicketReadDto>(result);
        }

        public IDataResult<MetaTicketReadDto> GetMetaTicketByArticleId(Guid articleId)
        {
            string cacheKey = $"article:{articleId}";
            if (_memoryCache.TryGetValue(cacheKey, out MetaTicketReadDto value))
            {
                return new SuccessDataResult<MetaTicketReadDto>(value);
            }

            var entity = _metaTicketDal.Get(x => x.ArticleId == articleId);

            if (entity == null)
                return new ErrorDataResult<MetaTicketReadDto>();

            var result = new MetaTicketReadDto
            {
                Id = entity.Id,
                ArticleId = entity.ArticleId,
                CreateDate = entity.CreateDate,
                Description = entity.Description,
                KeyWords = entity.KeyWords,
                Title = entity.Title
            };

            _memoryCache.Set(cacheKey, result, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(1),
                Priority = CacheItemPriority.Normal,
            });

            return new SuccessDataResult<MetaTicketReadDto>(result);
        }

        public IDataResult<List<MetaTicketReadDto>> GetMetaTickets()
        {
            var result = _metaTicketDal.GetAll(isGetPaging: false).Select(s => new MetaTicketReadDto
            {
                Id = s.Id,
                ArticleId = s.ArticleId,
                CreateDate = s.CreateDate,
                Description = s.Description,
                KeyWords = s.KeyWords,
                Title = s.Title
            }).ToList();

            return new SuccessDataResult<List<MetaTicketReadDto>>(result);
        }

        public IResult Update(MetaTicketUpdateDto metaTicket)
        {
            var entity = _metaTicketDal.Get(f => f.Id == metaTicket.Id);

            entity.Title = metaTicket.Title;
            entity.Description = metaTicket.Description;
            entity.KeyWords = metaTicket.KeyWords;
            entity.ArticleId = metaTicket.ArticleId;

            _metaTicketDal.Update(entity);
            _metaTicketDal.Save();
            return new SuccessResult();
        }
    }
}
