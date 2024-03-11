using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.CompanyServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class updatecompany : BL.BasePage
    {
        CompanyServiceClient companyclient = new CompanyServiceClient();
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
                GetCompany();
        }
        private void GetCompany()
        {
            companyclient = new CompanyServiceClient();
            try
            {
                CompanyDto compdto = companyclient.GetCompany();
                hdcompanyId.Value = Convert.ToString(compdto.CompanyId);
                txtaddress.Text = Convert.ToString(compdto.Address);
                txtcin.Text = Convert.ToString(compdto.CIN);
                txtcity.Text = Convert.ToString(compdto.City);
                txtcompanyname.Text = Convert.ToString(compdto.CompanyName);
                txtcontactperson.Text = Convert.ToString(compdto.Contact);
                txtemail.Text = Convert.ToString(compdto.Email);
                txtgstin.Text = Convert.ToString(compdto.GSTIN);
                txtlandline.Text = Convert.ToString(compdto.LandLine);
                txtmobile.Text = Convert.ToString(compdto.Mobile);
                txtpan.Text = Convert.ToString(compdto.PAN);
                txtpincode.Text = Convert.ToString(compdto.PinCode);
                txtstate.Text = Convert.ToString(compdto.State);
                txtsubheading.Text = Convert.ToString(compdto.Subheading);
                txtwebsite.Text = Convert.ToString(compdto.Website);
                companyclient.Close();
            }
            catch (Exception ex)
            {
                companyclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           companyclient = new CompanyServiceClient();
            try
            {
                CompanyDto cdto = new CompanyDto();
                cdto.Address = Convert.ToString(txtaddress.Text.Trim());
                cdto.CIN = Convert.ToString(txtcin.Text.Trim());
                cdto.City = Convert.ToString(txtcity.Text.Trim());
                cdto.CompanyName = Convert.ToString(txtcompanyname.Text.Trim());
                cdto.Contact = Convert.ToString(txtcontactperson.Text.Trim());
                cdto.Email = Convert.ToString(txtemail.Text.Trim());
                cdto.GSTIN = Convert.ToString(txtgstin.Text.Trim());
                cdto.LandLine = Convert.ToString(txtlandline.Text.Trim());
                cdto.Mobile = Convert.ToString(txtmobile.Text.Trim());
                cdto.PAN = Convert.ToString(txtpan.Text.Trim());
                cdto.PinCode = Convert.ToInt32(txtpincode.Text.Trim());
                cdto.State = Convert.ToString(txtstate.Text.Trim());
                cdto.Subheading = Convert.ToString(txtsubheading.Text.Trim());
                cdto.Website = Convert.ToString(txtwebsite.Text.Trim());
                cdto.UpdatedOn = DateTime.Now;
                cdto.CompanyId = Convert.ToInt32(hdcompanyId.Value);
                int id = companyclient.UpdateCompany(cdto);
                if (id > 0)
                {
                    lblcompanymsg.Text = "Company details updated successfully.";
                    lblcompanymsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblcompanymsg.Text = "Company details not updated successfully.";
                    lblcompanymsg.ForeColor = System.Drawing.Color.Red;
                }
                companyclient.Close();
            }
            catch (Exception ex)
            {
                companyclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}