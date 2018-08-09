using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Log
{
    public class LookLogService
    {

        public MyAppApiResult<bool> AddLog( MyApp_LookLog log)
        {
            var res = new MyAppApiResult<bool>();
            try
            {
                 

            }
            catch (Exception e)
            {
                res.AddError(e.Message);
            }
            return res;
        }
    }
}
