using JustStay.ATRC.RCBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class RestChairCustomerBookings : BasePage
    {
        #region " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindBookings();
            }
        }

        #endregion

        #region " Private Methods "

        private void BindBookings()
        {
            RestChairBookingServiceClient RCBClient = new RestChairBookingServiceClient();
            DateTime? fromdate = null, todate = null;

            if (!string.IsNullOrEmpty(txtfromdate.Text))
                fromdate = Convert.ToDateTime(txtfromdate.Text);
            if (!string.IsNullOrEmpty(txttodate.Text))
                todate = Convert.ToDateTime(txttodate.Text);

            grdCustomerBookings.DataSource = RCBClient.GetCustomerBookingsByATRC(Common.ATRCId,Convert.ToInt32(Request.QueryString["CId"]), fromdate, todate);
            grdCustomerBookings.DataBind();

            if (grdCustomerBookings.Rows.Count > 0)
            {
                grdCustomerBookings.UseAccessibleHeader = true;
                grdCustomerBookings.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdCustomerBookings.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
     
        #endregion

        protected void btngo_Click(object sender, EventArgs e)
        {
            BindBookings();
        }
    }
}