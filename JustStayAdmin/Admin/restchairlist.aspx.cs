using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.Services.DTO;

using JustStayAdmin.RCProfileServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class restchairlist : BL.BasePage
    {
        RestChairProfileServiceClient rcpsClient;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["rcpid"]))
                    {
                        hdnrcprofileid.Value = Convert.ToString(Request.QueryString["rcpid"]);
                        RestChairList();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void RestChairList()
        {
            try
            {
                rcpsClient = new RestChairProfileServiceClient();
                gvChairs.DataSource = rcpsClient.GetAllRestChairsByATRCProfile(Convert.ToInt32(hdnrcprofileid.Value));
                gvChairs.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { rcpsClient.Close(); }
        }
        protected void gvChairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rcpsClient = new RestChairProfileServiceClient();
            try
            {
                if (e.CommandName == "Delete")
                {
                    rcpsClient.DeleteRestChair(int.Parse(e.CommandArgument.ToString()));
                    RestChairList();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { rcpsClient.Close(); }
        }

        protected void gvChairs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvChairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("managerestchair.aspx?rcpId=" + hdnrcprofileid.Value,false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}