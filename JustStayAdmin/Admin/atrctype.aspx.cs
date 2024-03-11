using JustStay.CommonHub;
using JustStayAdmin.MastersServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class atrctype : BL.BasePage
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
                    BindATRCTypeList();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvTypes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[4].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete ATRC Type?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    new MastersServiceClient().DeleteATRCType(int.Parse(e.CommandArgument.ToString()));
                    BindATRCTypeList();
                    lblatrctypemsg.Text = "ATRC type deleted successfully.";
                    lblatrctypemsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblatrctypemsg.Text = "ATRC type not deleted successfully.";
                lblatrctypemsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }


        #endregion

        #region  "Private Methods "

        private void BindATRCTypeList()
        {
            try
            {
                MastersServiceClient masterClient = new MastersServiceClient();
                gvTypes.DataSource = masterClient.GetAllATRCTypes();
                gvTypes.DataBind();

                if (gvTypes.Rows.Count > 0)
                {
                    gvTypes.UseAccessibleHeader = true;
                    gvTypes.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvTypes.FooterRow.TableSection = TableRowSection.TableFooter;
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