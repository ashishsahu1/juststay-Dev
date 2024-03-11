using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class RCProfileRepository
    {
        juststayDbEntities entities;

        public RCProfileRepository()
        {
            entities = new juststayDbEntities();
        }

        public int InsertRestchairProfile(RestChairProfile rcProfile)
        {
            rcProfile.InsertedOn = DateTime.Now;
            entities.RestChairProfiles.Add(rcProfile);
            entities.SaveChanges();

            return rcProfile.RestChairProfileId;
        }

        public RestChairProfile GetRestChairProfileById(int profileId)
        {
            return entities.RestChairProfiles.FirstOrDefault(r => r.RestChairProfileId == profileId);
        }

        public void UpdateDetails()
        {
            entities.SaveChanges();
        }

        public List<GetAllRestChairProfile> GetAllRestChairProfile()
        {
            return entities.GetAllRestChairProfile().ToList();
        }
        #region  " ATRC Rest Chairs "

        public List<GetAllRestChairsByATRCProfile> GetAllRestChairsByATRCProfile(int profileId)
        {
            return entities.GetAllRestChairsByATRCProfile(profileId).ToList();
        }

        public ATRCRestChair GetATRCRestChairById(int chairId)
        {
            return entities.ATRCRestChairs.FirstOrDefault(c => c.ATRCRestChairId == chairId);
        }

        public int InsertATRCRestChair(ATRCRestChair chair)
        {
            entities.ATRCRestChairs.Add(chair);
            entities.SaveChanges();
            return chair.ATRCRestChairId;
        }
        public List<ATRCRestChair> GetAllRestChair()
        {
            return entities.ATRCRestChairs.ToList();
        }

        #endregion

        #region " Chairs "

        public List<ATRCChair> GetAllChairsByATRCRestChair(int rcId)
        {
            return entities.ATRCChairs.Where(a => a.ATRCRestChairId == rcId).ToList();
        }

        public ATRCChair GetChairById(int id)
        {
            return entities.ATRCChairs.FirstOrDefault(a => a.ChairId == id);
        }

        public void InsertChair(ATRCChair chair)
        {
            entities.ATRCChairs.Add(chair);
            entities.SaveChanges();
        }

        public void DeleteChair(int chairId)
        {
            ATRCChair chair = entities.ATRCChairs.FirstOrDefault(c => c.ChairId == chairId);
            entities.ATRCChairs.Remove(chair);
            entities.SaveChanges();
        }

        public void DeleteRestChair(int id)
        {
            var record = entities.ATRCRestChairs.Find(id);
            entities.ATRCRestChairs.Remove(record);
            entities.SaveChanges();
        }

        #endregion

    }
}
