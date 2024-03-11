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

namespace JustStayAdmin
{
    public partial class ManageRoomLabel :BasePage
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
                    hdRoomLabelId.Value = Request.QueryString["Id"];
                    BindRoomLabel();
                }
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

                Common.ShowAlertAndNavigate("Room Label saved successfully", "ListRoomLabels.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Room Label failed", "ListRoomLabels.aspx");
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindRoomLabel()
        {
            MastersServiceClient mastersclient = new MastersServiceClient();
            RoomLabelDto dto = mastersclient.GetRoomLabelById(int.Parse(hdRoomLabelId.Value));
            txtname.Text = dto.Name;            
            lblfilename.Text = dto.IconFileName;
            lblImageName.Text = dto.IconName;
        }

        private void SaveProfileImage(int roomLabelId, MastersServiceClient mastersclient)
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

        #endregion
    }
}