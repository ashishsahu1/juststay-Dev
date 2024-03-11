using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.RCBServiceReference;
using JustStayAdmin.ATRCServiceReference;
using JustStay.CommonHub;

namespace JustStayAdmin
{
    public partial class RestChairBooking : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindApprovedList();
                BindRestChairBookings();
            }
        }
        private void BindApprovedList()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            drpatrc.DataBind();
            drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
        }
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
                grdrestchairbookings.DataSource = rcbooking.GetRestChairBooking(int.Parse(drpatrc.SelectedValue), fromdate, todate,0,"");
                grdrestchairbookings.DataBind();

                if (grdrestchairbookings.Rows.Count > 0)
                {
                    grdrestchairbookings.UseAccessibleHeader = true;
                    grdrestchairbookings.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdrestchairbookings.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            BindRestChairBookings();
        }
    }
}