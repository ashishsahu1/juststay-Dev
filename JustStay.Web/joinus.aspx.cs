using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStay.Web.ATRCServiceReference;
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
    public partial class joinus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindSD();
                    if (Session["r"] != null)
                    {
                        if (Convert.ToInt32(hdnid.Value) == 1)
                        {
                            lblmsg.Text = "Your joining request as a ATR Center is send successfully. Kindly check email for login details. We will contact you soon. Thank You.";
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                        }
                        else if(Convert.ToInt32(hdnid.Value) == 0)
                        {
                            lblmsg.Text = "Thank you for your interest. Please try again...";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                            lblmsg.Text = string.Empty;

                        Session["r"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindSD()
        {
            ATRCServiceClient atrcClient = new ATRCServiceClient();
            try
            {
                rptSD.DataSource = atrcClient.GetATRCSDImages().Take(3).ToList();
                rptSD.DataBind();
                atrcClient.Close();
            }
            catch(Exception ex)
            {
                atrcClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnsand_Click(object sender, EventArgs e)
        {
            UserServiceClient userserviceClient = new UserServiceClient();
            try
            {
                if (Page.IsValid)
                {
                    Random num = new Random();
                    UserDto user = new UserDto();
                    user.Name = Convert.ToString(txtname.Text.Trim());
                    user.Address = Convert.ToString(txtaddress.Text.Trim());
                    user.Mobile = Convert.ToString(txtmobile.Text.Trim());
                    user.Email = Convert.ToString(txtemail.Text.Trim());
                    user.Username = Convert.ToString(txtmobile.Text.Trim());
                    user.Password = Convert.ToString(num.Next(1000, 1000000));
                    user.IsActive = true;
                    user.IsPaid = false;
                    user.UserTypeId = 2;
                    user.InsertedOn = DateTime.Now;
                    user.RoleId = 0;
                    user.IsAdmin = false;
                    int userid = userserviceClient.InsertUser(user);
                    SendMailtoAdmin();
                   // SendConfirmationSMS(user);
                    hdnid.Value = Convert.ToString(SendMailtoATRC(user));
                    Session["r"] = "yes";
                    txtname.Text = txtaddress.Text = txtmobile.Text = txtemail.Text = string.Empty;
                   
                    userserviceClient.Close();
                    if (Convert.ToInt32(hdnid.Value) == 1)
                    {
                        lblmsg.Text = "Your joining request as a ATR Center is send successfully. Kindly check email for login details. We will contact you soon. Thank You.";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (Convert.ToInt32(hdnid.Value) == 0)
                    {
                        lblmsg.Text = "Thank you for your interest. Please try again...";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                    // Response.Redirect("joinus.aspx#joinus", false);
                }
            }
            catch (Exception ex)
            {
                userserviceClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void SendMailtoAdmin()
        {
            try
            {
                string Content = string.Empty;
                Content = "To Just Stay, <br /><br />I am interested to join as a Just Stay ATR Center <br />Name: {name} <br /> Address: {address} <br /> Mobile: {mobile} <br /> Email: {email} <br />";
                Content = Content.Replace("{name}", Convert.ToString(txtname.Text.Trim()));
                Content = Content.Replace("{address}", Convert.ToString(txtaddress.Text.Trim()));
                Content = Content.Replace("{mobile}", Convert.ToString(txtmobile.Text.Trim()));
                Content = Content.Replace("{email}", Convert.ToString(txtemail.Text.Trim()));
                string[] toemail = new string[1];
                toemail[0] = "contact@juststay.in";
                int flag = Common.SendMailithBcc(txtemail.Text.Trim(), toemail, "Join Us Request For ATRC", "", Content);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private int SendMailtoATRC(UserDto userdto)
        {
            int flag = 0;
            try
            {
                string Content = string.Empty;
                Content = "Dear {user}, <br /><br />Thank you for your interest to join as a Just Stay ATR Center. <br /> Your JUST STAY ATRC account created successfully. <br /> Login details are as follow: <br /> Link: {link} <br /> UserName: {username} <br /> Password: {password}";
                Content = Content.Replace("{user}", Convert.ToString(userdto.Name));
                Content = Content.Replace("{link}", "https://atrc.juststay.in");
                Content = Content.Replace("{username}", Convert.ToString(userdto.Username));
                Content = Content.Replace("{password}", Convert.ToString(userdto.Password));
                string[] toemail = new string[1];
                toemail[0] = Convert.ToString(userdto.Email);
                flag = Common.SendMailithBcc("contact@juststay.in", toemail, "Just Stay ATR Center Login Details", "", Content);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return flag;
        }
        private void SendConfirmationSMS(UserDto userdto)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            try
            {
                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.ATRCConfirmationTemlate);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##name##", userdto.Name);
                    msg = msg.Replace("##uname##", userdto.Username);
                    msg = msg.Replace("##pass##", userdto.Password);
                    Common.SendSMS(userdto.Mobile, msg);
                    commonClient.Close();
                }
            }
            catch(Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}