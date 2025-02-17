using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUD.Filters.AuthorizationFilter
{
    public class PersonAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Cookies.ContainsKey("Auth-Key") == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
            else if (context.HttpContext.Request.Cookies["Auth-Key"] != "A100")
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
        }
    }
}
