<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managefaq.aspx.cs" Inherits="JustStayAdmin.Admin.managefaq" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanagefaq" runat="server">
    <asp:HiddenField ID="hdFAQId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="faq.aspx">FAQs</a>
                </li>
                <li class="active-bre">Manage FAQs
                </li>
                <li class="page-back">
                    <a href="faq.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage FAQs</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblfaqmsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="drpAudience" runat="server" AppendDataBoundItems="true" AutoPostBack="false">
                        <asp:ListItem Value="1" Text="Customer" />
                        <asp:ListItem Value="2" Text="ATRC" />
                    </asp:DropDownList>
                    <label for="drpCategories">Select Audience</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtquestion">Question</label>
                    <asp:TextBox ID="txtquestion" runat="server" class="form-control" MaxLength="500" />
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtquestion" ValidationGroup="valfaq">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtFAQAnswer" runat="server" TextMode="MultiLine" CssClass="validate"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtSequence">Sequence No.</label>
                    <asp:TextBox ID="txtSequence" runat="server" class="form-control" MaxLength="10" />
                    <asp:RequiredFieldValidator ID="rfvSeq" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtSequence" ValidationGroup="valfaq">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev11" runat="server" ControlToValidate="txtSequence"
                        ValidationExpression="^[0-9]*$" SetFocusOnError="true" Display="Dynamic" ValidationGroup="valfaq"
                        ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valfaq" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/faq.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
      <script src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            CKEDITOR.replace('ContentPlaceHolder1_txtFAQAnswer');
        }
    </script>
</asp:Content>

