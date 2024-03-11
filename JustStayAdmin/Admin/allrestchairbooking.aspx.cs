using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.RCBServiceReference;
using JustStayAdmin.ATRCServiceReference;
using JustStay.CommonHub;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace JustStayAdmin.Admin
{
    public partial class allrestchairbooking : BL.BasePage
    {
        ATRCServiceClient ATRCServiceclient;
        RestChairBookingServiceClient rcbooking;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);

                if (!IsPostBack)
                {
                    BindApprovedList();
                    BindRestChairBookings();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindApprovedList()
        {
            try
            {
                ATRCServiceclient = new ATRCServiceClient();
                drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                drpatrc.DataBind();
                drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
                ATRCServiceclient.Close();
            }
            catch(Exception ex)
            { 
                ATRCServiceclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { ATRCServiceclient.Close(); }
        }
        private void BindRestChairBookings()
        {
            rcbooking = new RestChairBookingServiceClient();
            try
            {
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(txtfromdate.Value);
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = Convert.ToDateTime(txttodate.Value);
                grdrestchairbookings.DataSource = rcbooking.GetRestChairBooking(int.Parse(drpatrc.SelectedValue), fromdate, todate, 0,Convert.ToString(txtrcsearch.Text.Trim()));
                grdrestchairbookings.DataBind();
                rcbooking.Close();
            }
            catch (Exception ex)
            {
                rcbooking.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { rcbooking.Close(); }
        }

        protected void btnrcbSearch_Click(object sender, EventArgs e)
        {
            BindRestChairBookings();
        }
    }
}