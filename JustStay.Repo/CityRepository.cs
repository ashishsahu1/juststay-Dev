using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class CityRepository
    {
        juststayDbEntities entities;
        public CityRepository()
        {
            entities = new juststayDbEntities();
        }
        public City GetCitybyId(int cid)
        {
            return entities.Cities.FirstOrDefault(c => c.CityId == cid);
        }

        public int InsertCity(City city)
        {
            city.InsertedOn = DateTime.Now;
            entities.Cities.Add(city);
            entities.SaveChanges();
            return city.CityId;
        }
        public int UpdateCity(City Cty)
        {
            City c = entities.Cities.FirstOrDefault(info => info.CityId == Cty.CityId);
            if (c == null) return 0;

            c.Name = Cty.Name;
            c.UpdatedOn = DateTime.Now;
            c.IsActive = Cty.IsActive;
            c.latitude = Cty.latitude;
            c.longitude = Cty.longitude;
            entities.SaveChanges();
            return c.CityId;
        }
        public List<City> CityList(string mode)
        {
            if(mode == "inactive")
            return (from list in entities.Cities where list.IsActive == false select list).ToList();
            else if(mode == "active")
                return (from list in entities.Cities where list.IsActive == true select list).ToList();
            else
                return (from list in entities.Cities select list).ToList();
        }
        public int DeleteCity(int id)
        {
            var x = entities.Cities.FirstOrDefault(i => i.CityId == id);
            entities.Cities.Remove(x);
            return entities.SaveChanges();
        }
    }
}
