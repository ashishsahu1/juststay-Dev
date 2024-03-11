using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestChairBookingService" in both code and config file together.
    [ServiceContract]
    public interface IRestChairBookingService
    {
        [OperationContract]
       int InsertRestChairBooking(RCBDto rcbdto);

        [OperationContract]
        int InsertRestChair(RCBDDto objRCBD);

        [OperationContract]
        int InsertRestChairPayment(RCPDto objRCPdto);

        [OperationContract]
        GetBookingDetailsByBookingId GetBookingDetails(int bookingid, int atrcid);

        [OperationContract]
        List<GetAllBooking> GetRestChairBooking(int atrcid, DateTime? fromdate, DateTime? todate,int userid,string search);

        [OperationContract]
        List<GetRestChairBookingByATRC> GetRestChairBookingByATRC(int atrcid, DateTime? fromdate, DateTime? todate, string pmode);

        [OperationContract]
        List<GetAllCustomerByATRC> GetAllCustomerByATRC(int atrcid, DateTime? fromdate, DateTime? todate);

        [OperationContract]
        List<GetCustomerBookingsByATRC> GetCustomerBookingsByATRC(int atrcid, int customerid, DateTime? fromdate, DateTime? todate);

        [OperationContract]
        void UpdateOrder(RCPDto pay);

        [OperationContract]
        void UpdatePaymentSuccess(RCPDto pay);

        [OperationContract]
        List<GetAllPaymentByCustomerId> GetAllPaymentByCustomerId(int customerid);

        [OperationContract]
        List<GetAllBookingByCustomerId> GetAllBookingByCustomerId(int customerid,string search,string mode);

        [OperationContract]
        void UpdateIsCancelBooking(int rcbid, bool iscancel, bool isrefund);

        [OperationContract]
        void UpdateIsDeleted(int rcbid, bool isdeleted);

        [OperationContract]
        List<GetBookingForCancelByCustomerId> GetBookingForCancelByCustomerId(int atrcid, string pmode);

        [OperationContract]
        void UpdatePayStatus(int RCPayId, int RCBId);

        [OperationContract]
        GetBookingReceipt GetBookingReceiptDetails(int rcbookingid);
    }
}
