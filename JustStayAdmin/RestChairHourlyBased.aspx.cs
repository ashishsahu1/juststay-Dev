using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CancellationPolicySerRef;
using JustStayAdmin.MastersServiceReference;
using JustStayAdmin.RCProfileServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class RestChairHourlyBased : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindApprovedList();
                BindPolicy();
                //BindRestChirType();
                //BindRCamenities();
                RestChairList();
            }
        }

        protected void btnRestChairHourly_Click(object sender, EventArgs e)
        {
            RestChairProfileServiceClient rcs = new RestChairProfileServiceClient();
            RestChairProfileDto rcp = new RestChairProfileDto();

            try
            {
                rcp.ATRCId = int.Parse(grdApprovedATRC.SelectedItem.Value);
                rcp.ManagerName = txtATRCManagerName.Text;
                rcp.ManagerMobile = txtManagerNumber.Text;
                rcp.ATRCTelephone = txtTelNumber.Text;
                rcp.StartDate = Convert.ToDateTime(txtStartDate.Text);
                rcp.EndDate = Convert.ToDateTime(txtEndDate.Text);
                rcp.CheckInTime = DateTime.Parse(txtRestChairchkIn.Text).TimeOfDay;
                rcp.CheckOutTime = DateTime.Parse(txtRestChairchkOut.Text).TimeOfDay;
                rcp.Status = byte.Parse(hdAcStatus.Value);
                rcp.ATRCPolicy = txtAtrcPolicy.Text;

                if(chkPolicy.Items.Count > 0)
                rcp.CancellationPolicies = string.Join(",", chkPolicy.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));

                int profileId = rcs.InsertRestchairProfile(rcp);
                if (profileId != 0)
                {
                    HiddenField1.Value = "true";
                    Clear();
                }
                else
                {
                    HiddenField1.Value = "false";
                    Clear();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindPolicy()
        {
            CancellationPolicyServiceClient cp = new CancellationPolicyServiceClient();
            chkPolicy.DataSource = cp.GetAllCancellationPolicies();
            chkPolicy.DataTextField = "PolicyName";
            chkPolicy.DataValueField = "PolicyId";
            chkPolicy.DataBind();
        }

        private void BindApprovedList()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            grdApprovedATRC.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            grdApprovedATRC.DataTextField = "ATRCName";
            grdApprovedATRC.DataValueField = "ATRCId";
            grdApprovedATRC.DataBind();
            grdApprovedATRC.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });

            //ddlatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            //ddlatrc.DataTextField = "ATRCName";
            //ddlatrc.DataValueField = "ATRCId";
            //ddlatrc.DataBind();
            //ddlatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
        }

        //private void BindRestChirType()
        //{
        //    MastersServiceClient cp = new MastersServiceClient();
        //    chkRestChairType.DataSource = cp.GetAllRCTypes();
        //    chkRestChairType.DataTextField = "Name";
        //    chkRestChairType.DataValueField = "TypeId";
        //    chkRestChairType.DataBind();
        //}

        //private void BindRCamenities()
        //{
        //    MastersServiceClient client = new MastersServiceClient();
        //    chkchairaminities.DataSource = client.GetAllAmenities(3);
        //    chkchairaminities.DataTextField = "Name";
        //    chkchairaminities.DataValueField = "AmenityId";
        //    chkchairaminities.DataBind();
        //}

        private void Clear()
        {
            txtATRCManagerName.Text = txtManagerNumber.Text = txtStartDate.Text = txtEndDate.Text = txtRestChairchkIn.Text = txtRestChairchkOut.Text = txtAtrcPolicy.Text = "";
        }

        protected void gvChairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                RestChairProfileServiceClient rcRepo = new RestChairProfileServiceClient();
                rcRepo.DeleteRestChair(int.Parse(e.CommandArgument.ToString()));
                RestChairList();
            }
        }

        protected void gvChairs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvChairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void RestChairList()
        {
            RestChairProfileServiceClient userRepo = new RestChairProfileServiceClient();
            gvChairs.DataSource = userRepo.GetAllRestChair();
            gvChairs.DataBind();

            if (gvChairs.Rows.Count > 0)
            {
                gvChairs.UseAccessibleHeader = true;
                gvChairs.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvChairs.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}