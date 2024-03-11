using AutoMapper;
using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestChairProfileService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestChairProfileService.svc or RestChairProfileService.svc.cs at the Solution Explorer and start debugging.
    public class RestChairProfileService : IRestChairProfileService
    {
        RCProfileRepository rcRepo;

        public RestChairProfileService()
        {
            ATRCMapper.Initialize();
            rcRepo = new RCProfileRepository();
        }

        public RestChairProfileDto GetRestChairProfile(int profileid)
        {
            RestChairProfile rcProfile = rcRepo.GetRestChairProfileById(profileid);
            RestChairProfileDto dto = Mapper.Map<RestChairProfile, RestChairProfileDto>(rcProfile);
            return dto;
        }

        public int InsertRestchairProfile(RestChairProfileDto rcProfileDto)
        {
            RestChairProfile rcProfile = new RestChairProfile();
            FillRCProfile(rcProfile, rcProfileDto);
            return rcRepo.InsertRestchairProfile(rcProfile);
        }

        public void UpdateRestchairProfile(RestChairProfileDto rcProfileDto)
        {
            RestChairProfile rcProfile = rcRepo.GetRestChairProfileById(rcProfileDto.RestChairProfileId);
            FillRCProfile(rcProfile, rcProfileDto);
            rcRepo.UpdateDetails();
        }

        public void UpdateRCProfilePolicy(RestChairProfileDto rcProfileDto)
        {
            RestChairProfile rcProfile = rcRepo.GetRestChairProfileById(rcProfileDto.ATRCId);
            rcProfile.ATRCPolicy = rcProfileDto.ATRCPolicy;
            rcProfile.CancellationPolicy = rcProfileDto.CancellationPolicy;
            rcProfile.CancellationPolicies = rcProfileDto.CancellationPolicies;
            rcRepo.UpdateDetails();
        }

        private void FillRCProfile(RestChairProfile rcProfile, RestChairProfileDto rcProfileDto)
        {
            rcProfile.ATRCId = rcProfileDto.ATRCId;
            rcProfile.ManagerName = rcProfileDto.ManagerName;
            rcProfile.ManagerMobile = rcProfileDto.ManagerMobile;
            rcProfile.ATRCTelephone = rcProfileDto.ATRCTelephone;
            rcProfile.StartDate = rcProfileDto.StartDate;
            rcProfile.EndDate = rcProfileDto.EndDate;
            rcProfile.CheckInTime = rcProfileDto.CheckInTime;
            rcProfile.CheckOutTime = rcProfileDto.CheckOutTime;
            rcProfile.Status = rcProfileDto.Status;
            rcProfile.ATRCPolicy = rcProfileDto.ATRCPolicy;
            rcProfile.CancellationPolicies = rcProfileDto.CancellationPolicies;
        }
        public List<GetAllRestChairProfile> GetAllRestChairProfile()
        {
            return rcRepo.GetAllRestChairProfile().ToList();
        }
        #region " ATRC Rest chairs "

        public List<ATRCRestChair> GetAllRestChair()
        {
            return rcRepo.GetAllRestChair();
        }

        public List<GetAllRestChairsByATRCProfile> GetAllRestChairsByATRCProfile(int profileId)
        {
            return rcRepo.GetAllRestChairsByATRCProfile(profileId);
        }

        public ATRCRestChairDTO GetATRCRestChairById(int chairId)
        {
            ATRCRestChair chair = rcRepo.GetATRCRestChairById(chairId);
            return Mapper.Map<ATRCRestChair, ATRCRestChairDTO>(chair);
        }

        public int InsertATRCRestChair(ATRCRestChairDTO chair)
        {
            return rcRepo.InsertATRCRestChair(Mapper.Map<ATRCRestChairDTO, ATRCRestChair>(chair));
        }

        public void UpdateATRCRestChair(ATRCRestChairDTO chairDTO)
        {
            ATRCRestChair chair = rcRepo.GetATRCRestChairById(chairDTO.ATRCRestChairId);
            Mapper.Map(chairDTO, chair);
            rcRepo.UpdateDetails();
        }
        
        public void DeleteRestChair(int id)
        {
            rcRepo.DeleteRestChair(id);
        }
        
        #endregion

        #region " Chairs "

        public List<ATRCChairDto> GetAllChairsByATRCRestChair(int rcId)
        {
            var list = rcRepo.GetAllChairsByATRCRestChair(rcId);

            return Mapper.Map<List<ATRCChair>, List<ATRCChairDto>>(list);
        }

        public void InsertChair(ATRCChairDto chair)
        {
            rcRepo.InsertChair(Mapper.Map<ATRCChairDto, ATRCChair>(chair));
        }

        public void UpdateChair(ATRCChairDto chairDTO)
        {
            ATRCChair chair = rcRepo.GetChairById(chairDTO.ChairId);
            chair.ChairNumber = chairDTO.ChairNumber;
            rcRepo.UpdateDetails();
        }

        public void DeleteChair(int chairId)
        {
            rcRepo.DeleteChair(chairId);
        }


        #endregion

    }
}
