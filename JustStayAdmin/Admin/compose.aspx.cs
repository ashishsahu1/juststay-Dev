using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.MessageServiceReference;
using JustStayAdmin.UserServiceReference;
using JustStayAdmin.CommonServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace JustStayAdmin.Admin
{
    public partial class compose : BL.BasePage
    {
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                sendMail();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        private void sendMail()
        {
            MessageServiceClient messageClient = new MessageServiceClient();
            UserServiceClient userClient = new UserServiceClient();
            CommonServiceClient commonClient = new CommonServiceClient();
            List<Attachment> attachmentList = new List<Attachment>();
            string newFileName = "";
            try
            {
                string[] from, to;
                int messageId;
          
            MessageDto message = new MessageDto()
            {
                Subject = txtSubject.Text,
                EmailBody = txtMessage.Value,
                InsertedBy = Common.UserId,
                MessageSource = 1
            };
            messageId = messageClient.InsertMessage(message);
            if (fileUpload1.HasFiles)
            {
                foreach (HttpPostedFile postfiles in fileUpload1.PostedFiles)
                {
                        string fileName = Path.GetFileName(postfiles.FileName);
                        AttachmentDto attchfile = new AttachmentDto();
                        attchfile.MasterTableId = messageId;
                        attchfile.TableName = Helper.MessageAdminTable;
                        newFileName = messageId + "_" + Helper.MessageAdminTable + "_" + fileName;
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
            from = saveMessageRecipient("<" + Common.UserName + "(Admin)>" + Common.UserEmail, "FROM", messageId, messageClient, userClient);

           
                Common.SendMailithBcc("contact@juststay.in", to, txtSubject.Text, "", txtMessage.Value, "", "JustStay", attachmentList);
                lblcomposemsg.Text = "Mail sent successfully";
                lblcomposemsg.ForeColor = System.Drawing.Color.Green;
                txtMessage.InnerText = txtSubject.Text = txtTo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblcomposemsg.Text = "Sending Mail Failed";
                lblcomposemsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                messageClient.Close();
                userClient.Close();
                commonClient.Close();
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
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [WebMethod]
        public static string GetAutoCompleteEmails(string term)
        {
            UserServiceClient userClient = new UserServiceClient();
            string stremail = "";
            try
            {
                stremail = userClient.GetAutoCompleteEmailList(term, "Admin");
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { userClient.Close(); }
            return stremail;
        }
    }
}