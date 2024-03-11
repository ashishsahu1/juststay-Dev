using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class MessageRepository
    {
        juststayDbEntities entities;

        public MessageRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<InboxMail> GetInboxMails(string search, int userId, string mode)
        {
            return entities.GetInboxMails(search, userId, mode).ToList();
        }

        public MessgeInfo GetMessageById(int messageId)
        {
            return entities.GetMessgeById(messageId).FirstOrDefault();
        }

        public int InsertMessage(Message message)
        {
            message.InsertedOn = DateTime.Now;
            entities.Messages.Add(message);
            entities.SaveChanges();
            return message.MessageId;
        }

        public void UpdateReferenceID(int newMsgId, int refMsgId)
        {
            var Message = entities.Messages.Where(m => m.MessageId == newMsgId).FirstOrDefault();
            Message.RefrenceId = refMsgId;
            entities.SaveChanges();
        }


        #region  " Message Receipent "

        public void InsertMessageRecipient(MessageRecipient rec)
        {
            rec.InsertedOn = DateTime.Now;
            entities.MessageRecipients.Add(rec);
            entities.SaveChanges();
        }

        public void MoveUserMessageToTrash(int messageId, int userId)
        {
            MessageRecipient rec = entities.MessageRecipients.FirstOrDefault(r => r.MessageId == messageId && r.UserId == userId);
            rec.Trashed = true;
            rec.UpdatedOn = DateTime.Now;
            entities.SaveChanges();
        }

        public void MarkMailAsRead(int msgId, int userId)
        {
            MessageRecipient rec = entities.MessageRecipients.FirstOrDefault(r => r.MessageId == msgId && r.UserId == userId);
            if (rec != null && rec.UnRead)
            {
                rec.UnRead = false;
                rec.UpdatedOn = DateTime.Now;
                entities.SaveChanges();
            }
        }

        #endregion

        #region  " Support Requests "

        public List<SupportRequestDetail> GetAdminSupportRequests()
        {
            return entities.GetAdminSupportRequests().ToList();
        }

        #endregion

    }
}
