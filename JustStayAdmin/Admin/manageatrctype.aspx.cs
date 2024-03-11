using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.Admin.BL;
using JustStay.CommonHub;
using JustStayAdmin.MastersServiceReference;
using JustStay.Services.DTO;

namespace JustStayAdmin.Admin
{
    public partial class manageatrctype : BL.BasePage
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
                        hdTypeId.Value = new RC4().Decrypt(Request.QueryString["Id"]);
                        BindATRcType();
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
            try
            {
                int typeId = int.Parse(hdTypeId.Value);

                MastersServiceClient masterClient = new MastersServiceClient();

                TypeDto type = new TypeDto()
                {
                    TypeId = typeId,
                    Name = txtatrctype.Text.Trim(),
                    Description = txtContent.Text.Trim()
                };

                if (typeId == 0)
                    masterClient.InsertATRCType(type);
                else
                    masterClient.UpdateATRCType(type);

                lblatrctypemsg.Text = "ATRC Type saved successfully";
                lblatrctypemsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblatrctypemsg.ForeColor = System.Drawing.Color.Red;
                lblatrctypemsg.Text = "Save ATRC Type failed";
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region " Private Methods "

        private void BindATRcType()
        {
            try
            {
                MastersServiceClient masterClient = new MastersServiceClient();
                int typeId = int.Parse(hdTypeId.Value);
                TypeDto dto = masterClient.GetATRCTypeById(typeId);
                txtatrctype.Text = dto.Name.Trim();
                txtContent.Text = dto.Description.Trim();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}