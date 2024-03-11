<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="highlight.aspx.cs" Inherits="JustStayAdmin.Admin.highlight" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="highlight.aspx">Highlight</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Manage Highlight</h4>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvHighlights" runat="server" AutoGenerateColumns="false" class="table table-hover" ShowHeader="true"
                                    DataKeyNames="HighlightId" OnRowCommand="gvHighlights_RowCommand"
                                    OnRowDeleting="gvHighlights_RowDeleting" OnRowEditing="gvHighlights_RowEditing" OnRowCancelingEdit="gvHighlights_RowCancelingEdit"
                                    OnRowUpdating="gvHighlights_RowUpdating" OnPageIndexChanging="gvHighlights_PageIndexChanging"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Category">
                                            <HeaderTemplate>
                                                  <label for="txtNewHighlight">Enter highlight name</label>
                                                 <asp:TextBox ID="txtNewHighlight" class="validate" runat="server" />
                                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtNewHighlight" Text="*" ValidationGroup="validaiton" ForeColor="red" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Name") %>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtHighlight" class="validate" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="vename" runat="server" ControlToValidate="txtHighlight" Text="*" ValidationGroup="editVal" ForeColor="Red" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ButtonUpdate" runat="server" ToolTip="Update" CommandName="Update" ImageUrl="~/Admin/images/update.png" ValidationGroup="editVal" />
                                                <asp:ImageButton ID="ButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" ImageUrl="~/Admin/images/cancel.png" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit" ImageUrl="~/Admin/images/edit.png" />
                                                <asp:ImageButton ID="ButtonDelete" runat="server" ToolTip="Delete" CommandName="Delete" ImageUrl="~/Admin/images/delete.png" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Add New" CommandName="AddNew" ImageUrl="~/Admin/images/addnew.png" ValidationGroup="validaiton" />
                                            </HeaderTemplate>
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
