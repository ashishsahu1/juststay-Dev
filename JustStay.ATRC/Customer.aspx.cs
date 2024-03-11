using JustStay.ATRC.RCBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class Customer : BasePage
    {
        #region " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindCustomers();
            }
        }

        #endregion

        #region " Private Methods "

        private void BindCustomers()
        {
            RestChairBookingServiceClient RCBClient = new RestChairBookingServiceClient();
            DateTime? fromdate = null, todate = null;

            if (!string.IsNullOrEmpty(txtfromdate.Text))
                fromdate = Convert.ToDateTime(txtfromdate.Text);
            if (!string.IsNullOrEmpty(txttodate.Text))
                todate = Convert.ToDateTime(txttodate.Text);

            grdBookings.DataSource = RCBClient.GetAllCustomerByATRC(Common.ATRCId, fromdate, todate);
            grdBookings.DataBind();

            if (grdBookings.Rows.Count > 0)
            {
                grdBookings.UseAccessibleHeader = true;
                grdBookings.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdBookings.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        public string GetBookingsLink(int custId)
        {
          return "<a style='font-weight:bold' href=\"RestChairCustomerBookings.aspx?CId=" + custId + "\">Bookings</a>";
        }
        #endregion

        protected void btngo_Click(object sender, EventArgs e)
        {
            BindCustomers();
        }
    }
}