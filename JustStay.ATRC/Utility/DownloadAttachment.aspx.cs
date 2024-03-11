using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC.Utility
{
    public partial class DownloadAttachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string attachmentPath = "";
            Response.Clear();
            Response.Buffer = false;
            if (Request.QueryString["DocName"] != null)
            {

                string DocName = (Request.QueryString["DocName"]);
                string Extn = Path.GetExtension(DocName);
                switch (Extn.ToLower())
                {
                    case (".txt"):
                        Response.ContentType = "text/plain";
                        break;
                    case (".bmp"):
                        Response.ContentType = "image/x-ms-bmp";
                        break;
                    case (".jpg"):
                        Response.ContentType = "image/jpeg";
                        break;
                    case (".doc"):
                        Response.ContentType = "application/msword";
                        break;
                    case (".html"):
                    case (".htm"):
                        Response.ContentType = "text/html";
                        break;
                    case (".js"):
                        Response.ContentType = "application/x-javascript";
                        break;
                    case (".xls"):
                    case (".xlsx"):
                        Response.ContentType = "application/x-msexcel";//"application/excel";
                        break;
                    case (".zip"):
                        Response.ContentType = "application/x-zip-compressed";
                        break;
                    case (".pdf"):
                        Response.ContentType = "application/pdf";
                        break;
                    default:
                        Response.ContentType = "application/octet-stream";
                        break;
                }
                try
                {
                    if (Convert.ToString(Request.QueryString["Mode"]) == "Sent")
                    {
                        attachmentPath = Path.Combine(Server.MapPath("~/EmailAttachments"), DocName);
                    }
                    else
                    {
                        attachmentPath = Path.Combine(ConfigurationManager.AppSettings["Attachments"], DocName);
                    }
                    
                    string[] name = DocName.Trim().Split('_');
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + name[2]);
                    Response.WriteFile(attachmentPath);
                    Response.End();
                }
                catch (Exception ex)
                {
                    Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
            }
        }
    }
}