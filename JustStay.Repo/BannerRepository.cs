using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
  public  class BannerRepository
    {
        juststayDbEntities entities;

        public BannerRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<Banner> GetBanners()
        {
            return entities.Banners.ToList();
        }

        public Banner GetBannerById(int id)
        {
            return entities.Banners.FirstOrDefault(b => b.BannerId == id);
        }

        public int InsertBanner(Banner banner)
        {
            banner.InsertedOn = DateTime.Now;
            entities.Banners.Add(banner);
            entities.SaveChanges();
            return banner.BannerId;
        }

        public void UpdateRecord()
        {
            entities.SaveChanges();
        }

        public void DeletBanner(int id)
        {
            var x = entities.Banners.FirstOrDefault(i => i.BannerId == id);
            entities.Banners.Remove(x);
            entities.SaveChanges();
        }
    }
}
