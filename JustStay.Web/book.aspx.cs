using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStay.Web.ATRCServiceReference;
using JustStay.Web.BusinessLogic;
using JustStay.Web.CommonServiceReference;
using JustStay.Web.RCBookingServiceReference;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class book : BasePage
    {
        public static int ATRCId = 0, HR = 1;
        public static string strfrom, strto, strDate, strTime, strperson, strhour, strcost;

       
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                JSEDS objsecurity = new JSEDS();
              
                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["aid"]))
                    {
                        ATRCId = Convert.ToInt32(objsecurity.Decrypt(Request.QueryString["aid"]));
                        Session["artcid"] = Convert.ToInt32(objsecurity.Decrypt(Request.QueryString["aid"]));
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["hr"]))
                    {
                        HR = Convert.ToInt32(objsecurity.Decrypt(Request.QueryString["hr"]));
                        lblhr.Text = strhour = Convert.ToString(objsecurity.Decrypt(Request.QueryString["hr"]));
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["Date"]) && !string.IsNullOrEmpty(Request.QueryString["hr"])
                    && !string.IsNullOrEmpty(Request.QueryString["Time"]))
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["frto"]))
                        {
                            string[] fromto = Convert.ToString(objsecurity.Decrypt(Request.QueryString["frto"])).Split('/');
                            strfrom = "From: " + fromto[0].ToString();
                            strto = "To: " + fromto[1].ToString();
                        }
                        strDate = "Date: " + objsecurity.Decrypt(Request.QueryString["Date"]).ToString();
                        strTime = "Time: " + objsecurity.Decrypt(Request.QueryString["Time"]).ToString();
                        hdnfromtime.Value = objsecurity.Decrypt(Request.QueryString["Time"]).ToString();
                        hdndate.Value = objsecurity.Decrypt(Request.QueryString["Date"]).ToString();

                        if (!string.IsNullOrEmpty(Request.QueryString["per"]))
                        strperson = "Per:" + objsecurity.Decrypt(Request.QueryString["per"]).ToString();

                        if (!string.IsNullOrEmpty(Request.QueryString["hr"]))
                            strhour = "Hr: " + objsecurity.Decrypt(Request.QueryString["hr"]).ToString();
                    }
                    else
                    {
                        if (Session["Search"] != null)
                        {
                            searchDto sdto = (searchDto)Session["Search"];
                            if (!string.IsNullOrEmpty(sdto.FrTo))
                            {
                                string[] fromto = Convert.ToString(objsecurity.Decrypt(sdto.FrTo)).Split('/');
                                strfrom = "From: " + fromto[0].ToString();
                                strto = "To: " + fromto[1].ToString();
                            }
                            strDate = "Date: " + Convert.ToString(objsecurity.Decrypt(sdto.Date));
                            strTime = "Time: " + Convert.ToString(objsecurity.Decrypt(sdto.Time));
                            hdnfromtime.Value = Convert.ToString(objsecurity.Decrypt(sdto.Time));


                            strhour = "Hr: " + Convert.ToString(objsecurity.Decrypt(sdto.Hr));
                        }
                        else
                        {
                            Response.Redirect("~/home.aspx",false);
                            Context.ApplicationInstance.CompleteRequest();
                        }

                    }
                    BindRestChairTypes();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnkback_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Date"]) && !string.IsNullOrEmpty(Request.QueryString["hr"])
                   && !string.IsNullOrEmpty(Request.QueryString["Time"]))
            {
                Response.Redirect("~/atrc.aspx?hr=" + Request.QueryString["hr"] + "&Mode=ALL" + "&Date=" + Request.QueryString["Date"] + "&Time=" + Request.QueryString["Time"], false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                if (Session["Search"] != null)
                {
                    searchDto sdto = (searchDto)Session["Search"];
                    Response.Redirect("~/atrc.aspx?hr=" + sdto.Hr + "&Mode=ALL" + "&Date=" + sdto.Date + "&Time=" + sdto.Time, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    DateTime dt = DateTime.Now.Date;
                    TimeSpan time = DateTime.Now.TimeOfDay;
                    Response.Redirect("~/atrc.aspx?hr=1" + "&Mode=ALL" + "&Date=" + dt.ToString() + "&Time=" + time.ToString(), false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void btnpayatrc_Click(object sender, EventArgs e)
        {
            RestChairBookingServiceClient RCbooking = new RestChairBookingServiceClient();
            try
            {
                JSEDS objsecurity = new JSEDS();
                if (Common.IsLogedIn)
                {
                    try
                    {
                        RCBDto rcbdto = new RCBDto();
                        RCBDDto rcbddto = new RCBDDto();
                        RCPDto rcpdto = new RCPDto();
                        if (!string.IsNullOrEmpty(Request.QueryString["aid"]) && !string.IsNullOrEmpty(Request.QueryString["Time"]) && !string.IsNullOrEmpty(Request.QueryString["Date"]) && !string.IsNullOrEmpty(Request.QueryString["hr"]))
                        {
                           // searchDto sdto = (searchDto)Session["Search"];
                            int hour = Convert.ToInt32(objsecurity.Decrypt(Request.QueryString["hr"]));
                            TimeSpan fromtime = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Time"])).TimeOfDay;
                            TimeSpan totime = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Time"])).AddHours(hour).TimeOfDay;
                            DateTime bdate = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Date"]));
                            string[] chairarray = hdnchairarray.Value.Split(',');
                            rcbdto.ATRCId = ATRCId;
                            rcbdto.BookingDate = bdate;
                            rcbdto.CustomerId = Common.CustomerId;
                            rcbdto.Hour = hour;
                            rcbdto.Person = chairarray.Length;
                            rcbdto.FromTime = fromtime;
                            rcbdto.ToTime = totime;
                            rcbdto.Status = "Payment Pending";
                            Random rand = new Random();
                            int randamnum = rand.Next(1,9999999);
                            rcbdto.BookingNumber = Common.UserId + "/JSTY/"+ randamnum + "/" + DateTime.Now.ToShortDateString();
                            rcbdto.IsCancel = false;
                            rcbdto.IsRefund = false;
                            rcbdto.IsDeleted = false;

                            if (hdnrcbid.Value == "0")
                            {
                                searchDto sdto = new searchDto();
                                int rcbid  = RCbooking.InsertRestChairBooking(rcbdto);
                                hdnrcbid.Value = rcbid.ToString();
                                sdto.AtrcId = Convert.ToString(Request.QueryString["aid"]);
                                sdto.Date = Convert.ToString(Request.QueryString["Date"]);
                                sdto.Time = Convert.ToString(Request.QueryString["Time"]);
                                sdto.Hr = Convert.ToString(Request.QueryString["hr"]);
                                sdto.RestChairBookingId = Convert.ToString(hdnrcbid.Value);
                                if (rcbid > 0)
                                {
                                    int counter = 0;
                                    for (int i = 0; i < chairarray.Length; i++)
                                    {
                                        rcbddto.ChairId = Convert.ToInt32(chairarray[i]);
                                        rcbddto.RestChairBookingId = Convert.ToInt32(hdnrcbid.Value);
                                        int chairid = RCbooking.InsertRestChair(rcbddto);
                                        if (chairid > 0)
                                        {
                                            counter++;
                                        }
                                    }
                                    if (chairarray.Length == counter)
                                    {
                                        rcpdto.RestChairBookingId = Convert.ToInt32(hdnrcbid.Value);
                                        rcpdto.TotalAmount = Convert.ToDecimal(hdntotalcost.Value);
                                        rcpdto.Discount = 0;
                                        rcpdto.NetAmount = Convert.ToDecimal(hdntotalcost.Value);
                                        rcpdto.CGST = 0;
                                        rcpdto.SGST = 0;
                                        rcpdto.PaymentDate = DateTime.Now;
                                        rcpdto.PaymentMode = "Pay At ATRC";
                                        rcpdto.IsSuccess = false;
                                        hdnrcpaymentid.Value = Convert.ToString(RCbooking.InsertRestChairPayment(rcpdto));
                                        sdto.RestChairPaymentId = hdnrcpaymentid.Value;
                                        if (Convert.ToInt32(hdnrcpaymentid.Value) > 0)
                                        {
                                            rcpdto.RCPaymentId = Convert.ToInt32(hdnrcpaymentid.Value);
                                            Random num = new Random();
                                            string orderid = Convert.ToString(num.Next(1000, 1000000));
                                            rcpdto.order_id = "ord_" + orderid;

                                            hdnorderid.Value = Convert.ToString("ord_" + orderid);
                                            sdto.OrderId = Convert.ToString("ord_" + orderid);
                                            sdto.TotalAmount = hdntotalcost.Value;
                                            Session["Search"] = sdto;
                                            Random otpnumber = new Random();
                                            string OTP = Convert.ToString(otpnumber.Next(100000, 999999));
                                            rcpdto.OTP = OTP;

                                            string output = SendOTP(Common.Name, Common.Mobile, OTP);
                                            int res = SendMailToCustomer(OTP);
                                            if (output != "" || res != 0)
                                            {
                                                RCbooking.UpdateOrder(rcpdto);
                                                Response.Redirect("~/view-booking.aspx?bid=" + objsecurity.Encrypt(hdnrcbid.Value)
                                                   + "&aid=" + objsecurity.Encrypt(Convert.ToString(ATRCId)) + "&m=" + objsecurity.Encrypt("pyat"), false);
                                                Context.ApplicationInstance.CompleteRequest();
                                            }
                                        }
                                    }
                                }
                            }
                            RCbooking.Close();
                        }
                        else { 
                            RCbooking.Close(); 
                            Response.Redirect("~/home.aspx",false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    catch (Exception ex)
                    {
                        RCbooking.Close();
                        Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
                else
                {
                    RCbooking.Close();
                    Response.Redirect("~/home.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                RCbooking.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { RCbooking.Close(); }
        }
        private void BindRestChairTypes()
        {
            List<GetRestChairByAtrcId> restchairtype = new List<GetRestChairByAtrcId>();
            ATRCServiceClient atrcclient = new ATRCServiceClient();
            try
            {
                JSEDS objsecurity = new JSEDS();
                DateTime bdate;
                if (Session["Search"] != null)
                {
                   searchDto sdto = (searchDto)Session["Search"];
                   bdate =  Convert.ToDateTime(objsecurity.Decrypt(sdto.Date) + " " + objsecurity.Decrypt(sdto.Time));
                }
                else
                {
                    bdate = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Date"]) + " " + objsecurity.Decrypt(Request.QueryString["Time"]));
                }
               
                restchairtype = atrcclient.GetRestChairDetailsByAtrcId(ATRCId, bdate, HR).ToList();
                if (restchairtype.Count > 0)
                {
                    rptrestchairtypes.DataSource = null;
                    rptrestchairtypes.DataBind(); ;

                    rptrestchairtypes.DataSource = restchairtype;
                    rptrestchairtypes.DataBind();
                }
                else
                {
                    rptrestchairtypes.DataSource = null;
                    rptrestchairtypes.DataBind();
                }
                atrcclient.Close();
            }
            catch(Exception ex)
            {
                atrcclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            RestChairBookingServiceClient RCbooking = new RestChairBookingServiceClient();
            try
            {
                JSEDS objsecurity = new JSEDS();
                if (Common.IsLogedIn)
                {
                    try
                    {
                        RCBDto rcbdto = new RCBDto();
                        RCBDDto rcbddto = new RCBDDto();
                        RCPDto rcpdto = new RCPDto();
                       
                        if (!string.IsNullOrEmpty(Request.QueryString["Date"]) && !string.IsNullOrEmpty(Request.QueryString["Time"]) && !string.IsNullOrEmpty(Request.QueryString["hr"]) && !string.IsNullOrEmpty(Request.QueryString["aid"]))
                        {
                            int hour = Convert.ToInt32(objsecurity.Decrypt(Request.QueryString["hr"]));
                            TimeSpan fromtime = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Time"])).TimeOfDay;
                            TimeSpan totime = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Time"])).AddHours(hour).TimeOfDay;
                            DateTime bdate = Convert.ToDateTime(objsecurity.Decrypt(Request.QueryString["Date"]));
                            string[] chairarray = hdnchairarray.Value.Split(',');
                            rcbdto.ATRCId = ATRCId;
                            rcbdto.BookingDate = bdate;
                            rcbdto.CustomerId = Common.CustomerId;
                            rcbdto.Hour = hour;
                            rcbdto.Person = chairarray.Length;
                            rcbdto.FromTime = fromtime;
                            rcbdto.ToTime = totime;
                            rcbdto.Status = "Payment Pending";
                            Random rand = new Random();
                            int randamnum = rand.Next(1, 9999999);
                            rcbdto.BookingNumber = Common.UserId + "/JSTY/" + randamnum + "/" + DateTime.Now.ToShortDateString();
                            rcbdto.IsCancel = false;
                            rcbdto.IsRefund = false;
                            rcbdto.IsDeleted = false;

                            if (hdnrcbid.Value == "0")
                            {
                                int restchairbookingid = RCbooking.InsertRestChairBooking(rcbdto);
                                hdnrcbid.Value = restchairbookingid.ToString();

                                searchDto sdto = new searchDto();
                                sdto.AtrcId = Convert.ToString(Request.QueryString["aid"]);
                                sdto.Date = Convert.ToString(Request.QueryString["Date"]);
                                sdto.Time = Convert.ToString(Request.QueryString["Time"]);
                                sdto.Hr = Convert.ToString(Request.QueryString["hr"]);
                                sdto.RestChairBookingId = Convert.ToString(hdnrcbid.Value);

                                if (restchairbookingid > 0)
                                {
                                    int counter = 0;
                                    for (int i = 0; i < chairarray.Length; i++)
                                    {
                                        rcbddto.ChairId = Convert.ToInt32(chairarray[i]);
                                        rcbddto.RestChairBookingId = Convert.ToInt32(hdnrcbid.Value);
                                        int chairid = RCbooking.InsertRestChair(rcbddto);
                                        if (chairid > 0)
                                        {
                                            counter++;
                                        }
                                    }
                                    if (chairarray.Length == counter)
                                    {
                                        rcpdto.RestChairBookingId = Convert.ToInt32(hdnrcbid.Value);
                                        rcpdto.TotalAmount = Convert.ToDecimal(hdntotalcost.Value);
                                        rcpdto.Discount = 0;
                                        rcpdto.NetAmount = Convert.ToDecimal(hdntotalcost.Value);
                                        rcpdto.CGST = 0;
                                        rcpdto.SGST = 0;
                                        rcpdto.PaymentDate = DateTime.Now;
                                        rcpdto.PaymentMode = "Online";
                                        hdnrcpaymentid.Value = Convert.ToString(RCbooking.InsertRestChairPayment(rcpdto));
                                        sdto.RestChairPaymentId = hdnrcpaymentid.Value;
                                        if (Convert.ToInt32(hdnrcpaymentid.Value) > 0)
                                        {
                                            RazorpayClient client = new RazorpayClient(Helper.RazorKey, Helper.RazorSecret);
                                            Dictionary<string, object> options = new Dictionary<string, object>();
                                            options.Add("amount", Convert.ToDecimal(hdntotalcost.Value) * 100); // amount in the smallest currency unit
                                            options.Add("receipt", Convert.ToString(hdnrcpaymentid.Value));
                                            options.Add("currency", "INR");
                                            options.Add("payment_capture", "1");
                                            Order order = client.Order.Create(options);
                                            rcpdto.RCPaymentId = Convert.ToInt32(hdnrcpaymentid.Value);
                                            rcpdto.order_id = Convert.ToString(order["id"]);

                                            hdnorderid.Value = Convert.ToString(order["id"]);
                                            sdto.OrderId = Convert.ToString(order["id"]);
                                            sdto.TotalAmount = hdntotalcost.Value;
                                            RCbooking.UpdateOrder(rcpdto);
                                            Session["Search"] = sdto;
                                            RCbooking.Close();
                                            Response.Redirect("~/payment.aspx", false);
                                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "razorpay(this)", true);
                                            Context.ApplicationInstance.CompleteRequest();
                                        }
                                    }
                                }
                                RCbooking.Close();
                            }
                            else
                            {
                                RCbooking.Close();
                                Response.Redirect("~/home.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                        }
                        else {
                            RCbooking.Close();
                            Response.Redirect("~/home.aspx",false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    catch (Exception ex)
                    {
                        RCbooking.Close();
                        Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
                else
                {
                    RCbooking.Close();
                    Response.Redirect("~/home.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                //SetProfile();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private string SendOTP(string ussername, string mobilenumber,string otp)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            string response = "";
            try
            {
               
                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.PayAtAtrc);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##customer##", ussername);
                    msg = msg.Replace("##OTP##", otp);
                    response = Common.SendSMS(mobilenumber, msg);
                }
                commonClient.Close();
            }
            catch (Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return response;
        }
        private int SendMailToCustomer(string otp)
        {
            int output = 0;
            try
            {
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "PayAtATRC.html");
                emailBody = emailBody.Replace("{NAME}", Common.Name);
                emailBody = emailBody.Replace("{OTP}", otp);

                string[] custemail = new string[1];
                if(string.IsNullOrEmpty(Common.Email))
                    custemail[0] = "contact@juststay.in";
                else
                    custemail[0] = Common.Email;

                output = Common.SendMailithBcc("contact@juststay.in", custemail, "OTP Pay At ATRC - JustStay", "", emailBody);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return output;
        }
    }
}