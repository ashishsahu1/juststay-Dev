using JustStay.CommonHub;
using JustStayAdmin.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class supportrequest : BL.BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);

                if (!IsPostBack)
                {
                    BindSupportRequests();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindSupportRequests()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            try
            {
                grdSupportReq.DataSource = msgClient.GetAdminSupportRequests();
                grdSupportReq.DataBind();
                msgClient.Close();
            }
            catch(Exception ex)
            {
                msgClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}