using JustStay.Services.DTO;
using JustStayAdmin.BannerServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageBanner : BasePage
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
                    hdBannerId.Value = Request.QueryString["Id"];
                    BindBanner();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int bannerId = int.Parse(hdBannerId.Value);

            BannerServiceClient bannerClient = new BannerServiceClient();

            BannerDto banner  = new BannerDto()
            {
                BannerId = bannerId,                
                Heading = txtHeading.Text,
                SubHeading=txtSubHeading.Text,
                Description = txtContent.Value               
            };

            try
            {
                if (bannerId == 0)
                    bannerId = bannerClient.InsertBanner(banner);
                else
                {
                    bannerClient.UpdateBanner(banner);

                    if (bannerImageUpload.HasFile)
                    {
                        string path = Server.MapPath("~/BannerImages/");

                        FileInfo file = new FileInfo(path + lblfilename.Text.ToString());
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                    }
                }

                SaveFile(bannerId, bannerClient);


                Common.ShowAlertAndNavigate("Banner saved successfully", "ListBanner.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Banner failed", "ListBanner.aspx");
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindBanner()
        {
            BannerServiceClient bannerClient = new BannerServiceClient();
            BannerDto banner = bannerClient.GetBannerById(int.Parse(hdBannerId.Value));

            txtHeading.Text = banner.Heading;
            txtSubHeading.Text = banner.SubHeading;
            txtContent.Value = banner.Description;          
            lblfilename.Text = banner.ImageNewName;
            rfvImage.Enabled = false;           
            hlImage.Text = banner.ImageName;
            hlImage.NavigateUrl = "/Utility/DownloadAttachment.aspx?From=BN&DocName=" + banner.ImageNewName;
        }

        private void SaveFile(int bannerId, BannerServiceClient bannerClient)
        {
            if (bannerImageUpload.HasFile)
            {
                string filename = Path.GetFileName(bannerImageUpload.PostedFile.FileName);
                string newFileName = Convert.ToString(bannerId + "_" + filename);
                string path = Server.MapPath("~/BannerImages/");
                string FullPath = path + newFileName;
                bannerImageUpload.SaveAs(FullPath);

                BannerDto banner = new BannerDto { BannerId = bannerId };
                banner.ImageName = filename;
                banner.ImageNewName = newFileName;
                bannerClient.UpdateBannerImage(banner);
            }
        }

        #endregion
    }
}