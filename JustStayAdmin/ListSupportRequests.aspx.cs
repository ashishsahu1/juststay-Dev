using JustStayAdmin.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListSupportRequests : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindSupportRequests();
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindSupportRequests()
        {
            MessageServiceClient msgClient = new MessageServiceClient();
            grdSupportReq.DataSource = msgClient.GetAdminSupportRequests();
            grdSupportReq.DataBind();

            if (grdSupportReq.Rows.Count > 0)
            {
                grdSupportReq.UseAccessibleHeader = true;
                grdSupportReq.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdSupportReq.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion
    }
}