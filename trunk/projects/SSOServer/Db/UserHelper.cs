using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Data.SqlClient;

namespace SSOServer.Db
{
    public class UserHelper
    {
        private static DBEntities db = new DBEntities();

        public static List<USERINFO> GetUserInfo(string UserId)
        {
            //#if DEBUG
            //            Debugger.Launch();
            //#endif

            List<USERINFO> users = new List<Db.USERINFO>();
            using (DBEntities db = new DBEntities())
            {
                USERINFO user = db.USERINFO.Find(Convert.ToInt32(UserId));
                users.Add(user);
            }

            return users;
        }

        public static USERINFO Login(string UserName, string Password)
        {
            //#if DEBUG
            //    Debugger.Launch();
            //#endif
            string condition = "";
            if (null != UserName && null != Password)
                condition = "select*From userinfo where UserName='" + UserName + "'";

            DbSqlQuery<USERINFO> result1 = db.USERINFO.SqlQuery(condition, UserName);
            if (null != result1 && result1.Count() > 0)
            {
                USERINFO user = result1.First<USERINFO>();

                if (null != user)
                {
                    //if (user.PASSWORD == Utils.md5Unicodebase64(Password))
                    if (user.PASSWORD == Password)
                        return user;
                }
            }
            return null;
        }

        public static USERINFO AddUser(USERINFO user)
        {
            USERINFO result = null;
            using (DBEntities db = new Db.DBEntities())
            {
                result = db.USERINFO.Add(user);
                db.SaveChanges();
            }
            return result;
        }

        public static int UpdateUser(USERINFO user)
        {
            USERINFO result = null;
            using (DBEntities db = new DBEntities())
            {
                result = db.USERINFO.Where(s => s.USERID == user.USERID).FirstOrDefault<USERINFO>();
            }

            using (DBEntities db = new DBEntities())
            {
                result.USERNAME = user.USERNAME;
                result.DISPLAYNAME = user.DISPLAYNAME;
                result.SHORTNAME = user.SHORTNAME;
                result.PASSWORD = user.PASSWORD;
                result.EMAIL = user.EMAIL;

                db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return 1;
        }

        public static int DelUser(string UserId)
        {
            USERINFO user = null;
            using (DBEntities db = new DBEntities())
            {
                user = db.USERINFO.Find(Convert.ToDecimal(UserId));
                db.USERINFO.Remove(user);
                db.SaveChanges();
                return 1;
            }
        }
    }
}