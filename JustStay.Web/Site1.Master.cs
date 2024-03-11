using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Web.CommonServiceReference;
using JustStay.CommonHub;
using JustStay.Services.DTO;

namespace JustStay.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Session["User"] != null)
                {
                    UserDto userDto = (UserDto)Session["User"];
                    lblusername.Text = userDto.Name.ToString();
                }
                BindCities();
            }
        }
        public string BindCities()
        {
            CommonServiceClient commonClient = new CommonServiceClient();
            string cities = "";
            try
            {
                var cityList = commonClient.GetAllCities();
                foreach (var city in cityList)
                {
                    cities += "<li><a href='atrc.aspx?Id=" + city.CityId + "&Mode=BYCITY'>" + city.Name + "</a></li>";
                }
                commonClient.Close();
            }
            catch(Exception ex)
            {
                commonClient.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return cities;
        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = null;
                Session["Search"] = null;
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/home.aspx",false);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}