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
    public class AndroMastersService
    {
        MastersRepository masterRepository;

        public AndroMastersService()
        {
            masterRepository = new MastersRepository();
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllAmenities/{catId}")]
        public List<AmenityDto> GetAllAmenities(string catId)
        {
            var list = masterRepository.GetAllAmenities(Convert.ToInt32(catId));

            List<AmenityDto> amenities = list.ConvertAll(x => new AmenityDto
            {
                AmenityId = x.AmenityId,
                Name = x.Name,
                IconFileUrl = ConfigurationManager.AppSettings["AmenityImages"] + x.IconFileName
            });

            return amenities;
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllCuisine")]
        public List<Cuisine> GetAllCuisines()
        {
            masterRepository = new MastersRepository();
            List<Cuisine> cussinelist = new List<Cuisine>();
            cussinelist = masterRepository.GetAllCuisines();
            return cussinelist;
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllHighlights")]
        public List<Highlight> GetAllHighlights()
        {
            masterRepository = new MastersRepository();
            List<Highlight> highlist = new List<Highlight>();
            highlist = masterRepository.GetAllHighlights();
            return highlist;
            
        }
    }
}
