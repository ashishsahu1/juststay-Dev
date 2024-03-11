using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class Customer : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {                
                BindCustomers();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindCustomers();
        }

        public string GetBookingsLink(int custId,int bookingCount)
        {
            if (bookingCount > 0)
            {
                return "<a style='font-weight:bold' href=\"ATRCBookings.aspx?CId=" + custId + "\">Bookings (" + bookingCount + ")</a>";
            }
            else
                return "No Bookings";
        }

        #endregion

        #region  " Private Methods "        
      
        private void BindCustomers()
        {
            CustomerServiceClient custClient = new CustomerServiceClient();
            grdCustomers.DataSource = custClient.GetAllCustomersDetails("");
            grdCustomers.DataBind();

            if (grdCustomers.Rows.Count > 0)
            {
                grdCustomers.UseAccessibleHeader = true;
                grdCustomers.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdCustomers.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion
    }
}