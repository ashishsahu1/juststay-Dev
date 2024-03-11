using JustStay.Services.DTO;
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
    public partial class ManageOffer : BasePage
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
                    hdOfferId.Value = Request.QueryString["Id"];
                    BindOffer();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int offerId = int.Parse(hdOfferId.Value);
            OfferServiceClient offerClient = new OfferServiceClient();

            OfferDto offer = new OfferDto()
            {
                OfferId=offerId,
                Heading = txtHeading.Text,
                SubHeading = txtSubHeading.Text,
                ShortDetail = txtShortDetail.Text,
                Details = txtDetails.Value,
                StartDate = Convert.ToDateTime(txtStartDate.Text),
                EndDate = !string.IsNullOrEmpty(txtEndDate.Text) ? Convert.ToDateTime(txtEndDate.Text) : (DateTime?)null
            };

            try
            {
                if (offerId == 0)
                    offerId= offerClient.InsertOffer(offer);
                else
                {
                    offerClient.UpdateOffer(offer);

                    if (offerImageUpload.HasFile)
                    {
                        string path = Server.MapPath("~/BlogImages/");

                        FileInfo file = new FileInfo(path + lblfilename.Text.ToString());
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                    }
                }

                SaveFile(offerId, offerClient);

                Common.ShowAlertAndNavigate("Offer saved successfully", "ListOffer.aspx");

            }
            catch (Exception ex)
            {
                Common.ShowAlertAndNavigate("Save Offer failed", "ListOffer.aspx");
            }
        }

        #endregion

        #region " Private MEthods "

        private void BindOffer()
        {
            OfferServiceClient offerClient = new OfferServiceClient();
            OfferDto offer = offerClient.GetOfferById(int.Parse(hdOfferId.Value));
            txtHeading.Text = offer.Heading;
            txtSubHeading.Text = offer.SubHeading;
            txtShortDetail.Text = offer.ShortDetail;
            txtDetails.Value = offer.Details;
            txtStartDate.Text = Convert.ToDateTime(offer.StartDate).ToString("dd/MM/yyyy");
            txtEndDate.Text = offer.EndDate.HasValue ? Convert.ToDateTime(offer.EndDate).ToString("dd/MM/yyyy") : "";
            lblfilename.Text = offer.OfferImgNewName;
            lblImageName.Text = offer.OfferImage;
        }

        private void SaveFile(int offerId, OfferServiceClient offerClient)
        {
            if (offerImageUpload.HasFile)
            {
                string filename = Path.GetFileName(offerImageUpload.PostedFile.FileName);
                string newFileName = Convert.ToString(offerId + "_" + filename);
                string path = Server.MapPath("~/BlogImages/");
                string FullPath = path + newFileName;
                offerImageUpload.SaveAs(FullPath);

                OfferDto dto = new OfferDto { OfferId = offerId };
                dto.OfferImage = filename;
                dto.OfferImgNewName = newFileName;
                offerClient.UpdateOfferImage(dto);
            }
        }

        #endregion
    }
}