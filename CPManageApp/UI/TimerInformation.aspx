<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="TimerInformation.aspx.cs" Inherits="CPManageApp.UI.TimerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <h2>My Parking Session<asp:Label ID="lblSession" runat="server" class="col-sm-6 col-form-label" Font-Bold="True" Visible="False"></asp:Label>
                </h2>
            <br />

            <!-- Start of  User Information-->
            <div class="form-control col-md-5">
                 
                <!--Username -->
                 <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" class="col-sm-6 col-form-label" Text="Username: "></asp:Label>
                    <asp:Label ID="lblRetrieveUsername" runat="server" class="col-sm-6 col-form-label" Text="" Font-Bold="True"></asp:Label>
                </div>

                <!--Current Time -->
                <div class="form-group">
                    <asp:Label ID="lblCurentTime" runat="server" class="col-sm-6 col-form-label" Text="Current Time: "></asp:Label>
                    <asp:Label ID="lblRetrieveCurrentTime" runat="server" class="col-sm-6 col-form-label" Text="" Font-Bold="True"></asp:Label>
                </div>

                 <!--Set Time -->
                 <div class="form-group">
                    <asp:Label ID="lblSetTime" runat="server" class="col-sm-6 col-form-label" Text="Set Time: "></asp:Label>
                    <asp:Label ID="lblRetrieveSetTime" runat="server" class="col-sm-6 col-form-label" Text="" Font-Bold="True"></asp:Label>
                </div>

                 <!--Vehicle No -->
                 <div class="form-group">
                    <asp:Label ID="lblVehicleNo" runat="server" class="col-sm-6 col-form-label" Text="Vehicle No: "></asp:Label>
                    <asp:Label ID="lblRetrieveVehicleNo" runat="server" class="col-sm-6 col-form-label" Text="" Font-Bold="True"></asp:Label>
                </div>

                 <!--Confirmation Button -->
                <div class="form-group">
                   <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Cssclass="btn btn-primary" OnClick="btnConfirm_Click" />
                    &nbsp;
                   <asp:Button ID="btnCancel" runat="server" Text="Cancel" Cssclass="btn btn-secondary" OnClick="btnCancel_Click"/>
                </div>

            </div>
            <!-- End of  User Information-->

        </div>
    </section>
</asp:Content>
