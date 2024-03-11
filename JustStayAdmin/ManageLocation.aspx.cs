﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStayAdmin.LocationServiceReference;
using JustStayAdmin.CityServiceReference;
using JustStay.Services.DTO;
using System.Data;

namespace JustStayAdmin
{
    public partial class ManageLocation : BasePage
    {
        #region  " Event Handlers "
        public int Cityid = 0;
        LocationServiceClient locationClient;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                Cityid = Convert.ToInt32(Request.QueryString["cid"]);
            }
            if (!Page.IsPostBack)
            {
                BindLocation();
            }
        }

        protected void grdlocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdlocation.PageIndex = e.NewPageIndex;
            BindLocation();
        }

        protected void grdlocation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdlocation.EditIndex = e.NewEditIndex;
            BindLocation();
        }

        protected void grdlocation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdlocation.EditIndex = -1;
            BindLocation();
        }

        protected void grdlocation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string iid = ((HiddenField)(grdlocation.Rows[e.RowIndex].Cells[0].FindControl("hdnlid"))).Value;
            string name = ((TextBox)(grdlocation.Rows[e.RowIndex].Cells[0].FindControl("txtname"))).Text;
            int cityid = Convert.ToInt32(((DropDownList)(grdlocation.Rows[e.RowIndex].Cells[0].FindControl("drpeditcity"))).SelectedValue);
            bool isactive = Convert.ToBoolean(((CheckBox)(grdlocation.Rows[e.RowIndex].Cells[0].FindControl("chkeditisactive"))).Checked);

         
            locationClient = new LocationServiceClient();
            LocationDto ldto = locationClient.GetLocationbyId(Convert.ToInt32(iid));
            ldto.Name = name;
            ldto.CityId = cityid;
            ldto.IsActive = isactive;

            locationClient.UpdateLocation(ldto);
            grdlocation.EditIndex = -1;
            BindLocation();
        }

        protected void grdlocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(grdlocation.DataKeys[e.RowIndex].Value);
                locationClient = new LocationServiceClient();
                locationClient.DeleteLocation(id);
                BindLocation();
            }
            catch (Exception ex)
            {

            }
        }

        protected void grdlocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox lname = (TextBox)grdlocation.FooterRow.FindControl("txtaddname");
                DropDownList drpcity = (DropDownList)grdlocation.FooterRow.FindControl("drpaddcity");
                CheckBox chkisactive = (CheckBox)grdlocation.FooterRow.FindControl("chkeditisactive");

               // List<CityDto> citylist = new CityServiceClient().CityList("0").ToList();
               // if (citylist == null) return;

                //drpcity.DataSource = citylist;
               // drpcity.DataBind();
               // drpcity.Items.Insert(0, new ListItem("--Select--", "0"));

                LocationDto ldto = new LocationDto()
                {
                    Name = lname.Text,
                    CityId = Convert.ToInt32(drpcity.SelectedValue),
                    IsActive = Convert.ToBoolean(chkisactive.Checked),
                    InsertedOn = DateTime.Now
                };

                locationClient = new LocationServiceClient();
                locationClient.InsertLocation(ldto);
                BindLocation();
            }
            
        }

        #endregion

        #region " Private Methods "

        private void BindLocation()
        {
            locationClient = new LocationServiceClient();
            List<LocationDto> locations = locationClient.LocationList(Cityid).ToList();

            if (locations.Count != 0)
            {
                grdlocation.DataSource = locations;
                grdlocation.DataBind();
            }
            else
            {
                locations.Add(new LocationDto());
                grdlocation.DataSource = locations;
                grdlocation.DataBind();
                grdlocation.Rows[0].Visible = false;
            }
        }

        #endregion

        protected void grdlocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<CityDto> citylist = new CityServiceClient().CityList("0").ToList();
            if (citylist == null) return;
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Footer)
            {
                var drpcity = e.Row.FindControl("drpaddcity") as DropDownList;
                if (null != drpcity)
                {
                    drpcity.DataSource = citylist;
                    drpcity.DataTextField = "Name";
                    drpcity.DataValueField = "CityId";
                    drpcity.DataBind();
                    drpcity.Items.Insert(0, new ListItem("Select City", "0"));
                }
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        var drpeditcity = e.Row.FindControl("drpeditcity") as DropDownList;
                        if (null != drpeditcity)
                        {
                            drpeditcity.DataSource = citylist;
                            drpeditcity.DataTextField = "Name";
                            drpeditcity.DataValueField = "CityId";
                            drpeditcity.DataBind();
                            drpeditcity.Items.Insert(0, new ListItem("Select City", "0"));
                        }
                        HiddenField hdncityid = e.Row.FindControl("hdncityid") as HiddenField;
                        drpeditcity.SelectedValue = hdncityid.Value;
                    }
               
            }

        }
    }
}