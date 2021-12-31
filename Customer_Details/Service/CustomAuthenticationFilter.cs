using Customer_Details.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Customer_Details.Service
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private Intern_DBEntities dbcontext = new Intern_DBEntities();
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserName"])))
            {
                filterContext.Result = new HttpUnauthorizedResult("Access is Denied");
            }

        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //Redirecting the user to the Login View of CustomerDataController Controller
                filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    //{ "controller", "CustomerDataController" },
                    { "action", "Login" }
               });
                
            }
        }
    }
}