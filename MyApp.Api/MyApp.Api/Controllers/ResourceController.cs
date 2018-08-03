using MyApp.Data;
using MyApp.Service;
using MyApp.Service.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyApp.Api.Controllers
{
    public class ResourceController:ApiController
    {
        private readonly ResourceService _resourceService;
        public ResourceController(ResourceService resourceService) {
            this._resourceService = resourceService;
                }


        [System.Web.Http.ActionName("addFile")]
        [HttpPost]
        public MyAppApiResult<bool> addFile()
        {
        return _resourceService.addFile();
        }


    }
    
}