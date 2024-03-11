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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportService.svc or ReportService.svc.cs at the Solution Explorer and start debugging.
    public class ReportService : IReportService
    {
        ReportRepository reportRepo;

        public ReportService()
        {
            reportRepo = new ReportRepository();
        }
        public List<GetAllATRCBills_Report> GetAllATRCBillsReport(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid)
        {
            return reportRepo.GetAllATRCBillsReport(atrcid, fromdate, todate, ispaid).ToList<GetAllATRCBills_Report>();
        }
        public List<GetAllATRC_Report> GetAllATRCReport(DateTime? fromdate, DateTime? todate, string search)
        {
            return reportRepo.GetAllATRCReport(fromdate, todate, search).ToList<GetAllATRC_Report>();
        }
        public List<GetAllBooking_Report> GetAllBookingReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid)
        {
            return reportRepo.GetAllBookingReport(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllBooking_Report>();
        }
        public List<GetAllCancelBookings_Report> GetAllCancelBookingsReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid)
        {
            return reportRepo.GetAllCancelBookingsReport(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllCancelBookings_Report>();
        }
        public List<GetAllCustomer_Report> GetAllCustomerReport(DateTime? fromdate, DateTime? todate, string search)
        {
            return reportRepo.GetAllCustomerReport(fromdate, todate, search).ToList<GetAllCustomer_Report>();
        }
        public List<GetAllJSBills_Report> GetAllJSBillsReport(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid)
        {
            return reportRepo.GetAllJSBillsReport(atrcid, fromdate, todate, ispaid).ToList<GetAllJSBills_Report>();
        }
        public List<GetAllRefundTrasactions_Report> GetAllRefundTrasactionsReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid)
        {
            return reportRepo.GetAllRefundTrasactionsReport(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllRefundTrasactions_Report>();
        }
        public List<GetAllTrasaction_Report> GetAllTrasactionReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid)
        {
            return reportRepo.GetAllTrasactionReport(fromdate, todate, search, bookingtype, atrcid).ToList<GetAllTrasaction_Report>();
        }
        public List<GetAllUserDetail_Report> GetAllUserDetailReport(DateTime? fromdate, DateTime? todate)
        {
            return reportRepo.GetAllUserDetailReport(fromdate, todate).ToList<GetAllUserDetail_Report>();
        }
    }
}
