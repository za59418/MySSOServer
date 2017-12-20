using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SSOServer
{
    [ServiceContract(Name = "RestUserService")]
    public interface IRestUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = Routing.GetToken, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetToken(string UserName, string Password);

        [OperationContract]
        [WebGet(UriTemplate = Routing.GetTokenWithType, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetTokenWithType(string UserName, string Password, string Type);

        [OperationContract]
        [WebGet(UriTemplate = Routing.GetUserInfo, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetUserInfo(string UserId);

        [OperationContract]
        [WebGet(UriTemplate = Routing.Login, BodyStyle = WebMessageBodyStyle.Bare)]
        string Login(string UserName, string Password);

        [OperationContract]
        [WebGet(UriTemplate = Routing.LoginWithToken, BodyStyle = WebMessageBodyStyle.Bare)]
        string LoginWithToken(string Token);

        [OperationContract]
        [WebGet(UriTemplate = Routing.AddUser, BodyStyle = WebMessageBodyStyle.Bare)]
        string AddUser(string Token, string UserName, string DisplayName, string ShortName, string Password, string Email);
        [OperationContract]
        [WebGet(UriTemplate = Routing.UpdateUser, BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateUser(string Token, string UserId, string UserName, string DisplayName, string ShortName, string Email, string Description, string UserType, string IsLockedOut);
        [OperationContract]
        [WebGet(UriTemplate = Routing.DelUser, BodyStyle = WebMessageBodyStyle.Bare)]
        string DelUser(string Token, string UserId);
        [OperationContract]
        [WebGet(UriTemplate = Routing.ChangePwd, BodyStyle = WebMessageBodyStyle.Bare)]
        string ChangePwd(string Token, string Password);
    }
    partial class Routing
    {
        public const string GetToken = "/GetToken/{UserName}/{Password}";
        public const string GetTokenWithType = "/GetTokenWithType/{UserName}/{Password}/{Type}";
        public const string GetUserInfo = "/GetUserInfo/{UserId}";
        public const string Login = "/Login/{UserName}/{Password}";
        public const string LoginWithToken = "/LoginWithToken/{Token}";

        public const string AddUser = "/AddUser/{Token}/{UserName}/{DisplayName}/{ShortName}/{Password}/{Email}";
        public const string UpdateUser = "/UpdateUser/{Token}/{UserId}/{UserName}/{DisplayName}/{ShortName}/{Email}/{Description}/{UserType}/{IsLockedOut}";
        public const string DelUser = "/DelUser/{Token}/{UserId}";
        public const string ChangePwd = "/ChangePwd/{Token}/{Password}";
    }

}
