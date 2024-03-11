using JustStayAdmin.BannerServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListBanner : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindBannerList();
            }
        }

        protected void gvBanners_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvBanners.DataKeys[e.RowIndex].Value);
            string name = gvBanners.Rows[e.RowIndex].Cells[4].Text;
            DeleteBanner(id, name);
            BindBannerList();
        }
      
        protected void gvBanners_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Banner?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region  " Private Methods "

        private void BindBannerList()
        {
            BannerServiceClient bannerClient = new BannerServiceClient();
            gvBanners.DataSource = bannerClient.GetBanners().ToList();
            gvBanners.DataBind();

            if (gvBanners.Rows.Count > 0)
            {
                gvBanners.UseAccessibleHeader = true;
                gvBanners.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvBanners.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void DeleteBanner(int bannerId, string filename)
        {
            try
            {
                BannerServiceClient bannerClient = new BannerServiceClient();
                bannerClient.DeletBanner(bannerId);

                string path = Server.MapPath("~/BannerImages/");
                FileInfo file = new FileInfo(path + filename);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Banner Deleted Successfully.')", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Banner Deletion Failed.')", true);
            }
        }


        #endregion
    }
}