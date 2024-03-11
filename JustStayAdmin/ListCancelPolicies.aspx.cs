using JustStayAdmin.CancellationPolicySerRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListCancelPolicies : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindPolicies();
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
            catch
            { }
        }

        protected void gvPolicies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int eid = Convert.ToInt32(gvPolicies.DataKeys[e.RowIndex].Value);
            DeletePolicy(eid);
            BindPolicies();

        }

        #endregion

        #region " Priavte Methods "

        private void BindPolicies()
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

        private void DeletePolicy(int policyId)
        {
            try
            {
                CancellationPolicyServiceClient policyClient = new CancellationPolicyServiceClient();
                policyClient.DeletePolicy(policyId);

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Cancellation Policy Deleted Successfully.')", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Cancellation Policy Deletion Failed.')", true);
            }
        }

        #endregion
    }
}