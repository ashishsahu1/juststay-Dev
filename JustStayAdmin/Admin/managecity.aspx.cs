using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStayAdmin.Admin.BL;
using JustStayAdmin.CityServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class managecity : BL.BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.SSL = true;
                base.Page_Load(sender, e);
                RC4 rc4 = new RC4();
                if (!IsPostBack)
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        hdCityId.Value = rc4.Decrypt(Request.QueryString["Id"]);
                        BindCity();
                    }
                }
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int cityId = int.Parse(hdCityId.Value);

            CityServiceClient cityRepository = new CityServiceClient();

            CityDto currentCity = new CityDto()
            {
                CityId = cityId,
                Name = txtcityname.Text,
                latitude = Convert.ToDecimal(txtlatitude.Text),
                longitude = Convert.ToDecimal(txtlongitude.Text),
                IsActive = chkisactive.Checked
            };

            try
            {
                if (cityId == 0)
                {
                    if(cityRepository.InsertCity(currentCity) > 0)
                    {
                        lblcitymsg.Text = "City saved successfully";
                        lblcitymsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblcitymsg.Text = "City not saved successfully";
                        lblcitymsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                   if(cityRepository.UpdateCity(currentCity) > 0)
                    {
                        lblcitymsg.Text = "City updated successfully";
                        lblcitymsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else {
                        lblcitymsg.Text = "City not updated successfully";
                        lblcitymsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindCity()
        {
            try
            {
                CityServiceClient cityRepository = new CityServiceClient();

                CityDto city = cityRepository.GetCitybyId(int.Parse(hdCityId.Value));
                txtcityname.Text = city.Name.ToString();
                txtlatitude.Text = city.latitude.ToString();
                txtlongitude.Text = city.longitude.ToString();
                chkisactive.Checked = Convert.ToBoolean(city.IsActive);
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion
    }
}