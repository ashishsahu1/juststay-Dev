<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managelocation.aspx.cs" Inherits="JustStayAdmin.Admin.managelocation" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <asp:HiddenField ID="hdCityId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="citylist.aspx">City list</a>
                </li>
                <li class="active-bre">Manage Location
                </li>
                 <li class="page-back">
                    <a href="managecity.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Manage Location</h4>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdlocation" runat="server" DataKeyNames="LocationId" ShowFooter="true"
                                    AutoGenerateColumns="false" class="table table-hover"
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
                                                <asp:TextBox ID="txtname" CssClass="validate" runat="server" Text='<%#Eval("Name") %>' MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ControlToValidate="txtname" Text="*"
                                                    ValidationGroup="EditValidate" ForeColor="Red" SetFocusOnError="true" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtaddname" CssClass="validate" placeholder="Enter City Name" runat="server" MaxLength="50" />
                                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtaddname" Text="*" SetFocusOnError="true"
                                                    ValidationGroup="validaiton" ForeColor="Red" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City">
                                            <ItemTemplate>
                                                <%#Eval("CityName") %>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hdncityid" runat="server" Value='<%#Eval("CityId") %>' />
                                                <div class="input-field col s12">
                                                    <asp:DropDownList ID="drpeditcity" runat="server" DataTextField="Name" DataValueField="CityId"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvdrpeditcity" runat="server" ControlToValidate="drpeditcity" Text="*" InitialValue="0"
                                                        ValidationGroup="EditValidate" ForeColor="Red" SetFocusOnError="true" />
                                                </div>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <div class="input-field col s12">
                                                    <asp:DropDownList ID="drpaddcity" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvdrpaddcity" runat="server" ControlToValidate="drpaddcity" Text="*"
                                                        ValidationGroup="validaiton" ForeColor="Red" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Is Active">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkactive" runat="server" ClientIDMode="Static"  CssClass="filled-in" Text='<%# (Convert.ToBoolean(Eval("IsActive"))) %>'  Checked='<%# (Convert.ToBoolean(Eval("IsActive"))) %>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkeditisactive" runat="server" ClientIDMode="Static"  CssClass="filled-in" Text='<%# (Convert.ToBoolean(Eval("IsActive"))) %>' Checked='<%# (Convert.ToBoolean(Eval("IsActive"))) %>' />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:CheckBox ID="chkeditisactive" runat="server" ClientIDMode="Static"  CssClass="filled-in" Text='<%# (Convert.ToBoolean(Eval("IsActive"))) %>' />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="InsertedOn">
                                            <ItemTemplate>
                                                <%#Eval("InsertedOn") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ButtonUpdate" runat="server" ToolTip="Update" CommandName="Update" ImageUrl="~/Admin/images/update.png" ValidationGroup="EditValidate" />
                                                <asp:ImageButton ID="ButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" ImageUrl="~/Admin/images/cancel.png" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit" ImageUrl="~/Admin/images/edit.png" />
                                                <asp:ImageButton ID="ButtonDelete" runat="server" ToolTip="Delete" CommandName="Delete" ImageUrl="~/Admin/images/delete.png" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonAdd" runat="server" ToolTip="Save & Add New" CommandName="AddNew" Text="Save & Add New"  ValidationGroup="validaiton" />
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
