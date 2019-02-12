<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CPManageApp.UI.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="py-5">
        <div class="container">
            <br />

            <h2 class="title"><span>Change Password</span></h2>

            <div class="form-control col-md-5">

                <!-- Username -->
                <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" class="col-sm-6 col-form-label" Text="Username: "></asp:Label>
                    <asp:Label ID="lblRetrieveUsername" runat="server" class="col-sm-6 col-form-label" Text="" Font-Bold="True"></asp:Label>
                </div>


                <!-- Old Password -->
                <div class="form-group">
                    <asp:Label ID="lblOldPassword" runat="server" class="col-sm-6 col-form-label" Text="Old Password: "></asp:Label>
                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" placeholder="Enter Your Old Password" MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblErrOldPassword" runat="server" ForeColor="#ff0000" ></asp:Label>
                </div>

                <!-- New Password -->
                <div class="form-group">
                    <asp:Label ID="lblNewPassword" runat="server" class="col-sm-6 col-form-label" Text="New Password: "></asp:Label>
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter Your New Password" MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblErrNewPassword" runat="server" ForeColor="#ff0000"></asp:Label>
                </div>

                <!-- Confirm Password -->
                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" class="col-sm-6 col-form-label" Text="Confirm Password: "></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Enter Your Confirm Password" MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblErrConfirmPassword" runat="server" ForeColor="#ff0000"></asp:Label>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                                ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword"
                                Style="color: #ff0000; text-align: left; font-size: small;" Display="Dynamic" ErrorMessage="The password and confirmed password do not match."
                                ValidationGroup="ChangePassword" />
                </div>

                <!-- Save Change Button -->
                <div class="form-group">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Cssclass="btn btn-primary" OnClick="btnUpdate_Click" ValidationGroup="ChangePassword"/>
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Cssclass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false"/>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
