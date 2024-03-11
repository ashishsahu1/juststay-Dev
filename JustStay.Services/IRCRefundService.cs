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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRCRefundService" in both code and config file together.
    [ServiceContract]
    public interface IRCRefundService
    {
        [OperationContract]
        int InsertRCRefund(RefundDto refddto);

        [OperationContract]
        List<GetAllCancelledBooking> GetAllCancelledBooking(int atrcid, DateTime? fromdate, DateTime? todate, string mode);

        [OperationContract]
        List<GetAllRefunds> GetAllRefunds(int atrcid, DateTime? fromdate, DateTime? todate, string mode);
    }
}
