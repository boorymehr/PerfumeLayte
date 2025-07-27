using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Services.Product.Querises.UserPermition;
namespace Perfume_Layte.Permition
{
    public class PermisionChecker : AuthorizeAttribute, IAuthorizationFilter
    {
        #region constractor
        private IUserPermition IUserPermition;
        private bool _isAdmin;
        public PermisionChecker(bool isAdmin)
        {
            _isAdmin = isAdmin;
        }
        #endregion

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IUserPermition = (IUserPermition)context.HttpContext.RequestServices.GetService(typeof(IUserPermition));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                int UserID = IUserPermition.Execut(context.HttpContext.User.Identity.Name);
                bool isAdmin =  IUserPermition.Execut(UserID);

                if (isAdmin != _isAdmin)
                {
                    context.Result = new RedirectResult("/Login/LoginUser");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Login/LoginUser");
            }
        }

        
    }
}
