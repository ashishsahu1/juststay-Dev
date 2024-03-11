using JustStay.CommonHub;
using JustStay.Web.BusinessLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string Content = string.Empty;
                    Content = "To Just Stay, <br /><br />Name: {name} <br /> Mobile: {mobile} <br /> Message: {msg} <br />";
                    Content = Content.Replace("{name}", Convert.ToString(txtmsgname.Text.Trim()));
                    Content = Content.Replace("{mobile}", Convert.ToString(txtmsgmobile.Text.Trim()));
                    Content = Content.Replace("{msg}", Convert.ToString(txtmsg.Text.Trim()));
                    string[] toemail = new string[1];
                    toemail[0] = "contact@juststay.in";
                    int flag = Common.SendMailithBcc("juststaypune@gmail.com", toemail, "Inquiry Message From Just Stay", "", Content);
                    if (flag != 0)
                    {
                        lblmsg.Text = "Email send successfully. We will contact you soon. Thank You";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        txtmsg.Text = string.Empty;
                        txtmsgmobile.Text = string.Empty;
                        txtmsgname.Text = string.Empty;
                    }
                    else
                    {
                        lblmsg.Text = "Email not send successfully. Please try again...";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        txtmsg.Text = string.Empty;
                        txtmsgmobile.Text = string.Empty;
                        txtmsgname.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void SaveMessage()
        {
            string[] from, to;
            int messageId;
            //MessageServiceClient messageClient = new MessageServiceClient();
            //UserServiceClient userClient = new UserServiceClient();
            //MessageDto message = new MessageDto()
            //{
            //    Subject = txtSubject.Text,
            //    EmailBody = txtMessage.Value,
            //    InsertedBy = Common.UserId,
            //    MessageSource = 1
            //};
        }
    }
}