<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="SetTimer.aspx.cs" Inherits="CPManageApp.UI.SetTimer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function leadingZeros(input) {
            if (!isNaN(input.value) && input.value.length === 1) {
                input.value = '0' + input.value;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <h2>Set My Parking Session</h2>
            <br />

            <div class="form-control col-md-5">
                <!-- Start of Timer Layout -->
                <div class="form-group">
                    Current Time: <asp:Label ID="lblCurrent" runat="server" class="col-sm-6 col-form-label" Text=""></asp:Label>
                     Carpark Closing Time: <asp:Label ID="lblClosing" runat="server" class="col-sm-6 col-form-label" Text=""></asp:Label>
                    </div>
                <%--<div class="form-row align-items-center">--%>
                    <!-- Hours -->
                    <div class="form-group">
                        Time Out:&nbsp;&nbsp;
                        <asp:TextBox ID="txtHours" TextMode="Number" runat="server" value="00" min="00" max="23" step="1" MaxLength="2" onchange="leadingZeros(this)" onclick="leadingZeros(this)"/>

                    &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
                        <asp:TextBox ID="txtMinutes" TextMode="Number" runat="server" value="00" min="00" max="59" step="1" onchange="leadingZeros(this)" MaxLength="2" onclick="leadingZeros(this)" />

                    </div>
                    <!-- Minutes -->
                    <div class="form-group">
                    </div>
                    
                    <!-- Vehicle -->
                    <div class="form-group">
                        <asp:Label ID="lblVehicleType" runat="server" class="col-sm-6 col-form-label" Text="Select Your Vehicle:"></asp:Label>
                        <asp:DropDownList ID="ddlUserVehicle" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>

                    <!-- Buttons -->
                    <div class="form-group col-md-2">

                        <asp:Button ID="btnSet" runat="server" Text="Set" CssClass="btn btn-primary" OnClick="btnSet_Click" />
                    </div>
                <%--</div>--%>
                <!-- End of Timer Layout -->
            </div>
            </div>
    </section>
</asp:Content>
