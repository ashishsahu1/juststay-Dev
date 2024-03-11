using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.BlogServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class manageblog : BL.BasePage
    {
        BlogServiceClient blogClient;

        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);

                if (!IsPostBack)
                {
                    BindCategories();
                    if (Request.QueryString["Id"] != null)
                    {
                        hdBlogId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Request.QueryString["Id"]);
                        BindBlog();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            blogClient = new BlogServiceClient();
            try
            {
                int blogId = int.Parse(hdBlogId.Value);
                BlogDto blog = new BlogDto()
                {
                    BlogId = blogId,
                    BlogCategoryId = int.Parse(drpCategories.SelectedValue),
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogContent = txtContent.Text.Trim(),
                    BlogDate = Convert.ToDateTime(txtBlogDate.Value.Trim())
                };
                if (blogId == 0)
                    blogId = blogClient.InsertBlog(blog);
                else
                {
                    blogClient.UpdateBlog(blog);

                    if (blogImageUpload.HasFile)
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["BlogImages"], lblfilename.Text.ToString());

                        FileInfo file = new FileInfo(path);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                }
                SaveFile(blogId, blogClient);
                lblblogmsg.Text = "Blog saved successfully";
                lblblogmsg.ForeColor = System.Drawing.Color.Green;
                blogClient.Close();
            }
            catch (Exception ex)
            {
                blogClient.Close();
                lblblogmsg.Text = "Save Blog failed";
                lblblogmsg.ForeColor = System.Drawing.Color.Green;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                blogClient.Close();
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindBlog()
        {
             blogClient = new BlogServiceClient();
            try
            {
               
                BlogDto blog = blogClient.GetBlogById(int.Parse(hdBlogId.Value));
                drpCategories.SelectedValue = blog.BlogCategoryId.ToString();
                txtTitle.Text = blog.BlogTitle;
                txtContent.Text = blog.BlogContent;
                txtBlogDate.Value = Convert.ToString(blog.BlogDate);
                lblfilename.Text = blog.BlogImageNewName;
                lblImageName.Text = blog.BlogImageName;
                blogClient.Close();
            }
            catch(Exception ex)
            {
                blogClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { blogClient.Close(); }
        }

        private void BindCategories()
        {
            blogClient = new BlogServiceClient();
            try
            {
               
                drpCategories.DataSource = blogClient.GetBlogCategories().ToList();
                drpCategories.DataBind();
                blogClient.Close();
            }
            catch (Exception ex)
            {
                blogClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { blogClient.Close(); }
        }

        private void SaveFile(int blogId, BlogServiceClient blogClient)
        {
            try
            {
                if (blogImageUpload.HasFile)
                {
                    string filename = Path.GetFileName(blogImageUpload.PostedFile.FileName);
                    string path = Path.Combine(ConfigurationManager.AppSettings["BlogImages"], blogId + "_" + filename);
                    blogImageUpload.SaveAs(path);
                    BlogDto dto = new BlogDto { BlogId = blogId };
                    dto.BlogImageName = filename;
                    dto.BlogImageNewName = Convert.ToString(blogId + "_" + filename);
                    blogClient.UpdateBlogImage(dto);
                }
            }
            catch(Exception ex)
            {
                blogClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { blogClient.Close(); }
        }

        #endregion
    }
}