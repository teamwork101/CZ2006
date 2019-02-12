<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CPManageApp.UI.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <div class="span8">
                <h2 class="title"><span>Sign Up</span></h2>
                <div class="contact_form">

                    <div id="note"></div>
                    <div id="fields">

                        <div class="form-control col-md-5">

                        <div class="form-group">
                            <label for="UserName" class="col-sm-6 col-form-label">Username:</label>
                            <asp:TextBox runat="server" Cssclass="form-control" type="text" ID="txtUsername" placeholder="" required="" MaxLength="50" />
                            <asp:Label ID="lblErrUsername" runat="server" ForeColor="#ff0000"></asp:Label>
                        </div>

                        <div class="form-group">
                            <label for="Password" class="col-sm-6 col-form-label">Password:</label>
                            <asp:TextBox runat="server" ID="txtPassword" Cssclass="form-control" type="password" placeholder="" required="" MaxLength="50" />
                            <asp:Label ID="lblErrPassword" runat="server" ForeColor="#ff0000"></asp:Label>
                        </div>

                        <div class="form-group">
                            <label for="ConfirmPassword" class="col-sm-6 col-form-label">Confirm Password:</label>
                            <asp:TextBox runat="server" ID="txtConfirmPassword" Cssclass="form-control" type="password" placeholder="" required="" MaxLength="50" />
                            <asp:Label ID="lblErrConfirmPassword" runat="server" ForeColor="#ff0000"></asp:Label>
                            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                                Style="color: #ff0000; text-align: left; font-size: small;" Display="Dynamic" ErrorMessage="The password and confirmed password do not match."
                                ValidationGroup="ChangePassword" />

                        </div>

                        <div class="form-group">
                            <label for="Email" class="col-sm-6 col-form-label">Email Address:</label>
                            <asp:TextBox runat="server" ID="txtEmail" Cssclass="form-control" type="email" placeholder="e.g. 123@abc.com" required="" MaxLength="50" />
                            <asp:Label ID="lblErrEmail" runat="server" ForeColor="#ff0000"></asp:Label>
                        </div>

                        <div class="form-group">
                        <label for="ContactNumber" class="col-sm-6 col-form-label">Contact Number:</label>
                        <asp:TextBox runat="server" ID="txtContactNumber" Cssclass="form-control" type="text" placeholder="e.g. 90121314" required="" MaxLength="8" />
                        </div>

                        <div class="form-row align-items-center">
                         <div class="col-auto my-1">
                        <label for="SecurityQns" class="col-sm-8 col-form-label">Security Question:</label>
                        <select required="" id="ddlSecurityQns" runat="server" Cssclass="custom-select mr-sm-4">
                            <option value="">Select Question</option>
                            <option value="Q1">What was your first pet name?</option>
                            <option value="Q2">What is your favorite color?</option>
                            <option value="Q3">Who is your favorite actor?</option>
                            <option value="Q4">What is your favorite movie?</option>
                            <option value="Q5">What is your favorite food?</option>
                        </select>
                        </div>
                        <asp:Label ID="lblErrSecurityQns" runat="server" ForeColor="#ff0000"></asp:Label>
                        </div>

                        <div class="form-group">
                        <label for="SecurityAns" class="col-sm-4 col-form-label">Security Answer:</label>
                        <asp:TextBox runat="server" ID="txtSecurityAns" Cssclass="form-control" type="text" placeholder="" required="" MaxLength="50" />
                        <asp:Label ID="lblErrSecurityAns" runat="server" ForeColor="#ff0000"></asp:Label>
                        </div>

                        <div class="form-group">
                        <div class="clear"></div>
                        <input type="reset" class="btn btn-secondary" value="Clear" />
                        <asp:Button runat="server" ID="btnSignUp" type="submit" class="btn btn-primary"
                            value="Register" Text="Sign Up" OnClick="btnSignUp_Click" />
                        <div class="clear"></div>
                        </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
