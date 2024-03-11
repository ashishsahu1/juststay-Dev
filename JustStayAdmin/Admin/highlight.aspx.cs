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
    public partial class highlight : BL.BasePage
    {
        MastersServiceClient mclient;
        #region  " Event Handler "
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    BindHighlights();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvHighlights_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mclient = new MastersServiceClient();
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox name = (TextBox)gvHighlights.HeaderRow.FindControl("txtNewHighlight");
                    mclient.InsertHighlight(name.Text);
                    Common.ShowAlertAndNavigate("Highlight added successfully.", "highlight.aspx");
                }
                mclient.Close();
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvHighlights_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvHighlights.EditIndex = e.NewEditIndex;
                BindHighlights();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvHighlights_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            mclient = new MastersServiceClient();
            try
            {
                int id = Convert.ToInt32(gvHighlights.DataKeys[e.RowIndex].Value);
                string name = ((TextBox)(gvHighlights.Rows[e.RowIndex].Cells[0].FindControl("txtHighlight"))).Text;

                HighlightDto highlight = new HighlightDto()
                {
                    HighlightId = id,
                    Name = name
                };

                mclient.UpdateHighlight(highlight);

                gvHighlights.EditIndex = -1;
                mclient.Close();
                Common.ShowAlertAndNavigate("Highlight updated successfully.", "highlight.aspx");
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvHighlights_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvHighlights.EditIndex = -1;
                BindHighlights();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvHighlights_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            mclient = new MastersServiceClient();
            try
            {
                int id = Convert.ToInt32(gvHighlights.DataKeys[e.RowIndex].Value);
                mclient.DeleteHighlight(id);
                mclient.Close();
                Common.ShowAlertAndNavigate("Highlight deleted successfully.", "highlight.aspx");
            }
            catch (Exception ex)
            {
                mclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvHighlights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvHighlights.PageIndex = e.NewPageIndex;
                BindHighlights();
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
        #region  " Private Methods "

        private void BindHighlights()
        {
            mclient = new MastersServiceClient();
            try
            {
                List<HighlightDto> data = mclient.GetAllHighlights().OrderByDescending(h => h.HighlightId).ToList();

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