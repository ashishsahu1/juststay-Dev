using JustStay.CommonHub;
using JustStayAdmin.FAQServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class faq : BL.BasePage
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
                    BindFAQList();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvFAQs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    FAQServiceClient faqRepo = new FAQServiceClient();
                    faqRepo.DeleteFAQ(int.Parse(e.CommandArgument.ToString()));
                    lblfaqlistmsg.Text = "FAQ deleted successfully.";
                    lblfaqlistmsg.ForeColor = System.Drawing.Color.Green;
                    BindFAQList();
                }
            }
            catch(Exception ex)
            {
                lblfaqlistmsg.Text = "FAQ not deleted successfully.";
                lblfaqlistmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvFAQs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete FAQ?')){ return false; };";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvFAQs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindFAQList();
        }

        #endregion

        #region  "Private Methods "

        private void BindFAQList()
        {
            try
            {
                FAQServiceClient faqRepo = new FAQServiceClient();
                gvFAQs.DataSource = faqRepo.GetFAQByAudience(int.Parse(drpAudience.SelectedValue));
                gvFAQs.DataBind();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        
        #endregion
    }
}