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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RCPaymentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RCPaymentService.svc or RCPaymentService.svc.cs at the Solution Explorer and start debugging.
    public class RCPaymentService : IRCPaymentService
    {
        PaymentRepository paymentRepo;
        public RCPaymentService()
        {
            paymentRepo = new PaymentRepository();
        }
        public List<GetAllOnlinePayment> GetOnlinePayment(int atrcid, DateTime? fromdate, DateTime? todate, string search)
        {
            return paymentRepo.GetAllOnlinePayment(atrcid, fromdate, todate, search).ToList<GetAllOnlinePayment>();
        }
        public List<GetAllOfflinePayment> GetOfflinePayment(int atrcid, DateTime? fromdate, DateTime? todate, string search)
        {
            return paymentRepo.GetAllOfflinePayment(atrcid, fromdate, todate, search).ToList<GetAllOfflinePayment>();
        }
        public List<ATRCOnlineBillingFromJuststay> ATRCOnlineBillingFromJuststay(int atrcid, DateTime? fromdate, DateTime? todate)
        {
            return paymentRepo.ATRCOnlineBillingFromJuststay(atrcid, fromdate, todate).ToList<ATRCOnlineBillingFromJuststay>();
        }
        public int InsertATRCBill(atrcbillDto billdto)
        {
            ATRCBill objatrcbill = new ATRCBill()
            {
               ATRCBillId = billdto.ATRCBillId,
               ATRCId = billdto.ATRCId,
               BillDate = billdto.BillDate,
               BillFrom = billdto.BillFrom,
               BillNo = billdto.BillNo,
               BillTo = billdto.BillTo,
               Description = billdto.Description,
               InsertedOn = billdto.InsertedOn,
               IsDeleted = billdto.IsDeleted,
               IsPaid = billdto.IsPaid,
               PaidAmount = billdto.PaidAmount,
               PaidDate = billdto.PaidDate,
               PaymentBy = billdto.PaymentBy,
               TotalAmount = billdto.TotalAmount,
               UpdatedOn = billdto.UpdatedOn
              
            };
            int id = paymentRepo.InsertATRCBill(objatrcbill);
            return id;
        }
        public void UpdateATRCBill(atrcbillDto atrcbilldto)
        {
            ATRCBill bdto = new ATRCBill
            {
               ATRCBillId = atrcbilldto.ATRCBillId,
               ATRCId = atrcbilldto.ATRCId,
               BillDate = atrcbilldto.BillDate,
               BillFrom = atrcbilldto.BillFrom,
               BillNo = atrcbilldto.BillNo,
               BillTo = atrcbilldto.BillTo,
               Description = atrcbilldto.Description,
               IsPaid = atrcbilldto.IsPaid,
               PaidAmount = atrcbilldto.PaidAmount,
               PaymentBy = atrcbilldto.PaymentBy,
               TotalAmount = atrcbilldto.TotalAmount
            };
            paymentRepo.UpdateATRCBill(bdto);
        }
        public List<GetAllATRCBills> GetAllATRCBill(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid)
        {
            return paymentRepo.GetAllATRCBill(atrcid, fromdate, todate, ispaid).ToList<GetAllATRCBills>();
        }
        public int DeleteATRCBill(int billid)
        {
            return paymentRepo.DeleteATRCBill(billid);
        }
        public GetATRCBillById GetATRCDetailsById(int id)
        {
            return paymentRepo.GetATRCDetailsById(id);
        }
        public int InsertJSBill(jsbillDto jsbilldto)
        {
            JSBill objjsbill = new JSBill()
            {
                JSBillId = jsbilldto.JSBillId,
                ATRCId = jsbilldto.ATRCId,
                BillDate = jsbilldto.BillDate,
                BillFrom = jsbilldto.BillFrom,
                BillNo = jsbilldto.BillNo,
                BillTo = jsbilldto.BillTo,
                Description = jsbilldto.Description,
                InsertedOn = jsbilldto.InsertedOn,
                IsDeleted = jsbilldto.IsDeleted,
                IsPaid = jsbilldto.IsPaid,
                PaidAmount = jsbilldto.PaidAmount,
                PaidDate = jsbilldto.PaidDate,
                PaymentBy = jsbilldto.PaymentBy,
                TotalAmount = jsbilldto.TotalAmount,
                UpdatedOn = jsbilldto.UpdatedOn

            };
            int id = paymentRepo.InsertJSBill(objjsbill);
            return id;
        }
        public void UpdateJSBill(jsbillDto billdto)
        {
            JSBill bdto = new JSBill
            {
                JSBillId = billdto.JSBillId,
                ATRCId = billdto.ATRCId,
                BillDate = billdto.BillDate,
                BillFrom = billdto.BillFrom,
                BillNo = billdto.BillNo,
                BillTo = billdto.BillTo,
                Description = billdto.Description,
                IsPaid = billdto.IsPaid,
                PaidAmount = billdto.PaidAmount,
                PaymentBy = billdto.PaymentBy,
                TotalAmount = billdto.TotalAmount
            };
            paymentRepo.UpdateJSBill(bdto);
        }
        public List<GetAllJSBills> GetAllJSBill(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid)
        {
            return paymentRepo.GetAllJSBill(atrcid, fromdate, todate, ispaid).ToList<GetAllJSBills>();
        }
        public int DeleteJSBill(int billid)
        {
            return paymentRepo.DeleteJSBill(billid);
        }
        public GetJSBillById GetJSBillById(int id)
        {
            return paymentRepo.GetJSBillById(id);
        }
        public List<PayAtATRCBillingToJuststay> PayAtATRCBillingToJuststay(int atrcid, DateTime? fromdate, DateTime? todate)
        {
            return paymentRepo.PayAtATRCBillingToJuststay(atrcid, fromdate, todate).ToList<PayAtATRCBillingToJuststay>();
        }
    }
}
