using Microsoft.AspNetCore.Mvc.Filters;
using TechBlog.Entity.Entities;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Web.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IVisitorService _visitorService;
        public ArticleVisitorFilter(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<Visitor> visitors = await _visitorService.GetAllVisitorsAsync();

            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitor visitor = new Visitor(getIp, getUserAgent);

            if (visitors.Any(x => x.IpAddress == visitor.IpAddress))
                await next();
            else
            {
                await _visitorService.CreateVisitorAsync(visitor);
            }
        }
    }
}
