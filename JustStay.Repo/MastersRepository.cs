using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class MastersRepository
    {
        juststayDbEntities entities;

        public MastersRepository()
        {
            entities = new juststayDbEntities();
        }

        #region " Cuisines "

        public List<Cuisine> GetAllCuisines()
        {
            return entities.Cuisines.ToList();
        }

        public Cuisine GetCuisineById(int id)
        {
            return entities.Cuisines.FirstOrDefault(c => c.CuisineId == id);
        }

        public void InsertCuisines(string name)
        {
            entities.Cuisines.Add(new Cuisine() { Name = name });
            entities.SaveChanges();
        }

        public void DeleteCuisine(int id)
        {
            var x = entities.Cuisines.FirstOrDefault(i => i.CuisineId == id);
            entities.Cuisines.Remove(x);
            entities.SaveChanges();
        }

        #endregion

        #region " Amenities "
       
        public List<Amenity> GetAllAmenities(int catId)
        {
            return entities.Amenities.Where(a => a.CategoryId == catId || catId == 0).ToList();
        }
     
        public Amenity GetAmenityById(int id)
        {
            return entities.Amenities.FirstOrDefault(c => c.AmenityId == id);
        }

        public int InsertAmenity(Amenity am)
        {
            entities.Amenities.Add(am);
            entities.SaveChanges();
            return am.AmenityId;
        }

        public void DeleteAmenity(int id)
        {
            var x = entities.Amenities.FirstOrDefault(i => i.AmenityId == id);
            entities.Amenities.Remove(x);
            entities.SaveChanges();
        }

        #endregion

        #region " Highlight "

        public List<Highlight> GetAllHighlights()
        {
            return entities.Highlights.ToList();
        }

        public Highlight GetHighlightById(int id)
        {
            return entities.Highlights.FirstOrDefault(c => c.HighlightId == id);
        }

        public void InsertHighlight(string name)
        {
            entities.Highlights.Add(new Highlight() { Name = name });
            entities.SaveChanges();
        }

        public void DeleteHighlight(int id)
        {
            var x = entities.Highlights.FirstOrDefault(i => i.HighlightId == id);
            entities.Highlights.Remove(x);
            entities.SaveChanges();
        }

        #endregion

        #region " RC Type"

        public List<RestChairType> GetAllRCTypes()
        {
            return entities.RestChairTypes.ToList();
        }

        public RestChairType GetRCTypeById(int id)
        {
            return entities.RestChairTypes.FirstOrDefault(c => c.RestChairTypeId == id);
        }

        public void InsertRCType(RestChairType c)
        {
            c.InsertedOn = DateTime.Now;
            entities.RestChairTypes.Add(c);
            entities.SaveChanges();
        }

        public void DeleteRCType(int id)
        {
            var x = entities.RestChairTypes.FirstOrDefault(i => i.RestChairTypeId == id);
            entities.RestChairTypes.Remove(x);
            entities.SaveChanges();
        }

        #endregion

        #region " ATRC Type "

        public List<ATRCType> GetAllATRCTypes()
        {
            return entities.ATRCTypes.ToList();
        }

        public ATRCType GetATRCTypeById(int id)
        {
            return entities.ATRCTypes.FirstOrDefault(c => c.ATRCTypeId == id);
        }

        public void InsertATRCType(ATRCType c)
        {
            c.InsertedOn = DateTime.Now;
            entities.ATRCTypes.Add(c);
            entities.SaveChanges();
        }

        public void DeleteATRCType(int id)
        {
            var x = entities.ATRCTypes.FirstOrDefault(i => i.ATRCTypeId == id);
            entities.ATRCTypes.Remove(x);
            entities.SaveChanges();
        }


        #endregion

        #region " Room Type "

        public List<RoomType> GetAllRoomTypes()
        {
            return entities.RoomTypes.ToList();
        }

        public RoomType GetRoomTypeById(int id)
        {
            return entities.RoomTypes.FirstOrDefault(c => c.RoomTypeId == id);
        }

        public void InsertRoomType(RoomType c)
        {
            c.InsertedOn = DateTime.Now;
            entities.RoomTypes.Add(c);
            entities.SaveChanges();
        }

        public void DeleteRoomType(int id)
        {
            var x = entities.RoomTypes.FirstOrDefault(i => i.RoomTypeId == id);
            entities.RoomTypes.Remove(x);
            entities.SaveChanges();
        }

        #endregion

        #region " Room Label "

        public List<RoomLabel> GetAllRoomLabels()
        {
            return entities.RoomLabels.ToList();
        }

        public RoomLabel GetRoomLabelById(int id)
        {
            return entities.RoomLabels.FirstOrDefault(c => c.RoomLabelId == id);
        }

        public int InsertRoomLabel(RoomLabel am)
        {
            entities.RoomLabels.Add(am);
            entities.SaveChanges();
            return am.RoomLabelId;
        }

        public void DeleteRoomLabel(int id)
        {
            var x = entities.RoomLabels.FirstOrDefault(i => i.RoomLabelId == id);
            entities.RoomLabels.Remove(x);
            entities.SaveChanges();
        }


        #endregion

        public void UpdateRecord()
        {
            entities.SaveChanges();
        }
    }
}
