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
    public partial class ListHighlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindHighlights();
            }
        }

        protected void gvHighlights_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox name = (TextBox)gvHighlights.FooterRow.FindControl("txtNewHighlight");
                MastersServiceClient client = new MastersServiceClient();
                client.InsertHighlight(name.Text);
                BindHighlights();
            }
        }
               
        protected void gvHighlights_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHighlights.EditIndex = e.NewEditIndex;
            BindHighlights();
        }
     
        protected void gvHighlights_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvHighlights.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)(gvHighlights.Rows[e.RowIndex].Cells[0].FindControl("txtHighlight"))).Text;

            HighlightDto highlight = new HighlightDto()
            {
                HighlightId = id,
                Name = name
            };

            new MastersServiceClient().UpdateHighlight(highlight);

            gvHighlights.EditIndex = -1;
            BindHighlights();
        }

        protected void gvHighlights_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHighlights.EditIndex = -1;
            BindHighlights();
        }

        protected void gvHighlights_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvHighlights.DataKeys[e.RowIndex].Value);
                new MastersServiceClient().DeleteHighlight(id);
                BindHighlights();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvHighlights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHighlights.PageIndex = e.NewPageIndex;
            BindHighlights();
        }


        #region  " Private Methods "

        private void BindHighlights()
        {
            MastersServiceClient client = new MastersServiceClient();
            List<HighlightDto> data = client.GetAllHighlights().ToList();

            if (data.Count != 0)
            {
                gvHighlights.DataSource = data;
                gvHighlights.DataBind();
            }
            else
            {
                data.Add(new HighlightDto());
                gvHighlights.DataSource = data;
                gvHighlights.DataBind();
                gvHighlights.Rows[0].Visible = false;
            }
        }

        #endregion

    }
}