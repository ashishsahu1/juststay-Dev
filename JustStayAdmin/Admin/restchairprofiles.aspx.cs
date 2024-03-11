using JustStay.CommonHub;
using JustStayAdmin.RCProfileServiceReference;
using JustStayAdmin.CommonServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class restchairprofiles : BL.BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindRestChairProfile();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindRestChairProfile()
        {
            RestChairProfileServiceClient repclient = new RestChairProfileServiceClient();
            grdrcprofile.DataSource = repclient.GetAllRestChairProfile();
            grdrcprofile.DataBind();
        }

        protected void grdrcprofile_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int RestChairProfileId = Convert.ToInt32(grdrcprofile.DataKeys[e.RowIndex].Value);
                DeleteProfile(RestChairProfileId);
                BindRestChairProfile();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdrcprofile_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private void DeleteProfile(int profileid)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            try
            {
                commonClient.Delete(profileid, "RCProfile");
                lblmsg.Text = "Rest Chair Profile Deleted Successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblmsg.Text = "RestChair Profile Deletion Failed.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            commonClient.Close();
        }
    }
}