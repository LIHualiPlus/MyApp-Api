using MyApp.Data;
using MyApp.Service;
using MyApp.Service.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyApp.Api.Controllers
{
    public class MemberController : ApiController
    {
        private readonly MemberService _memberService;

        public MemberController() {
            _memberService = new MemberService();
        }

        [System.Web.Http.ActionName("Login")]
        [HttpPost]
        [AllowAnonymous]
        public MyAppApiResult<MemberShip> Login(MemberShip user)
        {

            return _memberService.Login(user);
        }

        [System.Web.Http.ActionName("Regist")]
        [HttpPost]
        [AllowAnonymous]
        public MyAppApiResult<MemberShip> Regist(MemberShip user)
        {

            return _memberService.Regist(user);
        }
    }
}