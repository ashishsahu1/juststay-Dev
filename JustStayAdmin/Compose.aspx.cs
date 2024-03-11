using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.CommonServiceReference;
using JustStayAdmin.MessageServiceReference;
using JustStayAdmin.UserServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class Compose : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                if (Request.QueryString["Msgid"] != null && Request.QueryString["Mode"] != null)
                    SetMailData();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            sendMail();
        }

        #endregion

        private void sendMail()
        {
            string[] from, to;
            int messageId;
            List<Attachment> attachmentList = new List<Attachment>();
            MessageServiceClient messageClient = new MessageServiceClient();
            UserServiceClient userClient = new UserServiceClient();
            CommonServiceClient commoClient = new CommonServiceClient();
            MessageDto message = new MessageDto()
            {
                Subject = txtSubject.Text,
                EmailBody = txtMessage.Value,
                InsertedBy = Common.UserId,
                MessageSource = 1
            };
            messageId = messageClient.InsertMessage(message);
            // Check File Prasent or not  
            if (fileUpload1.HasFiles)
            {
                foreach (HttpPostedFile postfiles in fileUpload1.PostedFiles)
                {
                    string newFileName = "";
                    string fileName = Path.GetFileName(postfiles.FileName);
                    postfiles.SaveAs(Path.Combine(Server.MapPath("~/EmailAttachments"), fileName));
                    Attachment attachment = new Attachment(Path.Combine(Server.MapPath("~/EmailAttachments"), fileName));
                    attachmentList.Add(attachment);

                    //save attachment in DB
                    AttachmentDto image = new AttachmentDto();
                    image.MasterTableId = messageId;
                    image.TableName = Helper.MessageAtrcTable;

                    newFileName = messageId + "_" + Helper.MessageAtrcTable + "_" + fileName;

                    image.DocName = fileName.ToString();
                    image.DocNewName = newFileName;
                    commoClient.InsertAttachment(image);
                }
            }


            if (Request.QueryString["Mode"] == "Reply")
                messageClient.UpdateReferenceId(messageId, Convert.ToInt32(Request.QueryString["Msgid"].ToString()));//Update ReferenceID in case of Reply

            // saving recipients 
            to = saveMessageRecipient(txtTo.Text, "TO", messageId, messageClient, userClient);
            from = saveMessageRecipient("<" + Common.UserName + "(Admin)>" + Common.UserEmail, "FROM", messageId, messageClient, userClient);

            try
            {
                Common.SendMailithBcc("contact@juststay.in", to, txtSubject.Text, "", txtMessage.Value, "", "JustStay", attachmentList);
                Common.ShowAlertAndNavigate("Mail sent successfully", "Inbox.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.InnerException.Message);
                Common.ShowAlertAndNavigate("Sending Mail Failed", "Inbox.aspx");
            }
        }

        private string[] saveMessageRecipient(string emails, string headerType, int messageID, MessageServiceClient messageClient, UserServiceClient userClient)
        {
            string email, userType = "";
            int userId;
            string[] emailIds = new string[0];

            if (!string.IsNullOrEmpty(emails))
            {
                string[] aryEmails = emails.Replace(" ", "").Split(',');
                emailIds = new string[aryEmails.Length];

                for (int i = 0; i < aryEmails.Length; i++)
                {
                    email = aryEmails[i].Trim();
                    if (!string.IsNullOrEmpty(email))
                    {
                        userType = Common.GetUserType(email);
                        email = email.RemoveHTMLTag();
                        emailIds[i] = email;
                        userId = 0;
                        try
                        {
                            userId = (int)userClient.GetUserIdByEmailAndUserType(email, userType);
                        }
                        catch { }

                        MessageRecipientDto rec = new MessageRecipientDto()
                        {
                            MessageId = messageID,
                            ReceiverType = headerType,
                            UserId = userId,
                            Email = aryEmails[i]
                        };
                        messageClient.InsertMessageRecipient(rec);
                    }
                }
            }

            return emailIds;
        }

        private void SetMailData()
        {
            hdMessageId.Value = Request.QueryString["Msgid"];
            int MsgId = int.Parse(hdMessageId.Value);
            string Mode = "";
            string body = "";
            string to, from, subject, messageContent = "";
            Mode = Request.QueryString["Mode"];
            MessageServiceClient msgClient = new MessageServiceClient();
            MessgeInfo msg = msgClient.GetMessageById(MsgId);

            from = (msg.FromEmail);
            to = (msg.ToEmail);

            messageContent = msg.EmailBody;
            subject = msg.Subject;

            if (Mode == "Forward")
            {
                body = "<br/><br/>--------Fowarded Message-------<br/><br/>From : " + from + "<br/>Date : " + Helper.GetFormatedDate(msg.InsertedOn) + "";
                body = body + "<br/>Subject : " + subject;
                if (to != "")
                    body = body + "<br/>To : " + to;

            }
            else if (Mode == "Reply")
            {
                txtTo.Text = from;
                txtSubject.Text = "Re : " + subject;
                body = "On " + Helper.GetFormatedDate(msg.InsertedOn) + ",&lt;" + from + "&gt;  wrote:";

            }
            else if (Mode == "Sent_Reply")
            {
                txtTo.Text = to;
                txtSubject.Text = "Re : " + subject;
                body = "On " + Helper.GetFormatedDate(msg.InsertedOn) + ",&lt;" + from + "&gt;  wrote:";
            }

            txtMessage.Value = body + messageContent;
        }

        [WebMethod]
        public static string GetAutoCompleteEmails(string term)
        {
            UserServiceClient userClient = new UserServiceClient();
            return userClient.GetAutoCompleteEmailList(term, "Admin");
        }

    }
}