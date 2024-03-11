<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageSupport.aspx.cs" Inherits="JustStay.ATRC.ManageSupport" %>

<%@ Import Namespace="JustStay.CommonHub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">   
    
    <div class="basic-form-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="sparkline12-list">
                        <div class="sparkline12-graph">
                            <div class="basic-login-form-ad">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="all-form-element-inner">
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">To</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:Label ID="lblTo" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Subject</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtSubject" runat="server" class="form-control" />
                                                        <asp:RequiredFieldValidator ID="rfvSub" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtSubject" ValidationGroup="valSupport">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Message</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <textarea id="txtMessage" runat="server" rows="4" cols="60" />
                                                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtMessage" ValidationGroup="valSupport">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="login-btn-inner">
                                                    <div class="row">
                                                        <div class="col-lg-3"></div>
                                                        <div class="col-lg-9">
                                                            <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                <asp:LinkButton ID="btnSend" runat="server" OnClick="btnSend_Click" CausesValidation="true"
                                                                    ValidationGroup="valSupport" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Send"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ATRCDashboard.aspx">Cancel</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="data-table-area mg-b-15">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>Support Requests</h1>
                                        </div>
                                    </div>
                                    <div class="sparkline13-graph">
                                        <div class="datatable-dashv1-list custom-datatable-overright">
                                            <div id="toolbar">
                                            </div>
                                            <asp:GridView ID="grdInbox" runat="server" AutoGenerateColumns="false" class="table table-striped table-no-bordered" DataKeyNames="MessageId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-pagination-switch="true" 
                                                data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="MessageId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar" EmptyDataText="No Support Requests Found">
                                                <Columns>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="search-result">
                                                                <h3>
                                                                    <%#Eval("Subject").ToString()%>
                                                                </h3>
                                                                <p>
                                                                    Sent on
                                                                    <%#Helper.GetFormatedDate(Eval("InsertedOn"))%>
                                                                </p>
                                                                  <a href='ViewMail.aspx?From=support&Id=<%#Eval("MessageID")%>'>View</a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                   
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
