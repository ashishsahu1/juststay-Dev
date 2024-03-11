using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class ATRCBookingRepository
    {
        juststayDbEntities entities;

        public ATRCBookingRepository()
        {
            entities = new juststayDbEntities();
        }
        public List<Cust_ATRCBooking> GetATRCBookingsByCustomer(int custId)
        {
            return entities.GetATRCBookingsByCustomer(custId).ToList();
        }

        public string CheckForRestChairAvailability(int atrcId, int persons, DateTime fromTime, int hours)
        {
            ObjectParameter status = new ObjectParameter("Status", typeof(string));
            entities.CheckRestChairAvailability(atrcId, persons, fromTime.ToString("yyyy-MM-dd hh:mm tt"), hours, status);
            return (status.Value is DBNull ? "" : status.Value.ToString());
        }
     
    }
}
