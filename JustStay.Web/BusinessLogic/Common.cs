using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStay.Web.BlogServiceReference;
using JustStay.Web.CommonServiceReference;
using JustStay.Web.UserServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace JustStay.Web.BusinessLogic
{
    public static class Common
    {

        public static bool IsLogedIn
        {
            get
            {
                bool logedIn = false;
                if (HttpContext.Current.Session["User"] != null)
                {
                    logedIn = true;
                }
                return logedIn;
            }
            set { }
        }

        public static string Name
        {
            get
            {
                string UserName = "";
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                    UserName = udto.Name.ToString();
                }
                return UserName;
            }
        }

        public static int CustomerId
        {
            get
            {
                int custId = 0;
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                    custId = udto.CustomerId;
                }
                return custId;
            }
        }

        public static int UserId
        {
            get
            {
                int userId = 0;
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                    userId = udto.UserId;
                }
                return userId;
            }
        }

        public static string Mobile
        {
            get
            {
                string mobile = "";
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                    mobile = udto.Mobile;
                }
                return mobile;
            }
        }
        public static string Email
        {
            get
            {
                string email = "";
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                    email = udto.Email;
                }
                return email;
            }
        }

        public static int SendMailithBcc(string FromEmail, string[] ToEmail, string Subject, string bcc, string Body)
        {
            MailMessage objMail = new MailMessage();
            objMail.Body = Body;
            objMail.Subject = Subject;
            for (int i = 0; i < ToEmail.Length; i++)
            {
                objMail.To.Add(ToEmail[i].ToString());
            }
            objMail.Bcc.Add("nmskaar.business@gmail.com");
            objMail.From = new MailAddress(FromEmail, "JustStay"); 
            objMail.BodyEncoding = System.Text.Encoding.UTF8;
            objMail.Body = Body;
            objMail.IsBodyHtml = true;
            objMail.Priority = MailPriority.High;

            SmtpClient mailClient = new SmtpClient("smtp.gmail.com");
            mailClient.Port = 587;
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.Credentials = new System.Net.NetworkCredential("juststaypune@gmail.com", "sanjay6990");
          
            mailClient.Host = "smtp.gmail.com";

            try
            {
                mailClient.Send(objMail);
                return 1;
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                return 0;
            }
        }
        public static string SendSMS(string mobile, string msg)
        {
           
            CommonServiceClient commonClient = new CommonServiceClient();
            string strsms = "";
            try
            {
                SettingDto setting = commonClient.GetSettings();
                string smsUrl = setting.SmsUrl;
                smsUrl = smsUrl.Replace("uername", setting.SmsUsername);
                smsUrl = smsUrl.Replace("pwd", setting.SmsPassword);
                smsUrl = smsUrl.Replace("senderid", setting.SmsSenderId);
                smsUrl = smsUrl.Replace("mobile", mobile);
                smsUrl = smsUrl.Replace("message", msg);
                strsms = Helper.SendSMS(smsUrl);
            }
            catch (Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return strsms;
        }
        public static List<ListItem> GetListItemBlogList(List<BlogCatgoryDto> categories)
        {
            List<ListItem> blogList =
                     categories.ConvertAll(x => new ListItem
                     {
                         Value = "." + x.BlogCategoryId.ToString(),
                         Text = x.Name

                     });

            return blogList;
        }

        public static DateTime CombineDateAndTime(DateTime date,DateTime time)
        {
            return date + (time).TimeOfDay;
        }
    }
}