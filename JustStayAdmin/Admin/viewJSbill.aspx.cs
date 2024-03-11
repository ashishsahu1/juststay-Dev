using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CompanyServiceReference;
using JustStayAdmin.RCPaymentServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class viewJSbill : BL.BasePage
    {
        public static string strfromdate, strtodate = "";
        public static string strCompanyName, strsubheading, straddress, stremail,
            strmobile, strwebsite, strgstin, stratrcname, stratrcaddress,
            stratrcemail, stratrcmobile, strownername, stratrcnumber, strfinalamt, strbillno, strbilldate = "";

        Decimal dAmount = 0;
        DateTime billfrom, billto;
        int JSBillId, ATRCId = 0;
        Decimal dJSCommissionTotal = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnexcel);
                ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnexportpdf);
                RC4 rc = new RC4();
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["atrcid"]))
                    {
                        ATRCId = Convert.ToInt32(rc.Decrypt(Request.QueryString["atrcid"]));
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        JSBillId = Convert.ToInt32(rc.Decrypt(Request.QueryString["Id"]));
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["fr"]))
                    {
                        billfrom = Convert.ToDateTime(Request.QueryString["fr"]);
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["to"]))
                    {
                        billto = Convert.ToDateTime(Request.QueryString["to"]);
                    }
                    // BindApprovedATRCList();
                    BindGrid();
                    SetData();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void SetData()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["fr"]) && !string.IsNullOrEmpty(Request.QueryString["to"]))
                {
                    lbldaterange.Text = Convert.ToString(billfrom.ToShortDateString()) + " to " + Convert.ToString(billto.ToShortDateString());
                    strfromdate = "FromDate - " + Convert.ToString(billfrom.ToShortDateString());
                    strtodate = "ToDate - " + Convert.ToString(billto.ToShortDateString());
                }
                else
                {
                    lbldaterange.Text = string.Empty;
                    strfromdate = string.Empty;
                    strtodate = string.Empty;
                }
                CompanyServiceClient compclient = new CompanyServiceClient();
                CompanyDto cmpdto = compclient.GetCompany();
                if (cmpdto == null) return;
                strCompanyName = Convert.ToString(cmpdto.CompanyName);
                strsubheading = Convert.ToString(cmpdto.Subheading);
                straddress = Convert.ToString(cmpdto.Address);
                strwebsite = Convert.ToString(cmpdto.Website);
                strmobile = Convert.ToString(cmpdto.Mobile);
                stremail = Convert.ToString(cmpdto.Email);
                strgstin = Convert.ToString(cmpdto.GSTIN);

                ATRCServiceClient atrcclient = new ATRCServiceClient();
                ATRCDto atrc = atrcclient.GetATRCById(ATRCId);
                if (atrc == null) return;
                stratrcname = Convert.ToString(atrc.ATRCName);
                stratrcaddress = Convert.ToString(atrc.Address);
                stratrcemail = Convert.ToString(atrc.Email);
                stratrcmobile = Convert.ToString(atrc.Mobile);
                stratrcnumber = Convert.ToString(atrc.ATRCNumber);
                strownername = Convert.ToString(atrc.OwnerName);
                Decimal finalamt = Convert.ToDecimal(hdnamount.Value);
                totalamountword.Text = Common.NumberToWord(Convert.ToInt32(finalamt));
                totalamount.Text = hdnamount.Value;
                strfinalamt = hdnamount.Value;

                RCPaymentServiceClient rcpayclient = new RCPaymentServiceClient();
                GetJSBillById getbill = rcpayclient.GetJSBillById(JSBillId);
                strfromdate = Convert.ToString(getbill.BillFrom.Value.ToShortDateString());
                strtodate = Convert.ToString(getbill.BillTo.Value.ToShortDateString());
                strbilldate = Convert.ToString(getbill.BillDate.Value.ToShortDateString());
                strbillno = Convert.ToString(getbill.BillNo);

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
                List<PayAtATRCBillingToJuststay> atrcbilllist = new List<PayAtATRCBillingToJuststay>();
                atrcbilllist = pyclient.PayAtATRCBillingToJuststay(ATRCId, billfrom, billto).ToList<PayAtATRCBillingToJuststay>();
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
                if (ViewState["TotalJSCommission"] == null)
                {
                    Decimal? amtatrccomm = 0;
                    for (int i = 0; i <= atrcbilllist.Count - 1; i++)
                    {
                        if (atrcbilllist[i].JSCommission.HasValue)
                            amtatrccomm += atrcbilllist[i].JSCommission.Value;
                    }
                    ViewState["TotalJSCommission"] = amtatrccomm;
                }
                grdjsBill.DataSource = atrcbilllist;
                grdjsBill.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void ExportGridToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                if (!string.IsNullOrEmpty(billfrom.ToString()) && !string.IsNullOrEmpty(billto.ToString()))
                    Response.AddHeader("content-disposition", "attachment;filename=JSBill-" + Convert.ToString(billfrom) + "to" + Convert.ToString(billto) + ".xls");
                else
                    Response.AddHeader("content-disposition", "attachment;filename=JSBill.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Output.Write(Request.Form[hfGridHtml.UniqueID]);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void ExportGridToPDF()
        {
            try
            {
                //Response.Clear();
                //Response.Buffer = true;
                //if (!string.IsNullOrEmpty(txtfromdate.Value) && !string.IsNullOrEmpty(txttodate.Value))
                //    Response.AddHeader("content-disposition", "attachment;filename=ATRCBill-" + Convert.ToString(txtfromdate.Value) + "to" + Convert.ToString(txttodate.Value) + ".pdf");
                //else
                //    Response.AddHeader("content-disposition", "attachment;filename=ATRCBill.pdf");
                //Response.Charset = "";
                //Response.ContentType = "application/pdf";
                StringReader strReader = new StringReader(Convert.ToString(Request.Form[hfGridHtml.UniqueID]));
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //Document doc = new Document();
                //PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                //doc.Open();
                //XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, strReader);
                //doc.Close();
                //Response.Write(doc);
                //Response.End();
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(strReader);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                if (!string.IsNullOrEmpty(Convert.ToString(billfrom)) && !string.IsNullOrEmpty(Convert.ToString(billto)))
                    Response.AddHeader("content-disposition", "attachment;filename=JSBill-" + Convert.ToString(billfrom) + "to" + Convert.ToString(billto) + ".pdf");
                else
                    Response.AddHeader("content-disposition", "attachment;filename=JSBill.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdjsBill.Rows.Count > 0)
                    ExportGridToExcel();
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "ClientScript", "alert('No Record Found!')", true);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnexportpdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdjsBill.Rows.Count > 0)
                    ExportGridToPDF();
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "ClientScript", "alert('No Record Found!')", true);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void grdJSPayatrcBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblATRCCommission = (Label)e.Row.FindControl("lblJSCommission");
                    if (!string.IsNullOrEmpty(lblATRCCommission.Text))
                        dJSCommissionTotal += Decimal.Parse(lblATRCCommission.Text);

                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (!string.IsNullOrEmpty(lblAmount.Text))
                        dAmount += Decimal.Parse(lblAmount.Text);

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (ViewState["TotalJSCommission"] != null && dJSCommissionTotal != 0)
                    {
                        Label lblATRCCommissionTotal = (Label)e.Row.FindControl("lblJSCommissionTotal");
                        lblATRCCommissionTotal.Text = dJSCommissionTotal.ToString("N2");
                        hdnamount.Value = Convert.ToString(dJSCommissionTotal);
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
    }
}
