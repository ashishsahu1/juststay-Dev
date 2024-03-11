using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListRoomTypes : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindRoomTypeList();
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
                    foreach (LinkButton button in e.Row.Cells[4].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Room Type?')){ return false; };";
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
                new MastersServiceClient().DeleteRoomType(int.Parse(e.CommandArgument.ToString()));
                BindRoomTypeList();
            }
        }

        #endregion

        #region  "Private Methods "

        private void BindRoomTypeList()
        {
            MastersServiceClient masterClient = new MastersServiceClient();
            gvTypes.DataSource = masterClient.GetAllRoomTypes();
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