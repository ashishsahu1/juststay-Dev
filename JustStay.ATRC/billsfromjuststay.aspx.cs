using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.ATRC.RCPaymentServiceReference;
using JustStay.CommonHub;

namespace JustStay.ATRC
{
    public partial class billsfromjuststay : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            try
            {
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Text));
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = Convert.ToDateTime(Convert.ToString(txttodate.Text));

                bool? ispaid;
                if (drpispaid.SelectedValue == "True")
                    ispaid = true;
                else if (drpispaid.SelectedValue == "False")
                    ispaid = false;
                else
                    ispaid = Convert.ToBoolean(DBNull.Value);

                gvbillfromjslist.DataSource = rcpayclient.GetAllATRCBill(Common.ATRCId, fromdate, todate, ispaid);
                gvbillfromjslist.DataBind();
                if (gvbillfromjslist.Rows.Count > 0)
                {
                    gvbillfromjslist.UseAccessibleHeader = true;
                    gvbillfromjslist.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvbillfromjslist.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}