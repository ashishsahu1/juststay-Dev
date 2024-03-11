using JustStay.ATRC.MessageServiceReference;
using JustStay.ATRC.UserServiceReference;
using JustStay.ATRC.CommonServiceReference;
using JustStay.CommonHub;
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
        MessageServiceClient messageClient;
        UserServiceClient userClient;
        CommonServiceClient commonClient;
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);

                if (!IsPostBack)
                {
                    if (Request.QueryString["Msgid"] != null && Request.QueryString["Mode"] != null)
                        SetMailData();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            sendMail();
        }

        #endregion

        private void sendMail()
        {
            commonClient = new CommonServiceClient();
            try
            {
                string[] from, to;
                int messageId = 0;
                string newFileName = "";
                messageClient = new MessageServiceClient();
                userClient = new UserServiceClient();
                MessageDto message = new MessageDto()
                {
                    Subject = txtSubject.Text,
                    EmailBody = txtMessage.Value,
                    InsertedBy = Common.UserId,
                    MessageSource = 1
                };
                messageId = messageClient.InsertMessage(message);
                List<Attachment> attachmentList = new List<Attachment>();

                // Check File Prasent or not  
                if (fileUpload1.HasFiles)
                {
                    foreach (HttpPostedFile postfiles in fileUpload1.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postfiles.FileName);
                        AttachmentDto attchfile = new AttachmentDto();
                        attchfile.MasterTableId = messageId;
                        attchfile.TableName = Helper.MessageAtrcTable;
                        newFileName = messageId + "_" + Helper.MessageAtrcTable + "_" + fileName;
                        attchfile.DocName = fileName.ToString();
                        attchfile.DocNewName = newFileName;
                        postfiles.SaveAs(Path.Combine(Server.MapPath("~/EmailAttachments"), newFileName));
                        Attachment attachment = new Attachment(Path.Combine(Server.MapPath("~/EmailAttachments"), newFileName));
                        attachmentList.Add(attachment);
                        commonClient.InsertAttachment(attchfile);
                    }
                }
                if (Request.QueryString["Mode"] == "Reply")
                    messageClient.UpdateReferenceId(messageId, Convert.ToInt32(Request.QueryString["Msgid"].ToString()));//Update ReferenceID in case of Reply

                // saving recipients 
                to = saveMessageRecipient(txtTo.Text, "TO", messageId, messageClient, userClient);
                from = saveMessageRecipient("<" + Common.UserName + "(ATRC)>" + Common.UserEmail, "FROM", messageId, messageClient, userClient);

              
                int emailresponse = Common.SendMail("contact@juststay.in", to, txtSubject.Text, txtMessage.Value, attachmentList);
                if(emailresponse != 0)
                    Common.ShowAlertAndNavigate("Mail sent successfully", "Inbox.aspx");
                else
                    Common.ShowAlertAndNavigate("Sending Mail Failed", "Inbox.aspx");
               
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                messageClient.Close();
                userClient.Close();
            }
        }

        private string[] saveMessageRecipient(string emails, string headerType, int messageID, MessageServiceClient messageClient, UserServiceClient userClient)
        {
            string email, userType = "";
            int userId;
            string[] emailIds = new string[0];
            try
            {

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
                            email = Common.RemoveHTMLTag(email);
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
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
          
            return emailIds;
        }

        private void SetMailData()
        {
            try
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [WebMethod]
        public static string GetAutoCompleteEmails(string term)
        {
            UserServiceClient userClient = new UserServiceClient();
            return userClient.GetAutoCompleteEmailList(term, "ATRC");
        }

    }
}