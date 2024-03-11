using JustStay.Services.DTO;
using JustStayAdmin.TaxServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageTax : BasePage
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
                    hdTaxId.Value = Request.QueryString["Id"];
                    BindTaxDetails();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int taxId = int.Parse(hdTaxId.Value);
            TaxServiceClient taxClient = new TaxServiceClient();

            TaxDto tax = new TaxDto()
            {
                TaxId = taxId,
                TaxName = txtTaxName.Text,
                CGST = int.Parse(txtCGST.Text),
                SGST = int.Parse(txtSGST.Text),
                MinAmount = Convert.ToDecimal(txtMinAmt.Text),
                MaxAmount = Convert.ToDecimal(txtMaxAmt.Text)
            };

            try
            {
                if (taxId == 0)
                    taxClient.InsertTax(tax);
                else
                    taxClient.UpdateTax(tax);

                Common.ShowAlertAndNavigate("Tax saved successfully", "ListTax.aspx");

            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Tax failed", "ListTax.aspx");
            }
        }

        #endregion

        #region " Private Methods "

        private void BindTaxDetails()
        {
            TaxServiceClient taxClient = new TaxServiceClient();

            TaxDto tax = taxClient.GetTaxById(int.Parse(hdTaxId.Value));
            txtTaxName.Text = tax.TaxName;
            txtCGST.Text = tax.CGST.ToString();
            txtSGST.Text = tax.SGST.ToString();
            txtMinAmt.Text = tax.MinAmount.ToString();
            txtMaxAmt.Text = tax.MaxAmount.ToString();
        }

        #endregion

    }
}