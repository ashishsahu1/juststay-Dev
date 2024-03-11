using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class ReportRepository
    {
        juststayDbEntities entities;
        public ReportRepository()
        {
            entities = new juststayDbEntities();
        }
        public List<GetAllATRCBills_Report> GetAllATRCBillsReport(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid)
        {
            return entities.GetAllATRCBills_Report(atrcid, fromdate, todate, ispaid).ToList<GetAllATRCBills_Report>();
        }
        public List<GetAllATRC_Report> GetAllATRCReport(DateTime? fromdate, DateTime? todate,string search)
        {
            return entities.GetAllATRC_Report(fromdate, todate, search).ToList<GetAllATRC_Report>();
        }
        public List<GetAllBooking_Report> GetAllBookingReport(DateTime? fromdate, DateTime? todate, string search,string bookingtype,int atrcid)
        {
            return entities.GetAllBooking_Report(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllBooking_Report>();
        }
        public List<GetAllCancelBookings_Report> GetAllCancelBookingsReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid)
        {
            return entities.GetAllCancelBookings_Report(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllCancelBookings_Report>();
        }
        public List<GetAllCustomer_Report> GetAllCustomerReport(DateTime? fromdate, DateTime? todate, string search)
        {
            return entities.GetAllCustomer_Report(fromdate, todate, search).ToList<GetAllCustomer_Report>();
        }
        public List<GetAllJSBills_Report> GetAllJSBillsReport(int atrcid,DateTime? fromdate, DateTime? todate, bool? ispaid)
        {
            return entities.GetAllJSBills_Report(atrcid,fromdate, todate, ispaid).ToList<GetAllJSBills_Report>();
        }
        public List<GetAllRefundTrasactions_Report> GetAllRefundTrasactionsReport(DateTime? fromdate, DateTime? todate,string search,string bookingtype, int atrcid)
        {
            return entities.GetAllRefundTrasactions_Report(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllRefundTrasactions_Report>();
        }
        public List<GetAllTrasaction_Report> GetAllTrasactionReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid)
        {
            return entities.GetAllTrasaction_Report(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllTrasaction_Report>();
        }
        public List<GetAllUserDetail_Report> GetAllUserDetailReport(DateTime? fromdate, DateTime? todate)
        {
            return entities.GetAllUserDetail_Report(fromdate, todate).ToList<GetAllUserDetail_Report>();
        }
    }
}
