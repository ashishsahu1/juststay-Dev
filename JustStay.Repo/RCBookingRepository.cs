using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class RCBookingRepository
    {
        juststayDbEntities entities;
        public RCBookingRepository()
        {
            entities = new juststayDbEntities();
        }
        public int InsertRestChairBooking(RestChairBooking objRCB)
        {
            objRCB.InsertedOn = DateTime.Now;
            entities.RestChairBookings.Add(objRCB);
            entities.SaveChanges();
            return objRCB.RestChairBookingId;
        }
        public int InsertRestChair(RCBookingDetail objRCBD)
        {
            objRCBD.InsertedOn = DateTime.Now;
            entities.RCBookingDetails.Add(objRCBD);
            entities.SaveChanges();
            return objRCBD.RCBDetailId;
        }
        public int InsertRestChairPayment(RCPayment objRCP)
        {
            objRCP.InsertedOn = DateTime.Now;
            entities.RCPayments.Add(objRCP);
            entities.SaveChanges();
            return objRCP.RCPaymentId;
        }
        public GetBookingDetailsByBookingId GetBookingDetails(int BookingId,int Atrcid)
        {
            return entities.GetBookingDetailsByBookingId(BookingId, Atrcid).FirstOrDefault();
        }
        public List<GetAllBooking> GetRestChairBooking(int atrcid,DateTime? fromdate,DateTime? todate,int userid,string search)
        {
            return entities.GetAllBooking(atrcid, fromdate, todate,userid, search).ToList();
        }
        public List<GetRestChairBookingByATRC> GetRestChairBookingByATRC(int atrcid, DateTime? fromdate, DateTime? todate,string pmode)
        {
            return entities.GetRestChairBookingByATRC(atrcid, fromdate, todate,pmode).ToList();
        }
        public List<GetAllCustomerByATRC> GetAllCustomerByATRC(int atrcid, DateTime? fromdate, DateTime? todate)
        {
            return entities.GetAllCustomerByATRC(atrcid, fromdate, todate).ToList();
        }
        public List<GetCustomerBookingsByATRC> GetCustomerBookingsByATRC(int atrcid,int customerid, DateTime? fromdate, DateTime? todate)
        {
            return entities.GetCustomerBookingsByATRC(atrcid, customerid, fromdate, todate).ToList();
        }
        public void UpdateOrder(RCPayment pay)
        {
            RCPayment payment = entities.RCPayments.Where(a => a.RCPaymentId == pay.RCPaymentId).FirstOrDefault();
            payment.order_id = pay.order_id;
            payment.razorpay_payment_id = pay.razorpay_payment_id;
            payment.razorpay_signature = pay.razorpay_signature;
            payment.OTP = pay.OTP;
            entities.SaveChanges();
        }
        public void UpdatePaymentSuccess(RCPayment pay)
        {
            RCPayment payment = entities.RCPayments.Where(a => a.RCPaymentId == pay.RCPaymentId).FirstOrDefault();
            payment.IsSuccess = pay.IsSuccess;
            entities.SaveChanges();
        }
        public void UpdateBookingStatus(string  status,int bid)
        {
            RestChairBooking bk = entities.RestChairBookings.Where(a => a.RestChairBookingId == bid).FirstOrDefault();
            bk.Status = status;
            entities.SaveChanges();
        }
        public List<GetAllPaymentByCustomerId> GetAllPaymentByCustomerId(int customerid)
        {
            return entities.GetAllPaymentByCustomerId(customerid).ToList();
        }
        public List<GetAllPaymentByCustomerIdAndroid> GetAllPaymentByCustomerIdAndro(int customerid)
        {
            return entities.GetAllPaymentByCustomerIdAndroid(customerid).ToList();
        }
        public List<GetAllBookingByCustomerId> GetAllBookingByCustomerId(int customerid,string SEARCH,string mode)
        {
            return entities.GetAllBookingByCustomerId(customerid, SEARCH, mode).ToList();
        }
        public List<GetAllBookingByCustomerIdAndroid> GetAllBookingByCustomerIdAndro(int customerid, string SEARCH)
        {
            return entities.GetAllBookingByCustomerIdAndroid(customerid, SEARCH).ToList();
        }
        public void UpdateIsCancelBooking(int rcbid,bool iscancel,bool isrefund)
        {
            RestChairBooking rbooking = entities.RestChairBookings.Where(a => a.RestChairBookingId == rcbid).FirstOrDefault();
            rbooking.IsCancel = iscancel;
            rbooking.IsRefund = isrefund;
            entities.SaveChanges();
        }
        public void UpdateIsDeleted(int rcbid, bool isdeleted)
        {
            RestChairBooking rbooking = entities.RestChairBookings.Where(a => a.RestChairBookingId == rcbid).FirstOrDefault();
            rbooking.IsDeleted = isdeleted;
            entities.SaveChanges();
        }
        public List<GetBookingForCancelByCustomerId> GetBookingForCancelByCustomerId(int atrcid, string pmode)
        {
            return entities.GetBookingForCancelByCustomerId(atrcid, pmode).ToList();
        }
        public void UpdatePayStatus(int RCPayId,int RCBId)
        {
            RCPayment payment = entities.RCPayments.Where(a => a.RCPaymentId == RCPayId).FirstOrDefault();
            payment.Paystatus = "Received";
            payment.Paydate = DateTime.Now;
            entities.SaveChanges();

            RestChairBooking rcb = entities.RestChairBookings.Where(a => a.RestChairBookingId == RCBId).FirstOrDefault();
            rcb.Status = "Payment Received";
            entities.SaveChanges();
        }
        public GetBookingReceipt GetBookingReceiptDetails(int RestChairBookingId)
        {
            return entities.GetBookingReceipt(RestChairBookingId).FirstOrDefault();
        }
    }
}
