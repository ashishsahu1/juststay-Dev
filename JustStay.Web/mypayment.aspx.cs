using JustStay.CommonHub;
using JustStay.Web.BusinessLogic;
using JustStay.Web.RCBookingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class mypayment : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindAllPayment();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindAllPayment()
        {
            RestChairBookingServiceClient rcbsclient = new RestChairBookingServiceClient();
            try
            {
                grdallpayment.DataSource = rcbsclient.GetAllPaymentByCustomerId(Common.CustomerId);
                grdallpayment.DataBind();
                rcbsclient.Close();
            }
            catch(Exception ex)
            {
                rcbsclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnkreceipt_Click(object sender, EventArgs e)
        {

        }

        protected void grdallpayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "receipt")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string restchairbookingid = Convert.ToString(commandArgs[0]);
                    string paymentmode = Convert.ToString(commandArgs[1]);
                    if (paymentmode == "Online")
                    {
                        Response.Redirect("~/Receipt.aspx?rcbid=" + restchairbookingid);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                  "err_msg",
                                  "alert('Receipt is not generated for Pay-At-ATRC payment mode!');",
                                  true);
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdallpayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdallpayment.PageIndex = e.NewPageIndex;
            BindAllPayment();
        }
    }
}