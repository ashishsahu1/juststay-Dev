using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class DashboardRepository
    {
        juststayDbEntities entities;

        public DashboardRepository()
        {
            entities = new juststayDbEntities();
        }
        public GetAdminDashboardDetails GetAdminDashboardCount()
        {
            return entities.GetAdminDashboardDetails().FirstOrDefault();
        }
        public List<GetTodaysBooking> GetTodaysBooking()
        {
            return entities.GetTodaysBooking().ToList<GetTodaysBooking>();
        }
        public GetATRCDashboardDetails GetATRCDashboardCount(int ATRCId)
        {
            return entities.GetATRCDashboardDetails(ATRCId).FirstOrDefault();
        }
        public List<GetATRCTodaysBooking> GetATRCTodaysBooking(int ATRCId)
        {
            return entities.GetATRCTodaysBooking(ATRCId).ToList<GetATRCTodaysBooking>();
        }
    }
}
