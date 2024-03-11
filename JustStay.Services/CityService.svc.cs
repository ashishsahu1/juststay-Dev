using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CityService.svc or CityService.svc.cs at the Solution Explorer and start debugging.
    public class CityService : ICityService
    {
        CityRepository cityRepository;
        public CityService()
        {
            cityRepository = new CityRepository();
        }
        public int InsertCity(CityDto citydto)
        {
            City city = new City();
            city.Name = citydto.Name;
            city.IsActive = citydto.IsActive;
            city.latitude = citydto.latitude;
            city.longitude = citydto.longitude;

            return cityRepository.InsertCity(city);
        }

        public CityDto GetCitybyId(int id)
        {
            var city = cityRepository.GetCitybyId(id);
            if (city == null) return null;
            return FillCity(city);
        }
        private CityDto FillCity(City objCity)
        {
            CityDto cdto = new CityDto();
            cdto.CityId = objCity.CityId;
            cdto.Name = objCity.Name;
            cdto.InsertedOn = objCity.InsertedOn;
            cdto.UpdatedOn = objCity.UpdatedOn;
            cdto.IsActive = objCity.IsActive;
            cdto.latitude = objCity.latitude;
            cdto.longitude = objCity.longitude;

            return cdto;
        }

        public List<CityDto> CityList(string mode)
        {
            var clist = cityRepository.CityList(mode).ToList(); 
            if (clist == null) return null;

            List<CityDto> cdtolist =
            clist.ConvertAll(x => new CityDto
            {
                Name = x.Name,
                CityId = x.CityId,
                InsertedOn = x.InsertedOn,
                UpdatedOn = x.UpdatedOn,
                IsActive = x.IsActive,
                latitude = x.latitude,
                longitude = x.longitude,
            });
            return cdtolist;
        }

        public int DeleteCity(int id)
        {
            return cityRepository.DeleteCity(id);
        }
        public int UpdateCity(CityDto cityDto)
        {
            City city = cityRepository.GetCitybyId(cityDto.CityId);
            city.Name = cityDto.Name;
            city.IsActive = cityDto.IsActive;
            city.UpdatedOn = cityDto.UpdatedOn;
            city.latitude = cityDto.latitude;
            city.longitude = cityDto.longitude;
            cityRepository.UpdateCity(city);
            return city.CityId;
        }
    }

