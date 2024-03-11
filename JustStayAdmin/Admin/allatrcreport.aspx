<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="allatrcreport.aspx.cs" Inherits="JustStayAdmin.Admin.allatrcreport" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphatrcreport">
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="allatrcreport.aspx">All ATRC Report</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">

                <div class="box-inn-sp">
                    <div class="input-field col s2">
                        <input id="txtfromdate" runat="server" placeholder="From Date" />

                    </div>
                    <div class="input-field col s2">
                        <input id="txttodate" runat="server" placeholder="To Date" />

                    </div>
                    <div class="input-field col s2">
                       <asp:TextBox ID="textsearch" runat="server" CssClass="validate" placeholder="Serach for Name,Mobile,Email,Username"></asp:TextBox>
                    </div>
                    <div class="input-field col s2">
                        <asp:Button ID="btngetreport" runat="server" Text="Generate Report" CssClass="btn btn-info" OnClick="btngetreport_Click" OnClientClick="gethtml();" />
                    </div>
                </div>

            </div>
        </div>
        <div class="row">
            <ul class="nav navbar-right panel_toolbox">
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-file"></i>Report</a>
                    <ul class="dropdown-menu" role="menu">
                        <li>
                            <asp:LinkButton ID="btnexcel" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexcel_Click"><i class="fa fa-file-excel-o"></i> Excel</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnexportpdf" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexportpdf_Click"><i class="fa fa-file-pdf-o"></i> PDF</asp:LinkButton>
                        </li>
                    </ul>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
        <div class="row">
            <div class="table table-responsive" id="gid">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All ATRC Report</h4>
                            <strong>
                                <asp:Label ID="lbldaterange" runat="server"></asp:Label></strong>
                        </div>
                        <div class="row">
                            <div class="tab-inn">
                                <div class="input-field col s2">
                                    <b><%=strfromdate %></b>
                                </div>
                                <div class="input-field col s2">
                                    <b><%=strtodate %></b>
                                </div>
                            </div>
                        </div>

                        <div class="tab-inn">
                            <asp:Label ID="totalrecord" runat="server" ForeColor="Black" CssClass="total-records"></asp:Label>

                            <asp:GridView ID="grdatrc" runat="server" AutoGenerateColumns="false" ShowFooter="true" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                PageSize="100" AllowPaging="true" CssClass="table-hover" CellSpacing="0" OnPageIndexChanging="grdatrc_PageIndexChanging">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="srno" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ATRCNumber" HeaderText="ATRC Number" />
                                    <asp:BoundField HeaderText="ATRC Name" DataField="ATRCName" />
                                    <asp:BoundField HeaderText="Owner Name" DataField="OwnerName" />
                                     <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                                    <asp:BoundField HeaderText="Address" DataField="Address" />
                                    <asp:BoundField HeaderText="Email" DataField="Email" />
                                    <asp:BoundField HeaderText="City" DataField="CityName" />
                                    <asp:BoundField HeaderText="State" DataField="StateWIthCode" />
                                    <asp:BoundField HeaderText="Registered On" DataField="InsertedOn" DataFormatString="{0:dd/MM/yyyy}" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $('#ContentPlaceHolder1_txtfromdate').datepicker({
            uiLibrary: 'bootstrap', size: 'small',
            icons: {
                rightIcon: '<i class="material-icons">date_range</i>',
                previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
            }
        });
        $('#ContentPlaceHolder1_txttodate').datepicker({
            uiLibrary: 'bootstrap', size: 'small',
            icons: {
                rightIcon: '<i class="material-icons">date_range</i>',
                previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
            }
        });
    </script>
    <asp:HiddenField ID="hfGridHtml" runat="server" />


    <script type="text/javascript">
        function gethtml() {
            var data = "";
            data = $("#gid").html();
            $("#ContentPlaceHolder1_hfGridHtml").val("");
            $("#ContentPlaceHolder1_hfGridHtml").val(data);
        }
    </script>
</asp:Content>