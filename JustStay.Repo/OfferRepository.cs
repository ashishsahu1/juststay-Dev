using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class OfferRepository
    {
        juststayDbEntities entities;

        public OfferRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<Offer> GetAllOffers()
        {
            return entities.Offers.ToList();
        }

        public List<Offer> GetCustomerOffers()
        {
            return entities.Offers.Where(o => o.StartDate <= DateTime.Now &&
            (!o.EndDate.HasValue || o.EndDate.Value >= DateTime.Now)).ToList();
        }

        public Offer GetOfferById(int id)
        {
            return entities.Offers.FirstOrDefault(b => b.OfferId == id);
        }

        public int InsertOffer(Offer offer)
        {
            offer.InsertedOn = DateTime.Now;
            entities.Offers.Add(offer);
            entities.SaveChanges();
            return offer.OfferId;
        }

        public void UpdateRecord()
        {
            entities.SaveChanges();
        }

        public void DeletOffer(int id)
        {
            var x = entities.Offers.FirstOrDefault(i => i.OfferId == id);
            entities.Offers.Remove(x);
            entities.SaveChanges();
        }


    }
}
