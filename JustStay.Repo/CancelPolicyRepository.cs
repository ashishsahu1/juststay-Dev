using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
  public  class CancelPolicyRepository
    {
        juststayDbEntities entities;

        public CancelPolicyRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<CancellationPolicy> GetAllCancellationPolicies()
        {
            return entities.CancellationPolicies.ToList();
        }

        public CancellationPolicy GetCancellationPolicyById(int id)
        {
            return entities.CancellationPolicies.FirstOrDefault(c => c.PolicyId == id);
        }

        public void InsertPolicy(CancellationPolicy policy)
        {
            entities.CancellationPolicies.Add(policy);
            entities.SaveChanges();
        }

        public void UpdatePolicy()
        {
            entities.SaveChanges();
        }

        public void DeletePolicy(int id)
        {
            var tax = entities.CancellationPolicies.FirstOrDefault(x => x.PolicyId == id);
            entities.CancellationPolicies.Remove(tax);
            entities.SaveChanges();
        }

        public int UpdatePrivacyPolicy(PrivacyPolicy pp)
        {
            PrivacyPolicy p = entities.PrivacyPolicies.FirstOrDefault(info => info.PrivacyPolicyId == pp.PrivacyPolicyId);
            if (p == null) return 0;
            p.PrivacyPolicy1 = pp.PrivacyPolicy1;
            entities.SaveChanges();
            return p.PrivacyPolicyId;
        }
        public PrivacyPolicy GetPrivacyPolicy()
        {
            return entities.PrivacyPolicies.FirstOrDefault();
        }

    }
}
