using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LocationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LocationService.svc or LocationService.svc.cs at the Solution Explorer and start debugging.
    public class LocationService : ILocationService
    {
        LocationRepository locationRepository;
        public LocationService()
        {
            locationRepository = new LocationRepository();
        }
        public int InsertLocation(LocationDto ldto)
        {
            Location location       = new Location();
            location.Name           = ldto.Name;
            location.CityId         = ldto.CityId;
            location.IsActive       = ldto.IsActive;
            location.InsertedOn     = ldto.InsertedOn;
            location.UpdatedOn      = ldto.UpdatedOn;
            location.latitude       = ldto.latitude;
            location.longitude      = ldto.longitude;

            return locationRepository.InsertLocation(location);
        }

        public LocationDto GetLocationbyId(int id)
        {
            var location = locationRepository.GetLocationbyId(id);
            if (location == null) return null;
            return FillLocation(location);
        }
        private LocationDto FillLocation(Location objlocation)
        {
            LocationDto ldto = new LocationDto();
            ldto.LocationId = objlocation.LocationId;
            ldto.CityId = objlocation.CityId;
            ldto.Name = objlocation.Name;
            ldto.InsertedOn = objlocation.InsertedOn;
            ldto.UpdatedOn = objlocation.UpdatedOn;
            ldto.IsActive = objlocation.IsActive;
            ldto.latitude = objlocation.latitude;
            ldto.longitude = objlocation.longitude;

            return ldto;
        }

        public List<LocationDto> LocationList(int cityid)
        {
            var llist = locationRepository.LocationList(cityid).ToList();
            if (llist == null) return null;

            List<LocationDto> ldtolist =
            llist.ConvertAll(x => new LocationDto
            {
                LocationId  = x.LocationId,
                Name        = x.Name,
                CityId      = x.CityId,
                CityName    = x.CityName,
                InsertedOn  = x.InsertedOn,
                UpdatedOn   = x.UpdatedOn,
                IsActive    = x.IsActive,
                latitude    = x.latitude,
                longitude   = x.longitude,
            });
            return ldtolist;
        }

        public int DeleteLocation(int id)
        {
            return locationRepository.DeleteLocation(id);
        }
        public int UpdateLocation(LocationDto locationDto)
        {
            Location location = locationRepository.GetLocationbyId(locationDto.LocationId);
            location.Name       = locationDto.Name;
            location.CityId     = locationDto.CityId;
            location.IsActive   = locationDto.IsActive;
            location.InsertedOn = locationDto.InsertedOn;
            location.UpdatedOn  = locationDto.UpdatedOn;
            location.latitude   = locationDto.latitude;
            location.longitude  = locationDto.longitude;
            locationRepository.UpdateLocation(location);
            return location.LocationId;
        }
    }

