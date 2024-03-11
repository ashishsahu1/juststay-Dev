using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
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
            { throw ex; }
        }

        //protected void btnlogin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Authenticate.IsAuthenticated(Convert.ToString(username.Value), Convert.ToString(password.Value)) != 0)
        //            Response.Redirect("~/ATRCRegistration.aspx");
        //        else
        //            lblerrorMsg.InnerText = "Invalid username & password";
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
    }
}