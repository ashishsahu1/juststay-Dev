using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Services.DTO;
using JustStayAdmin.CityServiceReference;

namespace JustStayAdmin
{
    public partial class ManageCity : BasePage
    {
        #region  " Event Handlers "

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SSL = true;
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    hdCityId.Value = Request.QueryString["Id"];
                    BindCity();
                }
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
                    cityRepository.InsertCity(currentCity);
                else
                    cityRepository.UpdateCity(currentCity);

                Common.ShowAlertAndNavigate("City saved successfully", "ListCity.aspx");
            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save City failed", "ListCity.aspx");
            }
        }

        #endregion

        #region  " Private Methods "

        private void BindCity()
        {
            CityServiceClient cityRepository = new CityServiceClient();

            CityDto city = cityRepository.GetCitybyId(int.Parse(hdCityId.Value));
            txtcityname.Text = city.Name.ToString();
            txtlatitude.Text = city.latitude.ToString();
            txtlongitude.Text = city.longitude.ToString();
            chkisactive.Checked = Convert.ToBoolean(city.IsActive);
        }

        #endregion
   
    }
}