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
    public partial class myprofile : BasePage
    {
        public static string strname, strusername, strpassword, stremail, strMobile, strdob, straddress, strisactive = string.Empty;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindProfile();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindProfile()
        {
            CustomerServiceClient cclient = new CustomerServiceClient();
            try
            {
                CustomerDetail cust = cclient.GetCustomerDetail(Common.CustomerId);
                if (cust == null) return;
                strname = Convert.ToString(cust.Name);
                strusername = Convert.ToString(cust.Username);
                strpassword = new RC4().Encrypt(Convert.ToString(cust.Password));
                stremail = Convert.ToString(cust.Email);
                strMobile = Convert.ToString(cust.Mobile);
                if (cust.DOB != null)
                    strdob = Convert.ToString(cust.DOB.Value.ToShortDateString());
                else
                    strdob = string.Empty;
                straddress = Convert.ToString(cust.Address);
                strisactive = Convert.ToString(cust.IsActive);

                cclient.Close();
            }
            catch(Exception ex)
            {
                cclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}