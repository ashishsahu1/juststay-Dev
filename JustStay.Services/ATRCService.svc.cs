using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ATRCService" in code, svc and config file together.
// NOTE: In order to launch WCF Test Client for testing this service, please select ATRCService.svc or ATRCService.svc.cs at the Solution Explorer and start debugging.
public class ATRCService : IATRCService
{
    ATRCRepository centerRepository;

    public ATRCService()
    {
        centerRepository = new ATRCRepository();
    }

    public int GetATRCIdByProfileID(int id)
    {
        return centerRepository.GetATRCIdByProfileID(id);
    }

    public int InsertATRC(JustStay.Services.DTO.ATRCDto center)
    {
        ATRC atrc = new ATRC();
        atrc.Address = center.Address;
        atrc.ATRCId = center.ATRCId;
        atrc.ATRCName = center.ATRCName;
        atrc.Category = center.Category;
        atrc.CityId = center.CityId;
        atrc.Email = center.Email;
        atrc.LocationId = center.LocationId;
        atrc.Mobile = center.Mobile;
        atrc.OwnerName = center.OwnerName;
        atrc.Referral = center.Referral;
        atrc.StateId = center.StateId;
        atrc.Telephone = center.Telephone;
        atrc.UserId = center.UserId;
        atrc.Status = center.Status;
        atrc.Details = center.Details;
        atrc.Latitude = center.Latitude;
        atrc.Longitude = center.Longitude;
        atrc.GeoLocationName = center.GeoLocationName;
        atrc.DiningFacility = center.DiningFacility;
        atrc.DiningFromTime = center.DiningFromTime;
        atrc.DiningToTime = center.DiningToTime;
        atrc.highlights = center.highlights;
        atrc.Cuisines = center.Cuisines;
        atrc.Amenities = center.Amenities;
        atrc.ATRCTypeId = center.ATRCTypeId;
        return centerRepository.InsertATRC(atrc);
    }

    public ATRCDto GetATRCById(int id)
    {
        var artc = centerRepository.GetATRCByATRCId(id);
        if (artc == null) return null;
        return FillATRC(artc);
    }

    public ATRCDto GetATRCByUserId(int uid)
    {
        var artc = centerRepository.GetATRCByUserId(uid);
        if (artc == null) return null;
        return FillATRC(artc);
    }

    public List<ATRCDto> GetATRCByIds(int[] ids)
    {
        var artclist = centerRepository.GetATRCByIds(ids);
        List<ATRCDto> atrcdtolist =
        artclist.ConvertAll(x => new ATRCDto
        {
            Address = x.Address,
            ATRCId = x.ATRCId,
            ATRCName = x.ATRCName,
            ATRCNumber = x.ATRCNumber,
            ProfileImageNewName = x.ProfileImageNewName
        });
        return atrcdtolist;
    }

    private ATRCDto FillATRC(ATRC objATRC)
    {
        ATRCDto artcdto = new ATRCDto();
        artcdto.Address = objATRC.Address;
        artcdto.ATRCId = objATRC.ATRCId;
        artcdto.ATRCName = objATRC.ATRCName;
        artcdto.Category = objATRC.Category;
        artcdto.CityId = objATRC.CityId;
        artcdto.Email = objATRC.Email;
        artcdto.LocationId = objATRC.LocationId;
        artcdto.Mobile = objATRC.Mobile;
        artcdto.OwnerName = objATRC.OwnerName;
        artcdto.StateId = objATRC.StateId;
        artcdto.Telephone = objATRC.Telephone;
        artcdto.UserId = objATRC.UserId;
        artcdto.ATRCNumber = objATRC.ATRCNumber;
        artcdto.Status = objATRC.Status;

        return artcdto;
    }

    public List<ATRCDto> getAllATRC(int status)
    {
        var artclist = centerRepository.getAllATRC(status).ToList(); ;
        if (artclist == null) return null;

        List<ATRCDto> atrcdtolist =
        artclist.ConvertAll(x => new ATRCDto
        {
            Address = x.Address,
            ATRCId = x.ATRCId,
            ATRCName = x.ATRCName,
            ATRCNumber = x.ATRCNumber,
            Category = x.Category,
            CATEGORYNAMES = x.CATEGORYNAMES,
            CITY = x.CITY,
            CityId = x.CityId,
            Email = x.Email,
            LOCATION = x.LOCATION,
            LocationId = x.LocationId,
            Mobile = x.Mobile,
            NAMEWITHCODE = x.NAMEWITHCODE,
            OwnerName = x.OwnerName,
            Referral = x.Referral,
            REFERRALNAMES = x.REFERRALNAMES,
            StateId = x.StateId,
            Status = x.Status,
            Telephone = x.Telephone,
            UserId = x.UserId
        });
        return atrcdtolist;
    }

    public ATRCProfile GetATRCProfileById(int id)
    {
        return centerRepository.GetATRCProfileById(id);
    }

    //public List<ATRCCenter> GetATRCCenters(int typeId, string mode)
    //{
    //    return centerRepository.GetATRCCenters(typeId, mode);
    //}

    public  List<ATRCCenter> SearchATRCCenters(decimal minLat, decimal maxLtd, decimal minLng, decimal maxLng,string mode,string search,DateTime? date,int hour, int cityId = 0)
    {
        return centerRepository.SearchATRCCenters(minLat, maxLtd, minLng, maxLng,mode, search, date, hour,cityId);
    }

    public void UpdateATRCStatus(int artcid, int status)
    {
        centerRepository.UpdateATRCStatus(artcid, status);
    }

