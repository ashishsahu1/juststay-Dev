using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class manageroomtype : BL.BasePage
    {
        MastersServiceClient masterClient;
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
                        hdTypeId.Value = new JustStayAdmin.Admin.BL.RC4().Decrypt(Request.QueryString["Id"]);
                        BindRoomType();
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
            masterClient = new MastersServiceClient();
            try
            {
                int typeId = int.Parse(hdTypeId.Value);
                TypeDto type = new TypeDto()
                {
                    TypeId = typeId,
                    Name = txtroomtype.Text.Trim(),
                    Description = txtContent.Text.Trim()
                };
                if (typeId == 0)
                    masterClient.InsertRoomType(type);
                else
                    masterClient.UpdateRoomType(type);

                lblroomtypemsg.Text = "Room Type saved successfully";
                lblroomtypemsg.ForeColor = System.Drawing.Color.Green;
                masterClient.Close();
            }
            catch (Exception ex)
            {
                lblroomtypemsg.Text = "Save Room Type failed";
                lblroomtypemsg.ForeColor = System.Drawing.Color.Red;
                masterClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Methods "

        private void BindRoomType()
        {
            masterClient = new MastersServiceClient();
            try
            {
                int typeId = int.Parse(hdTypeId.Value);
                TypeDto dto = masterClient.GetRoomTypeById(typeId);
                txtroomtype.Text = dto.Name.Trim();
                txtContent.Text = dto.Description.Trim();
                masterClient.Close();
            }
            catch (Exception ex)
            {
                masterClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}