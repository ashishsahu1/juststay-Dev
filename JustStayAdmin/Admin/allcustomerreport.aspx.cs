using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using JustStay.CommonHub;
using JustStayAdmin.ReportServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class allcustomerreport : BL.BasePage
    {
        public static string strfromdate = "";
        public static string strtodate = "";
        ReportServiceClient reportClient;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnexcel);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnexportpdf);
            if (!IsPostBack)
            {
                BindGrid();
                SetData();
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
              
                List<GetAllCustomer_Report> customerlist = reportClient.GetAllCustomerReport(fromdate, todate, Convert.ToString(textsearch.Text.Trim())).ToList();
                if (customerlist == null) return;
                totalrecord.Text = "Total Records: " + customerlist.Count.ToString();
             
                grdcustomer.DataSource = customerlist;
                grdcustomer.DataBind();
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
                    Response.AddHeader("content-disposition", "attachment;filename=AllCustomerReport" + Convert.ToString(txtfromdate.Value) + "to" + Convert.ToString(txttodate.Value) + ".xls");
                else
                    Response.AddHeader("content-disposition", "attachment;filename=AllCustomerReport.xls");
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
                    Response.AddHeader("content-disposition", "attachment;filename=AllCustomerReport" + Convert.ToString(txtfromdate.Value) + "to" + Convert.ToString(txttodate.Value) + ".pdf");
                else
                    Response.AddHeader("content-disposition", "attachment;filename=AllCustomerReport.pdf");
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
                if (grdcustomer.Rows.Count > 0)
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
                if (grdcustomer.Rows.Count > 0)
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
        protected void grdcustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdcustomer.PageIndex = e.NewPageIndex;
                BindGrid();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "gethtml()", true);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}