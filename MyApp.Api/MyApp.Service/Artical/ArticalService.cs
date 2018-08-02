using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Artical
{
    public class ArticalService
    {
        public  List<MyApp_Book> getArticalList()
        {
            var result = new List<MyApp_Book>();
            try
            {
                var db = new MyAppEntities();
                result = db.MyApp_Book.ToList();
                
            }
            catch (Exception e)
            {
               
            }
            return result;
        }

    }
}
