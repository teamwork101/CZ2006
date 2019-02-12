<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="ResetPasswordUsername.aspx.cs" Inherits="CPManageApp.UI.ResetPasswordUsername" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <p>
                <br />
                <span class="form-control col-md-5">
                    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="usernameVal" runat="server" ErrorMessage="Enter Username" ValidationGroup="validate" ControlToValidate="tbUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" ValidationGroup="validate" />
                </span>


            </p>
        </div>
    </section>
</asp:Content>
