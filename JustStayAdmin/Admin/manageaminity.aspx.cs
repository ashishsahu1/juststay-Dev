using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.Admin.BL;
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
    public partial class manageaminity : BL.BasePage
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
                    if (Request.QueryString["Id"] != null)
                    {
                        hdAmentityId.Value = new RC4().Decrypt(Request.QueryString["Id"]);
                        BindAmenity();
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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

                lblaminitymsg.Text = "Amenity saved successfully";
                lblaminitymsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblaminitymsg.Text = "Save Amenity failed";
                lblaminitymsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindAmenity()
        {
            try
            {
                MastersServiceClient mastersclient = new MastersServiceClient();
                AmenityDto dto = mastersclient.GetAmenityById(int.Parse(hdAmentityId.Value));
                txtname.Text = dto.Name;
                drpCategories.SelectedValue = dto.CategoryId.ToString();
                lblfilename.Text = dto.IconFileName;
                lblImageName.Text = dto.IconName;
                rfvImage.Enabled = false;
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void SaveProfileImage(int amenityId, MastersServiceClient mastersclient)
        {
            try
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}