using JustStay.Web.ATRCServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.CommonHub;

namespace JustStay.Web
{
    public partial class home : System.Web.UI.Page
    {
        public static string strDate, strTime = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    JustStay.CommonHub.JSEDS objjseds = new JSEDS();
                    strDate = objjseds.Encrypt(DateTime.Now.ToShortDateString());
                    strTime = objjseds.Encrypt(DateTime.Now.ToShortTimeString());
                    BindSD();
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void BindSD()
        {
            ATRCServiceClient atrcClient = new ATRCServiceClient();
            try
            {
                rptSD.DataSource = atrcClient.GetATRCSDImages();
                rptSD.DataBind();
                atrcClient.Close();
            }
            catch(Exception ex)
            {
                atrcClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void lnknearby_Click(object sender, EventArgs e)
        {
            try
            {
                JustStay.CommonHub.JSEDS objjseds = new JSEDS();
                if (string.IsNullOrEmpty(hdFromLat.Value) && string.IsNullOrEmpty(hdFromLng.Value)) return;
                decimal fromLat = Convert.ToDecimal(hdFromLat.Value);
                decimal fromLng = Convert.ToDecimal(hdFromLng.Value);
                Response.Redirect("atrc.aspx?ml=" + objjseds.Encrypt(fromLat.ToString()) + "&mxl=0&mlg=" + objjseds.Encrypt(fromLng.ToString()) + "&mxlg=0&Mode=NEARBY",false);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSearchRestChair_Click(object sender, EventArgs e)
        {
            try
            {
                JustStay.CommonHub.JSEDS objjseds = new JSEDS();
                decimal fromLat = Convert.ToDecimal(hdFromLat.Value);
                decimal fromLng = Convert.ToDecimal(hdFromLng.Value);
                decimal ToLat = Convert.ToDecimal(hdToLat.Value);
                decimal ToLng = Convert.ToDecimal(hdToLng.Value);

                decimal minLat = fromLat <= ToLat ? fromLat : ToLat;
                decimal maxLat = fromLat >= ToLat ? fromLat : ToLat;

                decimal minLng = fromLng <= ToLng ? fromLng : ToLng;
                decimal maxLng = fromLng >= ToLng ? fromLng : ToLng;

                Response.Redirect("atrc.aspx?ml=" + objjseds.Encrypt(minLat.ToString()) + "&mxl=" + objjseds.Encrypt(maxLat.ToString()) + "&mlg=" + objjseds.Encrypt(minLng.ToString()) + "&mxlg=" + objjseds.Encrypt(maxLng.ToString()) + "&Mode=ALL" + "&Date=" + objjseds.Encrypt(from.Value) + "&Time=" + objjseds.Encrypt(timepicker.Value) + "&hr=" + objjseds.Encrypt(drphour.SelectedValue) + "&per=" + objjseds.Encrypt(drpperson.SelectedValue) + "&frto=" + objjseds.Encrypt(txtfrom.Text.Trim() + "/" + txtTO.Text.Trim()),false);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}