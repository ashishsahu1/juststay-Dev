using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using JustStay.ATRC.UserServiceReference;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text.RegularExpressions;

public class Common
{
    public static int UserId
    {
        get
        {
            int UserId = 0;
            if (HttpContext.Current.Session["User"] != null)
            {
                UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                UserId = Convert.ToInt32(udto.UserId);
            }
            return UserId;
        }
    }

    public static string UserName
    {
        get
        {
            string UserName = "";
            if (HttpContext.Current.Session["User"] != null)
            {
                UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                UserName = udto.Name.ToString();
            }
            return UserName;
        }
    }

    public static int ATRCId
    {
        get
        {
            int atrcId = 0;
            if (HttpContext.Current.Session["User"] != null)
            {
                UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                atrcId = udto.ATRCId;
            }
            return atrcId;
        }
    }

    public static string ATRCName
    {
        get
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                return udto.ATRCName;
            }
            return "";
        }
    }

    public static int ATRCStatus
    {
        get
        {
            int status = 0;
            if (HttpContext.Current.Session["User"] != null)
            {
                UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                status = udto.ATRCStatus;
            }
            return status;
        }
    }

    public static void AddSortImage(GridViewRow headerRow, GridView grd, string m_strSortExp, SortDirection m_SortDirection)
    {
        Int32 iCol = GetSortColumnIndex(m_strSortExp, grd);
        if (-1 == iCol || !string.IsNullOrEmpty(headerRow.Cells[iCol].Text))
        {
            return;
        }
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        sortImage.Style.Add("padding-left", "10px");
        //sortImage.Style.Add("align", "right");
        sortImage.ImageUrl = "~/Admin/images/arrow_large_up.png";
        sortImage.AlternateText = "No Sort Order";

        if (m_SortDirection == SortDirection.Ascending)
        {
            sortImage.ImageUrl = "~/Admin/images/arrow_large_up.png";
            sortImage.AlternateText = "Ascending Order";
        }
        else if (m_SortDirection == SortDirection.Descending)
        {
            sortImage.ImageUrl = "~/Admin/images/arrow_large_down.png";
            sortImage.AlternateText = "Descending Order";
        }


        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    public static int GetSortColumnIndex(String strCol, GridView grd)
    {
        foreach (DataControlField field in grd.Columns)
        {
            if (field.SortExpression == strCol)
            {
                return grd.Columns.IndexOf(field);
            }
        }

        return -1;
    }
    public static string NumberToWord(int num)
    {
        if (num == 0)
            return "Zero";

        if (num < 0)
            return "Not supported";

        var words = "";
        string[] strones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] strtens = { "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };


        int crore = 0, lakhs = 0, thousands = 0, hundreds = 0, tens = 0, single = 0;


        crore = num / 10000000; num = num - crore * 10000000;
        lakhs = num / 100000; num = num - lakhs * 100000;
        thousands = num / 1000; num = num - thousands * 1000;
        hundreds = num / 100; num = num - hundreds * 100;
        if (num > 19)
        {
            tens = num / 10; num = num - tens * 10;
        }
        single = num;


        if (crore > 0)
        {
            if (crore > 19)
                words += NumberToWord(crore) + "Crore ";
            else
                words += strones[crore - 1] + " Crore ";
        }

        if (lakhs > 0)
        {
            if (lakhs > 19)
                words += NumberToWord(lakhs) + "Lakh ";
            else
                words += strones[lakhs - 1] + " Lakh ";
        }

        if (thousands > 0)
        {
            if (thousands > 19)
                words += NumberToWord(thousands) + "Thousand ";
            else
                words += strones[thousands - 1] + " Thousand ";
        }

        if (hundreds > 0)
            words += strones[hundreds - 1] + " Hundred ";

        if (tens > 0)
            words += strtens[tens - 2] + " ";

        if (single > 0)
            words += strones[single - 1] + " ";

        return words;
    }

    public static decimal DefaultGSTRate { get { return Convert.ToDecimal("0.00"); } }

    public static ExcelPackage ConvertGridToExcel(GridView grid, string sheetName, string headerRange, int columnsToSkip, int firstColumn = 1)
    {
        ExcelPackage excel = new ExcelPackage();

        var workSheet = excel.Workbook.Worksheets.Add(sheetName);
        var totalCols = grid.Rows[0].Cells.Count - columnsToSkip;
        var totalRows = grid.Rows.Count;
        var headerRow = grid.HeaderRow;
        int cellIndex = 1;

        for (var i = firstColumn; i <= totalCols; i++)
        {
            TableCell cell = headerRow.Cells[i - 1];
            string headerName = cell.Text;

            if (cell.HasControls())
            {
                if (cell.Controls[0] is LinkButton) //when gridview is sortable, type of header is LinkButton
                {
                    LinkButton headerControl = cell.Controls[0] as LinkButton;
                    headerName = headerControl.Text;
                }
            }

            workSheet.Cells[1, cellIndex].Value = headerName;
            cellIndex++;
        }


        for (var j = 1; j <= totalRows; j++)
        {
            cellIndex = 1;
            for (var i = firstColumn; i <= totalCols; i++)
            {
                TableCell dataCell = grid.Rows[j - 1].Cells[i - 1];

                if (dataCell.HasControls())
                {
                    if (dataCell.Controls.Count > 0 && dataCell.Controls[1] is Label)
                    {
                        Label headerControl = dataCell.Controls[1] as Label;
                        workSheet.Cells[j + 1, cellIndex].Value = headerControl.Text;
                    }
                }
                else
                {
                    workSheet.Cells[j + 1, cellIndex].Value = dataCell.Text;
                }

                cellIndex++;
            }
        }

        cellIndex = 1;

        var footerRow = grid.FooterRow;
        for (var i = firstColumn; i <= totalCols; i++)
        {
            TableCell cell = footerRow.Cells[i - 1];
            string footerName = cell.Text.Replace("&nbsp;", "");

            if (cell.HasControls())
            {
                if (cell.Controls[1] is Label)
                {
                    Label footerControl = cell.Controls[1] as Label;
                    footerName = footerControl.Text;
                }
            }

            workSheet.Cells[totalRows + 2, cellIndex].Value = footerName;
            cellIndex++;
        }


        var headerCellRange = workSheet.Cells[headerRange];

        headerCellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
        headerCellRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
        headerCellRange.Style.Font.Bold = true;
        workSheet.Cells.AutoFitColumns();

        return excel;
    }

    public static void ShowAlertAndNavigate(string message, string destinationUrl)
    {
        var page = HttpContext.Current.CurrentHandler as Page;
        string alert_redirect_Script = string.Format(@"alert('{0}');window.location.href = '{1}';", message, destinationUrl);
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertredirectscript", alert_redirect_Script, true);
    }

    public static int SendMail(string FromEmail, string[] ToEmail, string Subject, string Body, List<Attachment> attachments = null)
    {
        MailMessage objMail = new MailMessage
        {
            Body = Body,
            Subject = Subject
        };

        for (int i = 0; i < ToEmail.Length; i++)
        {
            if (!string.IsNullOrEmpty(ToEmail[i]))
                objMail.To.Add(ToEmail[i]);
        }

        objMail.Bcc.Add("nmskaar.business@gmail.com");
        objMail.From = new MailAddress(FromEmail, "JustStay");
        objMail.BodyEncoding = System.Text.Encoding.UTF8;
        objMail.Body = Body;
        objMail.IsBodyHtml = true;
        objMail.Priority = MailPriority.High;

        //Add multiple attachment
        if (attachments != null)
        {
            foreach (var attachment in attachments)
            {
                objMail.Attachments.Add(attachment);
            }
        }

        SmtpClient mailClient = new SmtpClient("smtp.gmail.com")
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            UseDefaultCredentials = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new System.Net.NetworkCredential("juststaypune@gmail.com", "sanjay6990")
        };

        try
        {
            mailClient.Send(objMail);
            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public static void SetProtocol()
    {
        string sslEnable = System.Configuration.ConfigurationManager.AppSettings["isSiteLive"].ToString();
        if (sslEnable.ToLower() == "true")
        {
            if (!HttpContext.Current.Request.IsSecureConnection)
            {
                string redirectUrl = null;
                redirectUrl = HttpContext.Current.Request.Url.ToString().Replace("http:", "https:");
                HttpContext.Current.Response.Status = "301 Moved permanently";
                HttpContext.Current.Response.AddHeader("Location", redirectUrl);
            }
        }

    }
    public static string GetUserType(string email)
    {
        if (email.Contains("(Admin)"))
            return "Admin";
        else if (email.Contains("(ATRC)"))
            return "ATRC";
        else if (email.Contains("(Customer)"))
            return "Customer";
        else
            return "";
    }

    public static string RemoveHTMLTag(string Text)
    {
        return Regex.Replace(Text, @"<(.|\n)*?>", string.Empty);
    }

    public static string RemoveComma(string strTmp)
    {
        if (strTmp != "")
            return strTmp.Substring(1, strTmp.Length - 1);
        else
            return "";
    }
   
    public static string UserEmail
    {
        get
        {
            string email = "";
            if (HttpContext.Current.Session["User"] != null)
            {
                UserDto udto = (UserDto)HttpContext.Current.Session["User"];
                email = udto.Email.ToString();
            }
            return email;
        }
    }
        public static DateTime ConvertDateTimeFormat(string s)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return DateTime.ParseExact(s, "MM/dd/yyyy", culture);
        }
}
