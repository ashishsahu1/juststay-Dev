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
    public partial class cuisines : BL.BasePage
    {
        MastersServiceClient mclient;
        #region " event handler"

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    BindCusines();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvCuisines_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCuisines.PageIndex = e.NewPageIndex;
                BindCusines();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvCuisines_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvCuisines.EditIndex = e.NewEditIndex;
                BindCusines();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvCuisines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mclient = new MastersServiceClient();
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox name = (TextBox)gvCuisines.HeaderRow.FindControl("txtNewC");
                    mclient.InsertCuisine(name.Text);
                    Common.ShowAlertAndNavigate("Cuisine added successfully.", "cuisines.aspx");
                }
                mclient.Close();
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvCuisines_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvCuisines.EditIndex = -1;
                BindCusines();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvCuisines_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            mclient = new MastersServiceClient();
            try
            {
                int cuisineId = Convert.ToInt32(gvCuisines.DataKeys[e.RowIndex].Value);
                string name = ((TextBox)(gvCuisines.Rows[e.RowIndex].Cells[0].FindControl("txtCuisine"))).Text;

                CuisineDto cuisine = new CuisineDto()
                {
                    CuisineId = cuisineId,
                    Name = name
                };

                mclient.UpdateCusines(cuisine);

                gvCuisines.EditIndex = -1;
                mclient.Close();
                Common.ShowAlertAndNavigate("Cuisine updated successfully.", "cuisines.aspx");
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvCuisines_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            mclient = new MastersServiceClient();
            try
            {
                int id = Convert.ToInt32(gvCuisines.DataKeys[e.RowIndex].Value);
                mclient.DeleteCuisine(id);
                mclient.Close();
                Common.ShowAlertAndNavigate("Cuisine deleted successfully.", "cuisines.aspx");
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion " event handler"

        #region  " Private Methods "

        private void BindCusines()
        {
            mclient = new MastersServiceClient();
            try
            {
                List<CuisineDto> cuisines = mclient.GetAllCuisines().OrderByDescending(l => l.CuisineId).ToList();

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
                mclient.Close();
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
    }
}