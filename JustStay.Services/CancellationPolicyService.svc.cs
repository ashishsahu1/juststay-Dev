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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CancellationPolicyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CancellationPolicyService.svc or CancellationPolicyService.svc.cs at the Solution Explorer and start debugging.
    public class CancellationPolicyService : ICancellationPolicyService
    {
        CancelPolicyRepository cancelPolicyRepository;

        public CancellationPolicyService()
        {
            ATRCMapper.Initialize();
            cancelPolicyRepository = new CancelPolicyRepository();
        }

        public List<CancellationPolicyDto> GetAllCancellationPolicies()
        {
            var list = cancelPolicyRepository.GetAllCancellationPolicies();

            return Mapper.Map<List<CancellationPolicy>, List<CancellationPolicyDto>>(list);
        }

        public CancellationPolicyDto GetCancellationPolicyById(int taxId)
        {
            CancellationPolicy policy = cancelPolicyRepository.GetCancellationPolicyById(taxId);
            return Mapper.Map<CancellationPolicy, CancellationPolicyDto>(policy);
        }

        public void InsertPolicy(CancellationPolicyDto policyDto)
        {
            cancelPolicyRepository.InsertPolicy(Mapper.Map<CancellationPolicyDto, CancellationPolicy>(policyDto));
        }

        public void UpdatePolicy(CancellationPolicyDto policyDto)
        {
            CancellationPolicy policy = cancelPolicyRepository.GetCancellationPolicyById(policyDto.PolicyId);
            Mapper.Map(policyDto, policy);
            cancelPolicyRepository.UpdatePolicy();
        }

        public void DeletePolicy(int id)
        {
            cancelPolicyRepository.DeletePolicy(id);
        }

        public int UpdatePrivacyPolicy(PrivacyPolicyDto ppDto)
        {
            PrivacyPolicy pp = cancelPolicyRepository.GetPrivacyPolicy();
            pp.PrivacyPolicy1 = ppDto.PrivacyPolicy;
            new CancelPolicyRepository().UpdatePrivacyPolicy(pp);
            return pp.PrivacyPolicyId;
        }
        public PrivacyPolicyDto GetPrivacyPolicy()
        {
            var pricavy = cancelPolicyRepository.GetPrivacyPolicy();
            if (pricavy == null) return null;
            return FillPrivacy(pricavy);
        }
        private PrivacyPolicyDto FillPrivacy(PrivacyPolicy objPP)
        {
            PrivacyPolicyDto ppdto = new PrivacyPolicyDto();
            ppdto.PrivacyPolicy = objPP.PrivacyPolicy1;
            ppdto.PrivacyPolicyId = objPP.PrivacyPolicyId;
            return ppdto;
        }
    }
}
