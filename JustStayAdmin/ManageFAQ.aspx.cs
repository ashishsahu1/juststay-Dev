using JustStay.Services.DTO;
using JustStayAdmin.FAQServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageFAQ : BasePage
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
                    hdFAQId.Value = Request.QueryString["Id"];
                    BindFAQ();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int faqId = int.Parse(hdFAQId.Value);

            FAQServiceClient faqRepository = new FAQServiceClient();

            FAQDto currentFAQ = new FAQDto()
            {
                FAQId = faqId,
                Question = txtquestion.Text,
                Answer = txtFAQAnswer.Value,
                Sequence = int.Parse(txtSequence.Text),
                FAQAudienceId = int.Parse(drpAudience.SelectedValue)
            };

            try
            {
                if (faqId == 0)
                    faqRepository.InsertFAQ(currentFAQ);
                else
                    faqRepository.UpdateFAQ(currentFAQ);

                Common.ShowAlertAndNavigate("FAQ saved successfully", "ListFAQ.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save FAQ failed", "ListFAQ.aspx");
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindFAQ()
        {
            FAQServiceClient faqRepository = new FAQServiceClient();

            FAQDto faq = faqRepository.GetFAQById(int.Parse(hdFAQId.Value));
            drpAudience.SelectedValue = faq.FAQAudienceId.ToString();
            txtquestion.Text = faq.Question;
            txtFAQAnswer.Value = faq.Answer;
            txtSequence.Text = faq.Sequence.ToString();
        }

        #endregion
    }
}