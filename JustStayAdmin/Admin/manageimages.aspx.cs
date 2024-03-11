using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class manageimages : BL.BasePage
    {
        public static string path = ConfigurationManager.AppSettings["imagepath"];
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindATRC();
                    BindATRCImages();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindATRCImages();
        }
        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Add")
                {
                    imgid.Value = Convert.ToString(e.CommandArgument);
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnsaveSD_Click(object sender, EventArgs e)
        {
            try
            {
                ATRCImageDto imagedto = new ATRCImageDto
                {
                    ATRCImageId = Convert.ToInt32(imgid.Value),
                    IsSD = chkset.Checked,
                    SDName = txtName.Text,
                    SDDec = txtdec.Text
                };
                ATRCServiceClient atrcClient = new ATRCServiceClient();
                atrcClient.UpdateATRCImageSD(imagedto);
                Response.Redirect("~/Admin/manageimages.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #region  "Private Methods "

        private void BindATRC()
        {
            try
            {
                ATRCServiceClient atrcClient = new ATRCServiceClient();
                drpatrc.DataSource = atrcClient.getAllATRC(1);
                drpatrc.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindATRCImages()
        {
            try
            {
                ATRCServiceClient atrcClient = new ATRCServiceClient();
                grdATRCImages.DataSource = atrcClient.GetAllATRCImagesById(int.Parse(drpatrc.SelectedValue));
                grdATRCImages.DataBind();
            }catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
        protected void chkisprofile_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox ckl = (CheckBox)grdATRCImages.FindControl("chkisprofile");
                ATRCImageDto imagedto = new ATRCImageDto
                {
                    ATRCImageId = Convert.ToInt32(imgid.Value),
                    IsProfile = Convert.ToBoolean(ckl.Checked)
                };
                ATRCServiceClient atrcClient = new ATRCServiceClient();
                atrcClient.UpdateATRCProfile(imagedto);
                Response.Redirect("~/Admin/manageimages.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}