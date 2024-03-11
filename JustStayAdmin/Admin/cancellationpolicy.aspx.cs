using JustStay.CommonHub;
using JustStayAdmin.CancellationPolicySerRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class cancellationpolicy : BL.BasePage
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
                    BindPolicies();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[3].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Cancellation Policy?')){ return false; };";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvPolicies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int eid = Convert.ToInt32(gvPolicies.DataKeys[e.RowIndex].Value);
                DeletePolicy(eid);
                BindPolicies();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Priavte Methods "

        private void BindPolicies()
        {
            try
            {
                CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();
                gvPolicies.DataSource = policyClient.GetAllCancellationPolicies();
                gvPolicies.DataBind();

                if (gvPolicies.Rows.Count > 0)
                {
                    gvPolicies.UseAccessibleHeader = true;
                    gvPolicies.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvPolicies.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void DeletePolicy(int policyId)
        {
            try
            {
                CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();
                policyClient.DeletePolicy(policyId);

                lblcpmsg.Text = "Cancellation policy deleted successfully";
                lblcpmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch(Exception ex)
            {
                lblcpmsg.Text = "Cancellation policy deletion failed.";
                lblcpmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}