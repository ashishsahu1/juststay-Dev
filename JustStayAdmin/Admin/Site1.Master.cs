using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.CommonServiceReference;
using JustStayAdmin.UserServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                lblusername.Text = Common.UserName;
                lbladdress.Text = Common.Address;
            }
            if (!IsPostBack)
                SetSMSCount();
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session["User"] = null;
            Response.Redirect("~/Admin/login.aspx",false);
        }
        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            UserServiceClient userclient = new UserServiceClient();
            try
            {
                if (Session["User"] != null)
                {
                    UserDto userinfo = new UserDto();
                   
                    userinfo = userclient.GetUserbyId(Common.UserId);

                    if (string.Equals(txtcurrentpass.Text.Trim().ToString(), userinfo.Password.ToString()))
                    {
                        if (string.Equals(txtpassnew.Text.Trim().ToString(), txtpassconfirm.Text.Trim().ToString()))
                        {
                            userinfo.Password = txtpassnew.Text.Trim().ToString();
                            userinfo.UserId = Common.UserId;
                            hdnpassid.Value = userclient.UpdateUserPwd(userinfo).ToString();
                            if (int.Parse(hdnpassid.Value) > 0)
                            {
                                lblchange.Text = "Password change successfully! Please login again with new password.";
                                lblchange.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop1", "ShowChangePwdPopup();", true);
                            }
                        }
                        else
                        {
                            hdnpassid.Value = "1";
                            lblchange.Text = "New password & Conform password not match!";
                            lblchange.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop2", "ShowChangePwdPopup();", true);
                        }
                    }
                    else
                    {
                        hdnpassid.Value = "1";
                        lblchange.Text = "Current password not match! Please enter valid password..";
                        lblchange.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop3", "ShowChangePwdPopup();", true);
                    }
                    userclient.Close();
                }
                else
                {
                    userclient.Close();
                    Response.Redirect("~/Admin/login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblchange.Text = "Password not changed!";
                lblchange.ForeColor = System.Drawing.Color.Red;
                userclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowChangePwdPopup();", true);
            }
        }
        #region " Priavte MEthods "

        private void SetSMSCount()
        {
            try
            {
                CommonServiceClient commonClient = new CommonServiceClient();
                SettingDto setting = commonClient.GetSettings();
                string smsUrl = setting.SMSBalanceUrl;
                smsUrl = smsUrl.Replace("username", setting.SmsUsername);
                smsUrl = smsUrl.Replace("pwd", setting.SmsPassword);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(smsUrl);
                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                string strdata = reader.ReadToEnd();
                string[] strArr = null; char[] splitchar = { '|' }; strArr = strdata.Split(splitchar);
                if (strArr != null)
                    lblsmsbalance.Text = "SMS Balance: " + strArr[1].Split(':')[1];
                else
                    lblsmsbalance.Text = "SMS Balance: 0";
            }
            catch (Exception ex) {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
    }
}