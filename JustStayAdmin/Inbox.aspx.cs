using JustStayAdmin.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class Inbox : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindMails();
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            List<int> msgIds = new List<int>();

            foreach (GridViewRow grow in grdInbox.Rows)
            {
                CheckBox chkdel = (CheckBox)grow.FindControl("cbSelect");
                if (chkdel.Checked)
                {
                    int quotId = Convert.ToInt32(grdInbox.DataKeys[grow.RowIndex].Value);
                    msgIds.Add(quotId);
                }
            }

            if (msgIds.Any())
            {
                try
                {
                    MessageServiceClient msgClient = new MessageServiceClient();

                    foreach (int id in msgIds)
                    {
                        msgClient.MoveUserMessageToTrash(id, Common.UserId);
                    }

                    BindMails();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Mail(s) deleted successfully!')", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Mail(s) deletion failed!')", true);
                }
            }
        }

        protected void grdInbox_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InboxMail mail = (InboxMail)e.Row.DataItem;
                if (mail.UnRead)
                {
                    e.Row.CssClass = "textbold";
                }
            }
        }

        #endregion

        #region  "Private Methods"

        private void BindMails()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            string mode = "";
            if (Request.QueryString["Sent"] != null)
                mode = "Sent";
            else
                mode = "AdminInbox";
            grdInbox.DataSource = msgClient.GetInboxMails("", Common.UserId, mode);
            grdInbox.DataBind();

            if (grdInbox.Rows.Count > 0)
            {
                grdInbox.UseAccessibleHeader = true;
                grdInbox.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdInbox.FooterRow.TableSection = TableRowSection.TableFooter;
                lnkDelete.Visible = true;
            }
        }

        #endregion
               
        public string ShortenEmail(int length, string mail)
        {
            mail = mail.TrimStart(',');
            if (mail.Length > length)
                return mail.Substring(0, length - 3) + "...";
            else
                return mail;
        }    
    }
}