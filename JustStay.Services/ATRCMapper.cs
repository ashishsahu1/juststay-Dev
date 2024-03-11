using AutoMapper;
using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Web;

namespace JustStay.Services
{
    public static class ATRCMapper
    {
        private static bool _isInitialized;
        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<RestChairProfile, RestChairProfileDto>();
                    cfg.CreateMap<RoomLabel, RoomLabelDto>().ForMember(d => d.IconFileUrl, rl => rl.MapFrom(r => ConfigurationManager.AppSettings["AmenityImages"] + r.IconFileName));
                    cfg.CreateMap<Tax, TaxDto>();
                    cfg.CreateMap<TaxDto, Tax>();
                    cfg.CreateMap<CancellationPolicy, CancellationPolicyDto>();
                    cfg.CreateMap<CancellationPolicyDto, CancellationPolicy>();
                    cfg.CreateMap<ATRCRestChair, ATRCRestChairDTO>();
                    cfg.CreateMap<ATRCRestChairDTO, ATRCRestChair>();
                    cfg.CreateMap<Attachment, AttachmentDto>();
                    cfg.CreateMap<AttachmentDto, Attachment>();
                    cfg.CreateMap<ATRCChairDto, ATRCChair>();
                    cfg.CreateMap<ATRCChair, ATRCChairDto>();
                });
                _isInitialized = true;
            }
        }
    }   

}