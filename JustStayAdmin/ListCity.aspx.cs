using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.CityServiceReference;

namespace JustStayAdmin
{
    public partial class ListCity : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindCityList();
            }
        }

        protected void gvCitys_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                CityServiceClient cityRepo = new CityServiceClient();
                cityRepo.DeleteCity(int.Parse(e.CommandArgument.ToString()));
                BindCityList();
            }
        }

        protected void gvCitys_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete City?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        protected void gvCitys_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindCityList();
        }

        #endregion

        #region  "Private Methods "

        private void BindCityList()
        {
            CityServiceClient cityRepo = new CityServiceClient();
            gvCitys.DataSource = cityRepo.CityList("");
            gvCitys.DataBind();

            if (gvCitys.Rows.Count > 0)
            {
                gvCitys.UseAccessibleHeader = true;
                gvCitys.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvCitys.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        #endregion
    }
}