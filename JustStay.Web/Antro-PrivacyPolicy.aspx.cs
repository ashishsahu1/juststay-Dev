using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.Web.CancellationPolicyServiceReference;
using JustStay.Services.DTO;

namespace JustStay.Web
{
    public partial class Antro_PrivacyPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setPolicy();
            }
        }
        private void setPolicy()
        {
            CancellationPolicyServiceClient cpolicyclient = new CancellationPolicyServiceClient();
            try
            {
                PrivacyPolicyDto ppdto = cpolicyclient.GetPrivacyPolicy();
                if (ppdto == null) return;
                divcontent.InnerHtml = ppdto.PrivacyPolicy.Trim().ToString();
                cpolicyclient.Close();
            }
            catch (Exception ex)
            {
                cpolicyclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}