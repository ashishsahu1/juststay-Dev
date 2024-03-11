using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustStay.Services.DTO;
using JustStayAdmin.ATRCServiceReference;

namespace JustStayAdmin.Admin
{
    public partial class atrcaccount : BL.BasePage
    {
        ATRCServiceClient atrcclient = new ATRCServiceClient();
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    hdnatrcid.Value = new RC4().Decrypt(Convert.ToString(Request.QueryString["id"]));
                }
                SetData();
            }
        }
        private void SetData()
        {
            atrcclient = new ATRCServiceClient();
            ATRCAccount _account = atrcclient.GetATRCAccountByATRCId(int.Parse(hdnatrcid.Value));
            if(_account != null)
            {
                txtAccountName.Text = Convert.ToString(_account.AccountName);
                txtAccountNumber.Text = Convert.ToString(_account.AccountNumber);
                txtbankname.Text = Convert.ToString(_account.BankName);
                txtBranch.Text = Convert.ToString(_account.Branch);
                txtIFSC.Text = Convert.ToString(_account.IFSC);
                hdnatrcaccountid.Value = _account.ATRCAccountId.ToString();
            }
        }
        protected void btnsave_Click(object sender,EventArgs e)
        {
            try
            {
                atrcclient = new ATRCServiceClient();
                 ATRCAccountDto _accountdto = new ATRCAccountDto();
                _accountdto.AccountName = Convert.ToString(txtAccountName.Text.Trim());
                _accountdto.AccountNumber = Convert.ToString(txtAccountNumber.Text.Trim());
                _accountdto.ATRCId = Convert.ToInt32(hdnatrcid.Value);
                _accountdto.BankName = Convert.ToString(txtbankname.Text.Trim());
                _accountdto.IFSC = Convert.ToString(txtIFSC.Text.Trim());
                _accountdto.Branch = Convert.ToString(txtBranch.Text.Trim());
                _accountdto.ATRCAccountId = Convert.ToInt32(hdnatrcaccountid.Value);
                if (hdnatrcaccountid.Value == "0")
                {
                    hdnatrcaccountid.Value = atrcclient.InsertATRCAccount(_accountdto).ToString();
                }
                else
                {
                    atrcclient.UpdateATRCAccount(_accountdto);
                }
                if (int.Parse(hdnatrcaccountid.Value) > 0)
                {
                    lblmsg.Text = "ATRC Account Saved Successfully.";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                { 
                    lblmsg.Text = "ATRC Account Not Saved Successfully.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
                atrcclient.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                atrcclient.Close();
            }
        }
    }
}