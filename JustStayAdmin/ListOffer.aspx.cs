using JustStayAdmin.OfferServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin
{
    public partial class ListOffer : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindOffers();
            }
        }
        
        protected void gvOffers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int eid = Convert.ToInt32(gvOffers.DataKeys[e.RowIndex].Value);
            string name = gvOffers.Rows[e.RowIndex].Cells[3].Text;
            DeleteOffer(eid, name);
            BindOffers();
        }

        protected void gvOffers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete Offer?')){ return false; };";
                        }
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region " Private Method "

        private void BindOffers()
        {
            OfferServiceClient offerClient = new OfferServiceClient();
            gvOffers.DataSource = offerClient.GetAllOffers();
            gvOffers.DataBind();

            if (gvOffers.Rows.Count > 0)
            {
                gvOffers.UseAccessibleHeader = true;
                gvOffers.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvOffers.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void DeleteOffer(int offerId, string filename)
        {
            try
            {
                OfferServiceClient offerClient = new OfferServiceClient();
                offerClient.DeletOffer(offerId);

                string path = Server.MapPath("~/BlogImages/");
                FileInfo file = new FileInfo(path + filename);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();
                }

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Offer Deleted Successfully.')", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Blog Deletion Failed.')", true);
            }
        }

        #endregion
    }
}