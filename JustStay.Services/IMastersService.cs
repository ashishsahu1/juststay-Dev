using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMastersService" in both code and config file together.
    [ServiceContract]
    public interface IMastersService
    {
        [OperationContract]
        List<CuisineDto> GetAllCuisines();

        [OperationContract]
        void InsertCuisine(string name);

        [OperationContract]
        void UpdateCusines(CuisineDto cuisineDto);

        [OperationContract]
        void DeleteCuisine(int id);

        #region " Amenities "

        [OperationContract]
        List<AmenityDto> GetAllAmenities(int catId = 0);

        [OperationContract]
        AmenityDto GetAmenityById(int id);

        [OperationContract]
        int InsertAmenity(AmenityDto dto);

        [OperationContract]
        void UpdateAmenity(AmenityDto dto);

        [OperationContract]
        void UpdateAmenityIcon(AmenityDto dto);

        [OperationContract]
        void DeleteAmenity(int id);

        #endregion

        #region " Highlight "

        [OperationContract]
        List<HighlightDto> GetAllHighlights();

        [OperationContract]
        void InsertHighlight(string name);

        [OperationContract]
        void UpdateHighlight(HighlightDto hightlightDto);

        [OperationContract]
        void DeleteHighlight(int id);

        #endregion

        #region " RC Type "

        [OperationContract]
        List<TypeDto> GetAllRCTypes();

        [OperationContract]
        TypeDto GetRCTypeId(int id);

        [OperationContract]
        void InsertRCType(TypeDto dto);

        [OperationContract]
        void UpdateRCType(TypeDto dto);

        [OperationContract]
        void DeleteRCType(int id);

        #endregion

        #region " ATRCType "

        [OperationContract]
        List<TypeDto> GetAllATRCTypes();

        [OperationContract]
        TypeDto GetATRCTypeById(int id);

        [OperationContract]
        void InsertATRCType(TypeDto dto);

        [OperationContract]
        void UpdateATRCType(TypeDto dto);

        [OperationContract]
        void DeleteATRCType(int id);

        #endregion

        #region " Room Type "

        [OperationContract]
        List<TypeDto> GetAllRoomTypes();

        [OperationContract]
        TypeDto GetRoomTypeById(int id);

        [OperationContract]
        void InsertRoomType(TypeDto dto);

        [OperationContract]
        void UpdateRoomType(TypeDto dto);

        [OperationContract]
        void DeleteRoomType(int id);

        #endregion

        #region " Room Label "

        [OperationContract]
        List<RoomLabelDto> GetAllRoomLabels();

        [OperationContract]
        RoomLabelDto GetRoomLabelById(int id);

        [OperationContract]
        int InsertRoomLabel(RoomLabelDto dto);

        [OperationContract]
        void UpdateRoomLabel(RoomLabelDto dto);

        [OperationContract]
        void UpdateRoomLabelIcon(RoomLabelDto dto);

        [OperationContract]
        void DeleteRoomLabel(int id);

        #endregion

    }
}
