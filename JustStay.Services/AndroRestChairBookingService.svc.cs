using JustStay.CommonHub;
using JustStay.Repo;
using JustStay.Services.DTO;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace JustStay.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AndroRestChairBookingService
    {
        RCBookingRepository rcbookingRepository;
        public AndroRestChairBookingService()
        {
            rcbookingRepository = new RCBookingRepository();
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
           UriTemplate = "InsertRestChairBooking/{atrcid}/{bookingdate}/{fromtime}/{hour}/{person}/{status}/{totime}/{customerid}/{bookingnumber}/{iscancel}/{isrefund}/{isdeleted}")]
        public int InsertRestChairBooking(string atrcid, string bookingdate, string fromtime, string hour, string person,
            string status, string totime, string customerid, string bookingnumber,string iscancel,string isrefund,string isdeleted)
        {
            int bid = 0;
            try
            {
                RestChairBooking objrestchair = new RestChairBooking()
                {
                    ATRCId = Convert.ToInt32(atrcid),
                    BookingDate = Convert.ToDateTime(bookingdate),
                    FromTime = TimeSpan.Parse(fromtime),
                    Hour = Convert.ToInt32(hour),
                    Person = Convert.ToInt32(person),
                    Status = status,
                    ToTime = TimeSpan.Parse(totime),
                    CustomerId = Convert.ToInt32(customerid),
                    BookingNumber = bookingnumber,
                    IsCancel = Convert.ToBoolean(iscancel),
                    IsRefund = Convert.ToBoolean(isrefund),
                    IsDeleted = Convert.ToBoolean(isdeleted)
                };
                bid = rcbookingRepository.InsertRestChairBooking(objrestchair);
                return bid;
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "BookingAPI", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                return 0;
            }
           
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
         UriTemplate = "InsertRestChair/{restchairbookingid}/{chairid}")]
        public int InsertRestChair(string restchairbookingid,string chairid)
        {
            int cid = 0;
            try
            {
                RCBookingDetail objrestchaird = new RCBookingDetail()
                {
                    RestChairBookingId = Convert.ToInt32(restchairbookingid),
                    ChairId = Convert.ToInt32(chairid),
                };
                cid = rcbookingRepository.InsertRestChair(objrestchaird);
                return cid;
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "BookingAPI", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                return 0;
            }
           
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
       UriTemplate = "InsertRestChairPayment/{restchairbookingid}/{totalamount}/{discount}/{netamount}/{cgst}/{sgst}/{merchanttxnid}/{paymentdate}/{issuccess}/{paymentmode}/{otp}")]
        public int InsertRestChairPayment(string restchairbookingid,string totalamount, string discount, string netamount, string cgst, string sgst, string merchanttxnid, string paymentdate, string issuccess, string paymentmode, string otp)
        {
            int pid = 0;
            try
            {
                RCPayment objRCPayment = new RCPayment()
                {
                    RestChairBookingId = Convert.ToInt32(restchairbookingid),
                    TotalAmount = Convert.ToDecimal(totalamount),
                    Discount = Convert.ToInt32(discount),
                    NetAmount = Convert.ToDecimal(netamount),
                    CGST = Convert.ToDecimal(cgst),
                    SGST = Convert.ToDecimal(sgst),
                    MerchantTxnId = merchanttxnid,
                    PaymentDate = Convert.ToDateTime(paymentdate),
                    IsSuccess = Convert.ToBoolean(issuccess),
                    PaymentMode = paymentmode,
                    OTP = otp
                };
                pid = rcbookingRepository.InsertRestChairPayment(objRCPayment);
                return pid;
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "BookingAPI", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                return 0;
            }
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GetOrderId/{amount}/{rcpid}")]
        public string GetOrderId(string amount,string rcpid)
        {
            RazorpayClient client = new RazorpayClient(Helper.RazorKey, Helper.RazorSecret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", Convert.ToDecimal(amount) * 100); 
            options.Add("receipt", Convert.ToString(rcpid));
            options.Add("currency", "INR");
            options.Add("payment_capture", "1");
            Order order = client.Order.Create(options);
           return Convert.ToString(order["id"]);
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "UpdatePayment/{razor_orderid}/{razor_payid}/{razor_signature}/{rcpid}/{otp}")]
        public string UpdatePayment(string razor_orderid, string razor_payid,string razor_signature, string rcpid,string otp)
        {
            rcbookingRepository = new RCBookingRepository();
            RCPayment rcpay = new RCPayment
            {
                order_id = razor_orderid,
                razorpay_payment_id = razor_payid,
                razorpay_signature = razor_signature,
                RCPaymentId = Convert.ToInt32(rcpid),
                OTP = otp
            };
            try
            {
                rcbookingRepository.UpdateOrder(rcpay);
                return "1";
            }
            catch
            {
                return "0";
            }
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GenerateSignature/{razor_orderid}/{razor_paymentid}")]
        public string GenerateSignature(string razor_orderid, string razor_paymentid)
        {
           return Helper.getActualSignature(razor_orderid + "|" + razor_paymentid, Helper.RazorSecret);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "UpdatePaymentStatus/{issuccessflag}/{rcpid}")]
        public string UpdatePaymentStatus(string issuccessflag, string rcpid)
        {
            rcbookingRepository = new RCBookingRepository();
            RCPayment pay = new RCPayment
            {
                IsSuccess = Convert.ToBoolean(issuccessflag),
                RCPaymentId = Convert.ToInt32(rcpid)
            };
            try
            {
                rcbookingRepository.UpdatePaymentSuccess(pay);
                return "1";
            }
            catch { return "0"; }
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GetBookingDetails/{bookingid}/{atrcid}")]
        public GetBookingDetailsByBookingId GetBookingDetails(string bookingid, string atrcid)
        {
            return rcbookingRepository.GetBookingDetails(Convert.ToInt32(bookingid), Convert.ToInt32(atrcid));
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllBookingByCustomerId/{customerid}/{SEARCH}")]
        public List<GetAllBookingByCustomerIdAndroid> GetAllBookingByCustomerId(string customerid, string SEARCH)
        {
            rcbookingRepository = new RCBookingRepository();
            string search = "";
            if(SEARCH != "null")
            {
                search = SEARCH.Trim();
            }
            return rcbookingRepository.GetAllBookingByCustomerIdAndro(Convert.ToInt32(customerid), search).ToList<GetAllBookingByCustomerIdAndroid>();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllPaymentByCustomerId/{customerid}")]
        public List<GetAllPaymentByCustomerIdAndroid> GetAllPaymentByCustomerId(string customerid)
        {
            rcbookingRepository = new RCBookingRepository();
            return rcbookingRepository.GetAllPaymentByCustomerIdAndro(Convert.ToInt32(customerid)).ToList<GetAllPaymentByCustomerIdAndroid>();
        }
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "UpdateIsCancelBooking/{rcbid}/{iscancel}/{isrefund}")]
        public int UpdateIsCancelBooking(string rcbid, string iscancel, string isrefund)
        {
            rcbookingRepository = new RCBookingRepository();
            rcbookingRepository.UpdateIsCancelBooking(Convert.ToInt32(rcbid),Convert.ToBoolean(iscancel),Convert.ToBoolean(isrefund));
            return 1;
        }
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "UpdateIsDeleted/{rcbid}/{isdeleted}")]
        public int UpdateIsDeleted(string rcbid, string isdeleted)
        {
            rcbookingRepository = new RCBookingRepository();
            rcbookingRepository.UpdateIsDeleted(Convert.ToInt32(rcbid), Convert.ToBoolean(isdeleted));
            return 1;
        }
    }
}
