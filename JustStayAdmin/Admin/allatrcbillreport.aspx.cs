using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using JustStay.CommonHub;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.ReportServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class allatrcbillreport : BL.BasePage
    {
        public static string strfromdate = "";
        public static string strtodate, stratrcname, strpaystatus = "";

        ATRCServiceClient ATRCServiceclient;
        ReportServiceClient reportClient;
        Decimal dTotalAmount = 0;
        Decimal dPaidAmount = 0;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnexcel);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnexportpdf);
            if (!IsPostBack)
            {
                BindApprovedATRCList();
                BindGrid();
                SetData();
            }
        }
        private void BindApprovedATRCList()
        {
            ATRCServiceclient = new ATRCServiceClient();
            try
            {
                drpatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                drpatrc.DataBind();
                drpatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "--All ATRC--" });
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindGrid()
        {
            reportClient = new ReportServiceClient();
            try
            {
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
                    ispaid = null;

                List <GetAllATRCBills_Report> billlist = reportClient.GetAllATRCBillsReport(Convert.ToInt32(drpatrc.SelectedValue), fromdate, todate, ispaid).ToList();
                if (billlist == null) return;
                totalrecord.Text = "Total Records: " + billlist.Count.ToString();
                if (ViewState["TotalAmount"] == null)
                {
                    Decimal? rccharges = 0;
                    for (int i = 0; i <= billlist.Count - 1; i++)
                    {
                        if (billlist[i].TotalAmount.HasValue)
                            rccharges += billlist[i].TotalAmount.Value;
                    }
                    ViewState["TotalAmount"] = rccharges;
                }
                if (ViewState["TotalPaidAmount"] == null)
                {
                    Decimal? paidamt = 0;
                    for (int i = 0; i <= billlist.Count - 1; i++)
                    {
                        if (billlist[i].PaidAmount.HasValue)
                            paidamt += billlist[i].PaidAmount.Value;
                    }
                    ViewState["TotalPaidAmount"] = paidamt;
                }
                grdatrcbills.DataSource = billlist;
                grdatrcbills.DataBind();
                reportClient.Close();
            }
            catch (Exception ex)
            {
                reportClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { reportClient.Close(); }
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
                stratrcname = drpatrc.SelectedItem.Text; 
               
                if (!string.IsNullOrEmpty(txtfromdate.Value) && !string.IsNullOrEmpty(txttodate.Value))
                {
                    lbldaterange.Text = Convert.ToString(txtfromdate.Value) + " to " + Convert.ToString(txttodate.Value);
                    strfromdate = "FromDate - " + Convert.ToString(txtfromdate.Value);
                    strtodate = "ToDate - " + Convert.ToString(txttodate.Value);
                }
                else
                {
                    lbldaterange.Text = string.Empty;
                    strfromdate = string.Empty;
                    strtodate = string.Empty;
                }
                if (!string.IsNullOrEmpty(drpispaid.SelectedValue))
                {
                    strpaystatus = "Payment Status: " + drpispaid.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void ExportGridToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                if (!string.IsNullOrEmpty(txtfromdate.Value) && !string.IsNullOrEmpty(txttodate.Value))
                    Response.AddHeader("content-disposition", "attachment;filename=AllATRCBillReport" + Convert.ToString(txtfromdate.Value) + "to" + Convert.ToString(txttodate.Value) + ".xls");
                else
                    Response.AddHeader("content-disposition", "attachment;filename=AllATRCBillReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Output.Write(Request.Form[hfGridHtml.UniqueID]);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void ExportGridToPDF()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                if (!string.IsNullOrEmpty(txtfromdate.Value) && !string.IsNullOrEmpty(txttodate.Value))
                    Response.AddHeader("content-disposition", "attachment;filename=AllATRCBillReport" + Convert.ToString(txtfromdate.Value) + "to" + Convert.ToString(txttodate.Value) + ".pdf");
                else
                    Response.AddHeader("content-disposition", "attachment;filename=AllATRCBillReport.pdf");
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                StringReader strReader = new StringReader(Convert.ToString(Request.Form[hfGridHtml.UniqueID]));
                Document doc = new Document();

                PdfPTable tableLayout = new PdfPTable(4);

                PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, strReader);
                doc.Close();
                Response.Write(doc);
                Response.End();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnexportpdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdatrcbills.Rows.Count > 0)
                    ExportGridToPDF();
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "ClientScript", "alert('No Record Found!')", true);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdatrcbills.Rows.Count > 0)
                    ExportGridToExcel();
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "ClientScript", "alert('No Record Found!')", true);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btngetreport_Click(object sender, EventArgs e)
        {
            BindGrid(); SetData();
        }
        protected void grdatrcbills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdatrcbills.PageIndex = e.NewPageIndex;
                BindGrid();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "gethtml()", true);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdatrcbills_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (!string.IsNullOrEmpty(lblAmount.Text))
                        dTotalAmount += Decimal.Parse(lblAmount.Text);

                    Label lblpaidAmount = (Label)e.Row.FindControl("lblpaidAmount");
                    if (!string.IsNullOrEmpty(lblpaidAmount.Text))
                        dPaidAmount += Decimal.Parse(lblpaidAmount.Text);

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (ViewState["TotalAmount"] != null && dTotalAmount != 0)
                    {
                        Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
                        lblTotalAmount.Text = dTotalAmount.ToString("N2");
                    }
                    if (ViewState["TotalPaidAmount"] != null && dPaidAmount != 0)
                    {
                        Label lblTotalPaidAmount = (Label)e.Row.FindControl("lblTotalPaidAmount");
                        lblTotalPaidAmount.Text = dPaidAmount.ToString("N2");
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