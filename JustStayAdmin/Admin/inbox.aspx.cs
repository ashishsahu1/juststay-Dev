using JustStay.CommonHub;
using JustStayAdmin.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class inbox : BL.BasePage
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
                    BindMails();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            List<int> msgIds = new List<int>();
            try
            {
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
                        foreach (int id in msgIds)
                        {
                            msgClient.MoveUserMessageToTrash(id, Common.UserId);
                        }
                        BindMails();
                        lblinboxmsg.Text = "Mail(s) deleted successfully!";
                        lblinboxmsg.ForeColor = System.Drawing.Color.Green;
                    }
                    catch (Exception ex)
                    {
                        lblinboxmsg.Text = "Mail(s) deletion failed!";
                        lblinboxmsg.ForeColor = System.Drawing.Color.Red;
                        Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                    finally { msgClient.Close(); }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdInbox_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  "Private Methods"

        private void BindMails()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            try
            {
                string mode = "";
                if (Request.QueryString["Sent"] != null)
                    mode = "Sent";
                else
                {
                    mode = "AdminInbox";
                    hdFromInbox.Value = "1";
                }
                grdInbox.DataSource = msgClient.GetInboxMails("", Common.UserId, mode);
                grdInbox.DataBind();

                if (grdInbox.Rows.Count > 0)
                {
                    lnkDelete.Visible = true;
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { msgClient.Close(); }
        }

        #endregion

        public string ShortenEmail(int length, string mail)
        {
            try
            {
                mail = mail.TrimStart(',');
                if (mail.Length > length)
                    return mail.Substring(0, length - 3) + "...";
                else
                    return mail;
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return mail;
        }
    }
}