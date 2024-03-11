using JustStay.CommonHub;
using JustStay.Web.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["c"]) && Request.QueryString["c"] == "p")
                    {
                        lblerror.Text = "Password change successfully.";
                        lblerror.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                JSEDS objjsed = new JSEDS();
                int authenticated = Authenticate.IsAuthenticated(Convert.ToString(txtMobile.Text.Trim()), Convert.ToString(txtPassword.Text.Trim()));
                if (authenticated == 0)
                {
                    txtMobile.Text = txtPassword.Text = "";
                    lblerror.Text = "Invalid username & password.";
                }
                else
                {
                    if (Session["Search"] != null)
                    {
                        searchDto search = (searchDto)Session["Search"];
                        Response.Redirect("~/book.aspx?aid=" + search.AtrcId + "&Date=" + search.Date+ "&Time=" +search.Time + "&hr=" + search.Hr + "&frto=" + search.FrTo,false);
                    }
                    else
                    {
                        Response.Redirect("~/home.aspx",false);
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        //protected void lnkSigninGoogle_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string clientid = ConfigurationManager.AppSettings["GoogleClientId"];
        //        string clientsecret = ConfigurationManager.AppSettings["GoogleClientSecret"];
        //        string redirection_url = ConfigurationManager.AppSettings["GoogleRedirectUrl"];
        //        string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=openid%20email%20profile&prompt=select_account&access_type=offline&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
        //        Response.Redirect(url);
        //    }
        //    catch(Exception ex)
        //    {
        //        Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    }
        //}
    }
}