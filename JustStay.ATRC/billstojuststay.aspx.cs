using JustStay.ATRC.RCPaymentServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class billstojuststay : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            try
            {
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Text));
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = Convert.ToDateTime(Convert.ToString(txttodate.Text));

                bool? ispaid;
                if (drpispaid.SelectedValue == "True")
                    ispaid = true;
                else if (drpispaid.SelectedValue == "False")
                    ispaid = false;
                else
                    ispaid = Convert.ToBoolean(DBNull.Value);

                gvjsbilllist.DataSource = rcpayclient.GetAllJSBill(Common.ATRCId, fromdate, todate, ispaid);
                gvjsbilllist.DataBind();

                if (gvjsbilllist.Rows.Count > 0)
                {
                    gvjsbilllist.UseAccessibleHeader = true;
                    gvjsbilllist.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvjsbilllist.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btngo_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void gvjsbilllist_RowCommand(object sender, GridViewCommandEventArgs e)
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
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvjsbilllist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvjsbilllist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[9].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you really want to delete JS Bill?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}