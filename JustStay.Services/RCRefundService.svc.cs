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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RCRefundService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RCRefundService.svc or RCRefundService.svc.cs at the Solution Explorer and start debugging.
    public class RCRefundService : IRCRefundService
    {
        RefundRepository refundRepo;
        public RCRefundService()
        {
            refundRepo = new RefundRepository();
        }
        public int InsertRCRefund(RefundDto refddto)
        {
            RCRefund objrefund = new RCRefund()
            {
               Note = refddto.Note,
               razor_refund_id = refddto.razor_refund_id,
               RCPaymentId = refddto.RCPaymentId,
               RCRefundPaymentId = refddto.RCRefundPaymentId,
               RefundAmount = refddto.RefundAmount,
               RefundDate = refddto.RefundDate,
               RestChairBookingId = refddto.RestChairBookingId,
               status = refddto.status,
               InsertedOn = refddto.InsertedOn

            };
            int refdid = refundRepo.InsertRefund(objrefund);
            return refdid;
        }
        public List<GetAllCancelledBooking> GetAllCancelledBooking(int atrcid, DateTime? fromdate, DateTime? todate, string mode)
        {
            return refundRepo.GetAllCancelledBooking(atrcid, fromdate, todate, mode).ToList<GetAllCancelledBooking>();
        }
        public List<GetAllRefunds> GetAllRefunds(int atrcid, DateTime? fromdate, DateTime? todate, string mode)
        {
            return refundRepo.GetAllRefunds(atrcid, fromdate, todate, mode).ToList<GetAllRefunds>();
        }
    }
}
