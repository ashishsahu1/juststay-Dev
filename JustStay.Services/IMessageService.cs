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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMessageService" in both code and config file together.
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        List<InboxMail> GetInboxMails(string search, int userId, string mode);

        [OperationContract]
        MessgeInfo GetMessageById(int messageId);

        [OperationContract]
        int InsertMessage(MessageDto msg);

        [OperationContract]
        void UpdateReferenceId(int newMsgId, int refMsgId);

        #region  "Message Receipent "
       
        [OperationContract]
        void InsertMessageRecipient(MessageRecipientDto rec);

        [OperationContract]
        void MoveUserMessageToTrash(int messageId, int userId);

        [OperationContract]
        void MarkMailAsRead(int msgId, int userId);

        #endregion

        #region  " Support Requests "

        [OperationContract]
        List<SupportRequestDetail> GetAdminSupportRequests();

        #endregion
    }
}
