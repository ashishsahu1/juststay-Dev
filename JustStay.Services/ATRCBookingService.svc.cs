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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ATRCBookingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ATRCBookingService.svc or ATRCBookingService.svc.cs at the Solution Explorer and start debugging.
    public class ATRCBookingService : IATRCBookingService
    {
        ATRCBookingRepository centerRepository;

        public ATRCBookingService()
        {
            centerRepository = new ATRCBookingRepository();
        }
        
        public List<Cust_ATRCBooking> GetATRCBookingsByCustomer(int custId)
        {
            return centerRepository.GetATRCBookingsByCustomer(custId);
        }

        public string CheckForRestChairAvailability(int atrcId, int persons, DateTime fromTime, int hours)
        {
            return centerRepository.CheckForRestChairAvailability(atrcId, persons, fromTime, hours);
        }
    }
}
