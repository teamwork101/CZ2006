<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="ResetPasswordSecurityQns.aspx.cs" Inherits="CPManageApp.UI.ResetPasswordSecurityQns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
     <!-- Page Content -->
    <section class="py-5">
      <div class="container">
    <p>
        <br />
        <asp:Label ID="lblSession" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="lblPassword" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="lblSecurityQns" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="tbSecurityAns" runat="server" CssClass="form-control" placeholder="Input" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="securityAnsVal" runat="server" ErrorMessage="Please input an answer" ValidationGroup="validate" ControlToValidate="tbSecurityAns" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" ValidationGroup="validate"/>

        
        
</p>
      </div>
    </section>
</asp:Content>
