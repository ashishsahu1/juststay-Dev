<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="supportrequest.aspx.cs" Inherits="JustStayAdmin.Admin.supportrequest" %>

<%@ Import Namespace="JustStay.CommonHub" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphatrctype">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="roomtype.aspx">Support Requests</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Support Request</h4>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdSupportReq" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" DataKeyNames="MessageId"
                                    Width="100%" EmptyDataText="No Support Requests Found">
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
                                                        <%# Helper.GetFormatedDate(Eval("InsertedOn"))%>
                                                    </p>
                                                    <a href='viewmail.aspx?From=support&Id=<%#Eval("MessageID")%>'>View</a>
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
</asp:Content>

