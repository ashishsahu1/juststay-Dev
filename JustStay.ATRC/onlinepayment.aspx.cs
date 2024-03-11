using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.ATRC.RCPaymentServiceReference;

namespace JustStay.ATRC
{
    public partial class onlinepayment : BasePage
    {
        public string strpayments = "";
        Decimal dJSCommissionTotal = 0;
        Decimal dATRCCommissionTotal = 0;
        Decimal dCreditAmountTotal = 0;
        Decimal dRazorFessTotal = 0;
        Decimal dAmount = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindOnlinePayment();
            }
        }
        private void BindOnlinePayment()
        {
            try
            {
                RCPaymentServiceClient pyclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Text));
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = Convert.ToDateTime(Convert.ToString(txttodate.Text));//DateTime.ParseExact(txttodate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                List<GetAllOnlinePayment> pylist = new List<GetAllOnlinePayment>();
                pylist = pyclient.GetOnlinePayment(Common.ATRCId, fromdate, todate, Convert.ToString(txtrcsearch.Text.Trim())).ToList<GetAllOnlinePayment>();
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
                    if (ViewState["TotalCreditAmt"] == null)
                    {
                        Decimal? amtcredit = 0;
                        for (int i = 0; i <= pylist.Count - 1; i++)
                        {
                            if (pylist[i].PaidAmtfromRazor.HasValue)
                                amtcredit += pylist[i].PaidAmtfromRazor.Value;
                        }
                        ViewState["TotalCreditAmt"] = amtcredit;
                    }
                    if (ViewState["TotalRazorFess"] == null)
                    {
                        Decimal? amtrazorfess = 0;
                        for (int i = 0; i <= pylist.Count - 1; i++)
                        {
                            if (pylist[i].TotalRazorFees.HasValue)
                                amtrazorfess += pylist[i].TotalRazorFees.Value;
                        }
                        ViewState["TotalRazorFess"] = amtrazorfess;
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
                    gvonlinepayment.DataSource = pylist;
                    gvonlinepayment.DataBind();
                    if (gvonlinepayment.Rows.Count > 0)
                    {
                        gvonlinepayment.UseAccessibleHeader = true;
                        gvonlinepayment.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvonlinepayment.FooterRow.TableSection = TableRowSection.TableFooter;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnrcbSearch_Click(object sender, EventArgs e)
        {
            BindOnlinePayment();
        }

        protected void gvonlinepayment_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    //credit amount
                    Label lblPaidAmtfromRazor = (Label)e.Row.FindControl("lblPaidAmtfromRazor");
                    if (!string.IsNullOrEmpty(lblPaidAmtfromRazor.Text))
                        dCreditAmountTotal += Decimal.Parse(lblPaidAmtfromRazor.Text);

                    //razor fess
                    Label lblTotalRazorFees = (Label)e.Row.FindControl("lblTotalRazorFees");
                    if (!string.IsNullOrEmpty(lblTotalRazorFees.Text))
                        dRazorFessTotal += Decimal.Parse(lblTotalRazorFees.Text);

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
                    if (ViewState["TotalCreditAmt"] != null && dCreditAmountTotal != 0)
                    {
                        Label lblPaidAmtfromRazorTotal = (Label)e.Row.FindControl("lblPaidAmtfromRazorTotal");
                        lblPaidAmtfromRazorTotal.Text = dCreditAmountTotal.ToString("N2");
                    }
                    if (ViewState["TotalRazorFess"] != null && dRazorFessTotal != 0)
                    {
                        Label lblTotalRazorFeesTotal = (Label)e.Row.FindControl("lblTotalRazorFeesTotal");
                        lblTotalRazorFeesTotal.Text = dRazorFessTotal.ToString("N2");
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
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnkreset_Click(object sender, EventArgs e)
        {
            txtfromdate.Text = string.Empty;
            txttodate.Text = string.Empty;
        }
    }
}