using JustStay.CommonHub;
using JustStay.Web.FAQServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class faq : System.Web.UI.Page
    {
        int AudId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["f"]))
                    {
                        AudId = Convert.ToInt32(new JustStay.CommonHub.JSEDS().Decrypt(Request.QueryString["f"]));
                    }
                    BindFAQ(AudId);
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindFAQ(int audid)
        {
            FAQServiceClient faqClient = new FAQServiceClient();
            try
            {
                rptFaq.DataSource = faqClient.GetFAQByAudience(audid);
                rptFaq.DataBind();
                faqClient.Close();
            }
            catch(Exception ex)
            {
                faqClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { faqClient.Close(); }
        }
    }
}