using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


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
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
        }
    }