    public void UpdateATRC(ATRCDto center)
    {
        ATRC atrc = centerRepository.GetATRCByATRCId(center.ATRCId);
        atrc.ATRCName = center.ATRCName;
        atrc.Details = center.Details;
        atrc.Category = center.Category;
        atrc.Address = center.Address;
        atrc.StateId = center.StateId;
        atrc.OwnerName = center.OwnerName;
        atrc.CityId = center.CityId;
        atrc.LocationId = center.LocationId;
        atrc.Email = center.Email;
        atrc.Telephone = center.Telephone;
        atrc.Mobile = center.Mobile;
        atrc.Referral = center.Referral;
        atrc.DiningFacility = center.DiningFacility;
        atrc.DiningFromTime = center.DiningFromTime;
        atrc.DiningToTime = center.DiningToTime;
        atrc.highlights = center.highlights;
        atrc.Cuisines = center.Cuisines;
        atrc.Amenities = center.Amenities;
        atrc.Latitude = center.Latitude;
        atrc.Longitude = center.Longitude;
        atrc.GeoLocationName = center.GeoLocationName;
        atrc.ATRCTypeId = center.ATRCTypeId;

        centerRepository.UpdateATRC();
    }

    public void UpdateProfileImage(ATRCDto center)
    {
        ATRC atrc = centerRepository.GetATRCByATRCId(center.ATRCId);
        atrc.ProfileImageName = center.ProfileImageName;
        atrc.ProfileImageNewName = center.ProfileImageNewName;        
        centerRepository.UpdateATRC();
    }

    #region  " ATRC Images "

    public List<ATRCImageDto> GetAllATRCImagesById(int id)
    {
        var artclist = centerRepository.GetAllATRCImagesById(id).ToList();
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
            SDName = x.SDName,
            IsProfile = x.IsProfile
        });

        return atrcdtolist;
    }

    public void InsertATRCImage(ATRCImageDto imagedto)
    {
        ATRCImage image = new ATRCImage();
        image.ATRCId = imagedto.ATRCId;
        image.ATRCImageId = imagedto.ATRCImageId;
        image.ContentType = imagedto.ContentType;
        image.ImageName = imagedto.ImageName;
        image.InsertedOn = imagedto.InsertedOn;
        image.NewImageName = imagedto.NewImageName;
        image.IsSD = imagedto.IsSD;
        image.IsProfile = imagedto.IsProfile;

        centerRepository.InsertATRCImage(image);
    }

    public void DeleteATRCImage(int id)
    {
        centerRepository.DeleteATRCImage(id);
    }
    public void UpdateATRCImageSD(ATRCImageDto atrcimage)
    {
        ATRCImage atrc = centerRepository.GetATRCImagesById(atrcimage.ATRCImageId);
        atrc.IsSD = atrcimage.IsSD;
        atrc.SDDes = atrcimage.SDDec;
        atrc.SDName = atrcimage.SDName;
        centerRepository.UpdateATRCImageSD(atrc);
    }
    public void UpdateATRCProfile(ATRCImageDto atrcimage)
    {
        ATRCImage atrc = centerRepository.GetATRCImagesById(atrcimage.ATRCImageId);
        atrc.IsProfile= atrcimage.IsProfile;
        centerRepository.UpdateATRCProfile(atrc);
    }


    public List<ATRCImageDto> GetATRCSDImages()
    {
        var artclist = centerRepository.GetATRCSDImages().ToList();
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
            SDName = x.SDName,
            ATRCName = x.ATRCName,
            Address = x.Address,
            DiningFromTime = x.DiningFromTime,
            DiningToTime = x.DiningToTime
        });

        return atrcdtolist;
    }

    #endregion

    #region "ATRC profile "
    public List<GetRestChairByAtrcId> GetRestChairDetailsByAtrcId(int atrcid,DateTime date,int hour)
    {
        return centerRepository.GetRestChairDetailsById(atrcid,date,hour).ToList();
    }
    public List<GetRestChairbyId> GetRestchair(int id)
    {
        return centerRepository.GetRestChair(id).ToList();
    }
    #endregion

    #region " ATRC Account "
    public int InsertATRCAccount(JustStay.Services.DTO.ATRCAccountDto accountdto)
    {
        ATRCAccount _atrcaccount = new ATRCAccount();
        _atrcaccount.BankName = accountdto.BankName;
        _atrcaccount.Branch = accountdto.Branch;
        _atrcaccount.AccountName = accountdto.AccountName;
        _atrcaccount.AccountNumber = accountdto.AccountNumber;
        _atrcaccount.ATRCId = accountdto.ATRCId;
        _atrcaccount.IFSC = accountdto.IFSC;
        _atrcaccount.InsertedOn = DateTime.Now;
        return centerRepository.InsertATRCAccount(_atrcaccount);
    }
    public void UpdateATRCAccount(ATRCAccountDto accountdto)
    {
        ATRCAccount _atrcaccount = centerRepository.GetATRCAccountByATRCId(accountdto.ATRCId);
        _atrcaccount.AccountName = accountdto.AccountName;
        _atrcaccount.AccountNumber = accountdto.AccountNumber;
        _atrcaccount.ATRCId = accountdto.ATRCId;
        _atrcaccount.BankName = accountdto.BankName;
        _atrcaccount.Branch = accountdto.Branch;
        _atrcaccount.UpdatedOn = DateTime.Now;
        _atrcaccount.IFSC = accountdto.IFSC;

        centerRepository.UpdateATRCAccount();
    }
    public ATRCAccount GetATRCAccountByATRCId(int id)
    {
        return centerRepository.GetATRCAccountByATRCId(id);
    }
    #endregion
}
