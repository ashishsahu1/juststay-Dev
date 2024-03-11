using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.CancellationPolicySerRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class managecancelpolicy : BL.BasePage
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
                        hdPolicyId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Request.QueryString["Id"]);
                        BindPolicy();
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                Details = txtDetails.Text.Trim(),
                ApplyAfterBooking = chkApplyAfter.Checked,
                ApplyBeforeCheckIn = chkApplyBefore.Checked,
                RefundPercentage = Convert.ToDecimal(txtRefundPer.Text),
                FromTime = txtFromHours.Text + ":" + txtFromMin.Text,
                ToTime = txtToHours.Text + ":" + txtToMinutes.Text
            };

            try
            {
                if (policyId == 0)
                {
                    policyClient.InsertPolicy(policy);
                    txtDetails.Text = txtFromHours.Text = txtFromMin.Text = txtName.Text = txtRefundPer.Text = txtToHours.Text = txtToMinutes.Text = string.Empty;
                    drpTypes.SelectedValue = "0";
                }
                else
                    policyClient.UpdatePolicy(policy);

                lblcancellationplocy.Text = "Cancellation Policy saved successfully.";
                lblcancellationplocy.ForeColor = System.Drawing.Color.Green;

            }
            catch (Exception ex)
            {
                lblcancellationplocy.Text = "Save Cancellation Policy failed.";
                lblcancellationplocy.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Methods "

        private void BindPolicy()
        {
            try
            {
                CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();
                CancellationPolicyDto policy = policyClient.GetCancellationPolicyById(int.Parse(hdPolicyId.Value));
                txtName.Text = policy.PolicyName;
                drpTypes.SelectedValue = policy.PolicyType.ToString();
                txtDetails.Text = policy.Details;
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        #endregion
    }
}