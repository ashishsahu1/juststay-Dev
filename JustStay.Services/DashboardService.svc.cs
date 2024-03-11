using JustStay.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DashboardService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DashboardService.svc or DashboardService.svc.cs at the Solution Explorer and start debugging.
    public class DashboardService : IDashboardService
    {
        DashboardRepository dashboardRepo;
        public DashboardService()
        {
            dashboardRepo = new DashboardRepository();
        }
        public GetAdminDashboardDetails GetAdminDashboardDetails()
        {
            return dashboardRepo.GetAdminDashboardCount();
        }
        public List<GetTodaysBooking> GetTodayBooking()
        {
            return dashboardRepo.GetTodaysBooking();
        }
        public GetATRCDashboardDetails GetATRCDashboardDetails(int ATRCId)
        {
            return dashboardRepo.GetATRCDashboardCount(ATRCId);
        }
        public List<GetATRCTodaysBooking> GetATRCTodayBooking(int ATRCId)
        {
            return dashboardRepo.GetATRCTodaysBooking(ATRCId);
        }
    }
}
