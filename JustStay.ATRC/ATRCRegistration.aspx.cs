using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.ATRC.ATRCServiceReference;
using JustStay.ATRC.CommonServiceReference;
using JustStay.ATRC.UserServiceReference;
using System.IO;
using System.Configuration;
using System.Web.Script.Serialization;
using JustStay.CommonHub;

namespace JustStay.ATRC
{
    public partial class ATRCRegistration : BasePage
    {
        ATRCServiceClient ATRCService;
        CommonServiceClient commService;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    lblusername.Text = Convert.ToString(Common.UserName);
                    ATRCDto dto = new ATRCServiceClient().GetATRCByUserId(Common.UserId);
                    if (dto != null)
                    {
                        Response.Redirect("~/ATRCDashboard.aspx");
                    }
                    else
                    {
                        BindCategory();
                        BindStates();
                        BindCities();
                    }
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {               
                ATRCService = new ATRCServiceClient();
                ATRCDto center = new ATRCDto();
                center.UserId = Common.UserId;
                center.Status = 0;               
                center.ATRCName = txtRestName.Text;
                center.Details = txtATRCDtails.Value;
                center.Category = string.Join(",", chkCategory.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));
                center.OwnerName = txtOwnerName.Text;
                center.Address = txtAddress.Text;
                center.StateId = int.Parse(drpState.SelectedValue);
                center.CityId = int.Parse(drpCity.SelectedValue);
                var locationId = HttpContext.Current.Request.Form["drpLocation"];
                center.LocationId = int.Parse(locationId);

                center.Telephone = txtTel.Text;
                center.Email = txtemail.Text;
                center.Mobile = txtMobile.Text;
                center.Referral = string.Join(",", chkReferral.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));
                int centerId = ATRCService.InsertATRC(center);

                if (profileImageUpload.HasFile)
                {  
                    string filename = Path.GetFileName(profileImageUpload.PostedFile.FileName);
                    string newFileName = Convert.ToString(centerId + "_P_" + filename);
                    string path = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], newFileName);                   
                    profileImageUpload.SaveAs(path);

                    ATRCDto dto = new ATRCDto { ATRCId = centerId };
                    dto.ProfileImageName = filename;
                    dto.ProfileImageNewName = newFileName;
                    ATRCService.UpdateProfileImage(dto);
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
                                string newFileName = centerId + "_" + FileName;
                                string docpath = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], newFileName);
                                hpf.SaveAs(docpath);
                                image.ImageName = FileName.ToString();
                                image.ATRCId = centerId;
                                image.NewImageName = newFileName;
                                image.ContentType = hpf.ContentType;
                                image.IsSD = false;
                                image.IsProfile = false;
                                ATRCService.InsertATRCImage(image);
                            }
                        }
                    }
                }
                Common.ShowAlertAndNavigate("Waiting for approval, Juststay executive will contat you in next 24 hours. Thank you.", "ATRCDashboard.aspx");
            }
            catch (Exception ex)
            {
                ATRCService.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { ATRCService.Close(); }
        }

        #region " Private Methods "

        private void BindCategory()
        {
            commService = new CommonServiceClient();
            try {
                chkCategory.DataSource = commService.GetAllATRCCategory();
                chkCategory.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { commService.Close(); }
        }

        private void BindStates()
        {
            commService = new CommonServiceClient();
            try {
                drpState.DataSource = new CommonServiceClient().GetAllStates();
                drpState.DataBind();
                drpState.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select State" });
                drpState.SelectedValue = ConfigurationManager.AppSettings["MHId"];
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { commService.Close(); }
        }

        private void BindCities()
        {
            commService = new CommonServiceClient();
            try
            {
                drpCity.DataSource = new CommonServiceClient().GetAllCities();
                drpCity.DataBind();
                drpCity.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select City" });
                drpLocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select Location" });
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { commService.Close(); }
        }

        #endregion

        [System.Web.Services.WebMethod]
        public static string GetLocationsByCity(int cityId)
        {
            CommonServiceClient commService = new CommonServiceClient();
            var locations = commService.GetAlLocationsByCity(cityId).Select(p => new { p.LocationId, p.Name });
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            commService.Close();
            return jscript.Serialize(locations);
        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session["User"] = null;
            Response.Redirect("~/Login.aspx",false);
        }
    }
}