<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="Manage Location | Just Stay" CodeBehind="ManageLocation.aspx.cs" Inherits="JustStayAdmin.ManageLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cphmain" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdCityId" runat="server" Value="0" />
    <div class="basic-form-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <div class="table-responsive">
                <asp:GridView ID="grdlocation" runat="server" DataKeyNames="LocationId" ShowFooter="true"
                    AutoGenerateColumns="false" class="table table-hover table-striped table-bordered" 
                    CellSpacing="0" Width="100%" OnRowDataBound="grdlocation_RowDataBound" OnPageIndexChanging="grdlocation_PageIndexChanging" OnRowCancelingEdit="grdlocation_RowCancelingEdit" 
                    OnRowEditing="grdlocation_RowEditing" OnRowUpdating="grdlocation_RowUpdating" OnRowCommand="grdlocation_RowCommand"
                    OnRowDeleting="grdlocation_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("Name") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hdnlid" runat="server" Value='<%#Eval("LocationId") %>' />
                                <asp:TextBox ID="txtname" class="form-control" runat="server" Text='<%#Eval("Name") %>' MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ControlToValidate="txtname" Text="*"
                                     ValidationGroup="EditValidate" ForeColor="Red" SetFocusOnError="true"/>                       
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtaddname" class="form-control" placeholder="Enter City Name" runat="server" MaxLength="50" />
                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtaddname" Text="*" SetFocusOnError="true"
                                     ValidationGroup="validaiton" ForeColor="Red"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <%#Eval("CityName") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hdncityid" runat="server" Value='<%#Eval("CityId") %>'/>
                                <div class="form-select-list">
                                <asp:DropDownList ID="drpeditcity" runat="server" CssClass="form-control custom-select-value" DataTextField="Name" DataValueField="CityId"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="rfvdrpeditcity" runat="server" ControlToValidate="drpeditcity" Text="*" InitialValue="0"
                                     ValidationGroup="EditValidate" ForeColor="Red" SetFocusOnError="true"/>                       
                                    </div>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <div class="form-select-list">
                                <asp:DropDownList ID="drpaddcity" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvdrpaddcity" runat="server" ControlToValidate="drpaddcity" Text="*"
                                     ValidationGroup="validaiton" ForeColor="Red"/>
                                       </div>
                            </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Is Active">
                            <ItemTemplate>
                            <asp:CheckBox ID="chkactive" runat="server" Checked='<%# (Convert.ToBoolean(Eval("IsActive"))) %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkeditisactive" runat="server" Checked='<%# (Convert.ToBoolean(Eval("IsActive"))) %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkeditisactive" runat="server" CssClass="checkbox-inline"  />
                            </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="InsertedOn">
                            <ItemTemplate>
                                <%#Eval("InsertedOn") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-VerticalAlign="Middle">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ButtonUpdate" runat="server" ToolTip="Update" CommandName="Update" ImageUrl="~/img/update.png" ValidationGroup="EditValidate" />
                            <asp:ImageButton ID="ButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" ImageUrl="~/img/cancel.png" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit" ImageUrl="~/img/edit.png" />
<%--                                <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Style="background-image: url('../Admin/images/edit.png');" />--%>
                              <asp:ImageButton ID="ButtonDelete" runat="server" ToolTip="Delete" CommandName="Delete" ImageUrl="~/img/delete.png" />
<%--                                <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />--%>
                            </ItemTemplate>
                            <FooterTemplate>
                                 <asp:ImageButton ID="ButtonAdd" runat="server" ToolTip="Add New" CommandName="AddNew" ImageUrl="~/img/addnew.png" ValidationGroup="validaiton" />
                            </FooterTemplate>
                        </asp:TemplateField>                         
                    </Columns>
                    <%--  <EmptyDataRowStyle BackColor="#0a933f"
                    ForeColor="White" />
                <EmptyDataTemplate>
                    No Items Found.  
                </EmptyDataTemplate>--%>
                </asp:GridView>
            </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>