using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnklogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authenticate.IsAuthenticated(Convert.ToString(txtusername.Text.Trim()), Convert.ToString(txtpassword.Text.Trim())) != 0)
                {
                    Response.Redirect("~/Admin/dashboard.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                    lblerrorMsg.Text = "Invalid Username & Password.";
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin-Login", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}