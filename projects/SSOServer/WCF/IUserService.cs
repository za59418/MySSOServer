using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SSOServer
{
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// 根据用户名和密码获取token
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>登陆成功返回{"State":"Success", "Token":"XXXXX"}，失败返回{"State":"Fail","Message":"登陆失败"}</returns>
        [OperationContract]
        string GetToken(string UserName, string Password);

        /// <summary>
        /// 根据用户名、密码和用户类型获取token
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Type">Dci = 1,Current = 2,ToDay = 3</param>
        /// <returns>登陆成功返回{"State":"Success", "Token":"XXXXX"}，失败返回{"State":"Fail","Message":"登陆失败"}</returns>
        [OperationContract]
        string GetTokenWithType(string UserName, string Password, TokenType Type);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns>返回用户JSON串</returns>
        [OperationContract]
        string GetUserInfo(string UserId);

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>登陆成功返回{"State":"Success", "User":"用户信息"}，失败返回{"State":"Fail"}</returns>
        [OperationContract]
        string Login(string UserName, string Password);

        /// <summary>
        /// 用token登陆
        /// </summary>
        /// <param name="Token">token</param>
        /// <returns>登陆成功返回{"State":"Success", "User":"用户信息"}，失败返回{"State":"Fail"}</returns>
        [OperationContract]
        string LoginWithToken(string Token);

        /// <summary>
        /// 管理员添加用户
        /// </summary>
        /// <param name="token">管理员登陆获取到的token</param>
        /// <param name="username">添加的用户名</param>
        /// <param name="displayname">显示名</param>
        /// <param name="shortname">简称</param>
        /// <param name="password">密码</param>
        /// <param name="email">邮箱</param>
        /// <returns>管理员登陆成功返回{"state":"success"}，失败返回{"state":"fail", "message":"无此用户"}</returns>
        [OperationContract]
        string AddUser(string Token, string UserName, string DisplayName, string ShortName, string Password, string Email);

        /// <summary>
        /// 管理员修改用户
        /// </summary>
        /// <param name="Token">管理员登陆获取到的TOKEN</param>
        /// <param name="UserId">修改的用户ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="DisplayName"></param>
        /// <param name="ShortName">简称</param>
        /// <param name="Email">邮箱</param>
        /// <param name="Description">描述</param>
        /// <param name="UserType">用户类型</param>
        /// <param name="IsLockedOut">是否锁定</param>
        /// <returns>管理员登陆成功返回{"State":"Success"}，失败返回{"State":"Fail", "Message":"无此用户"}</returns>
        [OperationContract]
        string UpdateUser(string Token, string UserId, string UserName, string DisplayName, string ShortName, string Email, string Description, string UserType, string IsLockedOut);

        /// <summary>
        /// 管理员删除用户
        /// </summary>
        /// <param name="Token">管理员登陆获取到的TOKEN</param>
        /// <param name="UserId">被删除用户的ID</param>
        /// <returns>管理员登陆成功返回{"State":"Success"}，失败返回{"State":"Fail", "Message":"无此用户"}</returns>
        [OperationContract]
        string DelUser(string Token, string UserId);

        /// <summary>
        /// 修改自己的密码
        /// </summary>
        /// <param name="Token">用户登陆获取到的TOKEN</param>
        /// <param name="Password">新密码</param>
        /// <returns>用户登陆成功返回{"State":"Success"}，失败返回{"State":"Fail", "Message":"无此用户"}</returns>
        [OperationContract]
        string ChangePwd(string Token, string Password);
    }
}
