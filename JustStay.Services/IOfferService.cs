using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOfferService" in both code and config file together.
    [ServiceContract]
    public interface IOfferService
    {
        [OperationContract]
        List<OfferDto> GetAllOffers();

        [OperationContract]
        List<OfferDto> GetCustomerOffers();

        [OperationContract]
        OfferDto GetOfferById(int id);

        [OperationContract]
        int InsertOffer(OfferDto offerDto);

        [OperationContract]
        void UpdateOffer(OfferDto offerDto);

        [OperationContract]
        void UpdateOfferImage(OfferDto offerDto);

        [OperationContract]
        void DeletOffer(int id);
    }
}
