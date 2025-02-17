using CRUD.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD.Filters.ActionFilters
{
    public class PersonActionFilter : IActionFilter
    {
        private readonly ILogger<PersonActionFilter> _logger;
        private readonly string _key;
        private readonly string _value;
        public PersonActionFilter(ILogger<PersonActionFilter> logger,string key,string value)
        {
            _logger = logger;
            _key = key;
            _value = value;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            HomeController hm = (HomeController)context.Controller;
            var items = (IDictionary<string, Object?>)context.HttpContext.Items["items"];
            if (items != null)
            {
                if (items.ContainsKey("searchBy"))
                {
                    hm.ViewBag.SearchBy = items["searchBy"];
                }
                if (items.ContainsKey("query"))
                {
                    hm.ViewBag.Query = items["query"];
                }
                if (items.ContainsKey("sortBy"))
                {
                    hm.ViewBag.SortBy = items["sortBy"].ToString();
                }
                if (items.ContainsKey("column"))
                {
                    hm.ViewBag.Column = items["column"];
                }
            }
            _logger.LogCritical("Method Executed");
            context.HttpContext.Response.Headers[_key] = _value;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["items"] = context.ActionArguments;
            _logger.LogCritical("Method Executing");
        }
    }
}
