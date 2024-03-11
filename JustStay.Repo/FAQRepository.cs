using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
   public class FAQRepository
    {
        juststayDbEntities entities;

        public FAQRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<FAQ> GetFAQByAudience(int audId)
        {
            return entities.FAQs.Where(f => f.FAQAudienceId == audId).OrderBy(f=>f.Sequence).ToList();
        }

        public FAQ GetFAQById(int id)
        {
            return entities.FAQs.FirstOrDefault(q => q.FAQId == id);
        }

        public void InsertFAQ(FAQ faq)
        {
            faq.InsertedOn = DateTime.Now;
            entities.FAQs.Add(faq);
            entities.SaveChanges();
        }

        public void UpdateFAQ(FAQ faq)
        {
            faq.UpdatedOn = DateTime.Now;           
            entities.SaveChanges();
        }

        public void DeleteFAQ(int id)
        {
            var x = entities.FAQs.FirstOrDefault(i => i.FAQId == id);
            entities.FAQs.Remove(x);
            entities.SaveChanges();
        }
    }
}
