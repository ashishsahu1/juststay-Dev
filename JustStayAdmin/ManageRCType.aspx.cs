using JustStay.Services.DTO;
using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ManageRCType : BasePage
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
                    hdTypeId.Value = Request.QueryString["Id"];
                    BindRcType();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int typeId = int.Parse(hdTypeId.Value);

            MastersServiceClient masterClient = new MastersServiceClient();

            TypeDto type = new TypeDto()
            {
                TypeId = typeId,
                Name = txtTitle.Text,
                Description = txtContent.Value
            };

            try
            {
                if (typeId == 0)
                    masterClient.InsertRCType(type);
                else
                    masterClient.UpdateRCType(type);

                Common.ShowAlertAndNavigate("Rest Chair Type saved successfully", "ListRCTypes.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Rest Chair Type failed", "ListRCTypes.aspx");
            }
        }

        #endregion

        #region " Private Methods "

        private void BindRcType()
        {
            MastersServiceClient masterClient = new MastersServiceClient();
            int typeId = int.Parse(hdTypeId.Value);
            TypeDto dto = masterClient.GetRCTypeId(typeId);
            txtTitle.Text = dto.Name;
            txtContent.Value = dto.Description;
        }

        #endregion
    }
}