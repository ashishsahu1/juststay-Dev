using JustStay.ATRC.RCPaymentServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class addnewjsbill : BasePage
    {
        Decimal dJSCommissionTotal = 0;
        Decimal dAmount = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    //BindGrid();
                    if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        hdnjsbillid.Value = new JustStay.ATRC.RC4().Decrypt(Convert.ToString(Request.QueryString["Id"]));
                        SetJSBill();
                        BindGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindGrid()
        {
            try
            {
                RCPaymentServiceClient pyclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Text))
                    fromdate =Convert.ToDateTime(Convert.ToString(txtfromdate.Text));
                if (!string.IsNullOrEmpty(txttodate.Text))
                    todate = Convert.ToDateTime(txttodate.Text);

                List<PayAtATRCBillingToJuststay> jsbilllist = new List<PayAtATRCBillingToJuststay>();
                jsbilllist = pyclient.PayAtATRCBillingToJuststay(Common.ATRCId, fromdate, todate).ToList<PayAtATRCBillingToJuststay>();
                if (jsbilllist == null) return;
                if (ViewState["TotalAmount"] == null)
                {
                    Decimal? rccharges = 0;
                    for (int i = 0; i <= jsbilllist.Count - 1; i++)
                    {
                        if (jsbilllist[i].NetAmount.HasValue)
                            rccharges += jsbilllist[i].NetAmount.Value;
                    }
                    ViewState["TotalAmount"] = rccharges;
                }
                if (ViewState["TotalJSCommission"] == null)
                {
                    Decimal? amtatrccomm = 0;
                    for (int i = 0; i <= jsbilllist.Count - 1; i++)
                    {
                        if (jsbilllist[i].JSCommission.HasValue)
                            amtatrccomm += jsbilllist[i].JSCommission.Value;
                    }
                    ViewState["TotalJSCommission"] = amtatrccomm;
                }
                grdapyatrcbill.DataSource = jsbilllist;
                grdapyatrcbill.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void SetJSBill()
        {
            try
            {
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                GetJSBillById getbill = rcpayclient.GetJSBillById(Convert.ToInt32(hdnjsbillid.Value));
                if (getbill == null) return;
                txtbalance.Text = Convert.ToString(getbill.BalanceAmount);
                txtbilldate.Text = Convert.ToString(getbill.BillDate);
                txtbillno.Text = Convert.ToString(getbill.BillNo);
                txtdescription.Text = Convert.ToString(getbill.Description);
                txtfromdate.Text = Convert.ToString(getbill.BillFrom);
                txtpaidamount.Text = Convert.ToString(getbill.PaidAmount);
                txttodate.Text = Convert.ToString(getbill.BillTo);
                txttotalamount.Text = Convert.ToString(getbill.TotalAmount);
                chkispaid.Checked = Convert.ToBoolean(getbill.IsPaid);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnjscbillreport_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdapyatrcbill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblJSCommission = (Label)e.Row.FindControl("lblJSCommission");
                    if (!string.IsNullOrEmpty(lblJSCommission.Text))
                        dJSCommissionTotal += Decimal.Parse(lblJSCommission.Text);

                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (!string.IsNullOrEmpty(lblAmount.Text))
                        dAmount += Decimal.Parse(lblAmount.Text);

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (ViewState["TotalJSCommission"] != null && dJSCommissionTotal != 0)
                    {
                        Label lblJSCommissionTotal = (Label)e.Row.FindControl("lblJSCommissionTotal");
                        lblJSCommissionTotal.Text = dJSCommissionTotal.ToString("N2");
                        txttotalamount.Text = Convert.ToString(dJSCommissionTotal);
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

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (grdapyatrcbill.Rows.Count > 0)
                {
                    jsbillDto billdto = new jsbillDto();
                    billdto.JSBillId = Convert.ToInt32(hdnjsbillid.Value);
                    billdto.ATRCId = Convert.ToInt32(Common.ATRCId);
                    billdto.BillDate = Convert.ToDateTime(txtbilldate.Text);
                    billdto.BillFrom = Convert.ToDateTime(txtfromdate.Text);
                    billdto.BillTo = Convert.ToDateTime(txttodate.Text);
                    billdto.BillNo = Convert.ToString(txtbillno.Text.Trim());
                    billdto.Description = Convert.ToString(txtdescription.Text.Trim());
                    billdto.InsertedOn = DateTime.Now.Date;
                    billdto.IsDeleted = false;
                    billdto.IsPaid = Convert.ToBoolean(chkispaid.Checked);
                    billdto.PaidAmount = Convert.ToDecimal(txtpaidamount.Text);
                    billdto.PaymentBy = drppaymentby.SelectedValue;
                    billdto.TotalAmount = Convert.ToDecimal(txttotalamount.Text);
                    billdto.PaidDate = Convert.ToDateTime(txtbilldate.Text);
                    RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                    if (hdnjsbillid.Value == "0")
                    {
                        rcpayclient.InsertJSBill(billdto);
                    }
                    else
                        rcpayclient.UpdateJSBill(billdto);

                    Response.Redirect("~/billstojuststay.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no booking records avaliable. You can not save the bill.')", true);
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
    }
}