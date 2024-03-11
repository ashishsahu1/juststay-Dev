using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;
using JustStayAdmin.CommonServiceReference;
using JustStayAdmin.MastersServiceReference;
using JustStayAdmin.RCProfileServiceReference;
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
    public partial class managerestchair : BL.BasePage
    {
        RestChairProfileServiceClient rcClient;
        MastersServiceClient client;
        ATRCServiceClient ATRCServiceclient;
        CommonServiceClient commoClient;
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindMasterDetails();
                BindApprovedList();
                if (Request.QueryString["rcpId"] != null)
                {
                    hdRCProfileId.Value = Convert.ToString(Request.QueryString["rcpId"]);
                }
                if (Request.QueryString["Id"] != null)
                {
                    hdATRCRCId.Value = Request.QueryString["Id"];
                    BindRestChair();
                }
                BindATRCChairs();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int atrcrcId = int.Parse(hdATRCRCId.Value);
            rcClient = new RestChairProfileServiceClient();
            try
            {
               // var data = rcClient.GetRestChairProfile(int.Parse(ddlatrc.SelectedValue));
                //if (data == null) return;

                ATRCRestChairDTO chair = new ATRCRestChairDTO()
                {
                    RestChairProfileId = int.Parse(hdRCProfileId.Value),
                    ATRCRestChairId = atrcrcId,
                    ChairName = txtName.Text,
                    TypeId = byte.Parse(drpTypes.SelectedValue),
                    Description = txtDetails.Value,
                    ChairCount = int.Parse(txtCount.Text),
                    Amenities = Common.GetSelectedValues(chkAmenities),
                    Price = decimal.Parse(txtPrice.Text)
                };


                if (atrcrcId == 0)
                    atrcrcId = rcClient.InsertATRCRestChair(chair);
                else
                    rcClient.UpdateATRCRestChair(chair);

                SaveImages(atrcrcId);
                SaveChairs(atrcrcId);

                Common.ShowAlertAndNavigate("RestChair saved successfully", "restchairlist.aspx?rcpid=" + hdRCProfileId.Value);

            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
                Common.ShowAlertAndNavigate("Save RestChair failed", "restchairlist.aspx?rcpid=" + hdRCProfileId.Value);
            }
            finally { rcClient.Close(); }
        }
        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    string[] values = e.CommandArgument.ToString().Split(',');
                    DeleteATRCImage(int.Parse(values[0]), values[1]);
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
                    foreach (LinkButton button in e.Row.Cells[1].Controls.OfType<LinkButton>())
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
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void grdATRCImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void grdChairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew") || e.CommandName.Equals("New"))
                {
                    if (ViewState["CurrentChairs"] != null)
                    {
                        BindDataToGrid(e.CommandName);
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void grdChairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            rcClient = new RestChairProfileServiceClient();
            try
            {
                rcClient = new RestChairProfileServiceClient();
                if (ViewState["CurrentChairs"] != null)
                {
                    int rowIndex = Convert.ToInt32(e.RowIndex);
                    List<ATRCChairDto> chairs = (List<ATRCChairDto>)ViewState["CurrentChairs"];
                    ATRCChairDto chair = chairs[rowIndex];

                    if (chair.ChairId != 0)
                    {
                        rcClient.DeleteChair(chair.ChairId);
                    }

                    chairs.RemoveAt(rowIndex);
                    ViewState["CurrentChairs"] = chairs;
                    grdChairs.DataSource = chairs;
                    grdChairs.DataBind();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Methods "
        private void BindRestChair()
        {
            rcClient = new RestChairProfileServiceClient();
            int rcId = int.Parse(hdATRCRCId.Value);
            ATRCRestChairDTO chair = rcClient.GetATRCRestChairById(rcId);
           // hdProfileId.Value = chair.RestChairProfileId.ToString();
            txtName.Text = chair.ChairName;
            txtDetails.Value = chair.Description;
            drpTypes.SelectedValue = chair.TypeId.ToString();
            txtCount.Text = chair.ChairCount.ToString();
            txtPrice.Text = chair.Price.ToString();

            ddlatrc.SelectedValue = new ATRCServiceClient().GetATRCIdByProfileID(chair.RestChairProfileId).ToString();

            string amenity = Convert.ToString(chair.Amenities);
            string[] categories = amenity.Split(',');

            (from i in chkAmenities.Items.Cast<ListItem>()
             where Array.Exists<string>(categories, s => { return i.Value == s; })
             select i).ToList().ForEach(i => i.Selected = true);

            BindATRCImages();
        }
        private void BindRCamenities()
        {
            client = new MastersServiceClient();
            try
            {
                chkAmenities.DataSource = client.GetAllAmenities(3);
                chkAmenities.DataTextField = "Name";
                chkAmenities.DataValueField = "AmenityId";
                chkAmenities.DataBind();
                client.Close();
            }
            catch(Exception ex)
            {
                client.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { client.Close(); }
        }
        private void BindApprovedList()
        {
            ATRCServiceclient = new ATRCServiceClient();
            try
            {
                ddlatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
                ddlatrc.DataTextField = "atrcname";
                ddlatrc.DataValueField = "atrcid";
                ddlatrc.DataBind();
                ddlatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "select atrc" });
                ATRCServiceclient.Close();
            }
            catch (Exception ex)
            {
                ATRCServiceclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { ATRCServiceclient.Close(); }
        }
       

        private void BindATRCImages()
        {
            commoClient = new CommonServiceClient();
            try
            {
                int rcId = int.Parse(hdATRCRCId.Value);
                grdATRCImages.DataSource = commoClient.GetAttachementsByMaster(rcId, Helper.RestChairTable);
                grdATRCImages.DataBind();
            }
            catch (Exception ex)
            {
                commoClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                commoClient.Close();
            }
        }

        private void BindATRCChairs()
        {
            rcClient = new RestChairProfileServiceClient();
            try
            {
                List<ATRCChairDto> chairs = new List<ATRCChairDto>();
                int rcId = int.Parse(hdATRCRCId.Value);

                if (rcId != 0)
                {
                    chairs = rcClient.GetAllChairsByATRCRestChair(rcId).ToList();
                }

                ViewState["CurrentChairs"] = chairs;
                grdChairs.DataSource = chairs;
                grdChairs.DataBind();
                rcClient.Close();
            }
            catch(Exception ex)
            { rcClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { rcClient.Close(); }
        }


        private void BindMasterDetails()
        {
            client = new MastersServiceClient();
            try
            {
                drpTypes.DataSource = client.GetAllRCTypes();
                drpTypes.DataBind();

                chkAmenities.DataSource = client.GetAllAmenities(3);
                chkAmenities.DataBind();
                client.Close();

            }
            catch (Exception ex)
            {
                client.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                client.Close();
            }
        }

        private void SaveImages(int rcId)
        {
            commoClient = new CommonServiceClient(); 
            try {
                string FileName = "", newFileName = "";
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
                                AttachmentDto image = new AttachmentDto();
                                image.MasterTableId = rcId;
                                image.TableName = Helper.RestChairTable;

                                newFileName = rcId + "_" + Helper.RestChairTable + "_" + FileName;
                                hpf.SaveAs(Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], newFileName));

                                image.DocName = FileName.ToString();
                                image.DocNewName = newFileName;
                                commoClient.InsertAttachment(image);
                            }
                        }
                    }
                }
                commoClient.Close();
            }
            catch (Exception ex)
            {
                commoClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                commoClient.Close();
            }
        }

        private void DeleteATRCImage(int atrcImageId, string filename)
        {
            commoClient = new CommonServiceClient();
            try
            {
                commoClient.DeleteAttachment(atrcImageId);

                string FullPath = Path.Combine(ConfigurationManager.AppSettings["ATRCImages"], filename);
                FileInfo file = new FileInfo(FullPath);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }

                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdocsucess", "alert('ATRC Image Deleted Successfully.')", true);
                commoClient.Close();
            }
            catch(Exception ex)
            {
                commoClient.Close();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "hdfail", "alert('ATRC Image Not Deleted Successfully.Internal Error!!')", true);
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                commoClient.Close();
            }
        }

        private void SaveChairs(int id)
        {
            rcClient = new RestChairProfileServiceClient();
            try {
                if (ViewState["CurrentChairs"] != null)
                {
                    List<ATRCChairDto> chairs = (List<ATRCChairDto>)ViewState["CurrentChairs"];
                    int chairCount = chairs.Count();

                    if (chairCount != 0)
                    {
                        var newChairs = chairs.Where(p => p.ChairId == 0);
                        var existingChairs = chairs.Where(p => p.ChairId != 0);

                        foreach (ATRCChairDto chair in newChairs)
                        {
                            chair.ATRCRestChairId = id;
                            rcClient.InsertChair(chair);
                        }

                        foreach (ATRCChairDto chair in existingChairs)
                        {
                            rcClient.UpdateChair(chair);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                rcClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                rcClient.Close();
            }
        }

        private void BindDataToGrid(string command)
        {
            try
            {
                List<ATRCChairDto> chairs = (List<ATRCChairDto>)ViewState["CurrentChairs"];

                for (int i = 0; i < chairs.Count; i++)
                {
                    TextBox txtName = (TextBox)grdChairs.Rows[i].Cells[1].FindControl("txtChairNumber");
                    HiddenField hdChairId = (HiddenField)grdChairs.Rows[i].Cells[1].FindControl("hdChairId");
                    HiddenField hdChairChanged = (HiddenField)grdChairs.Rows[i].Cells[2].FindControl("hdChairChanges");

                    chairs[i].ChairId = Convert.ToInt32(hdChairId.Value);
                    chairs[i].ChairNumber = txtName.Text;
                    chairs[i].ChairSaved = Convert.ToBoolean(hdChairChanged.Value);
                }

                if (command.Equals("New"))
                {
                    int chairCount = int.Parse(txtCount.Text);
                    if (chairs.Count == chairCount)
                        lblRechedChairCount.Visible = true;
                    else
                    {
                        chairs.Add(new ATRCChairDto());
                        lblRechedChairCount.Visible = false;
                    }
                }

                ViewState["CurrentChairs"] = chairs;
                grdChairs.DataSource = chairs;
                grdChairs.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        protected void lnkClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("restchairlist.aspx?rcpid=" + hdRCProfileId.Value,false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}