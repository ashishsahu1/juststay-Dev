<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="compose.aspx.cs" Inherits="JustStayAdmin.Admin.compose" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageblog" runat="server">
    <asp:HiddenField ID="hdMessageId" runat="server" Value="0" />
   
   
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="compose.aspx">Compose</a>
                </li>
                <li class="page-back">
                    <a href="inbox.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Compose</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblcomposemsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtTo">To</label>
                    <asp:TextBox ID="txtTo" runat="server" CssClass="validate wickEnabled" />
                    <asp:RequiredFieldValidator ID="rfvTo" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtTo" ValidationGroup="valmsg">
                                                        </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtSubject">Subject</label>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="validate" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <textarea id="txtMessage" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div class="file-field">
                        <div class="btn">
                            <span>Attachments</span>
                            <asp:FileUpload ID="fileUpload1" runat="server" AllowMultiple="true" Font-Bold="true" onchange="document.getElementById('append-small-btn1').value = this.value;" />
                        </div>
                        <div class="file-path-wrapper">
                            <input type="text" id="append-small-btn1" placeholder="no file selected" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSend" runat="server" OnClick="btnSend_Click" CausesValidation="true" OnClientClick="javascript:return validateform();"
                        ValidationGroup="valmsg" CssClass="waves-effect waves-light btn-large" Text="Send"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/inbox.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
     <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="ckeditor/ckeditor.js"></script>
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
                          url: "/Admin/compose.aspx/GetAutoCompleteEmails",
                          data: "{ 'term':'" + extractLast(request.term) + "'}",
                          dataType: "json",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {
                              debugger;
                              var jsdata = JSON.parse(data.d);
                              response(jsdata);
                          },
                          error: function (response) {
                              alert("Error" + response.responseText);
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
            CKEDITOR.replace('ContentPlaceHolder1_txtMessage');
           // CKEDITOR.replace('ContentPlaceHolder1_txtMessage', {});
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
