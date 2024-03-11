using System;
using System.Linq;
using System.Web.UI;
using JustStay.CommonHub;
using JustStay.Web.RCBookingServiceReference;
using JustStay.Web.CompanyServiceReference;
using JustStay.Services.DTO;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using JustStay.Web.BusinessLogic;
using HtmlAgilityPack;
using System.Text;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;

namespace JustStay.Web
{
    public partial class Receipt : BasePage
    {
        public string stratrcname, stratrcmobileno, stratrcemail = "";
        public string strcustname, strcustmobileno = "";
        public string strtotaltax, strtotalamount, strgrandtotal = "";
        public string strcurrentdate = "";
        public string strbookingnumber, strbookingdate, strfromtime, strtotime, strperson, strhr = "";
        public string strpaydate, strpaydes, strpaytax, strpayamt = "";
        public string strcompanyname, strcompanysubheading, strcompanyaddress, strcompanymobile, strcompanyemail, strcompanywebsite = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnexportpdf);
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["rcbid"]))
                    {
                        SetCompanyDetails();
                        SetReceiptData(Convert.ToInt32(Request.QueryString["rcbid"]));
                        strcurrentdate = String.Format("{0:d/M/yyyy}", DateTime.Now.Date);
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void ExportGridToPDF()
        {
            try
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=RestChairBookingReceipt-" + hdnbookingnumber.Value + ".pdf");
                //Response.Charset = "";
                //Response.ContentType = "application/pdf";

                //HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
                //HtmlNode.ElementsFlags["input"] = HtmlElementFlag.Closed;
                //HtmlDocument doc = new HtmlDocument();
                //doc.OptionFixNestedTags = true;
                //doc.LoadHtml(strReader.ToString());
                //OrderStatusHTML = doc.DocumentNode.OuterHtml;
                //StringReader strReader = new StringReader(Convert.ToString(Request.Form[hfGridHtml.UniqueID]));
                //Document doc = new Document();
                //PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                //doc.Open();
                //XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, strReader);
                //doc.Close();
                //Response.Write(doc);
                //Response.End();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=RestChairBookingReceipt-" + hdnbookingnumber.Value + ".pdf");
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                string OrderStatusHTML = Convert.ToString(Request.Form[hfGridHtml.UniqueID]);
                HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
                HtmlDocument doc = new HtmlDocument();
                doc.OptionFixNestedTags = true;
                doc.LoadHtml(OrderStatusHTML);
                OrderStatusHTML = doc.DocumentNode.OuterHtml;

                StringReader strReader = new StringReader(OrderStatusHTML);
                Document pdfdoc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
                pdfdoc.Open();


                HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                //Set css
                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath("~/css/bootstrap.css"), true);
                cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath("~/css/receipt.css"), true);
                //Export
                IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(pdfdoc, writer)));

                var worker = new XMLWorker(pipeline, true);
                var xmlParse = new XMLParser(true, worker);
                xmlParse.Parse(strReader);
                xmlParse.Flush();
                pdfdoc.Close();
                Response.Write(pdfdoc);
                Response.End();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void SetCompanyDetails()
        {
            CompanyServiceClient compclient = new CompanyServiceClient();

            try
            {
                CompanyDto cdto = compclient.GetCompany();
                if (cdto == null) return;
                strcompanyaddress = cdto.Address;
                strcompanyname = cdto.CompanyName;
                strcompanysubheading = cdto.Subheading;
                strcompanywebsite = cdto.Website;
                strcompanymobile = cdto.Mobile;
                strcompanyemail = cdto.Email;
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { compclient.Close(); }
        }
        private void SetReceiptData(int rcbid)
        {
            RestChairBookingServiceClient rcbookingclient = new RestChairBookingServiceClient();
            try
            {
                GetBookingReceipt objbookingrecpt = rcbookingclient.GetBookingReceiptDetails(rcbid);
                if (objbookingrecpt == null) return;
                stratrcname = objbookingrecpt.ATRCName;
                stratrcemail = objbookingrecpt.Email;
                stratrcmobileno = objbookingrecpt.Mobile;
                strbookingdate = objbookingrecpt.BookingDate;
                strbookingnumber = objbookingrecpt.BookingNumber;
                hdnbookingnumber.Value = objbookingrecpt.BookingNumber;
                strcustmobileno = objbookingrecpt.CustMobile;
                strcustname = objbookingrecpt.CustName;
                strfromtime = objbookingrecpt.FromTime;
                strtotime = objbookingrecpt.ToTime;
                strhr = objbookingrecpt.Hour;
                strpayamt = objbookingrecpt.NetAmt;
                strpaydate = objbookingrecpt.BookingDate;
                strpaydes = objbookingrecpt.Chairs;
                strtotalamount = objbookingrecpt.NetAmt;
                strgrandtotal = objbookingrecpt.NetAmt;
                strperson = objbookingrecpt.Person;
            }
            catch (Exception ex)
            {
                rcbookingclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                rcbookingclient.Close();
            }
        }
        protected void btnexportpdf_Click(object sender, EventArgs e)
        {
            try
            {
                ExportGridToPDF();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
       


    }
}
