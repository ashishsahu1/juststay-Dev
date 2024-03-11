
using JustStay.ATRC.MessageServiceReference;
using JustStay.ATRC.UserServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class ManageSupport : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                string adminMail = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString();
                lblTo.Text = adminMail;
                BindMails();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SendMail();
        }
               
        #endregion

        #region  " Private Methods "

        private void SendMail()
        {
            int messageId;
            MessageServiceClient messageClient = new MessageServiceClient();
            UserServiceClient userClient = new UserServiceClient();
            string subject = txtSubject.Text;
            string msg = txtMessage.Value;

            MessageDto message = new MessageDto()
            {
                Subject = subject,
                EmailBody = msg,
                MessageSource = 2,
                InsertedBy = Common.UserId
            };

            messageId = messageClient.InsertMessage(message);

            // saving recipients 
            SaveMessageRecipient(lblTo.Text, "TO", messageId, messageClient, userClient);
            SaveMessageRecipient(Common.UserEmail, "FROM", messageId, messageClient, userClient);

            try
            {
                SendMailtoAdmin(msg, subject);
                SendMailtoUser(msg);
                Common.ShowAlertAndNavigate("Mail sent successfully", "ManageSupport.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.InnerException.Message);
                Common.ShowAlertAndNavigate("Sending Mail Failed", "ManageSupport.aspx");
            }
        }

        public bool SendMailtoAdmin(string message, string subject)
        {
            bool retVal = true;
            try
            {
                string mailTo = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString();
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "Support.html");
                emailBody = emailBody.Replace("{MESSAGEBODY}", message);
                emailBody = emailBody.Replace("{NAME}", Common.UserName);
                emailBody = emailBody.Replace("{ATRCNAME}", Common.ATRCName);

                Common.SendMail(Common.UserEmail, new string[] { mailTo }, subject, emailBody);
            }
            catch (Exception ex)
            {
                retVal = false;
            }
            return retVal;
        }

        private void SaveMessageRecipient(string email, string headerType, int messageID, MessageServiceClient messageClient, UserServiceClient userClient)
        {
            int userId;

            if (!string.IsNullOrEmpty(email))
            {
                userId = 0;

                try
                {
                    userId = (int)userClient.GetUserIdByEmailAndUserType(email, "ATRC");
                }
                catch { }

                MessageRecipientDto rec = new MessageRecipientDto()
                {
                    MessageId = messageID,
                    ReceiverType = headerType,
                    UserId = userId,
                    Email = email
                };
                messageClient.InsertMessageRecipient(rec);
            }
        }


        // Send Thank you Mail To User
        public bool SendMailtoUser(string body)
        {
            bool retVal = true;
            try
            {
                string mailFrom = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString();
                string templatePath = System.Configuration.ConfigurationManager.AppSettings["HtmlTemplates"].ToString();
                String emailBody = Helper.ReadFile(templatePath + "ThankYouSupport.html");
                emailBody = emailBody.Replace("{UserName}", Common.UserName);
                emailBody = emailBody.Replace("{Body}", body);
                Common.SendMail(mailFrom, new string[] { Common.UserEmail }, "Thank you for contacting us.", emailBody);
            }
            catch (Exception ex)
            {
                retVal = false;
            }
            return retVal;
        }

        private void BindMails()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            grdInbox.DataSource = msgClient.GetInboxMails("", Common.UserId, "ATRC_SUPPORTREQ");
            grdInbox.DataBind();

            if (grdInbox.Rows.Count > 0)
            {
                grdInbox.UseAccessibleHeader = true;
                grdInbox.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdInbox.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion
    }
}