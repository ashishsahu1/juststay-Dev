using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JSEDS objsecurity = new JSEDS();
            //string ml = objsecurity.Decrypt(Request.QueryString["ml"]);
            //string mxl = objsecurity.Decrypt(Request.QueryString["mxl"]);
            //string mlg = objsecurity.Decrypt(Request.QueryString["mlg"]);
            //string mxlg = objsecurity.Decrypt(Request.QueryString["mxlg"]);
            //string Date = objsecurity.Decrypt(Request.QueryString["Date"]);
            //string Time = objsecurity.Decrypt(Request.QueryString["Time"]);
            //string hr = objsecurity.Decrypt(Request.QueryString["hr"]);
            //string per = objsecurity.Decrypt(Request.QueryString["per"]);
            string aid = objsecurity.Decrypt(Request.QueryString["aid"]);
            // Response.Write(ml + "," + mxl + "," + mlg + "," + mxlg + "," + Date + "," + Time + "," + hr + "," + per);
            Response.Write(aid);
        }
    }
}