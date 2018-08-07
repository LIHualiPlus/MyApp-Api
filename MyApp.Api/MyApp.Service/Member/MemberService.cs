using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Member
{
    public class MemberService 
    {
        public MyAppApiResult<MemberShip> Login(MemberShip user)
        {
            var res = new MyAppApiResult<MemberShip>();
            try {
                using (var db = new MyAppEntities()) {
                    var member = db.MemberShip.FirstOrDefault(o => o.LoginName == user.LoginName && o.PassWord == user.PassWord);
                    if (member != null)
                    {
                        res.Data = member;
                    }
                    else {
                        res.AddError("用户名或密码不正确");
                        return res;
                    }
                }

            }
            catch (Exception e) {
                res.AddError(e.Message);
            }
            return res;
        }
        public MyAppApiResult<MemberShip> Regist(MemberShip user)
        {
            var res = new MyAppApiResult<MemberShip>();
            try
            {
                using (var db = new MyAppEntities())
                {
                    #region
                    if (db.MemberShip.Any(o => o.LoginName == user.LoginName)) {
                        res.AddError("用户已存在");
                        return res;
                    }
                    #endregion
                    user.Id = Guid.NewGuid();
                    db.MemberShip.Add(user);
                    db.SaveChanges();
                    res.Data = user;
                }

            }
            catch (Exception e)
            {
                res.AddError(e.Message);
            }
            return res;
        }
    }
}
