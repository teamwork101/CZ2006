<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateUserDetail.aspx.cs" Inherits="CPManageApp.UI.UpdateUserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <h2 class="title"><span>View/Update User Details</span></h2>

            <!-- Start User Form -->
            <div class="form-control col-md-5">

                <!-- Username -->
                <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" class="col-sm-6 col-form-label" Text="Username: "></asp:Label>
                    <asp:Label ID="lblRetrieveUsername" runat="server" class="col-sm-6 col-form-label" Text="" Font-Bold="True"></asp:Label>
                </div>

                <!-- Password -->
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" class="col-sm-6 col-form-label" Text="Password: "></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Your Password" MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblErrPassword" runat="server" ForeColor="#ff0000"></asp:Label>
                </div>

                <!-- Email -->
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" class="col-sm-6 col-form-label" Text="Email: "></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Your Email" MaxLength="100"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter correct email address"
                       ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">Invalid email address!</asp:RegularExpressionValidator>
                </div>

                <!-- Phone -->
                <div class="form-group">
                    <asp:Label ID="lblPhoneNum" runat="server" class="col-sm-6 col-form-label" Text="Phone Number: "></asp:Label>
                    <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="form-control" placeholder="Eg. 98736543" MaxLength="8" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:Label ID="lblErrPhoneNum" runat="server" ForeColor="#ff0000"></asp:Label>
                </div>

                <!-- Buttons -->
                <div class="form-group">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
                </div>
            </div>
            <!-- End User Form -->

        </div>
    </section>
</asp:Content>
