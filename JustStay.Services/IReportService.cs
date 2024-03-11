using JustStay.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportService" in both code and config file together.
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        List<GetAllATRCBills_Report> GetAllATRCBillsReport(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid);
        [OperationContract]
        List<GetAllATRC_Report> GetAllATRCReport(DateTime? fromdate, DateTime? todate, string search);
        [OperationContract]
        List<GetAllBooking_Report> GetAllBookingReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid);
        [OperationContract]
        List<GetAllCancelBookings_Report> GetAllCancelBookingsReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid);
        [OperationContract]
        List<GetAllCustomer_Report> GetAllCustomerReport(DateTime? fromdate, DateTime? todate, string search);
        [OperationContract]
        List<GetAllJSBills_Report> GetAllJSBillsReport(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid);
        [OperationContract]
        List<GetAllRefundTrasactions_Report> GetAllRefundTrasactionsReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid);
        [OperationContract]
        List<GetAllTrasaction_Report> GetAllTrasactionReport(DateTime? fromdate, DateTime? todate, string search, string bookingtype, int atrcid);
        [OperationContract]
        List<GetAllUserDetail_Report> GetAllUserDetailReport(DateTime? fromdate, DateTime? todate);
    }
}
