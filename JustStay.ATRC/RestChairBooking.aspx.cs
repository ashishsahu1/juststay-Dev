using JustStay.ATRC.RCBServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class RestChairBooking : BasePage
    {
        #region " Event Handlers "
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
           
            if (!IsPostBack)
            {
                BindRestChairBookings();
            }
        }

        #endregion

        #region " Private Methods "

        private void BindRestChairBookings()
        {
            try
            {
                RestChairBookingServiceClient rcbooking = new RestChairBookingServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate = Convert.ToDateTime(txtfromdate.Text);
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = Convert.ToDateTime(txttodate.Text);
                grdrestchairbookings.DataSource = rcbooking.GetRestChairBookingByATRC(Common.ATRCId, fromdate, todate,drppaymentmode.SelectedValue);
                grdrestchairbookings.DataBind();

                if (grdrestchairbookings.Rows.Count > 0)
                {
                    grdrestchairbookings.UseAccessibleHeader = true;
                    grdrestchairbookings.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdrestchairbookings.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        protected void btngo_Click(object sender, EventArgs e)
        {
            BindRestChairBookings();
        }

        protected void grdrestchairbookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Pay")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                int RcBid = Convert.ToInt32(commandArgs[0]);
                int RcPid = Convert.ToInt32(commandArgs[1]);
                RestChairBookingServiceClient rcbooking = new RestChairBookingServiceClient();
                rcbooking.UpdatePayStatus(RcPid, RcBid);
                BindRestChairBookings();
            }
        }

        protected void grdrestchairbookings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnpaystatus = (HiddenField)e.Row.FindControl("hdnpaymentdtatus");
                    HiddenField hdnatrcpaystatus = (HiddenField)e.Row.FindControl("hdnpaystatus");
                    if (hdnpaystatus.Value == "Pay At ATRC")
                    {
                        LinkButton lnkmakepayment = (LinkButton)e.Row.FindControl("lnkmakepay");
                        Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                        lnkmakepayment.Visible = true;
                        //lblstatus.Visible = true;
                        if(!string.IsNullOrEmpty(hdnatrcpaystatus.Value))
                        {
                            lnkmakepayment.Visible = false;
                            lblstatus.Visible = true;
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