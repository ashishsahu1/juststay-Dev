<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListCuisines.aspx.cs" Inherits="JustStayAdmin.ListCuisines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="data-table-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>Cuisines List</h1>
                            </div>
                        </div>
                        <div class="sparkline13-graph">
                            <div class="datatable-dashv1-list custom-datatable-overright">

                                <asp:GridView ID="gvCuisines" runat="server" AutoGenerateColumns="false" class="table table-hover table-striped table-bordered" ShowFooter="true"
                                    DataKeyNames="CuisineId" OnRowCommand="gvCuisines_RowCommand"
                                    OnRowDeleting="gvCuisines_RowDeleting" OnRowEditing="gvCuisines_RowEditing" OnRowCancelingEdit="gvCuisines_RowCancelingEdit"
                                    OnRowUpdating="gvCuisines_RowUpdating" OnPageIndexChanging="gvCuisines_PageIndexChanging"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <%#Eval("Name") %>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCuisine" class="form-control" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="vename" runat="server" ControlToValidate="txtCuisine" Text="*" ValidationGroup="editVal" ForeColor="Red"/>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewC" class="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtNewC" Text="*" ValidationGroup="validaiton" ForeColor="Red" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                 <asp:ImageButton ID="ButtonUpdate" runat="server" ToolTip="Update" CommandName="Update" ImageUrl="~/img/update.png" ValidationGroup="editVal" />
                                                <asp:ImageButton ID="ButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" ImageUrl="~/img/cancel.png" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit" ImageUrl="~/img/edit.png" />
                                                <asp:ImageButton ID="ButtonDelete" runat="server" ToolTip="Delete" CommandName="Delete" ImageUrl="~/img/delete.png" />
                                            </ItemTemplate>
                                            <FooterTemplate>                                               
                                                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Add New" CommandName="AddNew" ImageUrl="~/img/addnew.png" ValidationGroup="validaiton" />
                                            </FooterTemplate>
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
