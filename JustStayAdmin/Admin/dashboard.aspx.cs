using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStayAdmin.DashboardServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class dashboard : BL.BasePage
    {
        public static string strtotalcustomer, strtotalatrc, strtotalbookings, strtotalonlinebookings,
            strtotalofflinebookings,strtodaybooking,strtotalbookingamt,strtotalonlinebookingamt,strtotalofflineamt,strtotalatrccommission,strtotaljscommission;
        protected override void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SetCount();
                BindTodaysBooking();
            }
        }
        private void SetCount()
        {
            DashboardServiceClient dashboardclient = new DashboardServiceClient();
            try
            {
                GetAdminDashboardDetails getcount = dashboardclient.GetAdminDashboardDetails();
                strtotalcustomer = Convert.ToString(getcount.TotalCustomer);
                strtotalatrc = Convert.ToString(getcount.TotalATRC);
                strtotalbookings = Convert.ToString(getcount.TotalBooking);
                strtotalonlinebookings = Convert.ToString(getcount.TotalOnlineBooking);
                strtotalofflinebookings = Convert.ToString(getcount.TotalOfflineBooking);
                strtodaybooking = Convert.ToString(getcount.TotalTodayBooking);
                strtotalbookingamt = Convert.ToString(getcount.TotalBookingAmt);
                strtotalonlinebookingamt = Convert.ToString(getcount.TotalOnlineBookingAmt);
                strtotalofflineamt = Convert.ToString(getcount.TotalPayATRCBookingAmt);
                strtotalatrccommission = Convert.ToString(getcount.TotalATRCCommission);
                strtotaljscommission = Convert.ToString(getcount.TotalJSCommission);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            dashboardclient.Close();
        }
        private void BindTodaysBooking()
        {
            DashboardServiceClient dashboardclient = new DashboardServiceClient();
            try
            {
                List<GetTodaysBooking> todaysbooking = dashboardclient.GetTodayBooking().ToList();
                if (todaysbooking == null) return;
                grdtodaysbooking.DataSource = todaysbooking;
                grdtodaysbooking.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            dashboardclient.Close();
        }
    }
}