using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using JustStay.Repo;
using JustStay.Services.DTO;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestChairBookingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestChairBookingService.svc or RestChairBookingService.svc.cs at the Solution Explorer and start debugging.
    public class RestChairBookingService : IRestChairBookingService
    {
        RCBookingRepository rcbookingRepository;
        public RestChairBookingService()
        {
            rcbookingRepository = new RCBookingRepository();
        }
        public int InsertRestChairBooking(RCBDto objRCB)
        {
            RestChairBooking objrestchair = new RestChairBooking()
            {
                ATRCId                  = objRCB.ATRCId,
                BookingDate             = objRCB.BookingDate,
                FromTime                = objRCB.FromTime,
                Hour                    = objRCB.Hour,
                Person                  = objRCB.Person,
                Status                  = objRCB.Status,
                ToTime                  = objRCB.ToTime,
                CustomerId              = objRCB.CustomerId,
                BookingNumber           = objRCB.BookingNumber,
                IsCancel                = objRCB.IsCancel,
                IsRefund                = objRCB.IsRefund,
                IsDeleted               = objRCB.IsRefund
            };
            int id = rcbookingRepository.InsertRestChairBooking(objrestchair);
            return id;
        }
        public int InsertRestChair(RCBDDto objRCBD)
        {
            RCBookingDetail objrestchaird = new RCBookingDetail()
            {
              RestChairBookingId = objRCBD.RestChairBookingId,
              ChairId = objRCBD.ChairId,
            };
            int id = rcbookingRepository.InsertRestChair(objrestchaird);
            return id;
        }
        public int InsertRestChairPayment(RCPDto objRCPdto)
        {
            RCPayment objRCPayment = new RCPayment()
            {
               RestChairBookingId               = objRCPdto.RestChairBookingId,
               TotalAmount                      = objRCPdto.TotalAmount,
               Discount                         = objRCPdto.Discount,
               NetAmount                        = objRCPdto.NetAmount,
               CGST                             = objRCPdto.CGST,
               SGST                             = objRCPdto.SGST,
               MerchantTxnId                    = objRCPdto.MerchantTxnId,
               PaymentDate                      = objRCPdto.PaymentDate,
               IsSuccess                        = objRCPdto.IsSuccess,
               PaymentMode                      = objRCPdto.PaymentMode,
               OTP                              = objRCPdto.OTP
            };
            int id = rcbookingRepository.InsertRestChairPayment(objRCPayment);
            return id;
        }
        public GetBookingDetailsByBookingId GetBookingDetails(int bookingid,int atrcid)
        {
            return rcbookingRepository.GetBookingDetails(bookingid, atrcid);
        }
        public List<GetAllBooking> GetRestChairBooking(int atrcid, DateTime? fromdate,DateTime? todate,int userid,string search)
        {
            return rcbookingRepository.GetRestChairBooking(atrcid, fromdate, todate, userid, search).ToList<GetAllBooking>();
        }
        public List<GetRestChairBookingByATRC> GetRestChairBookingByATRC(int atrcid, DateTime? fromdate, DateTime? todate,string pmode)
        {
            return rcbookingRepository.GetRestChairBookingByATRC(atrcid, fromdate, todate,pmode).ToList<GetRestChairBookingByATRC>();
        }
        public List<GetAllCustomerByATRC> GetAllCustomerByATRC(int atrcid, DateTime? fromdate, DateTime? todate)
        {
            return rcbookingRepository.GetAllCustomerByATRC(atrcid, fromdate, todate).ToList<GetAllCustomerByATRC>();
        }
        public List<GetCustomerBookingsByATRC> GetCustomerBookingsByATRC(int atrcid, int customerid, DateTime? fromdate, DateTime? todate)
        {
            return rcbookingRepository.GetCustomerBookingsByATRC(atrcid, customerid, fromdate, todate).ToList<GetCustomerBookingsByATRC>();
        }
        public void UpdateOrder(RCPDto pay)
        {
            RCPayment rcpay = new RCPayment {
                order_id = pay.order_id,
                razorpay_payment_id = pay.razorpay_payment_id,
                razorpay_signature = pay.razorpay_signature,
                OTP = pay.OTP,
                RCPaymentId = pay.RCPaymentId
            };
            rcbookingRepository.UpdateOrder(rcpay);
        }
        public void UpdatePaymentSuccess(RCPDto pay)
        {
            RCPayment rcbpay = new RCPayment
            {
                IsSuccess = pay.IsSuccess,
                RCPaymentId = pay.RCPaymentId
            };
            rcbookingRepository.UpdatePaymentSuccess(rcbpay);
        }
        public List<GetAllPaymentByCustomerId> GetAllPaymentByCustomerId(int customerid)
        {
            return rcbookingRepository.GetAllPaymentByCustomerId(customerid).ToList<GetAllPaymentByCustomerId>();
        }
        public List<GetAllBookingByCustomerId> GetAllBookingByCustomerId(int customerid,string SEARCH,string mode)
        {
            return rcbookingRepository.GetAllBookingByCustomerId(customerid, SEARCH,mode).ToList<GetAllBookingByCustomerId>();
        }
        public void UpdateIsCancelBooking(int rcbid, bool iscancel, bool isrefund)
        {
           rcbookingRepository.UpdateIsCancelBooking(rcbid, iscancel, isrefund);
        }
        public void UpdateIsDeleted(int rcbid, bool isdeleted)
        {
            rcbookingRepository.UpdateIsDeleted(rcbid, isdeleted);
        }
        public List<GetBookingForCancelByCustomerId> GetBookingForCancelByCustomerId(int atrcid, string pmode)
        {
            return rcbookingRepository.GetBookingForCancelByCustomerId(atrcid,pmode).ToList<GetBookingForCancelByCustomerId>();
        }
        public void UpdatePayStatus(int RCPayId, int RCBId)
        {
            rcbookingRepository.UpdatePayStatus(RCPayId, RCBId);
        }
        public GetBookingReceipt GetBookingReceiptDetails(int rcbookingid)
        {
            return rcbookingRepository.GetBookingReceiptDetails(rcbookingid);
        }
    }
}
