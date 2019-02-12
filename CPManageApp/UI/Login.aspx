<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CPManageApp.UI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <div class="row">
                <div class="span8">
                   
                    <div class="form-control">
                         <h2 class="title"><span>Login</span></h2>
                        <div id="note"></div>
                        <div id="fields">

                            <div class="form-group">
                            <label for="firstName">Username:</label>
                            <asp:TextBox runat="server" ID="txtUsername" Cssclass="form-control" type="text" placeholder=""/>
                            <asp:requiredfieldvalidator ValidationGroup=“LoginValidate” ErrorText="Please fill in your username!" ControlToValidate="txtUsername" runat="server"/>
                            <asp:Label ID="lblErrUsername" runat="server" ForeColor="#CC3300"></asp:Label>

                            </div>

                            <div class="form-group">
                            <label for="lastName">Password:</label>
                            <asp:TextBox runat="server" ID="txtPassword" type="password" placeholder="" Cssclass="form-control"/>
                            <asp:requiredfieldvalidator ValidationGroup=“LoginValidate” ErrorText="Please fill in your password!" ControlToValidate="txtPassword" runat="server"/>
                            <asp:Label ID="lblErrPassword" runat="server" ForeColor="#CC3300"></asp:Label>
                            </div>

                            <asp:Button runat="server" Text="Login" input type="submit" value="Login" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup=“LoginValidate”/>
                             &nbsp;
                            <input type="reset" class="btn btn-secondary" value="Clear" />
                            &nbsp;
                            <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-dark" OnClick="btnResetPassword_Click" CausesValidation="false"/>
                        </div> 
                    </div>
                    <br />
                    <!--To leave a line-->
                    <a href="SignUp.aspx" class="style1"><span class="style3"><strong>Register</strong></span></a><span
                        class="style3"> if you don't have an account.</span><span class="style2">
                        </span>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
