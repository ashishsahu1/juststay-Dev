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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRCPaymentService" in both code and config file together.
    [ServiceContract]
    public interface IRCPaymentService
    {
        [OperationContract]
        List<GetAllOnlinePayment> GetOnlinePayment(int atrcid, DateTime? fromdate, DateTime? todate, string search);

        [OperationContract]
        List<GetAllOfflinePayment> GetOfflinePayment(int atrcid, DateTime? fromdate, DateTime? todate, string search);

        [OperationContract]
        List<ATRCOnlineBillingFromJuststay> ATRCOnlineBillingFromJuststay(int atrcid, DateTime? fromdate, DateTime? todate);

        [OperationContract]
        int InsertATRCBill(atrcbillDto billdto);

        [OperationContract]
        void UpdateATRCBill(atrcbillDto atrcbilldto);

        [OperationContract]
        List<GetAllATRCBills> GetAllATRCBill(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid);

        [OperationContract]
        int DeleteATRCBill(int billid);

        [OperationContract]
        GetATRCBillById GetATRCDetailsById(int id);

        [OperationContract]
        int InsertJSBill(jsbillDto jsbilldto);

        [OperationContract]
        void UpdateJSBill(jsbillDto billdto);

        [OperationContract]
        List<GetAllJSBills> GetAllJSBill(int atrcid, DateTime? fromdate, DateTime? todate, bool? ispaid);

        [OperationContract]
        int DeleteJSBill(int billid);

        [OperationContract]
        GetJSBillById GetJSBillById(int id);

        [OperationContract]
        List<PayAtATRCBillingToJuststay> PayAtATRCBillingToJuststay(int atrcid, DateTime? fromdate, DateTime? todate);
    }
}
