using JustStayAdmin.FAQServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListFAQ : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindFAQList();
            }
        }

        protected void gvFAQs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {                
                FAQServiceClient faqRepo = new FAQServiceClient();
                faqRepo.DeleteFAQ(int.Parse(e.CommandArgument.ToString()));
                BindFAQList();
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
            catch
            { }
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
            FAQServiceClient faqRepo = new FAQServiceClient();
            gvFAQs.DataSource = faqRepo.GetFAQByAudience(int.Parse(drpAudience.SelectedValue));
            gvFAQs.DataBind();

            if (gvFAQs.Rows.Count > 0)
            {
                gvFAQs.UseAccessibleHeader = true;
                gvFAQs.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvFAQs.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        #endregion
    }
}