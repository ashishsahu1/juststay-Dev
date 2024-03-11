using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CancellationPolicySerRef;
using JustStayAdmin.CommonServiceReference;
using JustStayAdmin.MastersServiceReference;
using JustStayAdmin.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class manageatrc : BL.BasePage
    {
        ATRCServiceClient ATRCService;
        UserServiceClient userserviceClient;
        CommonServiceClient commonClient;
        MastersServiceClient client;
        CancellationPolicyServiceClient cp;
        public static string path = ConfigurationManager.AppSettings["imagepath"];
        #region " Event Handlers"

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!Page.IsPostBack)
                {
                    BindMasterDetails();
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        hdATRCId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Convert.ToString(Request.QueryString["id"]));
                        BindATRCDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
       
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ATRCService = new ATRCServiceClient();
            try
            {
                ATRCDto center = new ATRCDto();
                center.ATRCName = txtRestName.Text;
                center.Details = txtATRCDtails.InnerText.Trim();
                center.Category = string.Join(",", chkCategory.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));
                center.OwnerName = txtOwnerName.Text;
                center.Address = txtAddress.Text;
                center.StateId = int.Parse(drpState.SelectedValue);
                center.CityId = int.Parse(drpCity.SelectedValue);
                center.ATRCTypeId = int.Parse(drpatrctype.SelectedValue);

                // var locationId = HttpContext.Current.Request.Form["ctl00$main$drpLocation"];
                center.LocationId = 0;

                center.Telephone = txtTel.Text;
                center.Email = txtemail.Text;
                center.Mobile = txtMobile.Text;
                center.Referral = null;
                //if (!string.IsNullOrEmpty(hdLat.Value))
                //{
                   // center.Latitude = decimal.Parse(hdLat.Value);
                   // center.Longitude = decimal.Parse(hdLng.Value);
                    center.GeoLocationName = txtGeoLocation.Text;
                //}
                center.Latitude = Convert.ToDecimal(txtlatitude.Text.Trim());
                center.Longitude = Convert.ToDecimal(txtlongitude.Text.Trim());
                center.DiningFacility = !string.IsNullOrEmpty(rblDining.SelectedValue) ? int.Parse(rblDining.SelectedValue) : (int?)null;
                center.DiningFromTime = !string.IsNullOrEmpty(txtDiningFrom.Text) ? DateTime.Parse(txtDiningFrom.Text).TimeOfDay : (TimeSpan?)null;
                center.DiningToTime = !string.IsNullOrEmpty(txtDiningTo.Text) ? DateTime.Parse(txtDiningTo.Text).TimeOfDay : (TimeSpan?)null;

                center.highlights = Common.GetSelectedValues(chkHighlights);
                center.Cuisines = Common.GetSelectedValues(chkCuisines);
                center.Amenities = Common.GetSelectedValues(chkAmenities);
                if (hdATRCId.Value == "0")
                {
                    int newuserid = InsertUser();
                    center.UserId = newuserid;
                    center.Status = 0;
                    int centerId = ATRCService.InsertATRC(center);
                    hdATRCId.Value = centerId.ToString();

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
                    CleartextBoxes();
                    Common.ShowAlertAndNavigate("ATRC created successfully.","atrcrequest.aspx");
                }
                else
                {
                    try
                    {
                        center.ATRCId = Convert.ToInt32(hdATRCId.Value);
                        ATRCService.UpdateATRC(center);
                        if (profileImageUpload.HasFile)
                        {
                            string path = ConfigurationManager.AppSettings["ATRCImages"];

                            FileInfo file = new FileInfo(path + lblProfileImage.Text.ToString());
                            if (file.Exists)//check file exsit or not
                            {
                                file.Delete();
                            }

                            SaveProfileImage(center.ATRCId, ATRCService);
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
                                        image.IsProfile = false;
                                        image.IsSD = false;
                                        ATRCService.InsertATRCImage(image);
                                    }
                                }
                            }
                        }
                        lblatrcmsg.Text = "ATRC updated successfully.";
                        lblatrcmsg.ForeColor = System.Drawing.Color.Green;
                    }
                    catch(Exception ex)
                    {
                        lblatrcmsg.Text = "ATRC not updated successfully.";
                        lblatrcmsg.ForeColor = System.Drawing.Color.Red;
                        Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
                BindATRCDetails();
                ATRCService.Close();
            }
            catch (Exception ex)
            {
                lblatrcmsg.Text = "ATRC not saved successfully.";
                lblatrcmsg.ForeColor = System.Drawing.Color.Red;
                ATRCService.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { ATRCService.Close(); }
        }
      
        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    string[] values = e.CommandArgument.ToString().Split(',');
                    DeleteATRCImage(int.Parse(values[0]), values[1]);
                   // ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "location", "BindLocations();", true);
                    BindATRCImages();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void grdATRCImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        #endregion

        #region " Private MEthods"
        private void SaveProfileImage(int centerId, ATRCServiceClient client)
        {
            try
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
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private int InsertUser()
        {
            userserviceClient = new UserServiceClient();
            int userid = 0;
            try
            {
                Random num = new Random();
                UserDto user = new UserDto();
                user.Name = Convert.ToString(txtOwnerName.Text.Trim());
                user.Address = Convert.ToString(txtAddress.Text.Trim());
                user.Mobile = Convert.ToString(txtMobile.Text.Trim());
                user.Email = Convert.ToString(txtemail.Text.Trim());
                user.Username = Convert.ToString(txtMobile.Text.Trim());
                user.Password = Convert.ToString(num.Next(2000, 999999999));
                user.IsActive = true;
                user.IsPaid = false;
                user.UserTypeId = 2;
                user.InsertedOn = DateTime.Now;
                user.RoleId = 0;
                user.IsAdmin = false;
                userid = userserviceClient.InsertUser(user);
                if (userid > 0)
                {
                    SendConfirmationSMS(user);
                    int res = SendMailtoATRC(user);
                    SendMailtoAdmin();
                }
                userserviceClient.Close();
            }
            catch(Exception ex)
            {
                userserviceClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                userserviceClient.Close();
            }
            return userid;
        }
        private void SendMailtoAdmin()
        {
            try
            {
                string Content = string.Empty;
                Content = "To Just Stay, <br /><br />I am interested to join as a Just Stay ATR Center <br />Name: {name} <br /> Address: {address} <br /> Mobile: {mobile} <br /> Email: {email} <br />";
                Content = Content.Replace("{name}", Convert.ToString(txtOwnerName.Text.Trim()));
                Content = Content.Replace("{address}", Convert.ToString(txtAddress.Text.Trim()));
                Content = Content.Replace("{mobile}", Convert.ToString(txtMobile.Text.Trim()));
                Content = Content.Replace("{email}", Convert.ToString(txtemail.Text.Trim()));
                string[] toemail = new string[1];
                toemail[0] = "contact@juststay.in";
                int flag = Common.SendMailithBcc(txtemail.Text.Trim(), toemail, "Join Us Request For ATRC from Admin", "", Content,"localhost","",null);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void SendConfirmationSMS(UserDto userdto)
        {
            commonClient = new CommonServiceClient();
            try
            {
                SMSTemplateDto template = commonClient.GetSMSTemplateByName(Helper.ATRCConfirmationTemlate);
                if (template != null)
                {
                    string msg = template.Template;
                    msg = msg.Replace("##name##", userdto.Name);
                    msg = msg.Replace("##uname##", userdto.Username);
                    msg = msg.Replace("##pass##", userdto.Password);
                    Common.SendSMS(userdto.Mobile, msg);
                }
                commonClient.Close();
            }
            catch (Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { commonClient.Close(); }
        }
        private int SendMailtoATRC(UserDto userdto)
        {
            int flag = 0;
            try
            {
                string Content = string.Empty;
                Content = "Dear {user}, <br /><br />Thank you for your interest to join as a Just Stay ATR Center. <br /> Your JUST STAY ATRC account created successfully. <br /> Login details are as follow: <br /> Link: {link} <br /> UserName: {username} <br /> Password: {password}";
                Content = Content.Replace("{user}", Convert.ToString(userdto.Name));
                Content = Content.Replace("{link}", "https://atrc.juststay.in");
                Content = Content.Replace("{username}", Convert.ToString(userdto.Username));
                Content = Content.Replace("{password}", Convert.ToString(userdto.Password));
                string[] toemail = new string[1];
                toemail[0] = Convert.ToString(userdto.Email);
                flag = Common.SendMailithBcc("contact@juststay.in", toemail, "Just Stay ATR Center Login Details", "", Content,"localhost","",null);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return flag;
        }
        private void BindMasterDetails()
        {
            commonClient = new CommonServiceClient();
            client = new MastersServiceClient();
            cp = new CancellationPolicyServiceClient();
            try
            {
                chkCategory.DataSource = commonClient.GetAllATRCCategory();
                chkCategory.DataBind();

                drpatrctype.DataSource = commonClient.GetATRCTypes();
                drpatrctype.DataBind();
                drpatrctype.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "ATRC Type" });

                chkAmenities.DataSource = client.GetAllAmenities(1);
                chkAmenities.DataBind();

                chkHighlights.DataSource = client.GetAllHighlights();
                chkHighlights.DataBind();

                chkCuisines.DataSource = client.GetAllCuisines();
                chkCuisines.DataBind();

                drpState.DataSource = new CommonServiceClient().GetAllStates();
                drpState.DataBind();
                drpState.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select State" });
                drpState.SelectedValue = ConfigurationManager.AppSettings["MHId"];

                drpCity.DataSource = new CommonServiceClient().GetAllCities();
                drpCity.DataBind();
                drpCity.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select City" });
                drpLocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "Select Location" });

                commonClient.Close();
                client.Close();
                cp.Close();
            }
            catch (Exception ex)
            {
                commonClient.Close();
                client.Close();
                cp.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally {
                commonClient.Close();
                client.Close();
                cp.Close();
            }
        }
        private void BindATRCDetails()
        {
            ATRCService = new ATRCServiceClient();
            try
            {
                ATRCProfile center = ATRCService.GetATRCProfileById(int.Parse(hdATRCId.Value)); //.GetATRCById(int.Parse(hdATRCId.Value));
                txtRestName.Text = center.ATRCName;
                txtATRCDtails.Value = center.Details;
                string category = Convert.ToString(center.Category);
                string[] categories = category.Split(',');

                (from i in chkCategory.Items.Cast<ListItem>()
                 where Array.Exists<string>(categories, s => { return i.Value == s; })
                 select i).ToList().ForEach(i => i.Selected = true);

                drpatrctype.SelectedValue = Convert.ToString(center.ATRCTypeId);
                txtRestName.Text = center.ATRCName;
                txtAddress.Text = center.Address;
                txtOwnerName.Text = center.OwnerName;
                txtTel.Text = center.Telephone;
                txtMobile.Text = center.Mobile;
                txtemail.Text = center.Email;
                drpState.SelectedValue = center.StateId.ToString();
                drpCity.SelectedValue = center.CityId.ToString();
                txtlatitude.Text = Convert.ToString(center.Latitude);
                txtlongitude.Text = Convert.ToString(center.Longitude);
               // hdLocationId.Value = center.LocationId.ToString();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "PopSites", "BindLocations();", true);

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
                    string FullPath = path + center.ProfileImageNewName;
                    profileImg.ImageUrl = FullPath;
                    profileImg.Visible = true;
                    lblProfileImage.Text = center.ProfileImageNewName;
                }
                txtGeoLocation.Text = center.GeoLocationName;
                    //hdLat.Value = center.Latitude.ToString();
                    //hdLng.Value = center.Longitude.ToString();
                BindATRCImages();
                ATRCService.Close();
            }
            catch (Exception ex)
            {
                ATRCService.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { ATRCService.Close(); }
        }
        private void BindATRCImages()
        {
            ATRCService = new ATRCServiceClient();
            try
            {
                grdATRCImages.DataSource = ATRCService.GetAllATRCImagesById(int.Parse(hdATRCId.Value));
                grdATRCImages.DataBind();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        [System.Web.Services.WebMethod]
        public static string GetLocationsByCity(int cityId)
        {
                CommonServiceClient commonClient = new CommonServiceClient();
                var locations = commonClient.GetAlLocationsByCity(cityId).Select(p => new { p.LocationId, p.Name });
                JavaScriptSerializer jscript = new JavaScriptSerializer(); commonClient.Close();
                return jscript.Serialize(locations); 
        }
        public void CleartextBoxes()
        {
            txtAddress.Text = txtemail.Text = txtGeoLocation.Text = txtMobile.Text = txtOwnerName.Text = txtRestName.Text = txtTel.Text = string.Empty;
        }
        private void DeleteATRCImage(int atrcImageId, string filename)
        {
            ATRCService = new ATRCServiceClient();
            try
            {
                ATRCService.DeleteATRCImage(atrcImageId);
                string FullPath = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], filename);
                FileInfo file = new FileInfo(FullPath);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }
                ATRCService.Close();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdocsucess", "alert('ATRC Image Deleted Successfully.')", true);
            }
            catch(Exception ex)
            {
                ATRCService.Close();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdfail", "alert('ATRC Image Not Deleted Successfully.Internal Error!!')", true);
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { ATRCService.Close(); }
        }

        #endregion
    }
}