using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.RCRefundServiceReference;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.RCBServiceReference;
using Razorpay.Api;
using JustStay.Services.DTO;

namespace JustStayAdmin.Admin
{
    public partial class rccancelbooking : BL.BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MainView.ActiveViewIndex = 0;
                BindApprovedList();
                BindCancelBooking();
            }
        }
        private void BindApprovedList()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            drpatrc.DataBind();
            drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
        }
        private void BindCancelBooking()
        {
            try
            {
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(txtfromdate.Value);
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = Convert.ToDateTime(txttodate.Value);
                List<GetAllCancelledBooking> blist = new RCRefundServiceClient().GetAllCancelledBooking(Convert.ToInt32(drpatrc.SelectedValue), fromdate, todate, "Online").Where(list => list.IsCancel == true).ToList();
                gvonlinecancelled.DataSource = blist;
                gvonlinecancelled.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void BindRefundedBooking()
        {
            try
            {
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(txtfromdate.Value);
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = Convert.ToDateTime(txttodate.Value);
                List<GetAllRefunds> rlist = new RCRefundServiceClient().GetAllRefunds(Convert.ToInt32(drpatrc.SelectedValue), fromdate, todate, "Online").ToList();
                gvrefund.DataSource = rlist;
                gvrefund.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            MainView.ActiveViewIndex = 0;
            BindCancelBooking();
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            MainView.ActiveViewIndex = 1;
            BindRefundedBooking();
        }

        protected void btnrcbSearch_Click(object sender, EventArgs e)
        {
            if(MainView.ActiveViewIndex == 0)
            {
                BindCancelBooking();
            }
            else if(MainView.ActiveViewIndex == 1)
            {
                BindRefundedBooking();
            }
        }

        protected void lnkrefund_Click(object sender, EventArgs e)
        {
            RCRefundServiceClient refundclient = new RCRefundServiceClient();
            RestChairBookingServiceClient recbclient = new RestChairBookingServiceClient();
            LinkButton btn = (LinkButton)(sender);
            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
            string rcbid = Convert.ToString(commandArgs[0]);
            string rcpid = Convert.ToString(commandArgs[1]);
            string razorpayid = Convert.ToString(commandArgs[3]);
            Decimal refunsamt = Convert.ToDecimal(commandArgs[4]);
            if (btn.CommandName == "refund")
            {
                RazorpayClient client = new RazorpayClient(Helper.RazorKey, Helper.RazorSecret);
                Refund refund = new Refund();
                try
                {
                    if (!string.IsNullOrEmpty(razorpayid))
                    {
                        Payment payment = client.Payment.Fetch(razorpayid);
                        //Partial Refund
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        int amount = Convert.ToInt32(refunsamt * 100);
                        data.Add("amount", amount);
                        refund = payment.Refund(data);

                        RefundDto rfdto = new RefundDto();
                        rfdto.Note = "Fefund on " + DateTime.Now;
                        rfdto.razor_refund_id = Convert.ToString(refund["id"]);
                        rfdto.RCPaymentId = Convert.ToInt32(rcpid);
                        rfdto.RefundAmount = refunsamt;
                        rfdto.RefundDate = DateTime.Now;
                        rfdto.RestChairBookingId = Convert.ToInt32(rcbid);
                        rfdto.status = Convert.ToString(refund["status"]);
                        hdnrefundis.Value = Convert.ToString(refundclient.InsertRCRefund(rfdto));
                        if (hdnrefundis.Value != "0")
                        {
                            recbclient.UpdateIsCancelBooking(int.Parse(rcbid), false, true);
                            btn.Enabled = false;
                            btn.Text = "Processed";
                            btn.Style.Add("color", "Green");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                  "err_msg",
                                  "alert('Booking can not be refund because,booking status is failed!');",
                                  true);
                    }
                }
                catch(Exception ex)
                {
                    Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
                //MainView.ActiveViewIndex = 0;
                //BindCancelBooking();
            }
        }

        protected void gvonlinecancelled_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkrefund= (LinkButton)e.Row.FindControl("lnkrefund");
                string[] commandArgs = lnkrefund.CommandArgument.ToString().Split(new char[] { ',' });
                string isrend = commandArgs[2];
                if(isrend == "True")
                {
                    lnkrefund.Text = "Processed";
                    lnkrefund.Enabled = false;
                    lnkrefund.Style.Add("color", "Green");
                }
                else
                {
                    lnkrefund.Text = "Make Refund";
                    lnkrefund.Enabled = true;
                    lnkrefund.Style.Add("color", "Blue");
                }
            }
        }

        protected void gvrefund_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvrefund.PageIndex = e.NewPageIndex;
            BindRefundedBooking();
        }

        protected void gvonlinecancelled_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvonlinecancelled.PageIndex = e.NewPageIndex;
            BindCancelBooking();
        }
    }
}