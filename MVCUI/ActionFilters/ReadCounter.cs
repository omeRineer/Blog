using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using Core.Utilities.ServiceTools;

namespace MVCUI.ActionFilters
{
    public class ReadCounter : ActionFilterAttribute
    {
        private int Duration { get; }
        readonly IArticleService _articleService;

        public ReadCounter(int duration = 10)
        {
            _articleService = StaticServiceProvider.GetService<IArticleService>();
            Duration = duration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var articleId = (Guid)context.ActionArguments["id"];
            const string hitBlog = "HitBlog";

            var isVisitor = context.HttpContext.Request.Cookies[hitBlog];
            if (isVisitor == null)
            {
                _articleService.AddReaderCount(articleId);
                context.HttpContext.Response.Cookies.Append(hitBlog, JsonConvert.SerializeObject(new List<string> { articleId.ToString() }), new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(Duration)
                });
            }
            else
            {
                if (!isVisitor.Contains(articleId.ToString()))
                {
                    _articleService.AddReaderCount(articleId);
                    var cookieList = JsonConvert.DeserializeObject<List<string>>(isVisitor);
                    cookieList.Add(articleId.ToString());
                    context.HttpContext.Response.Cookies.Append(hitBlog, JsonConvert.SerializeObject(cookieList), new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddHours(Duration)
                    });
                }
            }
        }
    }
}
