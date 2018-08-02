using MyApp.Data;
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
        public List<MyApp_Book> getArticalList( )
        {
            
             
            return _articalService.getArticalList();
        }
    }
}