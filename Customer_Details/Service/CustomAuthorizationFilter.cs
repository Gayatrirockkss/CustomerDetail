using Customer_Details.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Customer_Details.Service
{
    public class CustomAuthorizationFilter : AuthorizeAttribute
    {    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var UserName = Convert.ToString(httpContext.Session["UserName"]);
            if (!string.IsNullOrEmpty(UserName))
                using (var context = new Intern_DBEntities())
                {
                    var userRole = context.LoginDetails.Where(c => c.Login_UserName == UserName).FirstOrDefault();

                    if (UserName == "Admin") return true;
                    
                }


            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
               });
        }
    }
}