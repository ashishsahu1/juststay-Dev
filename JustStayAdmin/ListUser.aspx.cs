using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.UserServiceReference;

namespace JustStayAdmin
{
    public partial class ListUser : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindUserList();
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                UserServiceClient userRepo = new UserServiceClient();
                userRepo.DeleteUser(int.Parse(e.CommandArgument.ToString()));
                BindUserList();
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete User?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindUserList();
        }

        #endregion

        #region  "Private Methods "

        private void BindUserList()
        {
            UserServiceClient userRepo = new UserServiceClient();
            gvUsers.DataSource = userRepo.UserList();
            gvUsers.DataBind();

            if (gvUsers.Rows.Count > 0)
            {
                gvUsers.UseAccessibleHeader = true;
                gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvUsers.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        #endregion
    }
}