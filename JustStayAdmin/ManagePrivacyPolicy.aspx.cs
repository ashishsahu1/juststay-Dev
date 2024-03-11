using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Services.DTO;
using JustStayAdmin.CancellationPolicySerRef;

namespace JustStayAdmin
{
    public partial class ManagePrivacyPolicy : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                GetPrivacyPolicy();
            }
        }
        private void GetPrivacyPolicy()
        {
            PrivacyPolicyDto ppdto = new CancellationPolicyServiceClient().GetPrivacyPolicy();
            if (ppdto == null) return;
            txtContent.Value = ppdto.PrivacyPolicy.Trim().ToString();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //int blogId = int.Parse(hdBlogId.Value);

            //BlogServiceClient blogClient = new BlogServiceClient();

            //BlogDto blog = new BlogDto()
            //{
            //    BlogId = blogId,
            //    BlogCategoryId = int.Parse(drpCategories.SelectedValue),
            //    BlogTitle = txtTitle.Text,
            //    BlogContent = txtContent.Value,
            //    BlogDate = Convert.ToDateTime(txtBlogDate.Text)
            //};

            //try
            //{
            //    if (blogId == 0)
            //        blogId = blogClient.InsertBlog(blog);
            //    else
            //    {
            //        blogClient.UpdateBlog(blog);

            //        if (blogImageUpload.HasFile)
            //        {
            //            string path = Server.MapPath("~/BlogImages/");

            //            FileInfo file = new FileInfo(path + lblfilename.Text.ToString());
            //            if (file.Exists)//check file exsit or not
            //            {
            //                file.Delete();
            //            }
            //        }
            //    }

            //    SaveFile(blogId, blogClient);


            //    Common.ShowAlertAndNavigate("Blog saved successfully", "ListBlog.aspx");
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowAlertAndNavigate("Save Blog failed", "ListBlog.aspx");
            //}
        }

        #endregion
    }
}