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
    public partial class ListCuisines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCusines();
            }
        }

        protected void gvCuisines_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCuisines.PageIndex = e.NewPageIndex;
            BindCusines();
        }

        protected void gvCuisines_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCuisines.EditIndex = e.NewEditIndex;
            BindCusines();
        }

        protected void gvCuisines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox name = (TextBox)gvCuisines.FooterRow.FindControl("txtNewC");
                MastersServiceClient client = new MastersServiceClient();
                client.InsertCuisine(name.Text);
                BindCusines();
            }
        }

        protected void gvCuisines_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCuisines.EditIndex = -1;
            BindCusines();
        }

        protected void gvCuisines_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int cuisineId = Convert.ToInt32(gvCuisines.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)(gvCuisines.Rows[e.RowIndex].Cells[0].FindControl("txtCuisine"))).Text;
           
            CuisineDto cuisine = new CuisineDto()
            {
                CuisineId= cuisineId,
                Name=name
            };
           
            new MastersServiceClient().UpdateCusines(cuisine);

            gvCuisines.EditIndex = -1;
            BindCusines();
        }

        protected void gvCuisines_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvCuisines.DataKeys[e.RowIndex].Value);
                new MastersServiceClient().DeleteCuisine(id);
                BindCusines();
            }
            catch (Exception ex)
            {

            }
        }

        #region  " Private Methods "

        private void BindCusines()
        {
            MastersServiceClient client = new MastersServiceClient();
            List<CuisineDto> cuisines = client.GetAllCuisines().ToList();

            if (cuisines.Count != 0)
            {
                gvCuisines.DataSource = cuisines;
                gvCuisines.DataBind();
            }
            else
            {
                cuisines.Add(new CuisineDto());
                gvCuisines.DataSource = cuisines;
                gvCuisines.DataBind();
                gvCuisines.Rows[0].Visible = false;
            }
        }

        #endregion


    }
}