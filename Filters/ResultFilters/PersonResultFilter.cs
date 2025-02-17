using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUD.Filters.ResultFilters
{
    public class PersonResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
