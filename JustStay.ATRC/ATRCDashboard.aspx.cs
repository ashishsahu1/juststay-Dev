using JustStay.ATRC.DashboardServiceReference;
using JustStay.ATRC.UserServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class ATRCDashboard : BasePage
    {
        public string strtotalbooking, strtotalonlinebooking,
            strtotalpayatrcbooking, strtotaltodaysbooking, strtotalbookingamount,
            strtotalonlinebookingamount, strtotalpayatatrcamount, strtotalatrccommission = "";
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                UserDto udto = (UserDto)Session["User"];
                if (udto.ATRCStatus == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showstart();", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        SetCount();
                        BindTodaysBooking();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void SetCount()
        {
            DashboardServiceClient dashboardclient = new DashboardServiceClient();
            try
            {
                GetATRCDashboardDetails getcount = dashboardclient.GetATRCDashboardDetails(Common.ATRCId);
               
                strtotalbooking                 = Convert.ToString(getcount.TotalBooking);
                strtotalonlinebooking           = Convert.ToString(getcount.TotalOnlineBooking);
                strtotalpayatrcbooking          = Convert.ToString(getcount.TotalOfflineBooking);
                strtotaltodaysbooking           = Convert.ToString(getcount.TotalTodayBooking);
                strtotalonlinebookingamount     = Convert.ToString(getcount.TotalOnlineBookingAmt);
                strtotalbookingamount           = Convert.ToString(getcount.TotalBookingAmt);
                strtotalpayatatrcamount         = Convert.ToString(getcount.TotalPayATRCBookingAmt);
                strtotalatrccommission          = Convert.ToString(getcount.TotalATRCCommission);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                dashboardclient.Close();
            }
        }
        private void BindTodaysBooking()
        {
            DashboardServiceClient dashboardclient = new DashboardServiceClient();
            try
            {
                List<GetATRCTodaysBooking> todaysbooking = dashboardclient.GetATRCTodayBooking(Common.ATRCId).ToList();
                if (todaysbooking == null) return;
                grdtodaysbooking.DataSource = todaysbooking;
                grdtodaysbooking.DataBind();
            }
            catch (Exception ex)
            {
                dashboardclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                dashboardclient.Close();
            }
        }
    }
}