using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class PaymentRepository
    {
        juststayDbEntities entities;
        public PaymentRepository()
        {
            entities = new juststayDbEntities();
        }
        public List<GetAllOnlinePayment> GetAllOnlinePayment(int atrcid, DateTime? fromdate,DateTime? totime,string search)
        {
            return entities.GetAllOnlinePayment(atrcid, fromdate, totime, search).ToList();
        }
        public List<GetAllOfflinePayment> GetAllOfflinePayment(int atrcid, DateTime? fromdate, DateTime? totime, string search)
        {
            return entities.GetAllOfflinePayment(atrcid, fromdate, totime, search).ToList();
        }
        public List<ATRCOnlineBillingFromJuststay> ATRCOnlineBillingFromJuststay(int atrcid, DateTime? fromdate, DateTime? totime)
        {
            return entities.ATRCOnlineBillingFromJuststay(atrcid, fromdate, totime).ToList();
        }
        public int InsertATRCBill(ATRCBill objbill)
        {
            objbill.InsertedOn = DateTime.Now;
            entities.ATRCBills.Add(objbill);
            entities.SaveChanges();
            return objbill.ATRCBillId;
        }
        public void UpdateATRCBill(ATRCBill atrcbill)
        {
            ATRCBill bill = entities.ATRCBills.Where(a => a.ATRCBillId == atrcbill.ATRCBillId).FirstOrDefault();
            bill.ATRCBillId = atrcbill.ATRCBillId;
            bill.ATRCId = atrcbill.ATRCId;
            bill.BillDate = atrcbill.BillDate;
            bill.BillFrom = atrcbill.BillFrom;
            bill.BillNo = atrcbill.BillNo;
            bill.BillTo = atrcbill.BillTo;
            bill.Description = atrcbill.Description;
            bill.IsPaid = atrcbill.IsPaid;
            bill.PaidAmount = atrcbill.PaidAmount;
            bill.PaymentBy = atrcbill.PaymentBy;
            bill.TotalAmount = atrcbill.TotalAmount;
            bill.UpdatedOn = DateTime.Now.Date;
            entities.SaveChanges();
        }
        public List<GetAllATRCBills> GetAllATRCBill(int atrcid, DateTime? fromdate, DateTime? totime,bool? ispaid)
        {
            return entities.GetAllATRCBills(atrcid, fromdate, totime, ispaid).ToList();
        }
        public int DeleteATRCBill(int billid)
        {
            var x = entities.ATRCBills.FirstOrDefault(i => i.ATRCBillId == billid);
            entities.ATRCBills.Remove(x);
            return entities.SaveChanges();
        }
        public GetATRCBillById GetATRCDetailsById(int id)
        {
            return entities.GetATRCBillById(id).FirstOrDefault();
        }
        public int InsertJSBill(JSBill jbill)
        {
            jbill.InsertedOn = DateTime.Now;
            entities.JSBills.Add(jbill);
            entities.SaveChanges();
            return jbill.JSBillId;
        }
        public void UpdateJSBill(JSBill bill)
        {
            JSBill jbill = entities.JSBills.Where(a => a.JSBillId == bill.JSBillId).FirstOrDefault();
            bill.JSBillId = bill.JSBillId;
            bill.ATRCId = bill.ATRCId;
            bill.BillDate = bill.BillDate;
            bill.BillFrom = bill.BillFrom;
            bill.BillNo = bill.BillNo;
            bill.BillTo = bill.BillTo;
            bill.Description = bill.Description;
            bill.IsPaid = bill.IsPaid;
            bill.PaidAmount = bill.PaidAmount;
            bill.PaymentBy = bill.PaymentBy;
            bill.TotalAmount = bill.TotalAmount;
            bill.UpdatedOn = DateTime.Now.Date;
            entities.SaveChanges();
        }
        public List<GetAllJSBills> GetAllJSBill(int atrcid, DateTime? fromdate, DateTime? totime, bool? ispaid)
        {
            return entities.GetAllJSBills(atrcid, fromdate, totime, ispaid).ToList();
        }
        public int DeleteJSBill(int billid)
        {
            var x = entities.JSBills.FirstOrDefault(i => i.JSBillId == billid);
            entities.JSBills.Remove(x);
            return entities.SaveChanges();
        }
        public GetJSBillById GetJSBillById(int id)
        {
            return entities.GetJSBillById(id).FirstOrDefault();
        }
        public List<PayAtATRCBillingToJuststay> PayAtATRCBillingToJuststay(int atrcid, DateTime? fromdate, DateTime? totime)
        {
            return entities.PayAtATRCBillingToJuststay(atrcid, fromdate, totime).ToList();
        }
    }
}
