using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CommonServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class atrcrequest : BL.BasePage
    {
        #region " Event Handelers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);

                if (!IsPostBack)
                {
                    BindApprovedList();
                    BindRejectedList();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                List<ATRCDto> listatrc = new List<ATRCDto>();
                listatrc = ATRCServiceclient.getAllATRC(0).ToList();
                if (listatrc == null) return;
                gvatrcrequest.DataSource = listatrc;
                gvatrcrequest.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvatrcrequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdApprovedATRC_PreRender(object sender, EventArgs e)
        {

        }

        protected void grdApprovedATRC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "reject")
                {
                    RejectRequest(Convert.ToInt32(e.CommandArgument));
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdRejectedATRC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "approve")
                {
                    ApproveRequest(Convert.ToInt32(e.CommandArgument));
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Methods "       

        private void BindApprovedList()
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                grdApprovedATRC.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                grdApprovedATRC.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void BindRejectedList()
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                grdRejectedATRC.DataSource = ATRCServiceclient.getAllATRC(2).ToList();
                grdRejectedATRC.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void ApproveRequest(int artcid)
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                ATRCDto atrc = ATRCServiceclient.GetATRCById(artcid);
                ATRCServiceclient.UpdateATRCStatus(artcid, 1);
                SendApprovalSMS(atrc);
                int mailSent = SendApprovedMail(atrc);

                if (mailSent != 0)
                {
                    lblatrcmsg.Text = "ATRC account Approved successfully And Mail sent to Owner";
                    lblatrcmsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblatrcmsg.Text = "Sending approval mail to Owner Failed";
                    lblatrcmsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void RejectRequest(int artcid)
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                ATRCDto atrc = ATRCServiceclient.GetATRCById(artcid);
                ATRCServiceclient.UpdateATRCStatus(artcid, 2);
                SendRejectionSMS(atrc);
                int mailSent = SendRejectiondMail(atrc);

                if (mailSent != 0)
                    lblatrcmsg.Text = "ATRC account Rejected And Mail sent to Owner";
                else
                    lblatrcmsg.Text = "Sending rejection mail to Owner Failed";
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private int SendApprovedMail(ATRCDto atrc)
        {
            int flag = 0;
            try
            {
                string Content = string.Empty;
                Content = "Dear {user}, <br /><br />Congratulations!. Your profile is approved as ATRC. <br /> Welcome to Juststay!";
                Content = Content.Replace("{user}", Convert.ToString(atrc.OwnerName));
                string[] toemail = new string[1];
                toemail[0] = Convert.ToString(atrc.Email);
                flag = Common.SendMailithBcc("contact@juststay.in", toemail, "JustStay ATRC Request Approved", "", Content, "localhost", "JustStay ATRC Request Approved");
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return flag;
        }

        private int SendRejectiondMail(ATRCDto atrc)
        {
            int flag = 0;
            try
            {
                string Content = string.Empty;
                Content = "Dear {user}, <br /><br />Thank you for your interest to join as a JustStay ATR Center. <br /> Your JustStay ATRC account has been rejected. <br />";
                Content = Content.Replace("{user}", Convert.ToString(atrc.OwnerName));
                string[] toemail = new string[1];
                toemail[0] = Convert.ToString(atrc.Email);
                flag = Common.SendMailithBcc("contact@juststay.in", toemail, "JustStay ATRC Request Rejected", "", Content, "localhost", "JustStay ATRC Request Rejected");
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return flag;
        }

        private void SendApprovalSMS(ATRCDto atrc)
        {
            try
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void SendRejectionSMS(ATRCDto atrc)
        {
            try
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Public Method "

        public string GetBookingsLink(int custId, int bookingCount)
        {
            string strhtm = "";
            try
            {
                if (bookingCount > 0)
                {
                    strhtm = "<a style='font-weight:bold' href=\"Bookings.aspx?Id=" + custId + "\">Bookings (" + bookingCount + ")</a>";
                }
                else
                    strhtm = "No Bookings";
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return strhtm;
        }

        #endregion
    }
}