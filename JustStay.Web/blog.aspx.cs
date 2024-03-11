using JustStay.CommonHub;
using JustStay.Web.BlogServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindBlogs();
        }
        private void BindBlogs()
        {
            BlogServiceClient blogClient = new BlogServiceClient();
            try
            {
                rtpblog.DataSource = blogClient.GetBlogsWithDetail();
                rtpblog.DataBind();
                blogClient.Close();
            }
            catch(Exception ex)
            {
                blogClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}