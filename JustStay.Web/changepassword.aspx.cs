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
    public partial class changepassword : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            UserServiceClient client = new UserServiceClient();
            try {
                int userId = Common.UserId;
                if (client.ChangeUserPassword(userId, txtnewpassword.Text.Trim(), txtconfirmPassword.Text))
                {
                    PasswordSMS();
                    Session["User"] = null;
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("SignIn.aspx?c=p",false);
                }
                else
                {
                    txtnewpassword.Text = ""; txtconfirmPassword.Text = "";
                    lblmsg.Text = "New Password and Confirm Passowrd must be same..!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
                client.Close();
            }
            catch(Exception ex)
            {
                client.Close();
                lblmsg.Text = "Password not change successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private string PasswordSMS()
        {
            string strres = "";
            CommonServiceClient commonClient = new CommonServiceClient();
            try
            {
                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.ForgetPassword);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##password##", txtconfirmPassword.Text.Trim());
                    strres = Common.SendSMS(Common.Mobile, msg);
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
    }
}