using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CommonServiceReference;
using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class UpdateATRC : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    hdATRCId.Value = Request.QueryString["Id"];
                    BindMasterDetails();
                    BindStates();
                    BindCities();
                    BindATRCDetails();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            ATRCDto center = ATRCServiceclient.GetATRCById(int.Parse(hdATRCId.Value));

            center.ATRCName = txtRestName.Text;
            center.Details = txtATRCDtails.Value;
            center.Category = string.Join(",", chkCategory.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));
            center.Address = txtAddress.Text;
            center.OwnerName = txtOwnerName.Text;
            center.Email = txtemail.Text;
            center.Telephone = txtTel.Text;
            center.Mobile = txtMobile.Text;
            center.StateId = int.Parse(drpState.SelectedValue);
            center.CityId = int.Parse(drpCity.SelectedValue);
            var locationId = HttpContext.Current.Request.Form["ctl00$main$drpLocation"];
            center.LocationId = int.Parse(locationId);

            if (!string.IsNullOrEmpty(hdLat.Value))
            {
                center.Latitude = Convert.ToDecimal(hdLat.Value);
                center.Longitude = Convert.ToDecimal(hdLng.Value);
                center.GeoLocationName = txtGeoLoc.Text;
            }

            center.DiningFacility = !string.IsNullOrEmpty(rblDining.SelectedValue) ? int.Parse(rblDining.SelectedValue) : (int?)null;
            center.DiningFromTime = !string.IsNullOrEmpty(txtDiningFrom.Text) ? DateTime.Parse(txtDiningFrom.Text).TimeOfDay : (TimeSpan?)null;
            center.DiningToTime = !string.IsNullOrEmpty(txtDiningTo.Text) ? DateTime.Parse(txtDiningTo.Text).TimeOfDay : (TimeSpan?)null;

            center.highlights = Common.GetSelectedValues(chkHighlights);
            center.Cuisines = Common.GetSelectedValues(chkCuisines);
            center.Amenities = Common.GetSelectedValues(chkAmenities);
            center.Referral = Common.GetSelectedValues(chkReferral);

            ATRCServiceclient.UpdateATRC(center);

            //if (center.Category.Contains("1"))
            //{
            //    int restChairId = int.Parse(hdRestChairId.Value);
            //    ATRCRestChairDTO chair = new ATRCRestChairDTO()
            //    {
            //        RestChairId = restChairId,
            //        NumberOfChairs = int.Parse(txtNumberOfchair.Text),
            //        FromTime = !string.IsNullOrEmpty(txtFromTime.Text) ? DateTime.Parse(txtFromTime.Text).TimeOfDay : (TimeSpan?)null,
            //        ToTime = !string.IsNullOrEmpty(txtToTime.Text) ? DateTime.Parse(txtToTime.Text).TimeOfDay : (TimeSpan?)null
            //    };

            //    ATRCServiceclient.UpdateATRCRestChair(chair);
            //}

            if (profileImageUpload.HasFile)
            {
                string path = ConfigurationManager.AppSettings["ATRCImages"];

                FileInfo file = new FileInfo(path + lblProfileImage.Text.ToString());
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }

                SaveProfileImage(center.ATRCId, ATRCServiceclient);
            }

            string FileName = "";
            HttpFileCollection hfc = Request.Files;
            if (hfc.Count > 0)
            {
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    FileName = System.IO.Path.GetFileName(hpf.FileName);
                    if (hpf.ContentLength > 0)
                    {
                        if (!hfc.GetKey(i).Contains("profileImageUpload"))
                        {

                            ATRCImageDto image = new ATRCImageDto();
                            string newFileName = center.ATRCId + "_" + FileName;
                            string docpath = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], newFileName);
                            hpf.SaveAs(docpath);
                            image.ImageName = FileName.ToString();
                            image.ATRCId = center.ATRCId;
                            image.NewImageName = newFileName;
                            image.ContentType = hpf.ContentType;
                            ATRCServiceclient.InsertATRCImage(image);
                        }
                    }
                }
            }

            Common.ShowAlertAndNavigate("ATRC account updated successfully", "ATRC.aspx");
        }

        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string[] values = e.CommandArgument.ToString().Split(',');
                DeleteATRCImage(int.Parse(values[0]), values[1]);
                ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "location", "BindLocations();", true);
                BindATRCImages();
            }
        }

        protected void grdATRCImages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[2].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete phtoto?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        protected void grdATRCImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        #region  "Priavte Methods "

        private void BindATRCDetails()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            ATRCProfile center = ATRCServiceclient.GetATRCProfileById(int.Parse(hdATRCId.Value)); //.GetATRCById(int.Parse(hdATRCId.Value));
            txtRestName.Text = center.ATRCName;
            txtATRCDtails.Value = center.Details;
            string category = Convert.ToString(center.Category);
            string[] categories = category.Split(',');

            (from i in chkCategory.Items.Cast<ListItem>()
             where Array.Exists<string>(categories, s => { return i.Value == s; })
             select i).ToList().ForEach(i => i.Selected = true);

            txtRestName.Text = center.ATRCName;
            txtAddress.Text = center.Address;
            txtOwnerName.Text = center.OwnerName;
            txtTel.Text = center.Telephone;
            txtMobile.Text = center.Mobile;
            txtemail.Text = center.Email;
            drpState.SelectedValue = center.StateId.ToString();
            drpCity.SelectedValue = center.CityId.ToString();
            hdLocationId.Value = center.LocationId.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "PopSites", "BindLocations();", true);

            string referal = Convert.ToString(center.Referral);
            if (referal != null)
            {
                string[] referals = referal.Split(',');

                (from i in chkReferral.Items.Cast<ListItem>()
                 where Array.Exists<string>(referals, s => { return i.Value == s; })
                 select i).ToList().ForEach(i => i.Selected = true);
            }

            if (center.DiningFacility.HasValue)
                rblDining.SelectedValue = center.DiningFacility.Value.ToString();
            txtDiningFrom.Text = center.DiningFromTime.HasValue ? DateTime.Today.Add(center.DiningFromTime.Value).ToString("hh:mm tt") : "";
            txtDiningTo.Text = center.DiningToTime.HasValue ? DateTime.Today.Add(center.DiningToTime.Value).ToString("hh:mm tt") : "";

            //hdRestChairId.Value = center.RestChairId.HasValue ? center.RestChairId.Value.ToString() : "0";
            //txtNumberOfchair.Text = center.NumberOfChairs.ToString();
            //txtFromTime.Text = center.FromTime.HasValue ? DateTime.Today.Add(center.FromTime.Value).ToString("hh:mm tt") : "";
            //txtToTime.Text = center.ToTime.HasValue ? DateTime.Today.Add(center.ToTime.Value).ToString("hh:mm tt") : "";

            Common.BindCheckBoxList(center.highlights, chkHighlights);
            Common.BindCheckBoxList(center.Cuisines, chkCuisines);
            Common.BindCheckBoxList(center.Amenities, chkAmenities);

            if (!string.IsNullOrEmpty(center.ProfileImageNewName))
            {
                string FullPath = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], center.ProfileImageNewName);
                profileImg.ImageUrl = "https://www.juststay.in/ATRCImages/"  + center.ProfileImageNewName;
                profileImg.Visible = true;
                lblProfileImage.Text = center.ProfileImageNewName;
            }

            if (center.Latitude.HasValue)
            {
                txtGeoLoc.Text = center.GeoLocationName;
                hdLat.Value = center.Latitude.ToString();
                hdLng.Value = center.Longitude.ToString();
            }

            BindATRCImages();
            hdRCProfileId.Value = center.RestChairProfileId.ToString();
            //if (center.RestChairProfileId != 0)
            //    lnkCreateRCProfile.Text = "Edit Rest Chair Profile";
        }

        private void BindATRCImages()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            grdATRCImages.DataSource = ATRCServiceclient.GetAllATRCImagesById(int.Parse(hdATRCId.Value));
            grdATRCImages.DataBind();
        }

        private void BindStates()
        {
            drpState.DataSource = new CommonServiceClient().GetAllStates();
            drpState.DataBind();
            drpState.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select State" });
            drpState.SelectedValue = ConfigurationManager.AppSettings["MHId"];
        }

        private void BindCities()
        {
            drpCity.DataSource = new CommonServiceClient().GetAllCities();
            drpCity.DataBind();
            drpCity.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select City" });
            drpLocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select Location" });
        }

        private void BindMasterDetails()
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            MastersServiceClient client = new MastersServiceClient();

            chkCategory.DataSource = commonClient.GetAllATRCCategory();
            chkCategory.DataBind();

            chkAmenities.DataSource = client.GetAllAmenities(1);
            chkAmenities.DataBind();

            chkHighlights.DataSource = client.GetAllHighlights();
            chkHighlights.DataBind();

            chkCuisines.DataSource = client.GetAllCuisines();
            chkCuisines.DataBind();
        }

        private void DeleteATRCImage(int atrcImageId, string filename)
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                ATRCServiceclient.DeleteATRCImage(atrcImageId);

                string FullPath = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], filename);
                FileInfo file = new FileInfo(FullPath);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }

                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdocsucess", "alert('ATRC Image Deleted Successfully.')", true);
            }
            catch
            { ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdfail", "alert('ATRC Image Not Deleted Successfully.Internal Error!!')", true); }
        }

        private void SaveProfileImage(int centerId, ATRCServiceClient client)
        {
            string filename = Path.GetFileName(profileImageUpload.PostedFile.FileName);
            string newFileName = Convert.ToString(centerId + "_P_" + filename);
            string path = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], newFileName);
            profileImageUpload.SaveAs(path);

            ATRCDto dto = new ATRCDto { ATRCId = centerId };
            dto.ProfileImageName = filename;
            dto.ProfileImageNewName = newFileName;
            client.UpdateProfileImage(dto);
        }


        #endregion

        #region  " WebMethod "

        [System.Web.Services.WebMethod]
        public static string GetLocationsByCity(int cityId)
        {
            var locations = new CommonServiceClient().GetAlLocationsByCity(cityId).Select(p => new { p.LocationId, p.Name });
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(locations);
        }


        #endregion

        //protected void lnkCreateRCProfile_Click(object sender, EventArgs e)
        //{
        //    int rcProfileId = int.Parse(hdRCProfileId.Value);

        //    if (rcProfileId == 0)
        //        Response.Redirect("ManageRCProfile.aspx?ATRCId=" + hdATRCId.Value);
        //    else
        //        Response.Redirect("ManageRCProfile.aspx?Id=" + rcProfileId);
        //}
    }
}