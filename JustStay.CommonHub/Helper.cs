using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JustStay.CommonHub.ErrorLogServiceReference;
using System.Web;
using System.Security.Cryptography;
using System.Net.Mail;

namespace JustStay.CommonHub
{
  public static  class Helper
    {
        public const string CustomeRegistrationTemplate = "CustomeRegistration";
        public const string ATRCConfirmationTemlate = "ATRCConfirmation";
        public const string ATRCRejectionTemplate = "ATRCRejection";
        public const string ATRCApprovalTemplate = "ATRCApproval";
        public const string RCBookingConfirmTemplate = "RCBookingConfirm";
        public const string ForgetPassword = "ForgetPassword";
        public const string CustSignUpOTP = "CustSignUpOTP";
        public const string RazorKey = "rzp_live_LqnrevWLxsVNfm";
        public const string RazorSecret = "R7xsGWh7VrvAnL8ihDRnNPMg";
       // public const string RazorKey = "rzp_test_Vo6qzvunfbI3fR";
        //public const string RazorSecret = "YketVmPcadDN6XpvR8A5ZEM7";
        public const string PayAtAtrc = "PayAtAtrcOTP";
        public const string CustomeRegistrationEmail = "CustomeRegistrationEmail";


        public const string RestChairTable = "ATRC_RESTCHAIR";
        public const string MessageAtrcTable = "ATRCMESSAGE";
        public const string MessageAdminTable = "ADMINMESSAGE";

        public static string CreateShortString(int length, string data)
        {
            if (data.Length > length)
                return data.Substring(0, length - 3) + "...";
            else
                return data;
        }

        public static string GetFormatedDate(object date)
        {
            return string.Format("{0:ddd, MMM d, yyyy} at {1:hh:mm tt}", date, date);
        }

        public static string SendSMS(string smsUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(smsUrl);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string RemoveHTMLTag(this string value)
        {
            return Regex.Replace(value, @"<(.|\n)*?>", string.Empty);
        }


        public static string ReadFile(string fileName)
        {
            string Signature = " Thanks, <br /> JustStay";           
            StreamReader objStreamReader = File.OpenText(fileName);
            String contents = objStreamReader.ReadToEnd();
            return contents.Replace("{Signature}", Signature);
        }
        public static void SaveError(DateTime date,string error,string errirfrom,string pagename,string eventname)
        {
            ErrorLogServiceClient erroelogclient = new ErrorLogServiceClient();
            try
            {
                ErrorLogDto errlogdto = new ErrorLogDto
                {
                    date = date,
                    error = error,
                    ErrorFrom = errirfrom,
                    pagename = pagename,
                    eventname = eventname
                };
                erroelogclient.InsertErrorLog(errlogdto);
            }
            catch(Exception ex)
            {
                erroelogclient.Close();
            }
            finally
            {
                erroelogclient.Close();
            }
        }
        public static string GetCurrentPageName()
        {
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }
        public static string getActualSignature(string payload, string secret)
        {
            byte[] secretBytes = StringEncode(secret);

            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);

            var bytes = StringEncode(payload);

            return HashEncode(hashHmac.ComputeHash(bytes));
        }

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
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
                return 0;
            }
        }
        public static string ConvertDateTimeToString(this DateTime dt)
        {
           return dt.ToString("MM/dd/yyyy");
        }
        public static DateTime ChangeDateTimeFormat(this string s)
        {
           var culture = System.Globalization.CultureInfo.CurrentCulture;
           return DateTime.ParseExact(s, "MM/dd/yyyy", culture);
        }
    }
}
