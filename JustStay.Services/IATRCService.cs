using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IATRCService" in both code and config file together.
[ServiceContract]
public interface IATRCService
{
    [OperationContract]
    int InsertATRC(ATRCDto center);

    [OperationContract]
    int GetATRCIdByProfileID(int id);

    [OperationContract]
    ATRCDto GetATRCById(int id);

    [OperationContract]
    ATRCDto GetATRCByUserId(int userid);

    [OperationContract]
    List<ATRCDto> GetATRCByIds(int[] ids);

    [OperationContract]
    List<ATRCDto> getAllATRC(int status);

    [OperationContract]
    ATRCProfile GetATRCProfileById(int id);

    //[OperationContract]
    //List<ATRCCenter> GetATRCCenters(int typeId, string mode);

    [OperationContract]
    List<ATRCCenter> SearchATRCCenters(decimal minLat, decimal maxLtd, decimal minLng, decimal maxLng, string mode,string search, DateTime? date, int hour, int cityId = 0);

    [OperationContract]
    void UpdateATRCStatus(int artcid, int status);

    [OperationContract]
    void UpdateATRC(ATRCDto center);

    [OperationContract]
    void UpdateProfileImage(ATRCDto center);

    [OperationContract]
    List<ATRCImageDto> GetAllATRCImagesById(int id);

    [OperationContract]
    void InsertATRCImage(ATRCImageDto image);

    [OperationContract]
    void DeleteATRCImage(int id);

    [OperationContract]
    void UpdateATRCImageSD(ATRCImageDto atrcimage);

    [OperationContract]
    void UpdateATRCProfile(ATRCImageDto atrcimage);

    [OperationContract]
    List<ATRCImageDto> GetATRCSDImages();

    [OperationContract]
    List<GetRestChairByAtrcId> GetRestChairDetailsByAtrcId(int atrcid,DateTime date,int hour);

    [OperationContract]
    List<GetRestChairbyId> GetRestchair(int id);

    [OperationContract]
    int InsertATRCAccount(JustStay.Services.DTO.ATRCAccountDto accountdto);

    [OperationContract]
    void UpdateATRCAccount(ATRCAccountDto accountdto);

    [OperationContract]
    ATRCAccount GetATRCAccountByATRCId(int id);

}

