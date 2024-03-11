using JustStay.CommonHub;
using JustStayAdmin.RCBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class restchairbooking : BL.BasePage
    {
        public int CustomerId = 0;
        public static string strbooking = "0";
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    CustomerId = Convert.ToInt32(new JSEDS().Decrypt(Request.QueryString["Id"].ToString()));
                }
                BindAllBooking(); 
            }
        }
        private void BindAllBooking()
        {
            try
            {
                List<GetAllBookingByCustomerId> blist = new RestChairBookingServiceClient().GetAllBookingByCustomerId(CustomerId,txtrcsearch.Text.Trim(),drppaymentmode.SelectedValue).ToList();
                if (blist == null) return;
                lblcustname.Text = Convert.ToString(blist[0].CustDetails);
                gvrestchair.DataSource = blist;
                gvrestchair.DataBind();
                strbooking = blist.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnrcbSearch_Click(object sender, EventArgs e)
        {
            BindAllBooking();
        }

        protected void gvrestchair_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkcancel = (LinkButton)e.Row.FindControl("lnkbookingcancel");
                string[] commandArgs = lnkcancel.CommandArgument.ToString().Split(new char[] { ',' });
                string status = commandArgs[2];
                string bdate = commandArgs[3];
                string fromtime = commandArgs[4];
                string totime = commandArgs[5];
                string currentdate = DateTime.Now.Date.ToString();
                string paymode = commandArgs[6];
                TimeSpan currenttime = DateTime.Now.TimeOfDay;
                if (currentdate == bdate && currenttime >= Convert.ToDateTime(fromtime).TimeOfDay && currenttime <= Convert.ToDateTime(totime).TimeOfDay && paymode == "Pay At ATRC")
                {
                    lnkcancel.Visible = true;
                }
                else if (currentdate == bdate && currenttime >= Convert.ToDateTime(fromtime).TimeOfDay && currenttime <= Convert.ToDateTime(totime).TimeOfDay && paymode == "Online" && status == "True")
                {
                    lnkcancel.Visible = true;
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
        protected void gvrestchair_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvrestchair.PageIndex = e.NewPageIndex;
            BindAllBooking();
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
                    string cid = commandArgs[2];
                    Response.Redirect("view-booking.aspx?bid=" + objjseds.Encrypt(bid) + "&aid=" + objjseds.Encrypt(aid) + "&cid=" + CustomerId, false);
                }
            }
            catch (Exception ex)
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
                btn.Visible = false;
                btn.Text = "Cancelled";
                btn.Style.Add("color", "Red");
            }
            if (btn.CommandName == "Delete")
            {
                recbclient.UpdateIsDeleted(int.Parse(rcbid), true);
                BindAllBooking();
            }
        }
    }
}