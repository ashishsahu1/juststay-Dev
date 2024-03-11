using JustStay.ATRC.CommonServiceReference;
using JustStay.ATRC.MessageServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class ViewMail : BasePage
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
                    if (Request.QueryString["Id"] != null)
                    {
                        hmMessageId.Value = Request.QueryString["Id"];
                        ShowMail();
                        BindAttachment();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["From"] == null)
            {
                Response.Redirect(Request.QueryString["Mode"] != null ? "Inbox.aspx?Sent=true" : "Inbox.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("Inbox.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void lnkReply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compose.aspx?Msgid=" + hmMessageId.Value + (Request.QueryString["Mode"] != null ? "&Mode=Sent_Reply" : "&Mode=Reply"),false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void lnkForward_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compose.aspx?Msgid=" + hmMessageId.Value + "&Mode=Forward",false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            try
            {
                msgClient.MoveUserMessageToTrash(int.Parse(hmMessageId.Value), Common.UserId);
                Response.Redirect(Request.QueryString["Mode"] != null ? "Inbox.aspx?Sent=true" : "Inbox.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { msgClient.Close(); }
        }

        #endregion

        #region  " Private Methods "

        public void ShowMail()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            try
            {
                int msgId = int.Parse(hmMessageId.Value);
                MessgeInfo msg = msgClient.GetMessageById(msgId);
                lblFrom.Text = (msg.FromEmail);
                lblTo.Text = (msg.ToEmail);
                lblDate.Text = Helper.GetFormatedDate(msg.InsertedOn);

                if (!string.IsNullOrEmpty(msg.Subject))
                    lblSubject.Text = msg.Subject;
                else
                    lblSubject.Text = "No Subject";

                divMailContent.InnerHtml = msg.EmailBody;

                msgClient.MarkMailAsRead(msgId, Common.UserId);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { msgClient.Close(); }
        }

        private void BindAttachment()
        {
            CommonServiceClient commClient = new CommonServiceClient();
            try
            {
                List<AttachmentDto> attachemntlist = commClient.GetAttachementsByMaster(int.Parse(hmMessageId.Value),"").ToList();
                if (attachemntlist == null) return;
                grdattachments.DataSource = attachemntlist;
                grdattachments.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { commClient.Close(); }
        }


        #endregion

        protected void grdattachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                string docname = e.CommandArgument.ToString();
                Response.Redirect("~/Utility/DownloadAttachment.aspx?DocName=" + docname + "&Mode=" + Request.QueryString["Mode"]);
            }
        }
    }
}
