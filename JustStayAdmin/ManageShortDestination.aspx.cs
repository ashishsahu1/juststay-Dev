using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.ATRCServiceReference;
using JustStay.Services.DTO;

namespace JustStayAdmin
{
    public partial class ManageShortDestination : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                BindATRC();
                BindATRCImages();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindATRCImages();
        }
        #endregion

        #region  "Private Methods "

        private void BindATRC()
        {
            ATRCServiceClient atrcClient = new ATRCServiceClient();
            drpatrc.DataSource = atrcClient.getAllATRC(1);
            drpatrc.DataBind();
        }
        private void BindATRCImages()
        {
            ATRCServiceClient atrcClient = new ATRCServiceClient();
            grdATRCImages.DataSource = atrcClient.GetAllATRCImagesById(int.Parse(drpatrc.SelectedValue));
            grdATRCImages.DataBind();
        }
        #endregion

        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Add")
            {
                imgid.Value = Convert.ToString(e.CommandArgument);
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
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
                Response.Redirect("~/ManageShortDestination.aspx");
            }
            catch(Exception ex)
            { }
           
        }
    }
}