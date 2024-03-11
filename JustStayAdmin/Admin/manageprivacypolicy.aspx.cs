using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.CancellationPolicySerRef;

namespace JustStayAdmin.Admin
{
    public partial class manageprivacypolicy : BL.BasePage
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
                    GetPrivacyPolicy();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void GetPrivacyPolicy()
        {
            PrivacyPolicyDto ppdto = new CancellationPolicyServiceClient().GetPrivacyPolicy();
            if (ppdto == null) return;
            txtContent.Text = ppdto.PrivacyPolicy.Trim().ToString();
            hdprivacyid.Value = Convert.ToString(ppdto.PrivacyPolicyId);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int privacyid = int.Parse(hdprivacyid.Value);
                CancellationPolicyServiceClient ppClient = new CancellationPolicyServiceClient();
                PrivacyPolicyDto pp = new PrivacyPolicyDto()
                {
                    PrivacyPolicyId = privacyid,
                    PrivacyPolicy = Convert.ToString(txtContent.Text.Trim())

                };
                privacyid = ppClient.UpdatePrivacyPolicy(pp);
                lblprivacyplocymsg.Text = "Privacy Policy Updated Successfully";
                lblprivacyplocymsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblprivacyplocymsg.Text = "Privacy Policy Not Updated Successfully";
                lblprivacyplocymsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}