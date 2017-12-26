﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using SSOServer.Db;

namespace SSOServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestUserService : IRestUserService
    {
        public string GetToken(string UserName, string Password)
        {
            var user = UserHelper.Login(UserName, Password);
            if (null != user)
            {
                string str = string.Format("{0}|{1}", UserName, Password);
                Encoding uTF = Encoding.UTF8;
                byte[] bytes = uTF.GetBytes(str);
                return "{\"State\":\"Success\", \"Token\":\"" + Convert.ToBase64String(bytes, 0, bytes.Length) + "\"}";
            }
            return "{\"State\":\"Fail\",\"Message\":\"登陆失败\"}";
        }
        public string GetTokenWithType(string UserName, string Password, string Type)
        {
            var user = UserHelper.Login(UserName, Password);
            if (null != user)
            {
                string arg = "";
                switch (Type)
                {
                    case "1":
                        return GetToken(UserName, Password);
                    case "2":
                        arg = DateTime.Now.AddMinutes(1.0).ToString();
                        break;
                    case "3":
                        DateTime dateTime = DateTime.Now.AddDays(1.0);
                        arg = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0).ToString();
                        break;
                }
                string str = string.Format("{0}|{1}|{2}", UserName, Password, arg);
                Encoding uTF = Encoding.UTF8;
                byte[] bytes = uTF.GetBytes(str);
                return "{\"State\":\"Success\", \"Token\":\"" + Convert.ToBase64String(bytes, 0, bytes.Length) + "\"}";
            }
            return "{\"State\":\"Fail\",\"Message\":\"登陆失败\"}";
        }

        public string GetUserInfo(string UserId)
        {
            /*
            #if DEBUG
                        Debugger.Launch();
            #endif
            */
            if (null == UserId)
                return "[]";

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            jss.MaxJsonLength = Int32.MaxValue;
            var result = UserHelper.GetUserInfo(UserId);
            return jss.Serialize(result);
        }

        public string Login(string UserName, string Password)
        {
            /*
            #if DEBUG
                                    Debugger.Launch();
            #endif
            */
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            jss.MaxJsonLength = Int32.MaxValue;

            var user = UserHelper.Login(UserName, Password);
            if (null != user)
                return "{\"State\":\"Success\", \"User\":" + jss.Serialize(user) + "}";
            return "{\"State\":\"Fail\"}";
        }

        private USERINFO GetUserByToken(string Token)
        {
            string[] arr = GetToKenInfo(Token);
            USERINFO user = null;
            if (arr != null)
            {
                string UserName = arr[0], Password = arr[1];
                user = UserHelper.Login(UserName, Password);
            }
            return user;
        }

        public string LoginWithToken(string Token)
        {
            /*
            #if DEBUG
                                    Debugger.Launch();
            #endif
            */
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            jss.MaxJsonLength = Int32.MaxValue;

            USERINFO user = GetUserByToken(Token);
            if (null != user)
                return "{\"State\":\"Success\", \"User\":" + jss.Serialize(user) + "}";
            return "{\"State\":\"Fail\"}";
        }

        private string[] GetToKenInfo(string toKen)
        {
            byte[] bytes = Convert.FromBase64String(toKen);
            string @string = Encoding.UTF8.GetString(bytes);
            string[] array = @string.Split("|".ToCharArray());
            bool flag = array != null;
            string[] result;
            if (flag)
            {
                bool flag2 = array.Length == 2;
                if (flag2)
                {
                    result = array;
                    return result;
                }
                bool flag3 = array.Length == 3;
                if (flag3)
                {
                    DateTime now = DateTime.Now;
                    bool flag4 = DateTime.TryParse(array[2], out now);
                    if (flag4)
                    {
                        bool flag5 = now > DateTime.Now;
                        if (flag5)
                        {
                            result = array;
                            return result;
                        }
                    }
                }
            }
            result = null;
            return result;
        }
        public string AddUser(string Token, string UserName, string DisplayName, string ShortName, string Password, string Email)
        {
            USERINFO user = GetUserByToken(Token); // 登陆
            if (null != user)
            {
                user = new USERINFO(); // 添加
                user.USERNAME = UserName;
                user.DISPLAYNAME = DisplayName;
                user.SHORTNAME = ShortName;
                user.PASSWORD = Utils.md5Unicodebase64(Password);
                user.EMAIL = Email;
                USERINFO u = UserHelper.AddUser(user);
                if (null != u)
                    return "{\"State\":\"Success\"}";
            }
            return "{\"State\":\"Fail\", \"Message\":\"无此用户\"}";
        }

        public string UpdateUser(string Token, string UserId, string UserName, string DisplayName, string ShortName, string Email, string Description, string UserType, string IsLockedOut)
        {
            USERINFO user = GetUserByToken(Token); // 登陆
            if (null != user)
            {
                user = UserHelper.GetUserInfo(UserId)[0];
                user.USERNAME = UserName;
                user.DISPLAYNAME = DisplayName;
                user.SHORTNAME = ShortName;
                user.EMAIL = Email;
                user.DESCRIPTION = Description;
                int count = UserHelper.UpdateUser(user);
                if (count > 0)
                    return "{\"State\":\"Success\"}";
            }
            return "{\"State\":\"Fail\", \"Message\":\"无此用户\"}";
        }

        public string DelUser(string Token, string UserId)
        {
            USERINFO user = GetUserByToken(Token); // 登陆
            if (null != user)
            {
                int count = UserHelper.DelUser(UserId);
                if (count > 0)
                    return "{\"State\":\"Success\"}";
            }
            return "{\"State\":\"Fail\", \"Message\":\"无此用户\"}";
        }
        public string ChangePwd(string Token, string Password)
        {
            USERINFO user = GetUserByToken(Token); // 登陆
            user.PASSWORD = Utils.md5Unicodebase64(Password);
            if (null != user)
            {
                int count = UserHelper.UpdateUser(user);
                if (count > 0)
                    return "{\"State\":\"Success\"}";
            }
            return "{\"State\":\"Fail\", \"Message\":\"无此用户\"}";
        }
    }
}