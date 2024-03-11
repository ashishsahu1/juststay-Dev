using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class AttachmentRepository
    {
        juststayDbEntities entities;

        public AttachmentRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<Attachment> GetAttachementsByMaster(int masterId , string tableName)
        {
            return entities.Attachments.Where(a => a.MasterTableId == masterId && (a.TableName == tableName || "" == tableName)).ToList();
        }

        public void InsertAttachment(Attachment attachmetnt)
        {
            entities.Attachments.Add(attachmetnt);
            entities.SaveChanges();
        }

        public void DeleteAttachment(int attchmentId)
        {
            var attachment = entities.Attachments.FirstOrDefault(a => a.AttachmentId == attchmentId);
            entities.Attachments.Remove(attachment);
            entities.SaveChanges();
        }
    }
}
