<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListSupportRequests.aspx.cs" Inherits="JustStayAdmin.ListSupportRequests" %>
<%@ Import Namespace="JustStay.CommonHub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
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

                                            <asp:GridView ID="grdSupportReq" runat="server" AutoGenerateColumns="false" class="table table-striped table-no-bordered" DataKeyNames="MessageId"
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
                                                                    from 
                                                                   <%#Eval("Name").ToString()%>
                                                                </p>

                                                                <p>
                                                                    ATRC Name:
                                                                      <%#Eval("ATRCName").ToString()%>
                                                                </p>

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
