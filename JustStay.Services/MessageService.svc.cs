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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MessageService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MessageService.svc or MessageService.svc.cs at the Solution Explorer and start debugging.
    public class MessageService : IMessageService
    {
        MessageRepository msgRepository;

        public MessageService()
        {
            msgRepository = new MessageRepository();
        }

        public List<InboxMail> GetInboxMails(string search, int userId, string mode)
        {
            return msgRepository.GetInboxMails(search, userId, mode);
        }

        public MessgeInfo GetMessageById(int messageId)
        {
            return msgRepository.GetMessageById(messageId);
        }

        public int InsertMessage(MessageDto msg)
        {
            Message message = new Message()
            {
                Subject = msg.Subject,
                EmailBody = msg.EmailBody,
                MessageSource=msg.MessageSource,
                InsertedBy=msg.InsertedBy
            };

            return msgRepository.InsertMessage(message);
        }

        public void UpdateReferenceId(int newMsgId, int refMsgId)
        {
            msgRepository.UpdateReferenceID(newMsgId, refMsgId);
        }

        public void MarkMailAsRead(int msgId, int userId)
        {
            msgRepository.MarkMailAsRead(msgId, userId);
        }

        public void InsertMessageRecipient(MessageRecipientDto rec)
        {
            MessageRecipient recipient = new MessageRecipient()
            {
                MessageId = rec.MessageId,
                ReceiverType = rec.ReceiverType,
                UserId = rec.UserId,
                Email = rec.Email,
                UnRead = true,
                Trashed = false
            };

            msgRepository.InsertMessageRecipient(recipient);
        }

        public void MoveUserMessageToTrash(int messageId, int userId)
        {
            msgRepository.MoveUserMessageToTrash(messageId, userId);
        }

        #region  " Support Requests "

        public List<SupportRequestDetail> GetAdminSupportRequests()
        {
            return msgRepository.GetAdminSupportRequests();
        }
        #endregion
    }
}
