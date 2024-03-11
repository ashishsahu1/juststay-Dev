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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OfferService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OfferService.svc or OfferService.svc.cs at the Solution Explorer and start debugging.
    public class OfferService : IOfferService
    {
        OfferRepository offerRepository;

        public OfferService()
        {
            offerRepository = new OfferRepository();
        }

        public List<OfferDto> GetAllOffers()
        {
            var offers = offerRepository.GetAllOffers();
            List<OfferDto> offerList = new List<OfferDto>();
            foreach (Offer o in offers)
            {
                OfferDto dto = new OfferDto();
                FillOfferDto(dto, o);
                offerList.Add(dto);
            }

            return offerList;
        }

        public List<OfferDto> GetCustomerOffers()
        {
            var offers = offerRepository.GetCustomerOffers();
            List<OfferDto> offerList = new List<OfferDto>();
            foreach (Offer o in offers)
            {
                OfferDto dto = new OfferDto();
                FillOfferDto(dto, o);
                offerList.Add(dto);
            }

            return offerList;
        }

        public OfferDto GetOfferById(int id)
        {
            Offer offer = offerRepository.GetOfferById(id);
            OfferDto offerDto = new OfferDto();
            FillOfferDto(offerDto, offer);
            return offerDto;
        }

        public int InsertOffer(OfferDto offerDto)
        {
            Offer offer = new Offer();
            FillOffer(offer, offerDto);
            return offerRepository.InsertOffer(offer);
        }

        public void UpdateOffer(OfferDto offerDto)
        {
            Offer offer = offerRepository.GetOfferById(offerDto.OfferId);
            FillOffer(offer, offerDto);
            offerRepository.UpdateRecord();
        }

        public void UpdateOfferImage(OfferDto offerDto)
        {
            Offer offer = offerRepository.GetOfferById(offerDto.OfferId);
            offer.OfferImage = offerDto.OfferImage;
            offer.OfferImgNewName = offerDto.OfferImgNewName;
            offerRepository.UpdateRecord();
        }

        public void DeletOffer(int id)
        {
            offerRepository.DeletOffer(id);
        }

        #region "  Private MEthods "

        private void FillOffer(Offer offer, OfferDto offerDto)
        {
            offer.Heading = offerDto.Heading;
            offer.ShortDetail = offerDto.ShortDetail;
            offer.SubHeading = offerDto.SubHeading;
            offer.Details = offerDto.Details;
            offer.StartDate = offerDto.StartDate;
            offer.EndDate = offerDto.EndDate;
        }

        private void FillOfferDto(OfferDto offer, Offer offerDto)
        {
            offer.OfferId = offerDto.OfferId;
            offer.Heading = offerDto.Heading;
            offer.ShortDetail = offerDto.ShortDetail;
            offer.SubHeading = offerDto.SubHeading;
            offer.Details = offerDto.Details;
            offer.OfferImage = offerDto.OfferImage;
            offer.OfferImgNewName = offerDto.OfferImgNewName;
            offer.StartDate = offerDto.StartDate;
            offer.EndDate = offerDto.EndDate;
        }

        #endregion

    }
}
