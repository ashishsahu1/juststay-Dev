using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.Web.FAQServiceReference;

namespace JustStay.Web
{
    public partial class Andro_Faq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindFAQ();
        }
        private void BindFAQ()
        {
            FAQServiceClient faqClient = new FAQServiceClient();
            try
            {
                rptFaq.DataSource = faqClient.GetFAQByAudience(1);
                rptFaq.DataBind();
                faqClient.Close();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}