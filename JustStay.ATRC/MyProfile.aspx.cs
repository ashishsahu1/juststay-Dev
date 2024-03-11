using JustStay.ATRC.ATRCServiceReference;
using JustStay.ATRC.CommonServiceReference;
using JustStay.CommonHub;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.ATRC
{
    public partial class MyProfile : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindATRCDetails();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                ATRCDto center = ATRCServiceclient.GetATRCById(Common.ATRCId);

                //center.ATRCName = txtRestName.Text;
                //center.Category = string.Join(",", chkCategory.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));
                //center.OwnerName = txtOwnerName.Text;
                //center.Email = txtemail.Text;
                //center.Telephone = txtTel.Text;
                //center.Mobile = txtMobile.Text;
                //center.Referral = string.Join(",", chkReferral.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));

                //ATRCServiceclient.UpdateATRC(center);

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
                Common.ShowAlertAndNavigate("Profile updated successfully", "ATRCDashboard.aspx");
            }
            catch (Exception ex)
            {
               Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    string[] values = e.CommandArgument.ToString().Split(',');
                    DeleteATRCImage(int.Parse(values[0]), values[1]);
                    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "location", "BindLocations();", true);
                    BindATRCImages();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void grdATRCImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        #region  "Priavte Methods "

        private void BindATRCDetails()
        {
            try
            {
                ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
                ATRCProfile center = ATRCServiceclient.GetATRCProfileById(Common.ATRCId);
                lblATRCId.Text = center.ATRCNumber;
                lblATRCName.Text = center.ATRCName;
                lblCategory.Text = center.CategoryNames;
                lblAddress.Text = center.Address;
                lblOwnerName.Text = center.OwnerName;
                lblState.Text = center.StateName;
                lblCity.Text = center.CityName;
                lblLocation.Text = center.LocationName;
                // chkParking.Checked = center.Parking;
                // chkWifi.Checked = center.Wifi;
                // chkRestaurant.Checked = center.Restaurant;
                // chkCleanBath.Checked = center.CleanBathRoom;
                divAbout.InnerHtml = center.Details;
                lblDiningFacility.Text = center.DiningFacilityName;

                string timing = "";
                if (center.DiningFromTime.HasValue)
                    timing = center.DiningStartsOn;
                if (center.DiningToTime.HasValue)
                    timing += " To " + center.DiningEndsOn;

                lblDiningTimings.Text = timing;

                //if (center.Category.Contains("1"))
                //{
                //    divRestChairs.Visible = true;
                //    lblChairs.Text = center.NumberOfChairs.Value.ToString();

                //    string chairTiming = "";
                //    if (center.FromTime.HasValue)
                //        chairTiming = center.RestChairsStartTime;
                //    if (center.ToTime.HasValue)
                //        chairTiming += " To " + center.RestChairsEndTime;

                //    lblRCTimings.Text = chairTiming;
                //}
                string atrcimagespath = ConfigurationManager.AppSettings["ATRCImages"];
                if (!string.IsNullOrEmpty(center.ProfileImageNewName))
                    profileImg.ImageUrl = atrcimagespath + center.ProfileImageNewName;

                BindATRCImages();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void BindATRCImages()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            grdATRCImages.DataSource = ATRCServiceclient.GetAllATRCImagesById(Common.ATRCId);
            grdATRCImages.DataBind();
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

                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdocsucess", "alert('Image Deleted Successfully.')", true);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "ATRC", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdfail", "alert('Image Not Deleted Successfully.Internal Error!!')", true);
            }
        }


        #endregion       
    }
}