using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.UserServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class adminprofile : BL.BasePage
    {
        UserServiceClient userClient;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if(!IsPostBack)
            {
                GetAdminProfile();
            }
        }
        private void GetAdminProfile()
        {
            userClient = new UserServiceClient();
            try
            {
                UserDto udto = userClient.GetUserbyId(Common.UserId);
                if (udto == null) return;
                txtadminaddress.Text = Convert.ToString(udto.Address);
                txtadminemail.Text = Convert.ToString(udto.Email);
                txtadminmobile.Text = Convert.ToString(udto.Mobile);
                txtadminname.Text = Convert.ToString(udto.Name);
                hduserId.Value = Convert.ToString(Common.UserId);
                userClient.Close();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally {
                userClient.Close();
            }
        }
        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            userClient = new UserServiceClient();
            try
            {
                UserDto udto = new UserDto();
                udto.Name = Convert.ToString(txtadminname.Text.Trim());
                udto.Address = Convert.ToString(txtadminaddress.Text.Trim());
                udto.Mobile = Convert.ToString(txtadminmobile.Text.Trim());
                udto.Email = Convert.ToString(txtadminemail.Text.Trim());
                udto.UserId = Convert.ToInt32(hduserId.Value);
                hduserId.Value = userClient.UpdateAdmin(udto).ToString();
                if (int.Parse(hduserId.Value) > 0)
                {
                    lbladminprofilemsg.Text = "Admin profile updated successfully.";
                    lbladminprofilemsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lbladminprofilemsg.Text = "Admin profile not updated successfully.";
                    lbladminprofilemsg.ForeColor = System.Drawing.Color.Red;
                }
                userClient.Close();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                userClient.Close();
            }
        }
    }
}