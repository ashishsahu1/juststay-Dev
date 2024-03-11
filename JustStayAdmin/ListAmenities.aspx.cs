using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListAmenities : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindAmenities();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAmenities();
        }

        protected void gvAmenities_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvAmenities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[3].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Amenity?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        protected void gvAmenities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {                
                new MastersServiceClient().DeleteAmenity(int.Parse(e.CommandArgument.ToString()));
                BindAmenities();
            }
        }

        #endregion

        #region  "Private Methods "

        private void BindAmenities()
        {
            MastersServiceClient client = new MastersServiceClient();
            gvAmenities.DataSource = client.GetAllAmenities(int.Parse(drpCategories.SelectedValue));
            gvAmenities.DataBind();

            if (gvAmenities.Rows.Count > 0)
            {
                gvAmenities.UseAccessibleHeader = true;
                gvAmenities.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvAmenities.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion

       
    }
}