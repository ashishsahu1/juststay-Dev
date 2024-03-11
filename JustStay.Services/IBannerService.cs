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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBannerService" in both code and config file together.
    [ServiceContract]
    public interface IBannerService
    {
        [OperationContract]
        List<BannerDto> GetBanners();

        [OperationContract]
        BannerDto GetBannerById(int id);

        [OperationContract]
        int InsertBanner(BannerDto bannerDto);

        [OperationContract]
        void UpdateBanner(BannerDto bannerDto);

        [OperationContract]
        void UpdateBannerImage(BannerDto bannerDto);

        [OperationContract]
        void DeletBanner(int id);
    }
}
