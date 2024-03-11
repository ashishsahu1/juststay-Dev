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
    public partial class ListBlog : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindCategories();
                BindBlogs();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindBlogs();
        }

        protected void grdBlogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int eid = Convert.ToInt32(grdBlogs.DataKeys[e.RowIndex].Value);
            string name = grdBlogs.Rows[e.RowIndex].Cells[3].Text;
            DeleteBlog(eid, name);
            BindBlogs();
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
            catch
            { }
        }

        #endregion

        #region  " Private Methods "

        private void BindBlogs()
        {
            BlogServiceClient blogClient = new BlogServiceClient();
            grdBlogs.DataSource = blogClient.GetBlogs(int.Parse(drpCategories.SelectedValue)).ToList();
            grdBlogs.DataBind();

            if (grdBlogs.Rows.Count > 0)
            {
                grdBlogs.UseAccessibleHeader = true;
                grdBlogs.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdBlogs.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindCategories()
        {
            BlogServiceClient blogClient = new BlogServiceClient();

            drpCategories.DataSource = blogClient.GetBlogCategories().ToList();
            drpCategories.DataBind();
        }

        private void DeleteBlog(int blogid, string filename)
        {
            try
            {
                BlogServiceClient blogClient = new BlogServiceClient();
                blogClient.DeletBlog(blogid);

                string path = Server.MapPath("~/BlogImages/");
                FileInfo file = new FileInfo(path + filename);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Blog Deleted Successfully.')", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Blog Deletion Failed.')", true);
            }
        }

        #endregion
    }
}