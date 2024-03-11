using JustStay.Services.DTO;
using JustStayAdmin.CancellationPolicySerRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageCancelPolicy : BasePage
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
                    hdPolicyId.Value = Request.QueryString["Id"];
                    BindPolicy();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int policyId = int.Parse(hdPolicyId.Value);
            CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();

            CancellationPolicyDto policy = new CancellationPolicyDto()
            {
                PolicyId = policyId,
                PolicyName = txtName.Text,
                PolicyType = byte.Parse(drpTypes.SelectedValue),
                Details = txtDetails.Value,
                ApplyAfterBooking = chkApplyAfter.Checked,
                ApplyBeforeCheckIn = chkApplyBefore.Checked,
                RefundPercentage = Convert.ToDecimal(txtRefundPer.Text),
                FromTime= txtFromHours.Text +":"+ txtFromMin.Text,
                ToTime=txtToHours.Text+":"+txtToMinutes.Text
            };

            try
            {
                if (policyId == 0)
                    policyClient.InsertPolicy(policy);
                else
                    policyClient.UpdatePolicy(policy);

                Common.ShowAlertAndNavigate("Cancellation Policy saved successfully", "ListCancelPolicies.aspx");

            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Cancellation Policy failed", "ListCancelPolicies.aspx");
            }
        }

        #endregion

        #region " Private Methods "

        private void BindPolicy()
        {
            CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();
            CancellationPolicyDto policy = policyClient.GetCancellationPolicyById(int.Parse(hdPolicyId.Value));
            txtName.Text = policy.PolicyName;
            drpTypes.SelectedValue = policy.PolicyType.ToString();
            txtDetails.Value = policy.Details;
            chkApplyAfter.Checked = policy.ApplyAfterBooking;
            chkApplyBefore.Checked = policy.ApplyBeforeCheckIn;
            txtRefundPer.Text = policy.RefundPercentage.ToString();

            string[] time = policy.FromTime.Split(':');
            txtFromHours.Text = time[0];
            txtFromMin.Text = time[1];

            time = policy.ToTime.Split(':');
            txtToHours.Text = time[0];
            txtToMinutes.Text = time[1];

        }

        #endregion

    }
}