using JustStay.CommonHub;
using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace JustStay.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AndroATRCService
    {
        ATRCRepository centerRepository;
        MastersRepository masterRepository;


        public AndroATRCService()
        {
            centerRepository = new ATRCRepository();
            masterRepository = new MastersRepository();
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetATRCIdByProfileID/{id}")]
        public int GetATRCIdByProfileID(string id)
        {
            int atrcid = Convert.ToInt32(id);
            return centerRepository.GetATRCIdByProfileID(atrcid);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetATRCProfileById/{id}")]
        public ATRCProfile GetATRCProfileById(string id)
        {
            return centerRepository.GetATRCProfileById(Convert.ToInt32(id));
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SearchATRCCenters/{minLat}/{maxLtd}/{minLng}/{maxLng}/{mode}/{date}/{hour}/{cityid}")]
        public List<ATRCCenter> SearchATRCCenters(string minLat, string maxLtd, string minLng, string maxLng, string mode,string date,string hour,string cityId = "0")
        {
            List<ATRCCenter> objatrclist = new List<ATRCCenter>();
            try
            {
                DateTime? bookingdate = (DateTime?)null;
                if (date != null && date != "")
                    bookingdate = Convert.ToDateTime(date);
                else
                    bookingdate = DateTime.Now;

                decimal maximumlatitude = 0;
                if (maxLtd != "0")
                    maximumlatitude = Convert.ToDecimal(maxLtd);

                decimal maximumlongitude = 0;
                if (maxLng != "0")
                    maximumlongitude = Convert.ToDecimal(maxLng);

             objatrclist = centerRepository.SearchATRCCenters(Convert.ToDecimal(minLat), maximumlatitude, Convert.ToDecimal(minLng), maximumlongitude, mode, "", bookingdate, Convert.ToInt32(hour), 0);
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
            return objatrclist;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
              UriTemplate = "GetATRCAminities/{ATRCId}")]
        public List<AmenityDto> GetATRCAminities(string ATRCId)
        {
            List<AmenityDto> aminitylist = new List<AmenityDto>();
            masterRepository = new MastersRepository();
            var straminities = centerRepository.GetATRCByATRCId(Convert.ToInt32(ATRCId)).Amenities;
            List<string> stringList = straminities.Split(',').ToList();
            if(stringList.Count > 0)
            {
                for(int i=0;i<stringList.Count();i++)
                {
                    var amenity = masterRepository.GetAmenityById(Convert.ToInt32(stringList[i]));
                   
                    aminitylist.Add(new AmenityDto()
                    {
                        AmenityId = amenity.AmenityId,
                        Name = amenity.Name,
                        CategoryId = amenity.CategoryId,
                        IconName = amenity.IconName,
                        IconFileName = amenity.IconFileName,
                        IconFileUrl = ConfigurationManager.AppSettings["AmenityImages"] + amenity.IconFileName
                    });
                }
            }
            return aminitylist;
        }


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
            UriTemplate = "GetAllATRCImagesById/{ATRCId}")]
        public List<ATRCImageDto> GetAllATRCImagesById(string ATRCId)
        {
            var artclist = centerRepository.GetAllATRCImagesById(Convert.ToInt32(ATRCId)).ToList();
            if (artclist == null) return null;

            List<ATRCImageDto> atrcdtolist =
            artclist.ConvertAll(x => new ATRCImageDto
            {
                ATRCImageId = x.ATRCImageId,
                ATRCId = x.ATRCId,
                ImageName = x.ImageName,
                NewImageName = x.NewImageName,
                ContentType = x.ContentType,
                InsertedOn = x.InsertedOn,
                IsSD = x.IsSD,
                SDDec = x.SDDes,
                SDName = x.SDName
            });

            return atrcdtolist;
        }


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
         UriTemplate = "GetRestChairDetailsByAtrcId/{atrcid}/{date}/{hour}")]
        public List<GetRestChairByAtrcId> GetRestChairDetailsByAtrcId(string atrcid,string date,string hour)
        {
            return centerRepository.GetRestChairDetailsById(Convert.ToInt32(atrcid),Convert.ToDateTime(date),Convert.ToInt32(hour)).ToList();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GetRestchair/{ATRCRestChairId}")]
        public List<GetRestChairbyId> GetRestchair(string ATRCRestChairId)
        {
            return centerRepository.GetRestChair(Convert.ToInt32(ATRCRestChairId)).ToList();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "GetATRCSDImages")]
        public List<ATRCImageDto> GetATRCSDImages()
        {
            var alist = centerRepository.GetATRCSDImages().ToList();
            if (alist == null) return null;
                     
                List<ATRCImageDto> adtolist = alist.ConvertAll(at => new ATRCImageDto
                {
                    ATRCImageId = at.ATRCImageId,
                    ATRCId = at.ATRCId,
                    ImageName = at.ImageName,
                    NewImageName = at.NewImageName,
                    ContentType = at.ContentType,
                    InsertedOn = at.InsertedOn,
                    IsSD = at.IsSD,
                    SDDec = at.SDDes,
                    SDName = at.SDName,
                    ATRCName = at.ATRCName,
                    Address = at.Address,
                    DiningFromTime = at.DiningFromTime,
                    DiningToTime = at.DiningToTime
                });
          
            return adtolist;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AndroGetATRCProfile/{atrcid}")]
        public AndroGetATRCProfile AndroGetATRCProfile(string atrcid)
        {
            return centerRepository.AndroGetATRCProfile(Convert.ToInt32(atrcid));
        }
    }
}
