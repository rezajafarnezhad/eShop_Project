using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission =
                (NeedsPermissionsAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(
                    typeof(NeedsPermissionsAttribute));

            if (handlerPermission == null)
                return;

            var accountPermissions = _authHelper.GetPermissions();

            if (accountPermissions.All(x => x != handlerPermission.Permission))
            {
                context.HttpContext.Response.Redirect("/AccessDenied");

            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
           
        }
    }
}
