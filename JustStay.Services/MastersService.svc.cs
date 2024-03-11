using AutoMapper;
using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MastersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MastersService.svc or MastersService.svc.cs at the Solution Explorer and start debugging.
    // [AutomapServiceBehavior]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MastersService : IMastersService
    {
        MastersRepository commonRepository;

        public MastersService()
        {
            ATRCMapper.Initialize();
            commonRepository = new MastersRepository();
        }

        #region " Cuisines "

        public List<CuisineDto> GetAllCuisines()
        {
            var list = commonRepository.GetAllCuisines();

            List<CuisineDto> cuisins = list.ConvertAll(x => new CuisineDto
            {
                CuisineId = x.CuisineId,
                Name = x.Name
            });

            return cuisins;
        }

        public void InsertCuisine(string name)
        {
            commonRepository.InsertCuisines(name);
        }

        public void UpdateCusines(CuisineDto cuisineDto)
        {
            Cuisine c = commonRepository.GetCuisineById(cuisineDto.CuisineId);
            c.Name = cuisineDto.Name;
            commonRepository.UpdateRecord();
        }

        public void DeleteCuisine(int id)
        {
            commonRepository.DeleteCuisine(id);
        }

        #endregion

        #region  " Amenities "

        public List<AmenityDto> GetAllAmenities(int catId)
        {
            var list = commonRepository.GetAllAmenities(catId);

            List<AmenityDto> amenities = list.ConvertAll(x => new AmenityDto
            {
                AmenityId = x.AmenityId,
                Name = x.Name,
                IconFileName = x.IconFileName,
                IconFileUrl = ConfigurationManager.AppSettings["AmenityImages"] + x.IconFileName
            });

            return amenities;
        }

        public AmenityDto GetAmenityById(int id)
        {
            var amenity = commonRepository.GetAmenityById(id);
            return new AmenityDto()
            {
                AmenityId = amenity.AmenityId,
                Name = amenity.Name,
                CategoryId = amenity.CategoryId,
                IconName = amenity.IconName,
                IconFileName = amenity.IconFileName
            };
        }

        public int InsertAmenity(AmenityDto dto)
        {
            Amenity am = new Amenity();
            FillAmenity(am, dto);
            return commonRepository.InsertAmenity(am);
        }

        public void UpdateAmenity(AmenityDto dto)
        {
            Amenity c = commonRepository.GetAmenityById(dto.AmenityId);
            FillAmenity(c, dto);
            commonRepository.UpdateRecord();
        }

        public void UpdateAmenityIcon(AmenityDto dto)
        {
            Amenity c = commonRepository.GetAmenityById(dto.AmenityId);
            c.IconName = dto.IconName;
            c.IconFileName = dto.IconFileName;
            commonRepository.UpdateRecord();
        }

        public void DeleteAmenity(int id)
        {
            commonRepository.DeleteAmenity(id);
        }

        private void FillAmenity(Amenity am, AmenityDto dto)
        {
            am.Name = dto.Name;
            am.CategoryId = dto.CategoryId;
        }

        #endregion

        #region  " Highlight "

        public List<HighlightDto> GetAllHighlights()
        {
            var list = commonRepository.GetAllHighlights();

            List<HighlightDto> highlights = list.ConvertAll(x => new HighlightDto
            {
                HighlightId = x.HighlightId,
                Name = x.Name
            });

            return highlights;
        }

        public void InsertHighlight(string name)
        {
            commonRepository.InsertHighlight(name);
        }

        public void UpdateHighlight(HighlightDto hightlightDto)
        {
            Highlight c = commonRepository.GetHighlightById(hightlightDto.HighlightId);
            c.Name = hightlightDto.Name;
            commonRepository.UpdateRecord();
        }

        public void DeleteHighlight(int id)
        {
            commonRepository.DeleteHighlight(id);
        }

        #endregion

        #region  " RC Type "

        public List<TypeDto> GetAllRCTypes()
        {
            var list = commonRepository.GetAllRCTypes();

            List<TypeDto> types = list.ConvertAll(x => new TypeDto
            {
                TypeId = x.RestChairTypeId,
                Name = x.Name,
                Description = x.Description,
                InsertedOn = x.InsertedOn
            });

            return types;
        }

        public TypeDto GetRCTypeId(int id)
        {
            var rcType = commonRepository.GetRCTypeById(id);
            return new TypeDto()
            {
                TypeId = rcType.RestChairTypeId,
                Name = rcType.Name,
                Description = rcType.Description
            };
        }

        public void InsertRCType(TypeDto dto)
        {
            RestChairType rcType = new RestChairType()
            {
                Name = dto.Name,
                Description = dto.Description
            };

            commonRepository.InsertRCType(rcType);
        }

        public void UpdateRCType(TypeDto dto)
        {
            RestChairType c = commonRepository.GetRCTypeById(dto.TypeId);
            c.Name = dto.Name;
            c.Description = dto.Description;
            c.UpdatedOn = DateTime.Now;
            commonRepository.UpdateRecord();
        }

        public void DeleteRCType(int id)
        {
            commonRepository.DeleteRCType(id);
        }

        #endregion

        #region " ATRC Type "

        public List<TypeDto> GetAllATRCTypes()
        {
            var list = commonRepository.GetAllATRCTypes();

            List<TypeDto> types = list.ConvertAll(x => new TypeDto
            {
                TypeId = x.ATRCTypeId,
                Name = x.Name,
                Description = x.Description,
                InsertedOn = x.InsertedOn
            });

            return types;
        }

        public TypeDto GetATRCTypeById(int id)
        {
            var rcType = commonRepository.GetATRCTypeById(id);
            return new TypeDto()
            {
                TypeId = rcType.ATRCTypeId,
                Name = rcType.Name,
                Description = rcType.Description
            };
        }

        public void InsertATRCType(TypeDto dto)
        {
            ATRCType rcType = new ATRCType()
            {
                Name = dto.Name,
                Description = dto.Description
            };

            commonRepository.InsertATRCType(rcType);
        }

        public void UpdateATRCType(TypeDto dto)
        {
            ATRCType c = commonRepository.GetATRCTypeById(dto.TypeId);
            c.Name = dto.Name;
            c.Description = dto.Description;
            c.UpdatedOn = DateTime.Now;
            commonRepository.UpdateRecord();
        }

        public void DeleteATRCType(int id)
        {
            commonRepository.DeleteATRCType(id);
        }

        #endregion

        #region " Room Type "

        public List<TypeDto> GetAllRoomTypes()
        {
            var list = commonRepository.GetAllRoomTypes();

            List<TypeDto> types = list.ConvertAll(x => new TypeDto
            {
                TypeId = x.RoomTypeId,
                Name = x.Name,
                Description = x.Description,
                InsertedOn = x.InsertedOn
            });

            return types;
        }

        public TypeDto GetRoomTypeById(int id)
        {
            var rcType = commonRepository.GetRoomTypeById(id);
            return new TypeDto()
            {
                TypeId = rcType.RoomTypeId,
                Name = rcType.Name,
                Description = rcType.Description
            };
        }

        public void InsertRoomType(TypeDto dto)
        {
            RoomType rcType = new RoomType()
            {
                Name = dto.Name,
                Description = dto.Description
            };

            commonRepository.InsertRoomType(rcType);
        }

        public void UpdateRoomType(TypeDto dto)
        {
            RoomType c = commonRepository.GetRoomTypeById(dto.TypeId);
            c.Name = dto.Name;
            c.Description = dto.Description;
            c.UpdatedOn = DateTime.Now;
            commonRepository.UpdateRecord();
        }

        public void DeleteRoomType(int id)
        {
            commonRepository.DeleteRoomType(id);
        }


        #endregion

        #region " Room Label "

        public List<RoomLabelDto> GetAllRoomLabels()
        {
            var list = commonRepository.GetAllRoomLabels();
           
            return Mapper.Map<List<RoomLabel>, List<RoomLabelDto>>(list);     
        }

        public RoomLabelDto GetRoomLabelById(int id)
        {
            var roomlabel = commonRepository.GetRoomLabelById(id);

            RoomLabelDto dto = Mapper.Map<RoomLabel, RoomLabelDto>(roomlabel);
            
            return dto;
        }

        public int InsertRoomLabel(RoomLabelDto dto)
        {
            return commonRepository.InsertRoomLabel(new RoomLabel() { Name = dto.Name });
        }

        public void UpdateRoomLabel(RoomLabelDto dto)
        {
            RoomLabel c = commonRepository.GetRoomLabelById(dto.RoomLabelId);
            c.Name = dto.Name;
            commonRepository.UpdateRecord();
        }

        public void UpdateRoomLabelIcon(RoomLabelDto dto)
        {
            RoomLabel c = commonRepository.GetRoomLabelById(dto.RoomLabelId);
            c.IconName = dto.IconName;
            c.IconFileName = dto.IconFileName;
            commonRepository.UpdateRecord();
        }

        public void DeleteRoomLabel(int id)
        {
            commonRepository.DeleteRoomLabel(id);
        }


        #endregion

    }
}
