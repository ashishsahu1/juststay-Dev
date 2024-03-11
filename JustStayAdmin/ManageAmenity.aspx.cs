using JustStay.Services.DTO;
using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageAmenity : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    hdAmentityId.Value = Request.QueryString["Id"];
                    BindAmenity();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            int id = int.Parse(hdAmentityId.Value);

            MastersServiceClient mastersclient = new MastersServiceClient();
            try
            {
                AmenityDto dto = new AmenityDto()
                {
                    AmenityId = id,
                    Name = txtname.Text,
                    CategoryId = int.Parse(drpCategories.SelectedValue)
                };

                if (id == 0)
                    id = mastersclient.InsertAmenity(dto);
                else
                {
                    mastersclient.UpdateAmenity(dto);

                    if (amImageUpload.HasFile)
                    {
                        string path = ConfigurationManager.AppSettings["AmenityImages"];

                        FileInfo file = new FileInfo(path + lblfilename.Text.ToString());
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                    }

                }

                SaveProfileImage(id, mastersclient);

                Common.ShowAlertAndNavigate("Amenity saved successfully", "ListAmenities.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Amenity failed", "ListAmenities.aspx");
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindAmenity()
        {
            MastersServiceClient mastersclient = new MastersServiceClient();
            AmenityDto dto = mastersclient.GetAmenityById(int.Parse(hdAmentityId.Value));
            txtname.Text = dto.Name;
            drpCategories.SelectedValue = dto.CategoryId.ToString();
            lblfilename.Text = dto.IconFileName;
            lblImageName.Text = dto.IconName;
            rfvImage.Enabled = false;
        }

        private void SaveProfileImage(int amenityId, MastersServiceClient mastersclient)
        {
            if (amImageUpload.HasFile)
            {
                string filename = Path.GetFileName(amImageUpload.PostedFile.FileName);
                string newFileName = Convert.ToString(amenityId + "_" + filename);
                string path = Path.Combine(ConfigurationManager.AppSettings["AmenityImages"], newFileName);
                amImageUpload.SaveAs(path);

                AmenityDto dto = new AmenityDto { AmenityId = amenityId };
                dto.IconName = filename;
                dto.IconFileName = newFileName;
                mastersclient.UpdateAmenityIcon(dto);
            }
        }

        #endregion

    }
}