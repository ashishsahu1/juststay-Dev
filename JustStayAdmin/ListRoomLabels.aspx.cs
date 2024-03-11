using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListRoomLabels : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindRoomLabels();
            }
        }

        protected void gvTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvTypes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[3].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Room Label?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        protected void gvTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                new MastersServiceClient().DeleteRoomLabel(int.Parse(e.CommandArgument.ToString()));
                BindRoomLabels();
            }
        }

        #endregion

        #region  "Private Methods "

        private void BindRoomLabels()
        {
            MastersServiceClient client = new MastersServiceClient();
            gvTypes.DataSource = client.GetAllRoomLabels();
            gvTypes.DataBind();

            if (gvTypes.Rows.Count > 0)
            {
                gvTypes.UseAccessibleHeader = true;
                gvTypes.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvTypes.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion
    }
}