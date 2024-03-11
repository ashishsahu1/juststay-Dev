using JustStayAdmin.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListCustRequests : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindCustomerRequests();
            }
        }

        #endregion

        #region  " Private Methods "        

        private void BindCustomerRequests()
        {
            CustomerServiceClient custClient = new CustomerServiceClient();
            grdCustomerReqs.DataSource = custClient.GetAllCustomerRequets();
            grdCustomerReqs.DataBind();

            if (grdCustomerReqs.Rows.Count > 0)
            {
                grdCustomerReqs.UseAccessibleHeader = true;
                grdCustomerReqs.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdCustomerReqs.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion

    }
}