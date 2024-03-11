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
    public partial class aminitylist : BL.BasePage
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
                    BindAmenities();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvAmenities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string amenityid = commandArgs[0];
                    string iconfilename = commandArgs[1];

                    new MastersServiceClient().DeleteAmenity(int.Parse(amenityid));
                    string path = ConfigurationManager.AppSettings["AmenityImages"];
                
                    FileInfo file = new FileInfo(path + iconfilename);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    lblaminitylistmsg.Text = "Amenity delete successfully.";
                    lblaminitylistmsg.ForeColor = System.Drawing.Color.Green;
                    BindAmenities();
                }
            }
            catch(Exception ex)
            {
                lblaminitylistmsg.Text = "Amenity delete failed.";
                lblaminitylistmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  "Private Methods "

        private void BindAmenities()
        {
            try
            {
                MastersServiceClient client = new MastersServiceClient();
                gvAmenities.DataSource = client.GetAllAmenities(int.Parse(drpCategories.SelectedValue));
                gvAmenities.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}