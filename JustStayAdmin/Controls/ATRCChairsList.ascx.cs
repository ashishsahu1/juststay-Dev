using JustStayAdmin.RCProfileServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Controls
{
    public partial class ATRCChairsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                    BindChairs();
            }
        }

        //protected void lnkAddNew_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ManageRestChair.aspx?PId=" + Request.QueryString["Id"]);
        //}

        #region " Private Methods "

        private void BindChairs()
        {
            RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
            gvChairs.DataSource = rcClient.GetAllRestChairsByATRCProfile(int.Parse(Request.QueryString["Id"]));
            gvChairs.DataBind();
        }

        #endregion
    }
}