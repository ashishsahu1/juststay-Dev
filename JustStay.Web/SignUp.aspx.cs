using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Web.CommonServiceReference;
using JustStay.Web.UserServiceReference;
using JustStay.CommonHub;
using JustStay.Web.BusinessLogic;
using JustStay.Web.CustomerServiceReference;
using JustStay.Services.DTO;

namespace JustStay.Web
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Session["name"] = Convert.ToString(txtUsername.Text.Trim());
                    Session["email"] = Convert.ToString(txtEmail.Text.Trim());
                    Session["mobile"] = Convert.ToString(txtUserMobile.Text.Trim());
                    string res =  SendOTP(Convert.ToString(txtUsername.Text.Trim()), Convert.ToString(txtUserMobile.Text.Trim()));
                    txtUsername.Text = txtEmail.Text = txtUserMobile.Text = string.Empty;
                    divSignUp.Style.Add("display", "none");
                    divOTP.Style.Add("display", "block");
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #region Private Method
        private string SendOTP(string ussername,string mobilenumber)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            string strres = "";
            try
            {
                Random num = new Random();
                string OTP = Convert.ToString(num.Next(1000, 9999));

                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.CustSignUpOTP);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##customer##", ussername);
                    msg = msg.Replace("##OTP##", OTP);
                    strres = Common.SendSMS(mobilenumber, msg);
                }
                Session["OTP"] = OTP;
                Session["SentTime"] = DateTime.Now;
                commonClient.Close();
            }
            catch(Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return strres;
        }
        private void VerifyOTP(string OTP,string Password)
        {
            UserServiceClient userserviceClient = new UserServiceClient();
            CustomerServiceClient custClient = new CustomerServiceClient();
            try
            {
                string otpFromUser = OTP.Trim();

                bool validOTP = true;
                if (Session["name"] != null && Session["mobile"] != null)
                {
                    if (Session["OTP"].ToString() == otpFromUser)
                    {
                        DateTime sentTime = Convert.ToDateTime(Session["SentTime"]);
                        int seconds = DateTime.Now.Subtract(sentTime).Seconds;
                        if (seconds <= 60)
                        {
                            Random num = new Random();

                            UserDto user = new UserDto();
                            user.Name = Convert.ToString(Session["name"]);
                            user.Mobile = user.Username = Convert.ToString(Session["mobile"]);
                            user.Email = Convert.ToString(Session["email"]);
                            user.Password = Convert.ToString(Password.Trim());
                            user.IsActive = true;
                            user.IsPaid = false;
                            user.UserTypeId = 3;
                            user.InsertedOn = DateTime.Now;
                            user.RoleId = 0;
                            user.IsAdmin = false;
                            int userid = userserviceClient.InsertUser(user);

                            CustomerDto cust = new CustomerDto()
                            {
                                UserId = userid,
                                IsGuest = false
                            };
                            int custid = custClient.InsertCustomer(cust);
                            string strres = SendSMSToCustomer(user);
                            try
                            {
                                int succss = SendMailToCustomer(user);
                            }
                            catch (Exception ex)
                            {
                                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                            }
                            userserviceClient.Close();
                            custClient.Close();
                            // SendMailtoAdmin(user.Name, user.Mobile);
                            if (custid > 0 && strres != "")
                                Response.Redirect("~/SignIn.aspx", false);
                            else
                            {
                                lblerror.Text = "OTP varification fail.";
                                // lblerror.Text = "Wrong OTP. Please enter valid OTP.";
                                lblerror.ForeColor = System.Drawing.Color.Red;
                                txtPassword.Text = txtConfirmPassword.Text = txtOTP.Text = string.Empty;
                                lnkResendOTP.Visible = true;
                                lnkVerifyOTP.Visible = true;
                                userserviceClient.Close();
                                custClient.Close();
                            }
                        }
                        else
                        {
                            lblerror.Text = "OTP time expired. Please click on resend OTP button.";
                            lblerror.ForeColor = System.Drawing.Color.Red;
                            txtPassword.Text = txtConfirmPassword.Text = txtOTP.Text = string.Empty;
                            lnkResendOTP.Visible = true;
                            userserviceClient.Close();
                            custClient.Close();
                            // lnkVerifyOTP.Visible = true;
                        }
                    }
                    else
                    {
                        lblerror.Text = "Wrong OTP. Please enter valid OTP.";
                        lblerror.ForeColor = System.Drawing.Color.Red;
                        txtPassword.Text = txtConfirmPassword.Text = txtOTP.Text = string.Empty;
                        lnkResendOTP.Visible = true;
                        lnkVerifyOTP.Visible = true;
                        userserviceClient.Close();
                        custClient.Close();
                    }
                }
                else
                {
                    userserviceClient.Close();
                    custClient.Close();
                    Response.Redirect("~/SignUp.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = "OTP verification fail. Please try again later.";
                lblerror.ForeColor = System.Drawing.Color.Red;
                txtPassword.Text = txtConfirmPassword.Text = txtOTP.Text = string.Empty;
                Session["OTP"] = null;
                lnkVerifyOTP.Visible = false;
                lnkResendOTP.Visible = true;
                userserviceClient.Close();
                custClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private string SendSMSToCustomer(UserDto user)
        {
            string strres = "";
            CommonServiceClient commonClient = new CommonServiceClient();
            try
            {
                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.CustomeRegistrationTemplate);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##uname##", user.Mobile);
                    msg = msg.Replace("##password##", user.Password);
                    strres = Common.SendSMS(user.Mobile, msg);
                    commonClient.Close();
                }
            }
            catch(Exception ex)
            {
                strres = "";
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return strres;
        }

        private int SendMailToCustomer(UserDto user)
        {
            int res = 0;
            try
            {
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "CustomerRegistration.html");
                emailBody = emailBody.Replace("{NAME}", user.Name);
                emailBody = emailBody.Replace("{MOBILE}", user.Mobile);
                if (!string.IsNullOrEmpty(user.Email))
                    emailBody = emailBody.Replace("{EMAIL}", user.Email);
                else
                    emailBody = emailBody.Replace("{EMAIL}", "");

                if (string.IsNullOrEmpty(user.Email))
                    user.Email = "contact@juststay.in";

                 emailBody = emailBody.Replace("{PWD}", user.Password);

                res = Common.SendMailithBcc("contact@juststay.in", new string[] { user.Email }, "Registration in Just Stay", "", emailBody);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return res;
        }

        private void SendMailtoAdmin(string name, string mobile)
        {
            try
            {
                string Content = string.Empty;
                Content = "To Just Stay, <br /><br />New Customer is registerd in Just Stay. <br />Name: {name} <br /> Mobile: {mobile} <br />";
                Content = Content.Replace("{name}", name);
                Content = Content.Replace("{mobile}", mobile);
                string[] toemail = new string[1];
                toemail[0] = "contact@juststay.in";
                int flag = Common.SendMailithBcc("contact@juststay.in", toemail, "New Customer Registration", "", Content);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        protected void lnkVerifyOTP_Click(object sender, EventArgs e)
        {
            VerifyOTP(Convert.ToString(txtOTP.Text.Trim()), Convert.ToString(txtPassword.Text.Trim()));
        }

        protected void lnkResendOTP_Click(object sender, EventArgs e)
        {
            try
            {
                string otpres = SendOTP(Convert.ToString(Session["name"]), Convert.ToString(Session["mobile"]));
                if(!string.IsNullOrEmpty(otpres))
                {
                    lblerror.Text = "OTP(One Time Password) sent on your mobile number.";
                    lblerror.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblerror.Text = "OTP not send to you. Please try again later.";
                    lblerror.ForeColor = System.Drawing.Color.Red;
                }
                txtOTP.Text = txtPassword.Text = txtConfirmPassword.Text = "";
                lnkResendOTP.Visible = true;
                lnkVerifyOTP.Visible = true;
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}