<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="cuisines.aspx.cs" Inherits="JustStayAdmin.Admin.cuisines" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="cuisines.aspx">Cuisines</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Manage Cuisines</h4>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvCuisines" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ShowHeader="true" 
                                    DataKeyNames="CuisineId" OnRowCommand="gvCuisines_RowCommand"
                                    OnRowDeleting="gvCuisines_RowDeleting" OnRowEditing="gvCuisines_RowEditing" OnRowCancelingEdit="gvCuisines_RowCancelingEdit"
                                    OnRowUpdating="gvCuisines_RowUpdating" OnPageIndexChanging="gvCuisines_PageIndexChanging"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cuisines">
                                            <HeaderTemplate>
                                                  <label for="txtNewC">Enter cuisines name</label>
                                                  <asp:TextBox ID="txtNewC" CssClass="validate" runat="server" placeholder="Enter Cuisines Name" MaxLength="50" />
                                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtNewC"  ValidationGroup="validaiton" SetFocusOnError="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Eval("Name") %>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCuisine" CssClass="validate" MaxLength="50" placeholder="Enter Cuisines Name" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="vename" runat="server" ControlToValidate="txtCuisine" Text="*" ValidationGroup="editVal" ForeColor="Red" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                              <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Add New" CommandName="AddNew" ImageUrl="~/Admin/images/addnew.png" ValidationGroup="validaiton" />
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ButtonUpdate" runat="server" ToolTip="Update" CommandName="Update" ImageUrl="~/Admin/images/update.png" ValidationGroup="editVal" />
                                                <asp:ImageButton ID="ButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" ImageUrl="~/Admin/images/cancel.png" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit" ImageUrl="~/Admin/images/edit.png" />
                                                <asp:ImageButton ID="ButtonDelete" runat="server" ToolTip="Delete" CommandName="Delete" ImageUrl="~/Admin/images/delete.png" />
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
