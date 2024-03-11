using JustStay.CommonHub;
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

namespace JustStayAdmin.Admin
{
    public partial class manageroomlabel : BL.BasePage
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
                        hdRoomLabelId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Request.QueryString["Id"]);
                        BindRoomLabel();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hdRoomLabelId.Value);

            MastersServiceClient mastersclient = new MastersServiceClient();
            try
            {
                RoomLabelDto dto = new RoomLabelDto()
                {
                    RoomLabelId = id,
                    Name = txtname.Text
                };

                if (id == 0)
                    id = mastersclient.InsertRoomLabel(dto);
                else
                {
                    mastersclient.UpdateRoomLabel(dto);

                    if (rlImageUpload.HasFile)
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
                lblroomlabelmsg.Text = "Room Label saved successfully";
                lblroomlabelmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblroomlabelmsg.Text = "Save Room Label failed";
                lblroomlabelmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindRoomLabel()
        {
            try
            {
                MastersServiceClient mastersclient = new MastersServiceClient();
                RoomLabelDto dto = mastersclient.GetRoomLabelById(int.Parse(hdRoomLabelId.Value));
                txtname.Text = dto.Name;
                lblfilename.Text = dto.IconFileName;
                lblImageName.Text = dto.IconName;
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void SaveProfileImage(int roomLabelId, MastersServiceClient mastersclient)
        {
            try
            {
                if (rlImageUpload.HasFile)
                {
                    string filename = Path.GetFileName(rlImageUpload.PostedFile.FileName);
                    string newFileName = Convert.ToString(roomLabelId + "_RL_" + filename);
                    string path = Path.Combine(ConfigurationManager.AppSettings["AmenityImages"], newFileName);
                    rlImageUpload.SaveAs(path);

                    RoomLabelDto dto = new RoomLabelDto { RoomLabelId = roomLabelId };
                    dto.IconName = filename;
                    dto.IconFileName = newFileName;
                    mastersclient.UpdateRoomLabelIcon(dto);
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}