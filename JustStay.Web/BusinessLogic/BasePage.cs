using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustStay.Web.BusinessLogic
{
    public class BasePage : System.Web.UI.Page
    {
        private Boolean _SSL;
        public Boolean SSL
        {
            get { return _SSL; }
            set { _SSL = value; }
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                Common.IsLogedIn = false;
                HttpContext.Current.Response.Redirect("~/home.aspx");
            }
        }
    }
}