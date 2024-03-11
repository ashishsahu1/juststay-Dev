using JustStay.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class ATRCRepository
    {
        juststayDbEntities entities;

        public ATRCRepository()
        {
            entities = new juststayDbEntities();
        }

        public int GetATRCIdByProfileID(int id)
        {
            return entities.RestChairProfiles.Where(x => x.RestChairProfileId == id).FirstOrDefault().ATRCId;
        }

        public int InsertATRC(ATRC center)
        {
            try
            {
                entities.ATRCs.Add(center);
                entities.SaveChanges();

                InsertATRCAmenity(center.ATRCId);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            int id = center.ATRCId;

            string atrcNumber = id.ToString("D4");
            center.ATRCNumber = atrcNumber;
            entities.SaveChanges();

            return id;
        }

        public ATRC GetATRCByUserId(int userid)
        {
            return (from atrc in entities.ATRCs where atrc.UserId == userid select atrc).FirstOrDefault();
        }

        public ATRC GetATRCByATRCId(int atrcid)
        {
            return (from atrc in entities.ATRCs where atrc.ATRCId == atrcid select atrc).FirstOrDefault();
        }

        public List<ATRC> GetATRCByIds(int[] ids)
        {
            return entities.ATRCs.Where(i => ids.Contains(i.ATRCId)).ToList();
        }

        public List<ATRCDetail> getAllATRC(int status)
        {
            return entities.GetAllATRCRegistarions(status).ToList();
        }

        public ATRCProfile GetATRCProfileById(int id)
        {
            return entities.GetATRCProfile(id).FirstOrDefault();
        }

        //public List<ATRCCenter> GetATRCCenters(int typeId, string mode)
        //{
        //    return entities.GetATRCCenters(typeId, mode).ToList();
        //}

        public List<ATRCCenter> SearchATRCCenters(decimal minLat, decimal maxLtd, decimal minLng, decimal maxLng, string mode, string strsearch, DateTime? date, int hour, int cityId = 0)
        {
            return entities.SearchATRCCenters(minLat, maxLtd, minLng, maxLng, cityId, mode, strsearch, date, hour).ToList();
        }

        public void UpdateATRCStatus(int artcid, int status)
        {
            ATRC atrc = entities.ATRCs.Where(a => a.ATRCId == artcid).FirstOrDefault();
            atrc.Status = status;
            entities.SaveChanges();
        }

        public void UpdateATRC()
        {
            entities.SaveChanges();
        }

        #region  " ATRC Images "

        public ATRCImage GetATRCImagesById(int id)
        {
            return entities.ATRCImages.Where(i => i.ATRCImageId == id).FirstOrDefault();
        }

        public List<ATRCImage> GetAllATRCImagesById(int id)
        {
            return entities.ATRCImages.Where(i => i.ATRCId == id).ToList();
        }

        public void InsertATRCImage(ATRCImage image)
        {
            image.InsertedOn = DateTime.Now;
            entities.ATRCImages.Add(image);
            entities.SaveChanges();
        }

        public void DeleteATRCImage(int id)
        {
            var x = entities.ATRCImages.FirstOrDefault(i => i.ATRCImageId == id);
            entities.ATRCImages.Remove(x);
            entities.SaveChanges();
        }

        public void UpdateATRCImageSD(ATRCImage atrcimage)
        {
            ATRCImage atrcImage = entities.ATRCImages.Where(a => a.ATRCImageId == atrcimage.ATRCImageId).FirstOrDefault();
            atrcImage.SDName = atrcimage.SDName;
            atrcImage.SDDes = atrcimage.SDDes;
            atrcImage.IsSD = atrcimage.IsSD;
            entities.SaveChanges();
        }

        public void UpdateATRCProfile(ATRCImage atrcimage)
        {
            ATRCImage atrcImage = entities.ATRCImages.Where(a => a.ATRCImageId == atrcimage.ATRCImageId).FirstOrDefault();
            atrcImage.IsProfile = atrcimage.IsProfile;
            entities.SaveChanges();
        }
        public List<SDImageDto> GetATRCSDImages()
        {
            return (from list in entities.ATRCImages
                    join a in entities.ATRCs on list.ATRCId equals a.ATRCId
                    where list.IsSD == true
                    select new
                    {
                        ATRCImageId = list.ATRCImageId,
                        ATRCId = list.ATRCId,
                        ContentType = list.ContentType,
                        ImageName = list.ImageName,
                        NewImageName = list.NewImageName,
                        IsSD = list.IsSD,
                        SDDes = list.SDDes,
                        SDName = list.SDName,
                        ATRCName = a.ATRCName,
                        DiningFrom = a.DiningFromTime,
                        DiningTo = a.DiningToTime,
                        Address = a.Address

                    }).ToList().Select
                    (list => new SDImageDto()
                    {
                        ATRCImageId = list.ATRCImageId,
                        ATRCId = list.ATRCId,
                        ContentType = list.ContentType,
                        ImageName = list.ImageName,
                        NewImageName = list.NewImageName,
                        IsSD = list.IsSD,
                        SDDes = list.SDDes,
                        SDName = list.SDName,
                        ATRCName = list.ATRCName,
                        DiningFromTime = Convert.ToString(list.DiningFrom),
                        DiningToTime = Convert.ToString(list.DiningTo),
                        Address = list.Address
                    }).OrderByDescending(a => a.ATRCImageId).ToList();
        }

        #endregion

        #region " ATRC Amenities "

        public ATRCAmenity GetATRCAmenityById(int amId)
        {
            return entities.ATRCAmenities.FirstOrDefault(c => c.AmenityId == amId);
        }

        public void InsertATRCAmenity(int atrcId)
        {
            ATRCAmenity am = new ATRCAmenity();
            am.ATRCId = atrcId;
            entities.ATRCAmenities.Add(am);
            entities.SaveChanges();
        }

        public void UpdateRecord()
        {
            entities.SaveChanges();
        }

        #endregion

        #region " ATRC RestChair"
        public List<GetRestChairByAtrcId> GetRestChairDetailsById(int atrcid, DateTime date, int hour)
        {
            return entities.GetRestChairByAtrcId(atrcid, date, hour).ToList();
        }
        public List<GetRestChairbyId> GetRestChair(int id)
        {
            return entities.GetRestChairbyId(id).ToList();
        }
        #endregion

        public AndroGetATRCProfile AndroGetATRCProfile(int atrcid)
        {
            return entities.AndroGetATRCProfile(atrcid).FirstOrDefault();
        }
        public int InsertATRCAccount(ATRCAccount atrcaccount)
        {
            try
            {
                entities.ATRCAccounts.Add(atrcaccount);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return atrcaccount.ATRCAccountId;
        }
        public void UpdateATRCAccount()
        {
            entities.SaveChanges();
        }
        public ATRCAccount GetATRCAccountByATRCId(int atrcid)
        {
            return (from _account in entities.ATRCAccounts where _account.ATRCId == atrcid select _account).FirstOrDefault();
        }
    }
    public partial class ATRCImage
    {
        public string ATRCName { get; set; }
    }
   
}
