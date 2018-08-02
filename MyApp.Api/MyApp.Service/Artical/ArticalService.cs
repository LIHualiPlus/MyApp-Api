using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MyApp.Service.Artical
{
    public class ArticalService
    {
       
         
       
        public  List<MyApp_Article> getArticalList()
        {
             
            var result = new List<MyApp_Article>();
            try
            {
                using (var db = new MyAppEntities()) {
                result = db.MyApp_Article.ToList();

                }
                
            }
            catch (Exception e)
            {
               
            }
            return result;
        }


        public MyAppApiResult<bool> AddArticle(MyApp_Article article) {
            var result = new MyAppApiResult<bool>();
            try
            {
                var db = new MyAppEntities();
                    article.Id = Guid.NewGuid();
                    article.WriteTime = DateTime.Now;
                    article.AritcleAuthorId = Guid.NewGuid();
                    db.MyApp_Article.Add(article);
                    db.SaveChanges();
               
            }
            catch(Exception e){
                result.AddError(e.Message);
            }
            return result;

        }

    }
}
