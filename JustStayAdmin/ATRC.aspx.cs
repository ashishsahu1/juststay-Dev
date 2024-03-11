using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.ATRCServiceReference;
using JustStay.Services.DTO;
using JustStayAdmin.CommonServiceReference;
using JustStay.CommonHub;

namespace JustStayAdmin
{
    public partial class ATRC : BasePage
    {
        #region " Event Handelers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindApprovedList();
                BindRejectedList();
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            List<ATRCDto> listatrc = new List<ATRCDto>();
            listatrc = ATRCServiceclient.getAllATRC(0).ToList();
            if (listatrc == null) return;
            gvatrcrequest.DataSource = listatrc;
            gvatrcrequest.DataBind();

            if (gvatrcrequest.Rows.Count > 0)
            {
                gvatrcrequest.UseAccessibleHeader = true;
                gvatrcrequest.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvatrcrequest.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void gvatrcrequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int artcid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "approve")
            {
                ApproveRequest(artcid);
            }
            if (e.CommandName == "reject")
            {
                RejectRequest(artcid);
            }
        }

        protected void grdApprovedATRC_PreRender(object sender, EventArgs e)
        {

        }

        protected void grdApprovedATRC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "reject")
            {
                RejectRequest(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void grdRejectedATRC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approve")
            {
                ApproveRequest(Convert.ToInt32(e.CommandArgument));
            }
        }

        #endregion

        #region " Private Methods "       

        private void BindApprovedList()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            grdApprovedATRC.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            grdApprovedATRC.DataBind();

            if (grdApprovedATRC.Rows.Count > 0)
            {
                grdApprovedATRC.UseAccessibleHeader = true;
                grdApprovedATRC.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdApprovedATRC.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindRejectedList()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            grdRejectedATRC.DataSource = ATRCServiceclient.getAllATRC(2).ToList();
            grdRejectedATRC.DataBind();

            if (grdRejectedATRC.Rows.Count > 0)
            {
                grdRejectedATRC.UseAccessibleHeader = true;
                grdRejectedATRC.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdRejectedATRC.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void ApproveRequest(int artcid)
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            ATRCDto atrc = ATRCServiceclient.GetATRCById(artcid);
            ATRCServiceclient.UpdateATRCStatus(artcid, 1);
            SendApprovalSMS(atrc);
            int mailSent = SendApprovedMail(atrc);

            if (mailSent != 0)
                Common.ShowAlertAndNavigate("ATRC account Approved successfully And Mail sent to Owner", "ATRC.aspx");
            else
                Common.ShowAlertAndNavigate("Sending approval mail to Owner Failed", "ATRC.aspx");
        }

        private void RejectRequest(int artcid)
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            ATRCDto atrc = ATRCServiceclient.GetATRCById(artcid);
            ATRCServiceclient.UpdateATRCStatus(artcid, 2);
            SendRejectionSMS(atrc);
            int mailSent = SendRejectiondMail(atrc);

            if (mailSent != 0)
                Common.ShowAlertAndNavigate("ATRC account Rejected And Mail sent to Owner", "ATRC.aspx");
            else
                Common.ShowAlertAndNavigate("Sending rejection mail to Owner Failed", "ATRC.aspx");
        }

        private int SendApprovedMail(ATRCDto atrc)
        {
            string Content = string.Empty;
            Content = "Dear {user}, <br /><br />Congratulations!. Your profile is approved as ATRC. <br /> Welcome to Juststay!";
            Content = Content.Replace("{user}", Convert.ToString(atrc.OwnerName));
            string[] toemail = new string[1];
            toemail[0] = Convert.ToString(atrc.Email);
            int flag = Common.SendMailithBcc("contact@juststay.in", toemail, "JustStay ATRC Request Approved", "", Content, "localhost", "JustStay ATRC Request Approved");
            return flag;
        }

        private int SendRejectiondMail(ATRCDto atrc)
        {
            string Content = string.Empty;
            Content = "Dear {user}, <br /><br />Thank you for your interest to join as a JustStay ATR Center. <br /> Your JustStay ATRC account has been rejected. <br />";
            Content = Content.Replace("{user}", Convert.ToString(atrc.OwnerName));
            string[] toemail = new string[1];
            toemail[0] = Convert.ToString(atrc.Email);
            int flag = Common.SendMailithBcc("contact@juststay.in", toemail, "JustStay ATRC Request Rejected", "", Content, "localhost", "JustStay ATRC Request Rejected");
            return flag;
        }

        private void SendApprovalSMS(ATRCDto atrc)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.ATRCApprovalTemplate);
            if (template != null)
            {
                string msg = template.Template;
                msg = msg.Replace("##name##", atrc.OwnerName);
                Common.SendSMS(atrc.Mobile, msg);
            }
        }

        private void SendRejectionSMS(ATRCDto atrc)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.ATRCRejectionTemplate);
            if (template != null)
            {
                string msg = template.Template;
                msg = msg.Replace("##name##", atrc.OwnerName);
                Common.SendSMS(atrc.Mobile, msg);
            }
        }

        #endregion

        #region " Public Method "

        public string GetBookingsLink(int custId, int bookingCount)
        {
            if (bookingCount > 0)
            {
                return "<a style='font-weight:bold' href=\"Bookings.aspx?Id=" + custId + "\">Bookings (" + bookingCount + ")</a>";
            }
            else
                return "No Bookings";
        } 

        #endregion
    }
}