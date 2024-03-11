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

namespace JustStayAdmin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        #region  "Event Handlers "

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                lblusername.Text = Common.UserName;
            }
            if (!IsPostBack)
                SetSMSCount();
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session["User"] = null;
            Response.Redirect("~/Login.aspx");
        }       

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] != null)
                {
                    UserDto userinfo = new UserDto();
                    UserServiceClient userclient = new UserServiceClient();
                    userinfo = userclient.GetUserbyId(Common.UserId);

                    if (string.Equals(txtcurrentpass.Text.Trim().ToString(), userinfo.Password.ToString()))
                    {
                        if (string.Equals(txtpassnew.Text.Trim().ToString(), txtpassconfirm.Text.Trim().ToString()))
                        {
                            userinfo.Password =txtpassnew.Text.Trim().ToString();
                            userinfo.UserId = Common.UserId;
                            int uid = userclient.UpdateUserPwd(userinfo);
                            if (uid > 0)
                            {
                                lblchange.Text = "Password change successfully!";
                                lblchange.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowChangePwdPopup();", true);
                            }
                        }
                        else
                        {
                            lblchange.Text = "New password & Conform password not match!";
                            lblchange.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowChangePwdPopup();", true);
                        }
                    }
                    else
                    {
                        lblchange.Text = "Current password not match! Please enter valid password..";
                        lblchange.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowChangePwdPopup();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                lblchange.Text = "Password not changed!";
                lblchange.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowChangePwdPopup();", true);
            }
        }

        #endregion

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

            catch (Exception ex) { }
        }

        #endregion
    }
}