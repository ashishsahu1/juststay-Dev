using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStay.Web.ATRCServiceReference;
using JustStay.Web.BusinessLogic;
using JustStay.Web.CommonServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace JustStay.Web
{
    public partial class profile : System.Web.UI.Page
    {
        public static int ATRCId, HR = 0;
        public static string rate = "";
        public string stratrcname, straddress, ATRCAmenities, profileImageName, Highlights, Cuisines,
            GeoName, mobileNumber, strabout, dinningfrom, dinningto, dinningfacility, strfrom, strto, strDate, strTime, strperson, strhour, strcost = "";

        ATRCServiceClient atrcclient = new ATRCServiceClient();
        protected void btnSearchRC_Click(object sender, EventArgs e)
        {
            ILog logger = log4net.LogManager.GetLogger("ErrorLog");
            JSEDS objs = new JSEDS();
            try
            {
                if (!Common.IsLogedIn)
                {
                    searchDto searchobj = new searchDto();
                    searchobj.AtrcId = objs.Encrypt(Convert.ToString(ATRCId));
                    searchobj.Date = objs.Encrypt(Convert.ToString(from.Value.Trim()));
                    searchobj.Time = objs.Encrypt(Convert.ToString(timepicker.Value.Trim()));
                    searchobj.Hr = objs.Encrypt(Convert.ToString(drphour.SelectedValue));
                    searchobj.Per = objs.Encrypt(Convert.ToString(drpperson.SelectedValue));
                    searchobj.FrTo = "";
                    Session["Search"] = searchobj;
                    Response.Redirect("~/SignIn.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    Response.Redirect("~/book.aspx?aid=" + objs.Encrypt(ATRCId.ToString()) + "&Date=" + Convert.ToString(objs.Encrypt(from.Value.Trim())) + "&Time=" + Convert.ToString(objs.Encrypt(timepicker.Value.Trim())) + "&hr=" + Convert.ToString(objs.Encrypt(drphour.SelectedValue)) + "&per=" + Convert.ToString(objs.Encrypt(drpperson.SelectedValue)), false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                //Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void lnksubmit_Click(object sender, EventArgs e)
        {
            CommonServiceClient csclient = new CommonServiceClient();
            try
            {
                RatingDto rdto = new RatingDto()
                {
                    ATRCId = ATRCId,
                    City = Convert.ToString(txtcity.Text.Trim()),
                    Description = Convert.ToString(txtmsg.Text),
                    Email = Convert.ToString(txtemail.Text),
                    Mobile = Convert.ToString(txtmobile.Text),
                    Name = Convert.ToString(txtname.Text),
                    Star = float.Parse(hdnstar.Value),
                    UserId = Common.UserId,
                    InsertedOn = DateTime.Now
                };
                csclient.InsertRating(rdto);
                txtcity.Text = txtemail.Text = txtmobile.Text = txtmsg.Text = txtname.Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ratingpopup", "showRatingModal();", true);
                BindRating();
                csclient.Close();
            }
            catch (Exception ex)
            {
                csclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { csclient.Close(); }
        }

        protected void lnkbook_Click(object sender, EventArgs e)
        {
            try
            {
                JSEDS objs = new JSEDS();
                if (!string.IsNullOrEmpty(Request.QueryString["aid"]) && !string.IsNullOrEmpty(Request.QueryString["Date"]) && !string.IsNullOrEmpty(Request.QueryString["Time"]) && !string.IsNullOrEmpty(Request.QueryString["hr"]))
                {
                    if (!Common.IsLogedIn)
                    {
                        searchDto searchobj = new searchDto();
                        searchobj.AtrcId = objs.Encrypt(Convert.ToString(ATRCId));
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
                        Response.Redirect("~/book.aspx?aid=" + objs.Encrypt(ATRCId.ToString()) + "&Date=" + Convert.ToString(Request.QueryString["Date"]) + "&Time=" + Convert.ToString(Request.QueryString["Time"]) + "&hr=" + Convert.ToString(Request.QueryString["hr"]) + "&frto=" + Convert.ToString(Request.QueryString["frto"]),false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["aid"]) && !string.IsNullOrEmpty(Request.QueryString["m"]))
                {

                    if (Convert.ToString(Request.QueryString["m"]) == "n")
                    {
                        BindATRCImages();
                        SetProfile();
                        BindRating();
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                    }
                }
                else
                {
                    BindATRCImages();
                    SetProfile();
                    BindRating();
                    ClientScript.RegisterStartupScript(this.GetType(), "Popupnew", "ShowPopup();", true);
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                JSEDS objs = new JSEDS();
                if (!string.IsNullOrEmpty(Request.QueryString["aid"]))
                {
                    ATRCId = Convert.ToInt32(objs.Decrypt(Convert.ToString(Request.QueryString["aid"])));
                    Session["artcid"] = Convert.ToInt32(objs.Decrypt(Convert.ToString(Request.QueryString["aid"])));
                }
                if (!string.IsNullOrEmpty(Request.QueryString["hr"]))
                {
                    HR = Convert.ToInt32(objs.Decrypt(Convert.ToString(Request.QueryString["hr"])));
                    strhour = Convert.ToString(objs.Decrypt(Request.QueryString["hr"]));
                }
                if (!Page.IsPostBack)
                {
                    BindATRCImages();
                    SetProfile();
                    BindRating();
                    // BindRestChairTypes();
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindATRCImages()
        {
            atrcclient = new ATRCServiceClient();
            try {
                List<ATRCImageDto> imglist = atrcclient.GetAllATRCImagesById(ATRCId).Where(i => i.IsSD == false && i.IsProfile == false).ToList();
                rptatrcimage.DataSource = imglist;
                rptatrcimage.DataBind();
                rptinnerimages.DataSource = imglist;
                rptinnerimages.DataBind();
                atrcclient.Close();
            }
            catch(Exception ex)
            {
                atrcclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { atrcclient.Close(); }
        }
        private void SetProfile()
        {
            atrcclient = new ATRCServiceClient();
            try
            {
                JSEDS objs = new JSEDS();
                ATRCProfile center = atrcclient.GetATRCProfileById(ATRCId);
                if (center == null) return;
                stratrcname = Convert.ToString(center.ATRCName.Trim());
                straddress = Convert.ToString(center.Address.Trim());
                GeoName = Convert.ToString(center.GeoLocationName.Trim());
                mobileNumber = Convert.ToString(center.Mobile.Trim());
                hdLat.Value = Convert.ToString(center.Latitude.ToString());
                hdLng.Value = Convert.ToString(center.Longitude.ToString());
                ATRCAmenities = Convert.ToString(center.NewAmenities.Trim()); //center.AmenitiesNames.Trim();
                strabout = Convert.ToString(center.Details.Trim());
                dinningfrom = Convert.ToString(center.DiningStartsOn.Trim());
                dinningto = Convert.ToString(center.DiningEndsOn.Trim());
                dinningfacility = Convert.ToString(center.DiningFacilityName.Trim());
                Highlights = Convert.ToString(center.HighlightNames.Trim());
                Cuisines = Convert.ToString(center.CuisinesNames.Trim());
                lblrating.Text = Convert.ToString(center.Ratings.ToString());
                rate = "";
                if (center.Ratings > 0)
                {
                    for (int i = 0; i < center.Ratings; i++)
                    {
                        rate += "<i class='fa fa-star' aria-hidden='true'></i>";
                    }
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Date"]) && !string.IsNullOrEmpty(Request.QueryString["hr"])
                    && !string.IsNullOrEmpty(Request.QueryString["per"]) && !string.IsNullOrEmpty(Request.QueryString["frto"]))
                {
                    binfopanel.Visible = true;
                    string[] fromto;
                    if (!string.IsNullOrEmpty(Request.QueryString["frto"]))
                    {
                        fromto = Convert.ToString(objs.Decrypt(Request.QueryString["frto"])).Split('/');
                        strfrom = "From: " + Convert.ToString(fromto[0]);
                        strto = "To: " + Convert.ToString(fromto[1]);
                    }
                    strDate = "Date: " + Convert.ToString(objs.Decrypt(Request.QueryString["Date"]));
                    strTime = "Time: " + Convert.ToString(objs.Decrypt(Request.QueryString["Time"]));
                    strperson = "";
                    strhour = "Hours: " + Convert.ToString(objs.Decrypt(Request.QueryString["hr"]));
                }
                atrcclient.Close();
            }
            catch(Exception ex)
            {
                atrcclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { atrcclient.Close(); }
        }
        protected string StrRteting(int star)
        {
            string strrate = "";
            if(star > 0)
            {
                for(int j=0;j<star;j++)
                {
                    strrate += "<i class='fa fa-star' aria-hidden='true'></i>";
                }
            }
            return strrate;
        }
        private void BindRating()
        {
            CommonServiceClient cclient = new CommonServiceClient();
            try
            {
                List<RatingDto> list = cclient.GetAllRating(ATRCId).ToList();
                if (list == null) return;
                rptrating.DataSource = list;
                rptrating.DataBind();
                cclient.Close();
            }
            catch (Exception ex)
            {
                cclient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { cclient.Close(); }
        }
        private void BindRestChairTypes()
        {
            atrcclient = new ATRCServiceClient();
            List<GetRestChairByAtrcId> restchairtype = atrcclient.GetRestChairDetailsByAtrcId(ATRCId, Convert.ToDateTime(Request.QueryString["Date"]), HR).ToList();
            if (restchairtype.Count > 0)
            {
                //rptrestchairtypes.DataSource = restchairtype;
                //rptrestchairtypes.DataBind();
            }
            atrcclient.Close();
        }
    }
}