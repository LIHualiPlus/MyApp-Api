using MyApp.Data;
using MyApp.Service;
using MyApp.Service.Artical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyApp.Api.Controllers
{
    public class ArticalController: ApiController
    {
        private readonly ArticalService _articalService;

        public ArticalController() {
            _articalService = new ArticalService();

        }
        [System.Web.Http.ActionName("getArticalList")]
        [HttpGet]
        public List<MyApp_Article> getArticalList( )
        {

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