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

namespace JustStayAdmin
{
    public partial class ManageRestChair : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindMasterDetails();

                //if (Request.QueryString["PId"] != null)
                //{
                //    hdProfileId.Value=Request.QueryString["PId"];
                //}
                if (Request.QueryString["Id"] != null)
                {
                    hdRCId.Value = Request.QueryString["Id"];
                    BindRestChair();
                }
                BindATRCChairs();
                BindRCamenities();
                BindApprovedList();
            }
        }
        private void BindRCamenities()
        {
            MastersServiceClient client = new MastersServiceClient();
            chkAmenities.DataSource = client.GetAllAmenities(3);
            chkAmenities.DataTextField = "Name";
            chkAmenities.DataValueField = "AmenityId";
            chkAmenities.DataBind();
        }

        private void BindApprovedList()
        {
            ATRCServiceClient ATRCServiceclient = new ATRCServiceClient();
            ddlatrc.DataSource = ATRCServiceclient.getAllATRC(1).ToList();
            ddlatrc.DataTextField = "atrcname";
            ddlatrc.DataValueField = "atrcid";
            ddlatrc.DataBind();
            ddlatrc.Items.Insert(0, new System.Web.UI.WebControls.ListItem() { Value = "0", Text = "select atrc" });
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int rcId = int.Parse(hdRCId.Value);
            RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
            var data = rcClient.GetRestChairProfile(int.Parse(ddlatrc.SelectedValue));
            if (data == null) return;

            ATRCRestChairDTO chair = new ATRCRestChairDTO()
            {
                RestChairProfileId = data.RestChairProfileId,
                ATRCRestChairId = rcId,
                ChairName = txtName.Text,
                TypeId = byte.Parse(drpTypes.SelectedValue),
                Description = txtDetails.Value,
                ChairCount = int.Parse(txtCount.Text),
                Amenities = Common.GetSelectedValues(chkAmenities),
                Price = decimal.Parse(txtPrice.Text)
            };

            try
            {
                if (rcId == 0)
                    rcId = rcClient.InsertATRCRestChair(chair);
                else
                    rcClient.UpdateATRCRestChair(chair);

                SaveImages(rcId);
                SaveChairs(rcId);

                Common.ShowAlertAndNavigate("RestChair saved successfully", "RestChairHourlyBased.aspx");

            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save RestChair failed", "RestChairHourlyBased.aspx");
            }
        }

        protected void grdATRCImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string[] values = e.CommandArgument.ToString().Split(',');
                DeleteATRCImage(int.Parse(values[0]), values[1]);
                BindATRCImages();
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
            catch
            { }
        }

        protected void grdATRCImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdChairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew") || e.CommandName.Equals("New"))
            {
                if (ViewState["CurrentChairs"] != null)
                {
                    BindDataToGrid(e.CommandName);
                }
            }
        }

        protected void grdChairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentChairs"] != null)
            {
                int rowIndex = Convert.ToInt32(e.RowIndex);
                List<ATRCChairDto> chairs = (List<ATRCChairDto>)ViewState["CurrentChairs"];
                ATRCChairDto chair = chairs[rowIndex];

                if (chair.ChairId != 0)
                {
                    RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
                    rcClient.DeleteChair(chair.ChairId);
                }

                chairs.RemoveAt(rowIndex);
                ViewState["CurrentChairs"] = chairs;
                grdChairs.DataSource = chairs;
                grdChairs.DataBind();
            }
        }

        #endregion

        #region " Private Methods "

        private void BindRestChair()
        {
            RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
            int rcId = int.Parse(hdRCId.Value);
            ATRCRestChairDTO chair = rcClient.GetATRCRestChairById(rcId);
            hdProfileId.Value = chair.RestChairProfileId.ToString();
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

        private void BindATRCImages()
        {
            int rcId = int.Parse(hdRCId.Value);
            CommonServiceClient commoClient = new CommonServiceClient();
            grdATRCImages.DataSource = commoClient.GetAttachementsByMaster(rcId, Helper.RestChairTable);
            grdATRCImages.DataBind();
        }

        private void BindATRCChairs()
        {
            List<ATRCChairDto> chairs = new List<ATRCChairDto>();
            int rcId = int.Parse(hdRCId.Value);

            if (rcId != 0)
            {
                RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
                chairs = rcClient.GetAllChairsByATRCRestChair(rcId).ToList();
                //if (chairs.Count == 0)
                //    chairs.Add(new ATRCChairDto());
            }
            //else
            //    chairs.Add(new ATRCChairDto());

            ViewState["CurrentChairs"] = chairs;
            grdChairs.DataSource = chairs;
            grdChairs.DataBind();
        }


        private void BindMasterDetails()
        {
            MastersServiceClient client = new MastersServiceClient();

            drpTypes.DataSource = client.GetAllRCTypes();
            drpTypes.DataBind();

            chkAmenities.DataSource = client.GetAllAmenities(3);
            chkAmenities.DataBind();
        }

        private void SaveImages(int rcId)
        {
            CommonServiceClient client = new CommonServiceClient();
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
                            client.InsertAttachment(image);
                        }
                    }
                }
            }

        }

        private void DeleteATRCImage(int atrcImageId, string filename)
        {
            try
            {
                CommonServiceClient commoClient = new CommonServiceClient();
                commoClient.DeleteAttachment(atrcImageId);

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

        private void SaveChairs(int id)
        {
            if (ViewState["CurrentChairs"] != null)
            {
                List<ATRCChairDto> chairs = (List<ATRCChairDto>)ViewState["CurrentChairs"];
                int chairCount = chairs.Count();

                if (chairCount != 0)
                {
                    RestChairProfileServiceClient rcClient = new RestChairProfileServiceClient();
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

        private void BindDataToGrid(string command)
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

        #endregion


    }
}