using JustStay.CommonHub;
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
    public partial class blogs : BL.BasePage
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
                    BindBlogs();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindBlogs();
        }

        protected void grdBlogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int eid = Convert.ToInt32(grdBlogs.DataKeys[e.RowIndex].Value);
                string name = grdBlogs.Rows[e.RowIndex].Cells[3].Text;
                DeleteBlog(eid, name);
                BindBlogs();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdBlogs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Delete")
            //{

            //}
        }

        protected void grdBlogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Blog?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindBlogs()
        {
            blogClient = new BlogServiceClient();
            try
            {
                grdBlogs.DataSource = blogClient.GetBlogs(int.Parse(drpCategories.SelectedValue)).ToList();
                grdBlogs.DataBind();
                blogClient.Close();
            }
            catch (Exception ex)
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

        private void DeleteBlog(int blogid, string filename)
        {
            blogClient = new BlogServiceClient();
            try
            {
                blogClient.DeletBlog(blogid);
                string path = Path.Combine(ConfigurationManager.AppSettings["BlogImages"], filename);
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }
                lblbloglistmsg.Text = "Blog Deleted Successfully.";
                lblbloglistmsg.ForeColor = System.Drawing.Color.Green;
                blogClient.Close();
            }
            catch(Exception ex)
            {
                lblbloglistmsg.Text = "Blog Deletion Failed.";
                lblbloglistmsg.ForeColor = System.Drawing.Color.Red;
                blogClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { blogClient.Close(); }
        }

        #endregion
    }
}