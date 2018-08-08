using MyApp.Data;
using MyApp.Service.Log;
using MyApp.Service.models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MyApp.Service.Artical
{
    public class ArticalService
    {
        private MemberShip CurrentUser;
        private readonly LookLogService _lookLogService;
        public ArticalService() {
            _lookLogService = new LookLogService();
        }

        public List<ArticalListModel> getArticalList()
        {


            var result = new List<ArticalListModel>();
            try
            {
                using (var db = new MyAppEntities()) {
                    result = db.MyApp_Article.OrderByDescending(o => o.WriteTime).Select(o=>new ArticalListModel() {
                        Id= o.Id,
                        AritcleName =o.AritcleName,
                        AritcleAuthorId = o.AritcleAuthorId,
                        WriteTime= o.WriteTime,
                        Type=o.Type,
                        ChildType=o.ChildType,
                        SimpleText=o.SimpleText
                    } ).ToList();

                }

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public List<ArticalListModel> getArticalListByType(int type)
        {

            var result = new List<ArticalListModel>();
            try
            {
                using (var db = new MyAppEntities())
                {
                    result = db.MyApp_Article.Where(o => o.Type == type).OrderByDescending(o => o.WriteTime).Select(o=>new ArticalListModel() {
                        Id = o.Id,
                        AritcleName = o.AritcleName,
                        AritcleAuthorId = o.AritcleAuthorId,
                        WriteTime = o.WriteTime,
                        Type = o.Type,
                        ChildType = o.ChildType,
                        SimpleText = o.SimpleText
                    }).ToList();

                }

            }
            catch (Exception e)
            {

            }
            return result;
        }
        public MyAppApiResult<MyApp_Article> GetArticalById(Guid Id , MemberShip CurrentUser)
        {

            var result = new MyAppApiResult<MyApp_Article>();
            try
            {
                using (var db = new MyAppEntities())
                {
                    result.Data = db.MyApp_Article.FirstOrDefault(o => o.Id == Id);

                    db.MyApp_LookLog.Add(new MyApp_LookLog()
                    {
                        Id = Guid.NewGuid(),
                        MemberShipId = CurrentUser.Id,
                        ArticleId=Id
                    });
                    db.SaveChanges();
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
                #region
                if (String.IsNullOrEmpty(article.AritcleName) || String.IsNullOrEmpty(article.SimpleText) || article.Type == null) {
                    result.AddError("数据不全，请确认后提交");
                    return result;
                }
                #endregion
                var db = new MyAppEntities();
                article.Id = Guid.NewGuid();
                article.WriteTime = DateTime.Now;
                article.AritcleAuthorId = Guid.NewGuid();
                db.MyApp_Article.Add(article);
                db.SaveChanges();

            }
            catch (Exception e) {
                result.AddError(e.Message);
            }
            return result;

        }




         

    }
}
