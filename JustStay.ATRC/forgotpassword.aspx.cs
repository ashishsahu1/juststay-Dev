using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.ATRC.UserServiceReference;

namespace JustStay.ATRC
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtemail.Text.Trim()))
                {
                    UserServiceClient uclient = new UserServiceClient();
                    int userid = uclient.GetUserIdByEmailAndUserType(txtemail.Text.Trim(),"ATRC");
                    if (userid != 0)
                    {
                        UserDto udto = uclient.GetUserbyId(userid);
                        if (udto == null) return;
                        string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                        String emailBody = Helper.ReadFile(templatePath + "ForgotPwdMail.html");
                        emailBody = emailBody.Replace("{NAME}", udto.Name);
                        emailBody = emailBody.Replace("{PWD}", udto.Password);
                        emailBody = emailBody.Replace("{Signature}", "From JustStay");
                        int response = Common.SendMail("juststay.business@gmail.com", new string[] { txtemail.Text.Trim() }, "Your Password - From JustStay", emailBody);
                        if (response != 0)
                        {
                            lblerrorMsg.InnerText = "Your password sent on given email. Please check your email.";
                            lblerrorMsg.Style.Add("color", "green");
                        }
                        else
                        {
                            lblerrorMsg.InnerText = "Sending password fail. Please contact with Just Stay.";
                            lblerrorMsg.Style.Add("color","red");
                        }
                    }
                    else
                    {
                        lblerrorMsg.InnerText = "Your email address not exists in our system. Please enter registered ATRC email.";
                        lblerrorMsg.Style.Add("color", "red");
                    }
                }
                else
                {
                    lblerrorMsg.InnerText = "Please enter registered email";
                    lblerrorMsg.Style.Add("color", "red");
                }
            }
            catch (Exception ex)
            {
                lblerrorMsg.InnerText = "Sending password fail. Please contact with Just Stay.";
                lblerrorMsg.Style.Add("color", "red");
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}