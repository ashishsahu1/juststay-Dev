using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Web.BlogServiceReference;
using JustStay.Services.DTO;
using JustStay.CommonHub;

namespace JustStay.Web
{
    public partial class fullblog : System.Web.UI.Page
    {
        public static string strimagename, strblogtitle, strdate, strcontent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetBlog();
            }
        }
        private void SetBlog()
        {
            BlogServiceClient bclient = new BlogServiceClient();
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["bid"]))
                {
                    BlogDto blog = bclient.GetBlogById(Convert.ToInt32(Request.QueryString["bid"]));
                    if (blog == null) return;
                    strimagename = Convert.ToString(blog.BlogImageNewName);
                    strblogtitle = Convert.ToString(blog.BlogTitle);
                    strdate = Convert.ToString(blog.BlogDate.ToShortDateString());
                    strcontent = Convert.ToString(blog.BlogContent);
                }
                bclient.Close();
            }
            catch (Exception ex)
            {
                bclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}