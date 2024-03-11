using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string dologin(string uname, string password)
        {
            try
            {
                if (Authenticate.IsAuthenticated(Convert.ToString(uname), Convert.ToString(password)) != 0)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                throw ex;
                //Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin-Login", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }

        protected void btnadminlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authenticate.IsAuthenticated(Convert.ToString(username.Value), Convert.ToString(password.Value)) != 0)
                    Response.Redirect("~/Dashboard.aspx");
                else
                    lblerrorMsg.InnerText = "Invalid Username & Password.";
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin-Login", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }
    }
}