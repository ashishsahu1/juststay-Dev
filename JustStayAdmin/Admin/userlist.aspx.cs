using JustStay.CommonHub;
using JustStayAdmin.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class userlist : BL.BasePage
    {
        UserServiceClient userRepo;
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    BindUserList();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            userRepo = new UserServiceClient();
            try
            {
                if (e.CommandName == "Delete")
                {
                    
                    userRepo.DeleteUser(int.Parse(e.CommandArgument.ToString()));
                    BindUserList();
                }
                userRepo.Close();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { userRepo.Close(); }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[8].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete User?')){ return false; };";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUsers.PageIndex = e.NewPageIndex;
                BindUserList();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  "Private Methods "

        private void BindUserList()
        {
            userRepo = new UserServiceClient();
            try
            {
                gvUsers.DataSource = userRepo.UserList().OrderByDescending(uid => uid.UserId).ToList();
                gvUsers.DataBind();
                userRepo.Close();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { userRepo.Close(); }
        }

        #endregion

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}