using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyApp.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private MemberShip currentuser;

        public virtual MemberShip CurrentUser {
            get {
                var PassWord = ActionContext.Request.Headers.GetValues("PassWord").FirstOrDefault();
                var LoginName = ActionContext.Request.Headers.GetValues("LoginName").FirstOrDefault();
                using (var db = new MyAppEntities()) {
                 var user =  db.MemberShip.FirstOrDefault(o => o.PassWord == PassWord && o.LoginName==LoginName);

                    return user;
                }

            }

        }
    }
}