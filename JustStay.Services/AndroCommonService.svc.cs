using JustStay.CommonHub;
using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.IO;
using System.Net;

namespace JustStay.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AndroCommonService
    {
        CommonRepository commonRepository;
        ErrorLogRepository errorlogRepository;
        RatingRepository ratingRepository;

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SendSMS/{mobile}/{msg}")]
        public string SendSMS(string mobile, string msg)
        {
            commonRepository = new CommonRepository();
            Setting setting = commonRepository.GetSettings();

            string smsUrl = setting.SmsUrl;
            smsUrl = smsUrl.Replace("uername", setting.SmsUsername);
            smsUrl = smsUrl.Replace("pwd", setting.SmsPassword);
            smsUrl = smsUrl.Replace("senderid", setting.SmsSenderId);
            smsUrl = smsUrl.Replace("mobile", mobile);
            smsUrl = smsUrl.Replace("message", msg);
            return Helper.SendSMS(smsUrl);
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSettings")]
        public SettingDto GetSettings()
        {
            commonRepository = new CommonRepository();
            var setting = commonRepository.GetSettings();

            return new SettingDto()
            {
                SettingId = setting.SettingId,
                SmsUrl = setting.SmsUrl,
                SmsUsername = setting.SmsUsername,
                SmsPassword = setting.SmsPassword,
                SmsSenderId = setting.SmsSenderId,
                SMSBalanceUrl = setting.SMSBalanceUrl,
                privacy = setting.privacy
            };
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSMSTemplateByName/{tempname}")]
        public SMSTemplateDto GetSMSTemplateByName(string tempname)
        {
            commonRepository = new CommonRepository();
            var template = commonRepository.GetSMSTemplateByName(tempname);
            SMSTemplateDto sms = new SMSTemplateDto();
            sms.TemplateId = template.TemplateId;
            sms.Name = template.Name;
            sms.Template = template.Template;
            sms.InsertedOn = template.InsertedOn;
            sms.IsActive = template.IsActive;
            sms.UpdatedOn = template.UpdatedOn;
            return sms;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "InsertErrorLog/{date}/{error}/{errorfrom}/{eventname}/{pagename}")]
        public void InsertErrorLog(string date, string error,string errorfrom, string eventname, string pagename)
        {
            errorlogRepository = new ErrorLogRepository();
            ErrorLog log = new ErrorLog()
            {
                date = Convert.ToDateTime(date),
                error = error,
                ErrorFrom = errorfrom,
                eventname = eventname,
                pagename = pagename
            };
           errorlogRepository.InsertErrorLog(log);
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "InsertRating/{atrcid}/{name}/{email}/{mobile}/{city}/{comment}/{star}")]
        public int InsertRating(string atrcid,string name,string email,string mobile,string city,string comment,string star)
        {
            ratingRepository = new RatingRepository();
            Rating rate = new Rating 
            { 
                ATRCId = Convert.ToInt32(atrcid),
                Name = name,
                Email = email,
                Mobile = mobile,
                City = city,
                Description = comment,
                Star = Convert.ToDouble(star)
            };
            try
            {
                ratingRepository.InsertRating(rate);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllRating/{atrcid}")]
        public List<Rating> GetAllRating(string atrcid)
        {
           ratingRepository = new RatingRepository();
           return ratingRepository.GetAllRating(Convert.ToInt32(atrcid));
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "RegistrationMailToCustomer/{name}/{mobile}/{email}/{password}")]
        private int RegistrationMailToCustomer(string name,string mobile,string email,string password)
        {
            int res = 0;
            string useremail = "";
            try
            {
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "CustomerRegistration.html");
                emailBody = emailBody.Replace("{NAME}", name);
                emailBody = emailBody.Replace("{MOBILE}", mobile);
                if (!string.IsNullOrEmpty(email))
                    emailBody = emailBody.Replace("{EMAIL}", email);
                else
                    emailBody = emailBody.Replace("{EMAIL}", "");

                if (string.IsNullOrEmpty(email))
                    useremail = "contact@juststay.in";
                else
                    useremail = email;

                emailBody = emailBody.Replace("{PWD}", password);

                res = Helper.SendMailithBcc("contact@juststay.in", new string[] { useremail }, "Registration in Just Stay", "", emailBody);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Service", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return res;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetFAQ/{audId}")]
        public List<FAQ> GetFAQ(string audId)
        {
            FAQRepository faqRepository = new FAQRepository();
            List<FAQ> faqlist = faqRepository.GetFAQByAudience(Convert.ToInt32(audId));
            if (faqlist == null) return null;

            return faqlist;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "PayAtATRCOTPMailToCustomer/{name}/{otp}/{email}")]
        private int PayAtATRCOTPMailToCustomer(string name, string otp,string email)
        {
            int res = 0;
            string useremail = "";
            try
            {
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "PayAtATRC.html");
                emailBody = emailBody.Replace("{NAME}", name);
                emailBody = emailBody.Replace("{OTP}", otp);
                

                if (string.IsNullOrEmpty(email))
                    useremail = "contact@juststay.in";
                else
                    useremail = email;


                res = Helper.SendMailithBcc("contact@juststay.in", new string[] { useremail }, "OTP Pay At ATRC - JustStay", "", emailBody);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Service", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return res;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDistance/{fromlat}/{fromlng}/{atrclat}/{atrclng}")]
        private string GetDistance(string fromlat, string fromlng, string atrclat,string atrclng)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string strdata = "";
            try
            {
                //AIzaSyDdrX4Wb1plDTszZ-nW-OPsLZXkDxOH4ko
                //https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Washington,DC&destinations=New+York+City,NY&key=YOUR_API_KEY
                //location = location.Replace(' ', "%20");
                String url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + fromlat + "," + fromlng + "&destinations="+ atrclat  + "," + atrclng  + "&mode=driving&language=pl-PL&key=AIzaSyDdrX4Wb1plDTszZ-nW-OPsLZXkDxOH4ko";
                //"https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + lat + "," + lng + "&destinations=" + location + "&key=AIzaSyDdrX4Wb1plDTszZ-nW-OPsLZXkDxOH4ko";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                strdata = reader.ReadToEnd();

            }
            catch(Exception ex) {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Service", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return strdata;
        }


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ForgetPasswordMailToCustomer/{name}/{pass}/{email}")]
        private int ForgetPasswordMailToCustomer(string name, string pass,string email)
        {
            int res = 0;
            string useremail = "";
            try
            {
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "ForgotPwdMail.html");
                emailBody = emailBody.Replace("{NAME}", name);
                emailBody = emailBody.Replace("{PWD}", pass);
                if (string.IsNullOrEmpty(email))
                    useremail = "contact@juststay.in";
                else
                    useremail = email;

                res = Helper.SendMailithBcc("contact@juststay.in", new string[] { useremail }, "Your JustStay Password", "", emailBody);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Service", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return res;
        }

    }
}
