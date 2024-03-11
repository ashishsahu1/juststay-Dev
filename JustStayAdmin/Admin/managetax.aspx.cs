using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.TaxServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class managetax : BL.BasePage
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
                    if (Request.QueryString["Id"] != null)
                    {
                        hdTaxId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Request.QueryString["Id"]);
                        BindTaxDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            taxClient = new TaxServiceClient();
            try
            {
                int taxId = int.Parse(hdTaxId.Value);
                TaxDto tax = new TaxDto()
                {
                    TaxId = taxId,
                    TaxName = txtTaxName.Text,
                    CGST = Convert.ToDecimal(txtCGST.Text),
                    SGST = Convert.ToDecimal(txtSGST.Text),
                    MinAmount = Convert.ToDecimal(txtMinAmt.Text),
                    MaxAmount = Convert.ToDecimal(txtMaxAmt.Text)
                };
                if (taxId == 0)
                {
                    taxClient.InsertTax(tax);
                    txtTaxName.Text = txtSGST.Text = txtMinAmt.Text = txtMaxAmt.Text = txtCGST.Text = string.Empty;
                }
                else
                    taxClient.UpdateTax(tax);

                lbltaxesmsg.Text = "Tax saved successfully.";
                lbltaxesmsg.ForeColor = System.Drawing.Color.Green;
                taxClient.Close();
            }
            catch (Exception ex)
            {
                lbltaxesmsg.Text = "Save Tax failed.";
                lbltaxesmsg.ForeColor = System.Drawing.Color.Red;
                taxClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Methods "

        private void BindTaxDetails()
        {
            taxClient = new TaxServiceClient();
            try
            {
                TaxDto tax = taxClient.GetTaxById(int.Parse(hdTaxId.Value));
                txtTaxName.Text = Convert.ToString(tax.TaxName);
                txtCGST.Text = Convert.ToString(tax.CGST);
                txtSGST.Text = Convert.ToString(tax.SGST);
                txtMinAmt.Text = Convert.ToString(tax.MinAmount);
                txtMaxAmt.Text = Convert.ToString(tax.MaxAmount);
                taxClient.Close();
            }
            catch (Exception ex)
            {
                taxClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}