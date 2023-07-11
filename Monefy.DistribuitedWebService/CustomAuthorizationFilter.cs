using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Monefy.DistribuitedWebService
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                var response = new
                {
                    Success = false,
                    Message = "You are not authorized."
                };

                context.Result = new UnauthorizedObjectResult(response);
            }
        }
    }
}
