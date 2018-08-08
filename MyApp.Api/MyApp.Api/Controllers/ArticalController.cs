using MyApp.Api.filter;
using MyApp.Data;
using MyApp.Service;
using MyApp.Service.Artical;
using MyApp.Service.models;
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
        public List<ArticalListModel> getArticalList()
        {
            return _articalService.getArticalList();
        }
        [System.Web.Http.ActionName("GetArticalListByType")]
        [HttpGet]
        public List<ArticalListModel> getArticalListByType(int type)
        {

            return _articalService.getArticalListByType(type);
        }

        [System.Web.Http.ActionName("GetArticalById")]
        [HttpGet]
        public MyAppApiResult<MyApp_Article> GetArticalById(Guid Id)
        {

            return _articalService.GetArticalById(Id,CurrentUser);
        }

        [System.Web.Http.ActionName("addArtical")]
        [HttpPost]
        [AllowAnonymous]
        public MyAppApiResult<bool> addArtical(MyApp_Article article) {
             
            return _articalService.AddArticle(article);
        }
    }
}