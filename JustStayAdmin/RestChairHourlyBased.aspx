<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RestChairHourlyBased.aspx.cs" Inherits="JustStayAdmin.RestChairHourlyBased" %>


<%@ Register Src="~/Controls/ATRCHeader.ascx" TagPrefix="uc1" TagName="ATRCHeader" %>


<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">

    <style>
        input[type="radio"],
        input[type="checkbox"] {
            margin: 4px 0 0 5px;
        }

        .mycheckbox input[type="checkbox"] {
            margin-right: 5px;
        }
    </style>

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css" />
    <uc1:ATRCHeader runat="server" ID="ATRCHeader" />


    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="product-payment-inner-st">
                        <ul id="myTabedu1" class="tab-review-design">
                            <li id="ligeneral" class="active"><a href="#general" data-toggle="tab">General</a></li>
                            <li id="liPolicy"><a href="#Policy" data-toggle="tab">Policy</a></li>
                            <li id="liroom"><a href="#room" data-toggle="tab">Rest Chair</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content custom-product-edit">
                            <div class="product-tab-list tab-pane fade active in" id="description">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="review-content-section">
                                            <div class="tab-content">
                                                <div id="general" class="tab-pane fadeIn active">
                                                    <div class="container-fluid">
                                                        <div class="review-content-section">
                                                            <div class="col-lg-6 col-md-2">
                                                                <div class="row">
                                                                    <div class="form-group data-custon-pick data-custom-mg">
                                                                        <label><b>Select ATRC</b></label>
                                                                        <div class="form-group">
                                                                            <asp:DropDownList ID="grdApprovedATRC" runat="server" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtATRCManagerName" runat="server" class="form-control" placeholder="ATRC Manager Name"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtManagerNumber" runat="server" class="form-control" placeholder="Manager Mobile Number"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtTelNumber" runat="server" class="form-control" placeholder="ATRC Telephone Number"></asp:TextBox>
                                                                    </div>

                                                                    <div class="form-group data-custon-pick data-custom-mg">
                                                                        <label><b>Range Period</b></label>
                                                                        <div class="input-daterange input-group">
                                                                            <asp:TextBox CssClass="form-control" ID="txtStartDate" runat="server" placeholder="Start Date"></asp:TextBox>
                                                                            <span class="input-group-addon">to</span>
                                                                            <asp:TextBox CssClass="form-control" ID="txtEndDate" runat="server" placeholder="End Date"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <br />

                                                                    <div class="form-group data-custon-pick data-custom-mg">
                                                                        <label><b>Rest Chair Check In / Check Out</b></label>
                                                                        <div class="input-daterange input-group">
                                                                            <asp:TextBox CssClass="form-control timepicker" ID="txtRestChairchkIn" runat="server" placeholder="Check In Time"></asp:TextBox>
                                                                            <span class="input-group-addon">to</span>
                                                                            <asp:TextBox CssClass="form-control timepicker" ID="txtRestChairchkOut" runat="server" placeholder="Check Out Time"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <br />

                                                                    <div class="form-group data-custon-pick data-custom-mg" style="margin-bottom: 20px;">
                                                                        <label><b>Account Status</b></label>
                                                                        <input type="checkbox" id="chkAccountStatus" data-toggle="toggle" data-off="Active" data-on="Inactive" />
                                                                        <asp:HiddenField runat="server" Value="1" ID="hdAcStatus" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="Policy" class="tab-pane fadeIn">
                                                    <div class="container-fluid">
                                                        <div class="review-content-section">
                                                            <div class="col-lg-9 col-md-2 col-sm-1">
                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <label>ATRC Policy</label>
                                                                    </div>
                                                                    <asp:TextBox ID="txtAtrcPolicy" runat="server" TextMode="MultiLine" />
                                                                    <br />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-12 col-md-2 col-sm-6 col-xs-2">
                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <label>Cancellation Policy </label>
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-offset-1">
                                                                        <div class="row">
                                                                            <div class="col-lg-12 col-md-12">
                                                                                <div class="form-group">
                                                                                    <label>
                                                                                        <asp:CheckBoxList ID="chkPolicy" runat="server">
                                                                                        </asp:CheckBoxList>
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:Button ID="btnRestChairHourly" OnClick="btnRestChairHourly_Click" runat="server" Text="Submit" class="btn btn-primary" />
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="room" class="tab-pane fadeIn product-status mg-b-15">
                                                    <div class="container-fluid">

                                                        <div class="data-table-area mg-b-15">
                                                            <div class="container-fluid">
                                                                <div class="row">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <div class="sparkline13-list">
                                                                            <div class="sparkline13-hd">
                                                                                <div class="main-sparkline13-hd">
                                                                                    <h1>Rest Chair List</h1>
                                                                                </div>
                                                                                <div class="add-product">
                                                                                    <a href="ManageRestChair.aspx">Add Restchair</a>
                                                                                </div>
                                                                            </div>
                                                                            <div class="sparkline13-graph">
                                                                                <div class="datatable-dashv1-list custom-datatable-overright">
                                                                                    <asp:GridView ID="gvChairs" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                                                                        DataKeyNames="ATRCRestChairId" OnRowCommand="gvChairs_RowCommand" OnRowDataBound="gvChairs_RowDataBound" OnRowDeleting="gvChairs_RowDeleting"
                                                                                        Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true"
                                                                                        data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                                                        data-cookie-id-table="ATRCRestChairId" data-show-export="true" data-click-to-select="true">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ChairName" HeaderText="Name" />
                                                                                            <asp:BoundField DataField="ChairCount" HeaderText="Chair Count" />
                                                                                            <asp:BoundField DataField="Description" HeaderText="Chair Description" />
                                                                                            <asp:TemplateField HeaderText="Edit">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/ManageRestChair.aspx?Id={0}", Eval("ATRCRestChairId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("ATRCRestChairId").ToString() %>' ToolTip="Delete" ForeColor="Blue" CommandName="Delete"><img src="img/delete.png" /></asp:LinkButton>
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
                                                    <div class="asset-inner">

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

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="Content/bootstrap-toggle.min.css" rel="stylesheet" />
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="Scripts/bootstrap-toggle.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>

    <script>
        $(document).ready(function () {
            if ($(document.getElementById('<%=HiddenField1.ClientID %>')).val() != "") {
                if ($(document.getElementById('<%=HiddenField1.ClientID %>')).val() == "true") {
                    alert('Success');
                }
                else if ($(document.getElementById('<%=HiddenField1.ClientID %>')).val() == "false") {
                    alert('Try Again');
                }
            }

            $(document.getElementById('<%=txtRestChairchkIn.ClientID %>')).timepicker({});
            $(document.getElementById('<%=txtRestChairchkOut.ClientID %>')).timepicker({});
            $(document.getElementById('<%=txtStartDate.ClientID %>')).datepicker({
                dateFormat: 'dd-mm-yy',
                changeYear: true,
                changeMonth: true
            });
            $(document.getElementById('<%=txtEndDate.ClientID %>')).datepicker({
                dateFormat: 'dd-mm-yy',
                changeYear: true,
                changeMonth: true
            });
        });

        $("#chkAccountStatus").change(function () {
            if ($(this).prop("checked") == true) {
                $(document.getElementById('<%=hdAcStatus.ClientID%>')).val("0");
            } else {
                $(document.getElementById('<%=hdAcStatus.ClientID%>')).val("1");
            }
        });
    </script>

    <script>
        window.onload = function () {
            CKEDITOR.replace(document.getElementById('<%=txtAtrcPolicy.ClientID%>'), {});
        }
    </script>

    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width(150)
                        .height(200);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
        $(document).ready(function () {
            $("#txtnochair").change(function () {
                var no = $("#txtnochair").val();
                addRow(no);
            });
            function addRow(no) {
                var i;
                for (i = 1; i <= no - 1; i++) {
                    var ID = 2;
                    var html =
                        '<tr>' +
                        '<td>Chair Number<input type="text" name="txtchair' + ID + '" /></td>' +
                        '<td><input type="button" class="BtnMinus" value="-" /></td>' +
                        '</tr>'
                    $(html).appendTo($("#Table1"))
                    ID++;
                }
            }
            $("#Table1").on("click", ".BtnPlus", addRow);
            function deleteRow() {
                var par = $(this).parent().parent();
                par.remove();
            };
            $("#Table1").on("click", ".BtnMinus", deleteRow);

            //for miltiple file uplad

            var fileupID = 2;
            function addfileupRow() {
                var html =
                    '<tr>' +
                    '<td>File: <input type="file" name="fileUpload' + fileupID + '" /></td>' +
                    '<td><input type="button" class="BtnPlus" value="+" /></td>' +
                    '<td><input type="button" class="BtnMinus" value="-" /></td>' +
                    '</tr>'
                $(html).appendTo($("#Table2"))
                ID++;
            };
            $("#Table2").on("click", ".BtnPlus", addfileupRow);
            function deletefileupRow() {
                var par = $(this).parent().parent();
                par.remove();
            };
            $("#Table2").on("click", ".BtnMinus", deletefileupRow);
        });
    </script>
</asp:Content>
