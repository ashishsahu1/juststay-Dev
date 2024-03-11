using JustStay.Web.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Web.RCBookingServiceReference;
using JustStay.CommonHub;

namespace JustStay.Web
{
    public partial class allbooking : BasePage
    {
        public static string stronlinebooking, strpayatrcbooking = "0";
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindAllBooking();
                    BindPayATRCBooking();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindAllBooking()
        {
            try
            {
                List<GetAllBookingByCustomerId> blist = new RestChairBookingServiceClient().GetAllBookingByCustomerId(Common.CustomerId,"", "Online").ToList();
                grdallbooking.DataSource = blist;
                grdallbooking.DataBind();
                stronlinebooking = blist.Count.ToString();
                new RestChairBookingServiceClient().Close();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindPayATRCBooking()
        {
            try
            {
                List<GetAllBookingByCustomerId> payatrclist = new RestChairBookingServiceClient().GetAllBookingByCustomerId(Common.CustomerId, "", "Pay At ATRC").ToList();
                grdpayatrc.DataSource = payatrclist;
                grdpayatrc.DataBind();
                strpayatrcbooking = payatrclist.Count.ToString();
                new RestChairBookingServiceClient().Close();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void lnkviewdetails_Click(object sender, EventArgs e)
        {
            try
            {
                JSEDS objjseds = new JSEDS();
                LinkButton btn = (LinkButton)(sender);
                if (btn.CommandName == "view")
                {
                    string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
                    string bid = commandArgs[0];
                    string aid = commandArgs[1];
                    Response.Redirect("~/view-booking.aspx?bid=" + objjseds.Encrypt(bid) + "&aid=" + objjseds.Encrypt(aid) + "&m=" + objjseds.Encrypt("Ab"),false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnkbookingcancel_Click(object sender, EventArgs e)
        {
            RestChairBookingServiceClient recbclient = new RestChairBookingServiceClient();
            LinkButton btn = (LinkButton)(sender);
            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
            string rcbid = commandArgs[0];
            if (btn.CommandName == "cancel")
            {
                recbclient.UpdateIsCancelBooking(int.Parse(rcbid), true, true);
                btn.Enabled = false;
                btn.Text = "Cancelled";
                btn.Style.Add("color", "Red");
            }
            if(btn.CommandName == "Delete")
            {
                recbclient.UpdateIsDeleted(int.Parse(rcbid), true);
                BindAllBooking();
            }
            recbclient.Close();
        }

        protected void grdallbooking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkcancel = (LinkButton)e.Row.FindControl("lnkbookingcancel");
                    string[] commandArgs = lnkcancel.CommandArgument.ToString().Split(new char[] { ',' });
                    string status = commandArgs[2];
                    DateTime bdate = Convert.ToDateTime(commandArgs[3]).Date;
                    string fromtime = commandArgs[4];
                    string totime = commandArgs[5];
                    DateTime currentdate = DateTime.Now.Date;
                    string paymode = commandArgs[6];
                    TimeSpan currenttime = DateTime.Now.TimeOfDay;
                    bool iscancel = false;
                    if (!string.IsNullOrEmpty(Convert.ToString(commandArgs[7])))
                        iscancel  = Convert.ToBoolean(commandArgs[7]);

                    if (currentdate <= bdate && paymode == "Online" && status == "True" && iscancel == false)
                    {
                        lnkcancel.Visible = true;
                    }
                    else if(iscancel == true)
                    {
                        lnkcancel.Enabled = false;
                        lnkcancel.Text = "Cancelled";
                        lnkcancel.Style.Add("color", "Red");
                    }
                    else
                    {
                        if (status == "False")
                        {
                            lnkcancel.Text = "Delete";
                            lnkcancel.CommandName = "Delete";
                        }
                        else
                        {
                            lnkcancel.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdallbooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdallbooking.PageIndex = e.NewPageIndex;
            BindAllBooking();
        }
        protected void grdpayatrc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdpayatrc.PageIndex = e.NewPageIndex;
            BindPayATRCBooking();
        }
        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            RestChairBookingServiceClient recbclient = new RestChairBookingServiceClient();
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
                string rcbid = commandArgs[0];
                if (btn.CommandName == "cancel")
                {
                    recbclient.UpdateIsCancelBooking(int.Parse(rcbid), true, false);
                    btn.Enabled = false;
                    btn.Text = "Cancelled";
                    btn.Style.Add("color", "Red");
                }
                recbclient.Close();
            }
            catch (Exception ex)
            {
                recbclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdpayatrc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkcancel = (LinkButton)e.Row.FindControl("lnkcancel");
                    string[] commandArgs = lnkcancel.CommandArgument.ToString().Split(new char[] { ',' });
                    string status = commandArgs[2];
                    DateTime bdate = Convert.ToDateTime(commandArgs[3]).Date;
                    string fromtime = commandArgs[4];
                    string totime = commandArgs[5];
                    DateTime currentdate = DateTime.Now.Date;
                    string paymode = commandArgs[6];
                    TimeSpan currenttime = DateTime.Now.TimeOfDay;

                    bool ispayatrccancel = false;
                    if (!string.IsNullOrEmpty(Convert.ToString(commandArgs[7])))
                        ispayatrccancel = Convert.ToBoolean(commandArgs[7]);

                    if (currentdate <= bdate && currenttime <= Convert.ToDateTime(totime).TimeOfDay && paymode == "Pay At ATRC" && ispayatrccancel == false)
                    {
                        lnkcancel.Visible = true;
                    }
                    else if (ispayatrccancel == true)
                    {
                        lnkcancel.Enabled = false;
                        lnkcancel.Text = "Cancelled";
                        lnkcancel.Style.Add("color", "Red");
                    }
                    else
                    {
                        lnkcancel.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdallbooking_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void lnkonlinetab_Click(object sender, EventArgs e)
        {
            online.Visible = true;
            payatatrc.Visible = false;
        }

        protected void lnkpayatatrctab_Click(object sender, EventArgs e)
        {
            online.Visible = false;
            payatatrc.Visible = true;
        }

        protected void grdpayatrc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}