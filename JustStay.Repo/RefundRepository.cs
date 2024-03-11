using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class RefundRepository
    {
        juststayDbEntities entities;

        public RefundRepository()
        {
            entities = new juststayDbEntities();
        }
        public int InsertRefund(RCRefund refund)
        {
            refund.InsertedOn = DateTime.Now;
            entities.RCRefunds.Add(refund);
            entities.SaveChanges();
            return refund.RCRefundPaymentId;
        }
        public List<GetAllCancelledBooking> GetAllCancelledBooking(int atrcid, DateTime? fromdate, DateTime? todate, string mode)
        {
            return entities.GetAllCancelledBooking(atrcid, fromdate, todate, mode).ToList();
        }
        public List<GetAllRefunds> GetAllRefunds(int atrcid, DateTime? fromdate, DateTime? todate, string mode)
        {
            return entities.GetAllRefunds(atrcid, fromdate, todate, mode).ToList();
        }
    }
}
