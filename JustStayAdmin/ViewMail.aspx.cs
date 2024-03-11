using JustStay.CommonHub;
using JustStayAdmin.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ViewMail : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    hmMessageId.Value = Request.QueryString["Id"];
                    ShowMail();
                }
            }
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["From"] == null)
                Response.Redirect(Request.QueryString["Mode"] != null ? "Inbox.aspx?Sent=true" : "Inbox.aspx");

            Response.Redirect("ListSupportRequests.aspx");
        }

        protected void lnkReply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compose.aspx?Msgid=" + hmMessageId.Value + (Request.QueryString["Mode"] != null ? "&Mode=Sent_Reply" : "&Mode=Reply"));
        }

        protected void lnkForward_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compose.aspx?Msgid=" + hmMessageId.Value + "&Mode=Forward");
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            msgClient.MoveUserMessageToTrash(int.Parse(hmMessageId.Value), Common.UserId);
            Response.Redirect(Request.QueryString["Mode"] != null ? "Inbox.aspx?Sent=true" : "Inbox.aspx");
        }

        #endregion

        #region  " Private Methods "

        public void ShowMail()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
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


        #endregion      
    }
}
