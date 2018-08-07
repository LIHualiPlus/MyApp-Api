using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MyApp.Api.filter
{
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext) {
            var PassWord = actionContext.Request.Headers.GetValues("PassWord");
            var LoginName = actionContext.Request.Headers.GetValues("LoginName");

        }
    }
}