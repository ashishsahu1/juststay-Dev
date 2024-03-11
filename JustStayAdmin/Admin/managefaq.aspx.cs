using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.FAQServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class managefaq : BL.BasePage
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
                        hdFAQId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Request.QueryString["Id"]);
                        BindFAQ();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int faqId = int.Parse(hdFAQId.Value);

                FAQServiceClient faqRepository = new FAQServiceClient();

                FAQDto currentFAQ = new FAQDto()
                {
                    FAQId = faqId,
                    Question = txtquestion.Text.Trim(),
                    Answer = txtFAQAnswer.Text.Trim(),
                    Sequence = int.Parse(txtSequence.Text.Trim()),
                    FAQAudienceId = int.Parse(drpAudience.SelectedValue)
                };


                if (faqId == 0)
                {
                    faqRepository.InsertFAQ(currentFAQ);
                    txtFAQAnswer.Text = txtquestion.Text = txtSequence.Text = string.Empty;
                    drpAudience.SelectedValue = "0";
                }
                else
                    faqRepository.UpdateFAQ(currentFAQ);

                lblfaqmsg.Text = "FAQ saved successfully";
                lblfaqmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblfaqmsg.Text = "Save FAQ failed";
                lblfaqmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindFAQ()
        {
            try
            {
                FAQServiceClient faqRepository = new FAQServiceClient();

                FAQDto faq = faqRepository.GetFAQById(int.Parse(hdFAQId.Value));
                drpAudience.SelectedValue = faq.FAQAudienceId.ToString();
                txtquestion.Text = faq.Question;
                txtFAQAnswer.Text = faq.Answer;
                txtSequence.Text = faq.Sequence.ToString();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}