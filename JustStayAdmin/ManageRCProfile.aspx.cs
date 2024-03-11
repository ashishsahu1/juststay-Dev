using JustStay.Services.DTO;
using JustStayAdmin.CancellationPolicySerRef;
using JustStayAdmin.RCProfileServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageRCProfile : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                txtStartDate.Attributes["readonly"] = "readonly";
                txtEndDate.Attributes["readonly"] = "readonly";
                txtFromTime.Attributes["readonly"] = txtToTime.Attributes["readonly"] = "readonly";

                if (Request.QueryString["ATRCId"] != null)
                {
                    hdATRCId.Value = Request.QueryString["ATRCId"];
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableTabs", "DisableProfileTabs();", true);
                }
                else if (Request.QueryString["Id"] != null)
                {
                    hdRCProfileId.Value = Request.QueryString["Id"];
                    BindRestChairProfile();
                    if (Request.QueryString["From"] != null)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "ShowRestChairs();", true);
                }
            }
        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            int profileId = int.Parse(hdRCProfileId.Value);
            RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();

            RestChairProfileDto profile = new RestChairProfileDto();
            profile.RestChairProfileId = profileId;
            profile.ATRCId = int.Parse(hdATRCId.Value);
            profile.ManagerName = txtManagerName.Text;
            profile.ManagerMobile = txtMobile.Text;
            profile.ATRCTelephone = txtTel.Text;
            profile.StartDate = Convert.ToDateTime(txtStartDate.Text);
            profile.EndDate = Convert.ToDateTime(txtEndDate.Text);
            profile.CheckInTime = DateTime.Parse(txtFromTime.Text).TimeOfDay;
            profile.CheckOutTime = DateTime.Parse(txtToTime.Text).TimeOfDay;
            profile.Status = (byte)(rbActive.Checked ? 1 : 0);

            if (profileId == 0)
                rcClient.InsertRestchairProfile(profile);
            else
                rcClient.UpdateRestchairProfile(profile);

            Common.ShowAlertAndNavigate("Profile saved successfully", "UpdateATRC.aspx?Id=" + hdATRCId.Value);
        }

        protected void lnkSavePolicy_Click(object sender, EventArgs e)
        {
            int profileId = int.Parse(hdRCProfileId.Value);
            RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();

            RestChairProfileDto profile = new RestChairProfileDto()
            {
                RestChairProfileId = profileId,
                ATRCPolicy = txtATRCPolicy.Value,
                CancellationPolicy = txtCancellationPolicy.Value
            };

            string policies = "";

            foreach (ListItem item in drpCancellationPolicies.Items)
            {
                if (item.Selected)
                    policies += item.Value + ",";
            }

            profile.CancellationPolicies = policies.TrimEnd(',');

            rcClient.UpdateRCProfilePolicy(profile);
        }

        protected void lnkClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateATRC.aspx?Id=" + hdATRCId.Value);
        }

        #region " Private Method "

        private void BindRestChairProfile()
        {
            int profileId = int.Parse(hdRCProfileId.Value);
            RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
            RestChairProfileDto profile = rcClient.GetRestChairProfile(profileId);

            txtManagerName.Text = profile.ManagerName;
            txtMobile.Text = profile.ManagerMobile;
            txtTel.Text = profile.ATRCTelephone;
            txtStartDate.Text = profile.StartDate.ToShortDateString();
            txtEndDate.Text = profile.EndDate.ToShortDateString();
            txtFromTime.Text = DateTime.Today.Add(profile.CheckInTime).ToString("hh:mm tt");
            txtToTime.Text = DateTime.Today.Add(profile.CheckOutTime).ToString("hh:mm tt");
            if (profile.Status == 1)
                rbActive.Checked = true;
            else
                rbInactive.Checked = true;

            txtATRCPolicy.Value = profile.ATRCPolicy;
            txtCancellationPolicy.Value = profile.CancellationPolicy;
            BindCancellationPolices();

            if (!string.IsNullOrEmpty(profile.CancellationPolicies))
            {
                string[] policies = profile.CancellationPolicies.Split(',');

                foreach (ListItem item in drpCancellationPolicies.Items)
                {
                    if (policies.Contains(item.Value))
                        item.Selected = true;
                }
            }

            hdATRCId.Value = profile.ATRCId.ToString();
        }

        private void BindCancellationPolices()
        {
            CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();
            drpCancellationPolicies.DataSource = policyClient.GetAllCancellationPolicies();
            drpCancellationPolicies.DataBind();
        }

        #endregion


    }
}
