using JustStay.CommonHub;
using JustStay.Web.ATRCServiceReference;
using JustStay.Web.BusinessLogic;
using JustStay.Web.CommonServiceReference;
using JustStay.Web.MasterServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class atrc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindATRCCenters();
                    BindAmenities();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindATRCCenters()
        {
            ATRCServiceClient atrcClient = new ATRCServiceClient();
            try
            {
                JSEDS objsecurity = new JSEDS();
                if (!string.IsNullOrEmpty(Request.QueryString["Mode"]))
                {
                    string mode = Convert.ToString(Request.QueryString["Mode"]);
                    int hour = 1;
                    if(!string.IsNullOrEmpty(Request.QueryString["hr"]))
                    {
                        hour = Convert.ToInt32(objsecurity.Decrypt(Request.QueryString["hr"]),16);
                    }
                    DateTime? date = DateTime.Now;
                    if (!string.IsNullOrEmpty(Request.QueryString["Date"]))
                        date = Convert.ToDateTime(Convert.ToString(objsecurity.Decrypt(Request.QueryString["Date"])) + ' ' + Convert.ToString(objsecurity.Decrypt(Request.QueryString["Time"])));

                    decimal minLat = (mode.Equals("ALL") || mode.Equals("NEARBY")) ? Convert.ToDecimal(objsecurity.Decrypt(Request.QueryString["ml"])) : 0,
                        minLng = (mode.Equals("ALL") || mode.Equals("NEARBY")) ? Convert.ToDecimal(objsecurity.Decrypt(Request.QueryString["mlg"])) : 0,
                        maxLat = mode.Equals("ALL") ? Convert.ToDecimal(objsecurity.Decrypt(Request.QueryString["mxl"])) : 0,
                        maxLng = mode.Equals("ALL") ? Convert.ToDecimal(objsecurity.Decrypt(Request.QueryString["mxlg"])) : 0;


                    int cityId = mode.Equals("BYCITY") ? Convert.ToInt32(Request.QueryString["Id"]) : 0;

                    var centers = atrcClient.SearchATRCCenters(minLat, maxLat, minLng, maxLng, mode,
                        "", date, hour, cityId);

                    rptatrcsearch.DataSource = centers;
                    // .GetATRCCenters(int.Parse(Request.QueryString["Id"]), Request.QueryString["Mode"]);
                    rptatrcsearch.DataBind();

                    if (!centers.Any())
                        lblNoDataFound.Visible = true;

                   // ViewState["Ids"] = centers.Select(i => i.ATRCId).ToList();
                }
                atrcClient.Close();
            }
            catch (Exception ex)
            {
                atrcClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { atrcClient.Close(); }
        }
        public string SetDinings(int dining)
        {
            string diningImg = "";
            string dnings = "";
            try
            {

                if (dining == 1)
                    diningImg += "<img src='images/veg.png'/>";
                else if (dining == 2)
                    diningImg += "<img src='images/nonveg.png'/>";
                else if (dining == 3)
                    diningImg += "<img src='images/veg.png'/><img src='images/nonveg.png'/>";

                dnings += "<span style='display:none;' class='veg'>" + (dining == 1 ? 1 : 0) + "</span>";
                dnings += "<span style='display:none;' class='nonveg'>" + (dining == 2 ? 1 : 0) + "</span>";
                dnings += "<span style='display:none;' class='both'>" + (dining == 3 ? 1 : 0) + "</span>";

            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return diningImg + dnings;
        }
        private void BindAmenities()
        {
            try
            {
                var amenities = new MastersServiceClient().GetAllAmenities(1).ToList();
                List<ListItem> list = amenities.ConvertAll(x => new ListItem
                {
                    Value = "." + x.Name.Replace(' ', '_').ToString(),
                    Text = x.Name
                });

                rptaminities.DataSource = list;
                rptaminities.DataBind();
                new MastersServiceClient().Close();
            }
            catch (Exception ex)
            {
                new MastersServiceClient().Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { new MastersServiceClient().Close(); }
        }
        protected void lnkViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                JSEDS objsecurity = new JSEDS();
                LinkButton btn = (LinkButton)sender;
                int atrcId = int.Parse(btn.CommandArgument);
                if (Convert.ToString(Request.QueryString["Mode"]) == "ALL")
                {
                    if (!Common.IsLogedIn)
                    {
                        searchDto searchobj = new searchDto();
                        searchobj.AtrcId = objsecurity.Encrypt(Convert.ToString(atrcId));
                        searchobj.Date = Convert.ToString(Request.QueryString["Date"]);
                        searchobj.Time = Convert.ToString(Request.QueryString["Time"]);
                        searchobj.Hr = Convert.ToString(Request.QueryString["hr"]);
                        searchobj.FrTo = Convert.ToString(Request.QueryString["frto"]);
                        Session["Search"] = searchobj;
                        Response.Redirect("~/SignIn.aspx",false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        Response.Redirect("~/book.aspx?aid=" + objsecurity.Encrypt(atrcId.ToString()) + "&Date=" + Convert.ToString(Request.QueryString["Date"]) + "&Time=" + Convert.ToString(Request.QueryString["Time"]) + "&per=" + Convert.ToString(Request.QueryString["per"]) + "&hr=" + Convert.ToString(Request.QueryString["hr"]) + "&frto=" + Convert.ToString(Request.QueryString["frto"]),false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    hdnatrcid.Value = Convert.ToString(atrcId);
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                }
            }
            catch(Exception ex)
            {
               Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnSearchRC_Click(object sender, EventArgs e)
        {
            JSEDS objsecurity = new JSEDS();
            try
            {
                if (!Common.IsLogedIn)
                {
                    searchDto searchobj = new searchDto();
                    searchobj.AtrcId = Convert.ToString(objsecurity.Encrypt(hdnatrcid.Value));
                    searchobj.Date = Convert.ToString(objsecurity.Encrypt(from.Value.Trim()));
                    searchobj.Time = Convert.ToString(objsecurity.Encrypt(timepicker.Value.Trim()));
                    searchobj.Hr = Convert.ToString(objsecurity.Encrypt(drphour.SelectedValue));
                    searchobj.Per = Convert.ToString(objsecurity.Encrypt(drpperson.SelectedValue));
                    searchobj.FrTo = "";
                    Session["Search"] = searchobj;
                    Response.Redirect("~/SignIn.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    Response.Redirect("~/book.aspx?aid=" + objsecurity.Encrypt(hdnatrcid.Value) + "&Date=" + Convert.ToString(objsecurity.Encrypt(from.Value.Trim())) + "&Time=" + Convert.ToString(objsecurity.Encrypt(timepicker.Value.Trim())) + "&hr=" + Convert.ToString(objsecurity.Encrypt(drphour.SelectedValue)) + "&per=" + Convert.ToString(objsecurity.Encrypt(drpperson.SelectedValue)), false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        [WebMethod]
        public static string GetLocations(string search)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            string strloation = "";
            try
            {
                var locatiions = commonClient.GetAutoLocalities(search).Select(p => new { value = p.Name, label = p.Name, id = p.Id, mode = p.Mode });
                strloation = jscript.Serialize(locatiions);
            }
            catch (Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                commonClient.Close();
            }
            return strloation;
        }
        [WebMethod]
        public static string GetCity(string search)
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            string strcity = "";
            try
            {
                var locatiions = commonClient.GetAllCitiesBySearch(search).Select(p => new { value = p.Name, label = p.Name, id = p.CityId, latitude = p.latitude, longitude = p.longitude });
                strcity = jscript.Serialize(locatiions);
            }
            catch (Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { commonClient.Close(); }
            return strcity;
        }

        protected void lnkviewprofile_Click(object sender, EventArgs e)
        {
            JSEDS objsecurity = new JSEDS();
            LinkButton btn = (LinkButton)sender;
            int atrcId = int.Parse(btn.CommandArgument);
            if (Convert.ToString(Request.QueryString["Mode"]) == "ALL")
            {
                Response.Redirect("~/profile.aspx?aid=" + objsecurity.Encrypt(atrcId.ToString()) + "&Date=" + Convert.ToString(Request.QueryString["Date"]) + "&Time=" + Convert.ToString(Request.QueryString["Time"]) + "&per=" + Convert.ToString(Request.QueryString["per"]) + "&hr=" + Convert.ToString(Request.QueryString["hr"]) + "&frto=" + Convert.ToString(Request.QueryString["frto"]), false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/profile.aspx?aid=" + objsecurity.Encrypt(atrcId.ToString()) + "&m=n", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}