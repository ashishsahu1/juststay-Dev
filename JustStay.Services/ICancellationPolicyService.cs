using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICancellationPolicyService" in both code and config file together.
    [ServiceContract]
    public interface ICancellationPolicyService
    {
        [OperationContract]
        List<CancellationPolicyDto> GetAllCancellationPolicies();

        [OperationContract]
        CancellationPolicyDto GetCancellationPolicyById(int taxId);

        [OperationContract]
        void InsertPolicy(CancellationPolicyDto tax);

        [OperationContract]
        void UpdatePolicy(CancellationPolicyDto policyDto);

        [OperationContract]
        void DeletePolicy(int id);

        [OperationContract]
        int UpdatePrivacyPolicy(PrivacyPolicyDto ppDto);

        [OperationContract]
        PrivacyPolicyDto GetPrivacyPolicy();
    }
}
