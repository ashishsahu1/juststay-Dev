using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.RCPaymentServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class atrcbilllist : BL.BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindApprovedATRCList();
                BindGrid();
            }
        }
        private void BindApprovedATRCList()
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                drpatrc.DataBind();
                drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void BindGrid()
        {
            try
            {
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Value));
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = Convert.ToDateTime(Convert.ToString(txttodate.Value));

                bool? ispaid;
                if (drpispaid.SelectedValue == "True")
                    ispaid = true;
                else if (drpispaid.SelectedValue == "False")
                    ispaid = false;
                else
                    ispaid = Convert.ToBoolean(DBNull.Value);

                gvatrcbilllist.DataSource = rcpayclient.GetAllATRCBill(Convert.ToInt32(drpatrc.SelectedValue), fromdate, todate, ispaid);
                gvatrcbilllist.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvatrcbilllist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    RCPaymentServiceClient rcpayrepo = new RCPaymentServiceClient();
                    rcpayrepo.DeleteATRCBill(int.Parse(e.CommandArgument.ToString()));
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvatrcbilllist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvatrcbilllist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[9].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you really want to delete ATRC Bill?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}