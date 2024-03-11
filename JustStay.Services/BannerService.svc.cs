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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BannerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BannerService.svc or BannerService.svc.cs at the Solution Explorer and start debugging.
    public class BannerService : IBannerService
    {
        BannerRepository bannerRepository;

        public BannerService()
        {
            bannerRepository = new BannerRepository();
        }

        public List<BannerDto> GetBanners()
        {
            var banners = bannerRepository.GetBanners();

            List<BannerDto> bannerList =
           banners.ConvertAll(banner => new BannerDto
           {
               BannerId = banner.BannerId,
               Heading = banner.Heading,
               SubHeading = banner.SubHeading,
               Description = banner.Description,
               ImageName = banner.ImageName,
               ImageNewName = banner.ImageNewName
           });

            return bannerList;
        }

        public BannerDto GetBannerById(int id)
        {
            var banner = bannerRepository.GetBannerById(id);
            BannerDto bannerDTO = new BannerDto()
            {
                BannerId = banner.BannerId,
                Heading = banner.Heading,
                SubHeading = banner.SubHeading,
                Description = banner.Description,
                ImageName = banner.ImageName,
                ImageNewName = banner.ImageNewName
            };
            return bannerDTO;
        }

        public int InsertBanner(BannerDto bannerDto)
        {
            Banner banner = new Banner();
            FillBanner(banner, bannerDto);
            return bannerRepository.InsertBanner(banner);
        }

        public void UpdateBanner(BannerDto bannerDto)
        {
            Banner banner = bannerRepository.GetBannerById(bannerDto.BannerId);
            FillBanner(banner, bannerDto);
            bannerRepository.UpdateRecord();
        }

        public void UpdateBannerImage(BannerDto bannerDto)
        {
            Banner banner = bannerRepository.GetBannerById(bannerDto.BannerId);
            banner.ImageName = bannerDto.ImageName;
            banner.ImageNewName = bannerDto.ImageNewName;
            bannerRepository.UpdateRecord();
        }

        public void DeletBanner(int id)
        {
            bannerRepository.DeletBanner(id);
        }

        private void FillBanner(Banner banner, BannerDto bannerDto)
        {
            banner.Heading = bannerDto.Heading;
            banner.SubHeading = bannerDto.SubHeading;
            banner.Description = bannerDto.Description;
        }
    }
}
