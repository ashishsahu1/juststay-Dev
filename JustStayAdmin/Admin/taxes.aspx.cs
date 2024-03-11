using JustStay.CommonHub;
using JustStayAdmin.TaxServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class taxes : BL.BasePage
    {
        TaxServiceClient taxClient;
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);

                if (!IsPostBack)
                {
                    BindTaxes();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvTaxes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int eid = Convert.ToInt32(gvTaxes.DataKeys[e.RowIndex].Value);
                DeleteTax(eid);
                BindTaxes();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Method "

        private void BindTaxes()
        {
            taxClient = new TaxServiceClient();
            try
            {
                gvTaxes.DataSource = taxClient.GetAllTaxes();
                gvTaxes.DataBind();
                taxClient.Close();
            }
            catch(Exception ex)
            {
                taxClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void DeleteTax(int taxId)
        {
            taxClient = new TaxServiceClient();
            try
            {
                taxClient.DeleteTax(taxId);
                lbltaxmsg.Text = "Tax Deleted Successfully.";
                lbltaxmsg.ForeColor = System.Drawing.Color.Green;
                taxClient.Close();
            }
            catch(Exception ex)
            {
                lbltaxmsg.Text = "Tax Deletion Failed.";
                lbltaxmsg.ForeColor = System.Drawing.Color.Red;
                taxClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}