using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommonService" in both code and config file together.
[ServiceContract]
public interface ICommonService
{
    [OperationContract]
    List<State> GetAllStates();

    [OperationContract]
    List<City> GetAllCities();

    [OperationContract]
    List<City> GetAllCitiesBySearch(string search);

    [OperationContract]
    List<Location> GetAlLocationsByCity(int cityId);

    [OperationContract]
    List<ATRCCategory> GetAllATRCCategory();

    [OperationContract]
    List<ATRCSubCategory> GetAllATRCSubCategory(int categoryid);

    [OperationContract]
    SettingDto GetSettings();

    [OperationContract]
    SMSTemplateDto GetSMSTemplateByName(string name);

    [OperationContract]
    List<Localities> GetAutoLocalities(string search);

    [OperationContract]
    List<ATRCType> GetATRCTypes();

    #region " Attachment "

    [OperationContract]
    List<AttachmentDto> GetAttachementsByMaster(int masterId, string tableName);

    [OperationContract]
    void InsertAttachment(AttachmentDto dto);

    [OperationContract]
    void DeleteAttachment(int attchmentId);

    #endregion

    [OperationContract]
    void InsertRating(RatingDto rate);

    [OperationContract]
    List<RatingDto> GetAllRating(int atrcid);

    [OperationContract]
    string Encrypt(string data);

    [OperationContract]
    string Decrypt(string data);

    [OperationContract]
    void Delete(int id, string mode);

}

