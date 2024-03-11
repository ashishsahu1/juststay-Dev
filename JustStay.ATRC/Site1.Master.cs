using JustStay.ATRC.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        #region  "Event Handlers"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                lblusername.Text = Common.UserName;
            }
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
                            userinfo.Password = txtpassnew.Text.Trim().ToString();
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

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session["User"] = null;
            Response.Redirect("~/Login.aspx");
        } 

        #endregion
    }
}