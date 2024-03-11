using JustStay.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDashboardService" in both code and config file together.
    [ServiceContract]
    public interface IDashboardService
    {
        [OperationContract]
        GetAdminDashboardDetails GetAdminDashboardDetails();

        [OperationContract]
        List<GetTodaysBooking> GetTodayBooking();

        [OperationContract]
        GetATRCDashboardDetails GetATRCDashboardDetails(int ATRCId);

        [OperationContract]
        List<GetATRCTodaysBooking> GetATRCTodayBooking(int ATRCId);
    }
}
