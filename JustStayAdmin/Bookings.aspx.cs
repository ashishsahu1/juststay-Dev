using JustStay.CommonHub;
using JustStayAdmin.RCBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class Bookings : BasePage
    {
        #region  " Event Handlers "

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
            try
            {
                RestChairBookingServiceClient bookingClient = new RestChairBookingServiceClient();
                grdBookings.DataSource = bookingClient.GetCustomerBookingsByATRC(int.Parse(Request.QueryString["Id"]), 0, null, null);
                grdBookings.DataBind();

                if (grdBookings.Rows.Count > 0)
                {
                    grdBookings.UseAccessibleHeader = true;
                    grdBookings.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdBookings.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

    }
}