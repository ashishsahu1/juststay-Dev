using JustStay.Services.DTO;
using JustStayAdmin.BlogServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageBlog : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindCategories();
                if (Request.QueryString["Id"] != null)
                {
                    hdBlogId.Value = Request.QueryString["Id"];
                    BindBlog();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int blogId = int.Parse(hdBlogId.Value);

            BlogServiceClient blogClient = new BlogServiceClient();

            BlogDto blog = new BlogDto()
            {
                BlogId = blogId,
                BlogCategoryId = int.Parse(drpCategories.SelectedValue),
                BlogTitle = txtTitle.Text,
                BlogContent = txtContent.Value,
                BlogDate = Convert.ToDateTime(txtBlogDate.Text)
            };

            try
            {
                if (blogId == 0)
                    blogId = blogClient.InsertBlog(blog);
                else
                {
                    blogClient.UpdateBlog(blog);

                    if (blogImageUpload.HasFile)
                    {
                        string path = Server.MapPath("~/BlogImages/");

                        FileInfo file = new FileInfo(path + lblfilename.Text.ToString());
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                    }
                }

                SaveFile(blogId, blogClient);


                Common.ShowAlertAndNavigate("Blog saved successfully", "ListBlog.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Blog failed", "ListBlog.aspx");
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindBlog()
        {
            BlogServiceClient blogClient = new BlogServiceClient();
            BlogDto blog = blogClient.GetBlogById(int.Parse(hdBlogId.Value));
            drpCategories.SelectedValue = blog.BlogCategoryId.ToString();
            txtTitle.Text = blog.BlogTitle;
            txtContent.Value = blog.BlogContent;
            txtBlogDate.Text = Convert.ToDateTime(blog.BlogDate).ToString("dd/MM/yyyy");
            lblfilename.Text = blog.BlogImageNewName;
            lblImageName.Text = blog.BlogImageName;
        }

        private void BindCategories()
        {
            BlogServiceClient blogClient = new BlogServiceClient();

            drpCategories.DataSource = blogClient.GetBlogCategories().ToList();
            drpCategories.DataBind();
        }

        private void SaveFile(int blogId, BlogServiceClient blogClient)
        {
            if (blogImageUpload.HasFile)
            {
                string filename = Path.GetFileName(blogImageUpload.PostedFile.FileName);
                string newFileName = Convert.ToString(blogId + "_" + filename);
                string path = Server.MapPath("~/BlogImages/");
                string FullPath = path + newFileName;
                blogImageUpload.SaveAs(FullPath);

                BlogDto dto = new BlogDto { BlogId = blogId };
                dto.BlogImageName = filename;
                dto.BlogImageNewName = newFileName;
                blogClient.UpdateBlogImage(dto);
            }

        }

        #endregion
    }
}