using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CancellationPolicySerRef;
using JustStayAdmin.RCProfileServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class managercprofile : BL.BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindApprovedList();
                    BindPolicy();
                    if(!string.IsNullOrEmpty(Request.QueryString["rcpid"]))
                    {
                        hdnrcprofileid.Value = Convert.ToString(Request.QueryString["rcpid"]);
                        BindRestChairProfile();
                       // RestChairList();
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnsavegeneral_Click(object sender, EventArgs e)
        {
            RestChairProfileServiceClient rcs = new RestChairProfileServiceClient();
            RestChairProfileDto rcp = new RestChairProfileDto();

            try
            {
                rcp.ATRCId = int.Parse(drpatrc.SelectedItem.Value);
                rcp.ManagerName = Convert.ToString(txtATRCManagerName.Text.Trim());
                rcp.ManagerMobile = Convert.ToString(txtManagerNumber.Text.Trim());
                rcp.ATRCTelephone = Convert.ToString(txtTelNumber.Text.Trim());
                rcp.StartDate = DateTime.ParseExact(txtrcstartdate.Value.Trim(),"MM/dd/yyyy",CultureInfo.InvariantCulture);
                rcp.EndDate = DateTime.ParseExact(txtrcenddate.Value.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                rcp.CheckInTime = DateTime.Parse(txtrcstarttime.Text.Trim()).TimeOfDay;
                rcp.CheckOutTime = DateTime.Parse(txtrcendtime.Text.Trim()).TimeOfDay;
                rcp.Status = byte.Parse(hdAcStatus.Value);
                rcp.ATRCPolicy = txtAtrcPolicy.Text;
                if (chkPolicy.Items.Count > 0)
                    rcp.CancellationPolicies = string.Join(",", chkPolicy.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));

                if (hdnrcprofileid.Value == "0")
                {
                    hdnrcprofileid.Value = rcs.InsertRestchairProfile(rcp).ToString();
                }
                else
                {
                    rcp.RestChairProfileId = Convert.ToInt32(hdnrcprofileid.Value);
                    rcs.UpdateRestchairProfile(rcp);
                }
                lblrcpmsg.Text = "Rest chair profile saved successfully.";
                lblrcpmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblrcpmsg.Text = "Rest chair profile not saved successfully.";
                lblrcpmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void gvChairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                RestChairProfileServiceClient rcRepo = new RestChairProfileServiceClient();
                rcRepo.DeleteRestChair(int.Parse(e.CommandArgument.ToString()));
               
            }
        }

        protected void gvChairs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvChairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        #region " Private method"
        private void BindApprovedList()
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                drpatrc.DataBind();
                drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindPolicy()
        {
            try
            {
                CancellationPolicyServiceClient cp = new CancellationPolicyServiceClient();
                chkPolicy.DataSource = cp.GetAllCancellationPolicies();
                chkPolicy.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindRestChairProfile()
        {
            RestChairProfileServiceClient repclient = new RestChairProfileServiceClient();
            RestChairProfileDto rcpdto = new RestChairProfileDto();
            rcpdto = repclient.GetRestChairProfile(int.Parse(hdnrcprofileid.Value));
            if (rcpdto == null) return;
            drpatrc.SelectedValue = Convert.ToString(rcpdto.ATRCId);
            txtATRCManagerName.Text = Convert.ToString(rcpdto.ManagerName.Trim());
            txtManagerNumber.Text = Convert.ToString(rcpdto.ManagerMobile.Trim());
            txtTelNumber.Text = Convert.ToString(rcpdto.ATRCTelephone.Trim());
            txtrcstartdate.Value = Convert.ToString(rcpdto.StartDate.ToShortDateString());
            txtrcenddate.Value = Convert.ToString(rcpdto.EndDate.ToShortDateString().Trim());
            txtrcstarttime.Text = Convert.ToString(rcpdto.CheckInTime);
            txtrcendtime.Text = Convert.ToString(rcpdto.CheckOutTime);
            txtAtrcPolicy.Text = Convert.ToString(rcpdto.ATRCPolicy.Trim());
            chkAccountStatus.Checked = Convert.ToBoolean(rcpdto.Status);
            Common.BindCheckBoxList(rcpdto.CancellationPolicies, chkPolicy);
        }
      
        #endregion  " Private method"
    }
}