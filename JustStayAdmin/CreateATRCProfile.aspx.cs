using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CommonServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class CreateATRCProfile : System.Web.UI.Page
    {
        #region " Event Handlers"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCategory();
                BindStates();
                BindCities();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ATRCServiceClient ATRCService = new ATRCServiceClient();

                ATRCDto center = new ATRCDto();
                center.UserId = Common.UserId;
                center.Status = 0;
                center.ATRCName = txtRestName.Text;
                center.Details = null;
                center.Category = string.Join(",", chkCategory.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));
                center.OwnerName = txtOwnerName.Text;
                center.Address = txtAddress.Text;
                center.StateId = int.Parse(drpState.SelectedValue);
                center.CityId = int.Parse(drpCity.SelectedValue);

                var locationId = HttpContext.Current.Request.Form["ctl00$main$drpLocation"];
                center.LocationId = int.Parse(locationId);
                
                center.Telephone = txtTel.Text;
                center.Email = txtemail.Text;
                center.Mobile = txtMobile.Text;
                center.Referral = null;
                center.Latitude = decimal.Parse(hdFromLat.Value);
                center.Longitude = decimal.Parse(hdFromLng.Value);
                center.GeoLocationName = txtGeoLocation.Text;
                center.DiningFacility = !string.IsNullOrEmpty(rblDining.SelectedValue) ? int.Parse(rblDining.SelectedValue) : (int?)null;

                int centerId = ATRCService.InsertATRC(center);

                if (profileImageUpload.HasFile)
                {
                    string filename = Path.GetFileName(profileImageUpload.FileName);
                    string newFileName = Convert.ToString(centerId + "_P_" + filename);
                    
                    string path = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], newFileName);
                    profileImageUpload.SaveAs(path);

                    ATRCDto dto = new ATRCDto { ATRCId = centerId };
                    dto.ProfileImageName = filename;
                    dto.ProfileImageNewName = newFileName;
                    ATRCService.UpdateProfileImage(dto);
                }
                CleartextBoxes();
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region " Private MEthods"


        private void BindCategory()
        {
            chkCategory.DataSource = new CommonServiceClient().GetAllATRCCategory();
            chkCategory.DataBind();
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

        #endregion

        [System.Web.Services.WebMethod]
        public static string GetLocationsByCity(int cityId)
        {
            var locations = new CommonServiceClient().GetAlLocationsByCity(cityId).Select(p => new { p.LocationId, p.Name });
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(locations);
        }

        public void CleartextBoxes()
        {
            txtAddress.Text = txtemail.Text = txtGeoLocation.Text = txtMobile.Text = txtOwnerName.Text = txtRestName.Text = txtTel.Text = string.Empty;
        }
    }
}