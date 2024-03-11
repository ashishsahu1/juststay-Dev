using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class LocationRepository
    {
        juststayDbEntities entities;
        public LocationRepository()
        {
            entities = new juststayDbEntities();
        }
        public Location GetLocationbyId(int lid)
        {
            return entities.Locations.FirstOrDefault(c => c.LocationId == lid);
        }

        public int InsertLocation(Location location)
        {
            location.InsertedOn = DateTime.Now;
            entities.Locations.Add(location);
            entities.SaveChanges();
            return location.LocationId;
        }
        public int UpdateLocation(Location location)
        {
            Location l = entities.Locations.FirstOrDefault(info => info.LocationId == location.LocationId);
            if (l == null) return 0;

            l.Name = location.Name;
            l.UpdatedOn = DateTime.Now;
            l.IsActive = location.IsActive;
            l.latitude = location.latitude;
            l.longitude = location.longitude;
            entities.SaveChanges();
            return l.LocationId;
        }
        public List<GetLocationDetails> LocationList(int cityid)
        {
            return entities.GetLocation(cityid).ToList();   
        }
        public int DeleteLocation(int id)
        {
            var x = entities.Locations.FirstOrDefault(i => i.LocationId == id);
            entities.Locations.Remove(x);
            return entities.SaveChanges();
        }
    }
}
