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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IATRCBookingService" in both code and config file together.
    [ServiceContract]
    public interface IATRCBookingService
    {
        [OperationContract]
        List<Cust_ATRCBooking> GetATRCBookingsByCustomer(int custId);

        [OperationContract]
        string CheckForRestChairAvailability(int atrcId, int persons, DateTime fromTime, int hours);
    }
}
