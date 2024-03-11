using JustStay.CommonHub;
using JustStayAdmin.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class customer : BL.BasePage
    {
        CustomerServiceClient custclient = new CustomerServiceClient();
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                BindCustomers();
            }
        }
        private void BindCustomers()
        {
            CustomerServiceClient custClient = new CustomerServiceClient();
            gvcustomer.DataSource = custClient.GetAllCustomersDetails(txtsearch.Text.Trim());
            gvcustomer.DataBind();
            custClient.Close();
        }
        private void DeleteCustomer(int userid)
        {
            CustomerServiceClient custClient = new CustomerServiceClient();
            try
            {
                int id = custClient.DeleteCustomer(userid);
                if(id == 0)
                    lblcustmsg.Text = "Customer Deleted Successfully.";
                lblcustmsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblcustmsg.Text = "Customer Deletion Failed.";
                lblcustmsg.ForeColor = System.Drawing.Color.Red;
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            custClient.Close();
        }

        protected void gvcustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(gvcustomer.DataKeys[e.RowIndex].Value);
                DeleteCustomer(userid);
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void gvcustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvcustomer.PageIndex = e.NewPageIndex;
            BindCustomers();
        }

        protected void gvcustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
        }

        protected void gvcustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Are you sure you want to delete customer. Note that after deleting customer all rest chair bookings will also be deleting. ?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btncustSearch_Click(object sender, EventArgs e)
        {
            BindCustomers();
        }
    }
}