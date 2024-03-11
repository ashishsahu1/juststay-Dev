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
    public partial class managerctype : BL.BasePage
    {
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
                        BindRcType();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnrctype_Click(object sender, EventArgs e)
        {
            try
            {
                int typeId = int.Parse(hdTypeId.Value);

                MastersServiceClient masterClient = new MastersServiceClient();

                TypeDto type = new TypeDto()
                {
                    TypeId = typeId,
                    Name = txtTitle.Text,
                    Description = txtContent.Text.Trim()
                };


                if (typeId == 0)
                    masterClient.InsertRCType(type);
                else
                    masterClient.UpdateRCType(type);

                lblrctypemsg.Text = "Rest Chair Type saved successfully";
                lblrctypemsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblrctypemsg.Text = "Save Rest Chair Type failed";
                lblrctypemsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #region " Private Methods "

        private void BindRcType()
        {
            try
            {
                MastersServiceClient masterClient = new MastersServiceClient();
                int typeId = int.Parse(hdTypeId.Value);
                TypeDto dto = masterClient.GetRCTypeId(typeId);
                txtTitle.Text = dto.Name;
                txtContent.Text = dto.Description;
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}