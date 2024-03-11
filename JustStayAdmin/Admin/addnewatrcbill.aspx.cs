using JustStay.CommonHub;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.RCPaymentServiceReference;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class addnewatrcbill : Admin.BL.BasePage
    {
        Decimal dATRCCommissionTotal = 0;
        Decimal dAmount = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    BindApprovedATRCList();
                    BindGrid();
                    if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        hdnatrcbillid.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Convert.ToString(Request.QueryString["Id"]));
                        SetATRCBill();
                        BindGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void SetATRCBill()
        {
            try
            {
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                GetATRCBillById getbill = rcpayclient.GetATRCDetailsById(Convert.ToInt32(hdnatrcbillid.Value));
                if (getbill == null) return;
                drpatrc.SelectedValue = Convert.ToString(getbill.ATRCId);
                txtbalance.Text = Convert.ToString(getbill.BalanceAmount);
                txtbilldate.Value = Convert.ToString(getbill.BillDate);
                txtbillno.Text = Convert.ToString(getbill.BillNo);
                txtdescription.Text = Convert.ToString(getbill.Description);
                txtfromdate.Value = Convert.ToString(getbill.BillFrom);
                txtpaidamount.Text = Convert.ToString(getbill.PaidAmount);
                txttodate.Value = Convert.ToString(getbill.BillTo);
                txttotalamount.Text = Convert.ToString(getbill.TotalAmount);
                chkispaid.Checked = Convert.ToBoolean(getbill.IsPaid);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try {
                atrcbillDto billdto = new atrcbillDto();
                billdto.ATRCBillId = Convert.ToInt32(hdnatrcbillid.Value);
                billdto.ATRCId = Convert.ToInt32(drpatrc.SelectedValue);
                billdto.BillDate = Convert.ToDateTime(txtbilldate.Value);
                billdto.BillFrom = Convert.ToDateTime(txtfromdate.Value);
                billdto.BillTo = Convert.ToDateTime(txttodate.Value);
                billdto.BillNo = Convert.ToString(txtbillno.Text.Trim());
                billdto.Description = Convert.ToString(txtdescription.Text.Trim());
                billdto.InsertedOn = DateTime.Now.Date;
                billdto.IsDeleted = false;
                billdto.IsPaid = Convert.ToBoolean(chkispaid.Checked);
                billdto.PaidAmount = Convert.ToDecimal(txtpaidamount.Text);
                billdto.PaymentBy = drppaymentby.SelectedValue;
                billdto.TotalAmount = Convert.ToDecimal(txttotalamount.Text);
                billdto.PaidDate = Convert.ToDateTime(txtbilldate.Value);
                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                if(hdnatrcbillid.Value == "0")
                {
                    rcpayclient.InsertATRCBill(billdto);
                }
                else
                    rcpayclient.UpdateATRCBill(billdto);

                Response.Redirect("~/Admin/atrcbilllist.aspx",false);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
        protected void grdATRCOnlineBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblATRCCommission = (Label)e.Row.FindControl("lblATRCCommission");
                    if (!string.IsNullOrEmpty(lblATRCCommission.Text))
                        dATRCCommissionTotal += Decimal.Parse(lblATRCCommission.Text);

                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (!string.IsNullOrEmpty(lblAmount.Text))
                        dAmount += Decimal.Parse(lblAmount.Text);

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (ViewState["TotalATRCCommission"] != null && dATRCCommissionTotal != 0)
                    {
                        Label lblATRCCommissionTotal = (Label)e.Row.FindControl("lblATRCCommissionTotal");
                        lblATRCCommissionTotal.Text = dATRCCommissionTotal.ToString("N2");
                        txttotalamount.Text = Convert.ToString(dATRCCommissionTotal);
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
        private void BindGrid()
        {
            try
            {
                RCPaymentServiceClient pyclient = new RCPaymentServiceClient();
                DateTime? fromdate = null, todate = null;

                if (!string.IsNullOrEmpty(txtfromdate.Value))
                    fromdate = Convert.ToDateTime(Convert.ToString(txtfromdate.Value));
                if (!string.IsNullOrEmpty(txttodate.Value))
                    todate = Convert.ToDateTime(Convert.ToString(txttodate.Value));

                List<ATRCOnlineBillingFromJuststay> atrcbilllist = new List<ATRCOnlineBillingFromJuststay>();
                atrcbilllist = pyclient.ATRCOnlineBillingFromJuststay(int.Parse(drpatrc.SelectedValue), fromdate, todate).ToList<ATRCOnlineBillingFromJuststay>();
                if (atrcbilllist == null) return;
                if (ViewState["TotalAmount"] == null)
                {
                    Decimal? rccharges = 0;
                    for (int i = 0; i <= atrcbilllist.Count - 1; i++)
                    {
                        if (atrcbilllist[i].NetAmount.HasValue)
                            rccharges += atrcbilllist[i].NetAmount.Value;
                    }
                    ViewState["TotalAmount"] = rccharges;
                }
                if (ViewState["TotalATRCCommission"] == null)
                {
                    Decimal? amtatrccomm = 0;
                    for (int i = 0; i <= atrcbilllist.Count - 1; i++)
                    {
                        if (atrcbilllist[i].ATRCCommission.HasValue)
                            amtatrccomm += atrcbilllist[i].ATRCCommission.Value;
                    }
                    ViewState["TotalATRCCommission"] = amtatrccomm;
                }
                grdATRCOnlineBill.DataSource = atrcbilllist;
                grdATRCOnlineBill.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnatrcbillreport_Click(object sender, EventArgs e)
        {
            BindGrid(); 
        }
    }
}