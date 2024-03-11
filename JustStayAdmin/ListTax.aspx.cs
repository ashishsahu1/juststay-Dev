using JustStayAdmin.TaxServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListTax : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindTaxes();
            }
        }

        protected void gvTaxes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int eid = Convert.ToInt32(gvTaxes.DataKeys[e.RowIndex].Value);           
            DeleteTax(eid);
            BindTaxes();
        }

        protected void gvTaxes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Tax?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region " Private Method "

        private void BindTaxes()
        {
            TaxServiceClient taxClient = new TaxServiceClient();
            gvTaxes.DataSource = taxClient.GetAllTaxes();
            gvTaxes.DataBind();

            if (gvTaxes.Rows.Count > 0)
            {
                gvTaxes.UseAccessibleHeader = true;
                gvTaxes.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvTaxes.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void DeleteTax(int taxId)
        {
            try
            {
                TaxServiceClient taxClient = new TaxServiceClient();
                taxClient.DeleteTax(taxId);
               
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Tax Deleted Successfully.')", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Tax Deletion Failed.')", true);
            }
        }

        #endregion
    }
}