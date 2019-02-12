<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="UserHomepage.aspx.cs" Inherits="CPManageApp.UI.UserHomepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />

            <h2 class="title">User Home Page</h2>
            <asp:Label ID="lblWelcome" runat="server" Text="" Font-Size="Medium"></asp:Label>
            <div class="row">
            <!-- Start List of Button Forms -->
            <div class="form-control col-md-5">
                <!-- Change Password -->
                <div class="form-group">
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-secondary btn-block" OnClick="btnChangePassword_Click" />
                </div>

                <!-- Update User Detail -->
                <div class="form-group ">
                    <asp:Button ID="btnUserDetail" runat="server" Text="Update/View User Detail" CssClass="btn btn-secondary btn-block" OnClick="btnUserDetail_Click" />
                </div>

                <!-- View Parking History -->
                <div class="form-group">
                    <asp:Button ID="btnParkingHistory" runat="server" Text="View Parking History" CssClass="btn btn-secondary btn-block" OnClick="btnParkingHistory_Click" />
                </div>

                <!-- Manage Vehicle -->
                <div class="form-group">
                    <asp:Button ID="btnManageVehicle" runat="server" Text="View Vehicle(s) Owned" CssClass="btn btn-secondary btn-block" OnClick="btnManageVehicle_Click" />
                </div>

                <!-- Set Timer -->
                 <div class="form-group">
                    <asp:Button ID="btnSetTimer" runat="server" Text="Set My Parking Time" CssClass="btn btn-secondary btn-block" OnClick="btnSetTimer_Click" />
                </div>

            </div>
            <!-- End List of Button Forms -->
            
            </div>
        </div>
    </section>
</asp:Content>
