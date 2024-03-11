using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;
using JustStay.ATRC.RCPaymentServiceReference;
using System.Globalization;

namespace JustStay.ATRC
{
    public partial class offlinetrasction : BasePage
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
                BindOfflinePayment();
            }
        }
        private void BindOfflinePayment()
        {
            try
            {
                RCPaymentServiceClient pyclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Text));
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = DateTime.ParseExact(txttodate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                List<GetAllOfflinePayment> pylist = new List<GetAllOfflinePayment>();
                pylist = pyclient.GetOfflinePayment(Common.ATRCId, fromdate, todate, Convert.ToString(txtrcsearch.Text.Trim())).ToList<GetAllOfflinePayment>();
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
                    if (gvofflinepayment.Rows.Count > 0)
                    {
                        gvofflinepayment.UseAccessibleHeader = true;
                        gvofflinepayment.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvofflinepayment.FooterRow.TableSection = TableRowSection.TableFooter;
                    }
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

      

        protected void lnkrest_Click(object sender, EventArgs e)
        {
            txttodate.Text = string.Empty;
            txtfromdate.Text = string.Empty;
        }
    }
}