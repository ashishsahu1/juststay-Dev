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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestChairProfileService" in both code and config file together.
    [ServiceContract]
    public interface IRestChairProfileService
    {
        #region " ATRC Rest Chair Profile "   
          
        [OperationContract]
        RestChairProfileDto GetRestChairProfile(int id);

        [OperationContract]
        int InsertRestchairProfile(RestChairProfileDto rcProfile);

        [OperationContract]
        void UpdateRestchairProfile(RestChairProfileDto rcProfileDto);

        [OperationContract]
        void UpdateRCProfilePolicy(RestChairProfileDto rcProfileDto);

        [OperationContract]
        List<GetAllRestChairProfile> GetAllRestChairProfile();

        #endregion

        #region " ATRC Rest Chair "     
        [OperationContract]
        void DeleteRestChair(int id);

        [OperationContract]
        List<ATRCRestChair> GetAllRestChair();

        [OperationContract]
        List<GetAllRestChairsByATRCProfile> GetAllRestChairsByATRCProfile(int profileId);

        [OperationContract]
        ATRCRestChairDTO GetATRCRestChairById(int chairId);

        [OperationContract]
        int InsertATRCRestChair(ATRCRestChairDTO chair);

        [OperationContract]
        void UpdateATRCRestChair(ATRCRestChairDTO chairDTO);

        #endregion

        #region " Chairs "

        [OperationContract]
        List<ATRCChairDto> GetAllChairsByATRCRestChair(int rcId);

        [OperationContract]
        void InsertChair(ATRCChairDto chair);

        [OperationContract]
        void UpdateChair(ATRCChairDto chairDTO);

        [OperationContract]
        void DeleteChair(int chairId);

        #endregion

    }
}
