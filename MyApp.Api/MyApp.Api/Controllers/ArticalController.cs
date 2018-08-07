using MyApp.Api.filter;
using MyApp.Data;
using MyApp.Service;
using MyApp.Service.Artical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MyApp.Api.Controllers
{
    [AuthorizeFilter]
    public class ArticalController: BaseApiController
    {
        private readonly ArticalService _articalService;

        public ArticalController() {
            _articalService = new ArticalService();

        }
        [System.Web.Http.ActionName("getArticalList")]
        [HttpGet]
        public List<MyApp_Article> getArticalList()
        {
            var a = CurrentUser;
            return _articalService.getArticalList();
        }
        [System.Web.Http.ActionName("GetArticalListByType")]
        [HttpGet]
        public List<MyApp_Article> getArticalListByType(int type)
        {

            return _articalService.getArticalListByType(type);
        }

        [System.Web.Http.ActionName("addArtical")]
        [HttpPost]
        [AllowAnonymous]
        public MyAppApiResult<bool> addArtical(MyApp_Article article) {
             
            return _articalService.AddArticle(article);
        }
    }
}