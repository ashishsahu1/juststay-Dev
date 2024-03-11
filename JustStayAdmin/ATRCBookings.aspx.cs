using JustStayAdmin.ATRCBookingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ATRCBookings : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindATRCBookings();
            }
        }

        #endregion

        private void BindATRCBookings()
        {
            ATRCBookingServiceClient bookingClient = new ATRCBookingServiceClient();
            grdBookings.DataSource = bookingClient.GetATRCBookingsByCustomer(int.Parse(Request.QueryString["CId"]));
            grdBookings.DataBind();

            if (grdBookings.Rows.Count > 0)
            {
                grdBookings.UseAccessibleHeader = true;
                grdBookings.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdBookings.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }
    }
}