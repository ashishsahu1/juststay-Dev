using JustStay.CommonHub;
using JustStay.Web.BusinessLogic;
using JustStay.Web.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class edit_profile : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                BindCustDetails();
            }
        }
        private void BindCustDetails()
        {
            CustomerServiceClient custclient = new CustomerServiceClient();
            try
            {
                CustomerDetail customer = custclient.GetCustomerDetail(Common.CustomerId);
                txtname.Text = Convert.ToString(customer.Name);
                txtusername.Text = Convert.ToString(customer.Username);
                txtpassword.Text = Convert.ToString(customer.Password);
                txtemail.Text = Convert.ToString(customer.Email);
                txtmobile.Text = Convert.ToString(customer.Mobile);
                txtaddres.Text = Convert.ToString(customer.Address);

                if (customer.DOB.HasValue)
                    txtDOB.Text = Convert.ToString(customer.DOB.Value.ToShortDateString());

                if (!string.IsNullOrEmpty(customer.Gender))
                    rdogender.SelectedValue = Convert.ToString(customer.Gender);

                custclient.Close();
            }
            catch (Exception ex)
            {
                custclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnedit_Click(object sender, EventArgs e)
        {
            CustomerDetail cust = new CustomerDetail();
            CustomerServiceClient custserclient = new CustomerServiceClient();
            try
            {
                cust.CustomerId = Common.CustomerId;
                cust.UserId = Common.UserId;
                cust.Name = Convert.ToString(txtname.Text);
                cust.DOB = (!string.IsNullOrEmpty(txtDOB.Text)) ? Convert.ToDateTime(txtDOB.Text) : (DateTime?)null;
                cust.Email = Convert.ToString(txtemail.Text);
                cust.Gender = rdogender.SelectedValue;
                cust.Mobile = Convert.ToString(txtmobile.Text);
                cust.Address = Convert.ToString(txtaddres.Text.Trim());
                custserclient.UpdateCustomerProfile(cust);
                custserclient.Close();
                Response.Redirect("~/myprofile.aspx",false);
            }
            catch(Exception ex)
            {
                custserclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}