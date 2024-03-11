using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using System.Globalization;
using JustStayAdmin.RCPaymentServiceReference;
using JustStayAdmin.ATRCServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class offlinepayment : BL.BasePage
    {
        public string strpayments = "";
        Decimal dJSCommissionTotal = 0;
        Decimal dATRCCommissionTotal = 0;
        Decimal dAmount = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindApprovedATRC();
                BindOfflinePayment();
            }
        }
        private void BindApprovedATRC()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            drpatrc.DataBind();
            drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select ATRC" });
        }
        private void BindOfflinePayment()
        {
            try
            {
                RCPaymentServiceClient pyclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Value));
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = DateTime.ParseExact(txttodate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                List<GetAllOfflinePayment> pylist = new List<GetAllOfflinePayment>();
                pylist = pyclient.GetOfflinePayment(int.Parse(drpatrc.SelectedValue), fromdate, todate, Convert.ToString(txtrcsearch.Text.Trim())).ToList<GetAllOfflinePayment>();
                if (pylist != null)
                {
                    if (ViewState["TotalJustCommission"] == null)
                    {
                        Decimal? amtjustcomm = 0;
                        for (int i = 0; i <= pylist.Count - 1; i++)
                        {
                            if (pylist[i].JustStayCommission.HasValue)
                                amtjustcomm += pylist[i].JustStayCommission.Value;
                        }
                        ViewState["TotalJustCommission"] = amtjustcomm;
                    }
                    if (ViewState["TotalATRCCommission"] == null)
                    {
                        Decimal? amtatrccomm = 0;
                        for (int i = 0; i <= pylist.Count - 1; i++)
                        {
                            if (pylist[i].ATRCCommission.HasValue)
                                amtatrccomm += pylist[i].ATRCCommission.Value;
                        }
                        ViewState["TotalATRCCommission"] = amtatrccomm;
                    }
                    if (ViewState["TotalAmount"] == null)
                    {
                        Decimal? rccharges = 0;
                        for (int i = 0; i <= pylist.Count - 1; i++)
                        {
                            if (pylist[i].TotalAmount.HasValue)
                                rccharges += pylist[i].TotalAmount.Value;
                        }
                        ViewState["TotalAmount"] = rccharges;
                    }
                    strpayments = pylist.Count.ToString();
                    gvofflinepayment.DataSource = pylist;
                    gvofflinepayment.DataBind();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnrcbSearch_Click(object sender, EventArgs e)
        {
            BindOfflinePayment();
        }

        protected void gvofflinepayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //juststay commission
                    Label lblJuststayCommission = (Label)e.Row.FindControl("lblJuststayCommission");
                    if (!string.IsNullOrEmpty(lblJuststayCommission.Text))
                        dJSCommissionTotal += Decimal.Parse(lblJuststayCommission.Text);

                    //atrc commission
                    Label lblATRCCommission = (Label)e.Row.FindControl("lblATRCCommission");
                    if (!string.IsNullOrEmpty(lblATRCCommission.Text))
                        dATRCCommissionTotal += Decimal.Parse(lblATRCCommission.Text);

                    //total amount
                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (!string.IsNullOrEmpty(lblAmount.Text))
                        dAmount += Decimal.Parse(lblAmount.Text);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (ViewState["TotalJustCommission"] != null && dJSCommissionTotal != 0)
                    {
                        Label lblJuststayCommissionTotal = (Label)e.Row.FindControl("lblJuststayCommissionTotal");
                        lblJuststayCommissionTotal.Text = dJSCommissionTotal.ToString("N2");
                    }
                    if (ViewState["TotalATRCCommission"] != null && dATRCCommissionTotal != 0)
                    {
                        Label lblATRCCommissionTotal = (Label)e.Row.FindControl("lblATRCCommissionTotal");
                        lblATRCCommissionTotal.Text = dATRCCommissionTotal.ToString("N2");
                    }
                   
                    if (ViewState["TotalAmount"] != null && dAmount != 0)
                    {
                        Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
                        lblTotalAmount.Text = dAmount.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvofflinepayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvofflinepayment.PageIndex = e.NewPageIndex;
            BindOfflinePayment();
        }

        protected void lnkrest_Click(object sender, EventArgs e)
        {
            txttodate.Value = string.Empty;
            txtfromdate.Value = string.Empty;
            drpatrc.SelectedValue = "0";
        }
    }
}