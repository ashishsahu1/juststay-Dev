using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.ATRC.RCRefundServiceReference;
using JustStay.CommonHub;

namespace JustStay.ATRC
{
    public partial class refundtrasaction : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                BindRefundedBooking();
            }
        }
        private void BindRefundedBooking()
        {
            try
            {
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate = Convert.ToDateTime(txtfromdate.Text);
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = Convert.ToDateTime(txttodate.Text);
                List<GetAllRefunds> rlist = new RCRefundServiceClient().GetAllRefunds(Common.ATRCId, fromdate, todate, "Online").ToList();
                gvrefund.DataSource = rlist;
                gvrefund.DataBind();
                if (gvrefund.Rows.Count > 0)
                {
                    gvrefund.UseAccessibleHeader = true;
                    gvrefund.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvrefund.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnrcbSearch_Click(object sender, EventArgs e)
        {
            BindRefundedBooking();
        }
    }
}