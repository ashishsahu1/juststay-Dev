using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.UserServiceReference;
using JustStay.Services.DTO;
using JustStay.CommonHub;

namespace JustStayAdmin.Admin
{
    public partial class manageuser : BL.BasePage
    {
        UserServiceClient userclient;
        int userid = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                JustStayAdmin.Admin.BL.RC4 rc = new BL.RC4();
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    userid = Convert.ToInt32(rc.Decrypt(Request.QueryString["Id"]));
                }
                if (!IsPostBack)
                {
                    SetDetails();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnmanageuser_Click(object sender, EventArgs e)
        {
            userclient = new UserServiceClient();
            try
            {
                int id = userclient.UpdateUser(userid, txtname.Text.Trim(), txtmobile.Text.Trim(), txtemail.Text.Trim(), Convert.ToString(chkisactive.Checked));
                if (id > 0)
                {
                    userclient.Close();
                    Common.ShowAlertAndNavigate("User updated successfully.", "userlist.aspx");
                }
                else
                {
                    userclient.Close();
                    Common.ShowAlertAndNavigate("User not updated successfully.", "userlist.aspx");
                }
            }
            catch (Exception ex)
            {
               Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { userclient.Close(); }
        }
        private void SetDetails()
        {
            userclient = new UserServiceClient();
            try
            {
                UserDto user = userclient.GetUserbyId(userid);
                if (user == null) return;
                txtname.Text = user.Name;
                txtmobile.Text = user.Mobile;
                txtemail.Text = user.Email;
                chkisactive.Checked = Convert.ToBoolean(user.IsActive);
                userclient.Close();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { userclient.Close(); }
        }
    }
}