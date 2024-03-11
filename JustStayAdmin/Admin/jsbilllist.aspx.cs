using JustStay.CommonHub;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.RCPaymentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class jsbilllist : BL.BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindApprovedATRCList();
                BindGrid();
            }
        }
        private void BindGrid()
        {
            try
            {
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Value));
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = Convert.ToDateTime(Convert.ToString(txttodate.Value));

                bool? ispaid;
                if (drpispaid.SelectedValue == "True")
                    ispaid = true;
                else if (drpispaid.SelectedValue == "False")
                    ispaid = false;
                else
                    ispaid = Convert.ToBoolean(DBNull.Value);

                gvjsbilllist.DataSource = rcpayclient.GetAllJSBill(Convert.ToInt32(drpatrc.SelectedValue), fromdate, todate, ispaid);
                gvjsbilllist.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindApprovedATRCList()
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                drpatrc.DataBind();
                drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btngo_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}