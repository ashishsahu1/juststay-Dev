using JustStay.CommonHub;
using JustStayAdmin.MastersServiceReference;
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
    public partial class roomlabel : BL.BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    BindRoomLabels();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string id = commandArgs[0];
                    string iconfilename = commandArgs[1];
                    new MastersServiceClient().DeleteRoomLabel(int.Parse(id));
                    string path = ConfigurationManager.AppSettings["AmenityImages"];

                    FileInfo file = new FileInfo(path + iconfilename);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    BindRoomLabels();
                    lblroomlabelmsg.Text = "Room Label deleted successfully.";
                    lblroomlabelmsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch(Exception ex)
            {
                lblroomlabelmsg.Text = "Room Label not deleted successfully.";
                lblroomlabelmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  "Private Methods "

        private void BindRoomLabels()
        {
            try
            {
                MastersServiceClient client = new MastersServiceClient();
                gvTypes.DataSource = client.GetAllRoomLabels();
                gvTypes.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}