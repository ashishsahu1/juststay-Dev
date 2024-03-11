using JustStay.Web.UserServiceReference;
using JustStay.Web.CommonServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustStay.Web.BusinessLogic
{
    /// <summary>
    /// Summary description for ValidateData
    /// </summary>
    public class ValidateData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Boolean isEixst = false;
            string para = "";

            string mode = context.Request.QueryString["mode"];
            string value = context.Request.QueryString["value"];
            string userTypeId = context.Request.QueryString["userTypeId"];

            switch (mode)
            {
                case "mobile":
                    isEixst = IsMobileExist(value, int.Parse(userTypeId));
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(isEixst);
                    break;
                case "email":
                    isEixst = IsEmailExist(value, int.Parse(userTypeId));
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(isEixst);
                    break;
                case "enq":
                    para = EncryptString(value);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(para);
                    break;
                case "dnq":
                    para = DecryptString(value);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(para);
                    break;
            }
        }        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region  " Private Methods "       

        private bool IsMobileExist(string mobile, int userTypeId)
        {
            UserServiceClient userClient = new UserServiceClient();
            return userClient.IsMobileExist(mobile, userTypeId);
        }

        private bool IsEmailExist(string email, int userTypeId)
        {
            UserServiceClient userClient = new UserServiceClient();
            return userClient.IsEmailExist(email, userTypeId);
        }
        private string EncryptString(string data)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            return commonClient.Encrypt(data);
        }
        private string DecryptString(string data)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            return commonClient.Decrypt(data);
        }
        #endregion
    }
}