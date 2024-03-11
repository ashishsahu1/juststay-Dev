using JustStay.Web.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Web.RCBookingServiceReference;
using JustStay.Services.DTO;
using JustStay.CommonHub;
using JustStay.Web.CommonServiceReference;

namespace JustStay.Web
{
    public partial class payment : BasePage
    {
        public static string strtotalcost, strfrom, strto, strDate, strTime, strperson, strhour, strcost = "";
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                JustStay.CommonHub.JSEDS objjseds = new JSEDS();
                if (!Page.IsPostBack)
                {
                    if (Session["Search"] != null)
                    {
                        searchDto serchdto = (searchDto)Session["Search"];
                        if (!string.IsNullOrEmpty(Convert.ToString(serchdto.FrTo)))
                        {
                            string[] fromto = Convert.ToString(objjseds.Decrypt(serchdto.FrTo)).Split('/');
                            strfrom = "From: " + fromto[0].ToString();
                            strto = "To: " + fromto[1].ToString();
                        }
                        strDate = "Date: " + Convert.ToString(objjseds.Decrypt(serchdto.Date));
                        strTime = "Time: " + Convert.ToString(objjseds.Decrypt(serchdto.Time));
                        strhour = "Hr: " + Convert.ToString(objjseds.Decrypt(serchdto.Hr));

                        txtbname.Text = Convert.ToString(Common.Name);
                        txtbmobile.Text = Convert.ToString(Common.Mobile);
                        txtbemail.Text = Convert.ToString(Common.Email);
                        hdnatrcid.Value = Convert.ToString(objjseds.Decrypt(serchdto.AtrcId));
                        hdnorderid.Value = Convert.ToString(serchdto.OrderId);
                        hdnrcbid.Value = Convert.ToString(serchdto.RestChairBookingId);
                        hdnrcpaymentid.Value = Convert.ToString(serchdto.RestChairPaymentId);
                        strtotalcost = Convert.ToString(serchdto.TotalAmount);
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        [WebMethod]
        public static void Insert(string orderid, string payid, string signature, string rcpid)
        {
            RestChairBookingServiceClient RCbooking = new RestChairBookingServiceClient();
            try
            {
                JustStay.CommonHub.JSEDS objjseds = new JSEDS();
                if (HttpContext.Current.Request.Url.Host == HttpContext.Current.Request.UrlReferrer.Host)
                {
                    RCPDto rcp = new RCPDto
                    {
                        order_id = objjseds.Decrypt(orderid),
                        razorpay_payment_id = objjseds.Decrypt(payid),
                        razorpay_signature = objjseds.Decrypt(signature),
                        RCPaymentId = Convert.ToInt32(objjseds.Decrypt(rcpid))
                    };
                    RCbooking.UpdateOrder(rcp);
                }
                RCbooking.Close();
            }
            catch(Exception ex)
            {
                RCbooking.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        
    }
}