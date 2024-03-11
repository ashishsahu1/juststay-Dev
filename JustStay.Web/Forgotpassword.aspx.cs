using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStay.Web.BusinessLogic;
using JustStay.Web.CommonServiceReference;
using JustStay.Web.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class Forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
     
        private string SendFwdPwdSMS(UserDto udto)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            string strres = "";
            try
            {
                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.ForgetPassword);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##password##", udto.Password);
                    strres = Common.SendSMS(udto.Mobile, msg);
                }
                commonClient.Close();
            }
            catch (Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return strres;
        }
        private int SendForgotPwdMailToCustomer(UserDto user)
        {
            int res = 0;
            try
            {
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "ForgotPwdMail.html");
                emailBody = emailBody.Replace("{NAME}", user.Name);
                emailBody = emailBody.Replace("{PWD}", user.Password);

                res = Common.SendMailithBcc("contact@juststay.in", new string[] { user.Email }, "Your JustStay Password", "", emailBody);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return res;
        }

        protected void btnforgetpassword_Click(object sender, EventArgs e)
        {
            UserServiceClient userclient = new UserServiceClient();
            try
            {
                string uname = txtForgotMobile.Text.Trim();
                UserDto udto = userclient.GetCustUserByUsernameOrMobile(uname);

                if (udto != null)
                {
                    if (udto.Mobile.Equals(uname))
                    {
                        string res = SendFwdPwdSMS(udto);
                        if(!string.IsNullOrEmpty(res))
                        {
                            lblerror.Text = "Password sent on your mobile. Please check SMS.";
                            lblerror.ForeColor = System.Drawing.Color.Green;
                            Response.Redirect("~/SignIn.aspx",false);
                        }
                        else
                        {
                            lblerror.Text = "Sorry.. sending password fail.";
                            lblerror.ForeColor = System.Drawing.Color.Red;
                            txtForgotMobile.Text = string.Empty;
                        }
                    }
                    else
                    {
                        lblerror.Text = "Mobile number does not exist.";
                        lblerror.ForeColor = System.Drawing.Color.Red;
                        txtForgotMobile.Text = string.Empty;
                    }
                    //else
                    //{
                    //    SendForgotPwdMailToCustomer(udto);
                    //    lblerror.Text = "Password sent on your email. Please check Email.";
                    //}

                }
                else
                {
                    lblerror.Text = "Mobile number does not exist.";
                    lblerror.ForeColor = System.Drawing.Color.Red;
                    txtForgotMobile.Text = string.Empty;
                }
                userclient.Close();
            }
            catch (Exception ex)
            {
                userclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}