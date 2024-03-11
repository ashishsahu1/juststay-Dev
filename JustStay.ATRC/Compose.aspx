<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compose.aspx.cs" Inherits="JustStayAdmin.Compose" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdMessageId" runat="server" Value="0" />
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    
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
                                                        <asp:TextBox ID="txtTo" runat="server" class="form-control wickEnabled" />
                                                        <asp:RequiredFieldValidator ID="rfvTo" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtTo" ValidationGroup="valmsg">
                                                        </asp:RequiredFieldValidator>
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
                                                       <%-- <asp:RequiredFieldValidator ID="rfvName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtSubject" ValidationGroup="valmsg">
                                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Message</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <textarea id="txtMessage" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Attachments</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:FileUpload ID="fileUpload1" runat="server" class="form-control-file" AllowMultiple="true" Font-Bold="true" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="login-btn-inner">
                                                    <div class="row">
                                                        <div class="col-lg-3"></div>
                                                        <div class="col-lg-9">
                                                            <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                <asp:LinkButton ID="btnSend" runat="server" OnClick="btnSend_Click" CausesValidation="true" OnClientClick="javascript:return validateform();"
                                                                    ValidationGroup="valmsg" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Send"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/Inbox.aspx">Cancel</asp:LinkButton>
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

    <script type="text/javascript">
        $(function () {
            function split(val) {
                return val.split(/,\s*/);
            }
            function extractLast(term) {

                return split(term).pop();
            }
            $(".wickEnabled")
              .bind("keydown", function (event) {
                  if (event.keyCode === $.ui.keyCode.TAB &&
                     $(this).data("autocomplete").menu.active) {
                      event.preventDefault();
                  }
              }).autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          type: "POST",
                          url: "/Compose.aspx/GetAutoCompleteEmails",
                          data: "{ 'term':'" + extractLast(request.term) + "'}",
                          dataType: "json",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {
                              debugger;
                              var jsdata = JSON.parse(data.d);
                              response(jsdata);
                          },
                          error: function (response) {
                              alert("Error" + res.responseText);
                          }
                      });
                  },
                  search: function () {
                      // custom minLength
                      var term = extractLast(this.value);
                      if (term.length < 2) {
                          return false;
                      }
                  },
                  focus: function () {
                      // prevent value inserted on focus
                      return false;
                  },
                  select: function (event, ui) {
                      var terms = split(this.value);
                      // remove the current input
                      terms.pop();
                      // add the selected item
                      terms.push(ui.item.value);
                      // add placeholder to get the comma-and-space at the end
                      terms.push("");
                      this.value = terms.join(", ");
                      return false;
                  }
              });
        });
    </script>

    <script type="text/javascript">
        window.onload = function () {
            CKEDITOR.replace('main_txtMessage', {});
        }

        function validateform() {
            var formError = 'Error';
            var to = '<%=txtTo.ClientID%>';
            if (validateEmails(to) == false)
                formError = formError + '\nPlease enter valid To email Addresses';
           
            if (formError != 'Error') {
                alert(formError);
                return false;
            }
            return true;
        }

        function validateEmails(object) {
            var address = document.getElementById(object).value;
            var patt = new RegExp("<.*>");
            var result = address.split(',');
            for (var i = 0; i < result.length; i++) {
                var testEmail = result[i].replace(patt, '');
                if (!validateEmail(testEmail))
                    return false;
            }
            return true;

        }
        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function validateEmail(address) {
            var reg = /^([a-zA-Z0-9_.-])+@([a-zA-Z0-9_.-])+\.([a-zA-Z])+([a-zA-Z])+\s*/
            address = trim(address);
            if (address != "")
                return (reg.test(address));
            else
                return true
        }
        
    </script>

</asp:Content>
