using AutoMapper;
using JustStay.Repo;
using JustStay.Services;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommonService" in code, svc and config file together.
// NOTE: In order to launch WCF Test Client for testing this service, please select CommonService.svc or CommonService.svc.cs at the Solution Explorer and start debugging.
public class CommonService : ICommonService
{
    CommonRepository commonRepository;

    public CommonService()
    {
        commonRepository = new CommonRepository();
        ATRCMapper.Initialize();
    }

    public List<State> GetAllStates()
    {
        return commonRepository.GetAllStates();
    }

    public List<City> GetAllCities()
    {
        return commonRepository.GetAllCities();
    }

    public List<City> GetAllCitiesBySearch(string search)
    {
        return commonRepository.GetAllCitiesBySearch(search);
    }
    public List<Location> GetAlLocationsByCity(int cityId)
    {
        return commonRepository.GetAlLocationsByCity(cityId);
    }
    public List<ATRCCategory> GetAllATRCCategory()
    {
        return commonRepository.GetAllATRCCategory();
    }
    public List<ATRCSubCategory> GetAllATRCSubCategory(int categoryid)
    {
        return commonRepository.GetAllATRCSubCategory(categoryid);
    }

    public SettingDto GetSettings()
    {
        var setting = commonRepository.GetSettings();

        return new SettingDto()
        {
            SettingId = setting.SettingId,
            SmsUrl = setting.SmsUrl,
            SmsUsername = setting.SmsUsername,
            SmsPassword = setting.SmsPassword,
            SmsSenderId = setting.SmsSenderId,
            SMSBalanceUrl = setting.SMSBalanceUrl
        };
    }

    public SMSTemplateDto GetSMSTemplateByName(string name)
    {
        var template = commonRepository.GetSMSTemplateByName(name);

        return new SMSTemplateDto()
        {
            TemplateId = template.TemplateId,
            Name = template.Name,
            Template = template.Template
        };
    }

    public List<Localities> GetAutoLocalities(string search)
    {
        return commonRepository.GetAutocompleteLocalities(search);
    }

    public List<ATRCType> GetATRCTypes()
    {
        return commonRepository.GetATRCTypes();
    }
    
  
   
    public List<AttachmentDto> GetAttachementsByMaster(int masterId, string tableName)
    {
        var list = new AttachmentRepository().GetAttachementsByMaster(masterId,tableName);

        return Mapper.Map<List<Attachment>, List<AttachmentDto>>(list);
    }

    public void InsertAttachment(AttachmentDto dto)
    {
        new AttachmentRepository().InsertAttachment(Mapper.Map<AttachmentDto, Attachment>(dto));
    }

    public void DeleteAttachment(int attchmentId)
    {
        new AttachmentRepository().DeleteAttachment(attchmentId);
    }
    public void InsertRating(RatingDto rate)
    {
       new RatingRepository().InsertRating(Mapper.Map<RatingDto, Rating>(rate));
    }
    public List<RatingDto> GetAllRating(int atrcid)
    {
        var list = new RatingRepository().GetAllRating(atrcid);

        return Mapper.Map<List<Rating>, List<RatingDto>>(list);
    }
    public string Encrypt(string data)
    {
        JustStay.CommonHub.JSEDS objsec = new JustStay.CommonHub.JSEDS();
        return objsec.Encrypt(data);
    }
    public string Decrypt(string data)
    {
        JustStay.CommonHub.JSEDS objsec = new JustStay.CommonHub.JSEDS();
        return objsec.Decrypt(data);
    }
    public void Delete(int id, string mode)
    {
        commonRepository.Delete(id, mode);
    }
}

