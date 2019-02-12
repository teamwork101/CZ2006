<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="CarparkView.aspx.cs" Inherits="CPManageApp.UI.CarparkView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="py-5">
        <div class="container">
            <br />

            <h2 class="title"><span>View Carpark</span></h2>
            <div class="row">
                <!-- Start List of Button Forms -->
                <%--                <div class="form-control col-md-5">--%>
                <!-- Change Password -->
                <div class="form-group">
                    <table style="width: 100%;">
                        <tr>
                            <td><b>
                                <asp:Label ID="lblCarparkName" runat="server" Style="font-size: x-large"></asp:Label>
                            </b>
                                <asp:Label ID="lblCarparkId" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>&nbsp&nbsp&nbsp;</td>
                            <td>&nbsp&nbsp&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" />
                            </td>
                            <td>&nbsp&nbsp&nbsp;</td>

                            <td>
                                <asp:Label ID="lblInfo" runat="server" Style="font-size: large" Text="Carpark Information"></asp:Label>
                                <br />
                                Operating Hours:
                                <asp:Label ID="lblStartHr" runat="server" Text=""></asp:Label>H to
                                <asp:Label ID="lblEndHr" runat="server" Text=""></asp:Label>H
                                <br />
                                Location:
                                <asp:Label ID="lblAddr" runat="server" Text=""></asp:Label>
                                <br />
                                Total Slots:
                                <asp:Label ID="lblSlots" runat="server"></asp:Label>
                                <br />
                                Rates:<br />
                                <asp:Label ID="lblRates" runat="server" Text=""></asp:Label>
                            </td>

                        </tr>
                        <tr>

                            <td>&nbsp&nbsp&nbsp;</td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" Text="Back" />  </td>
                        </tr>
                    </table>
                    <br/>
                    <asp:Label ID="lblLegend" runat="server" Text="Legend" ForeColor="Black" Font-Size="Large" Font-Underline="True" Font-Bold="true"></asp:Label>
            <br />
            <asp:Label ID="lblAccessibleLots" runat="server" Text="Accessible Parking Lots" BackColor="Blue" ForeColor="Wheat" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="lblAvailableLots" runat="server" Text="Available Parking Lots" BackColor="Green" ForeColor="Wheat" Font-Size="Large"></asp:Label>
            <br/>
            <asp:Label ID="lblOccupiedLots" runat="server" Text="Occupied Parking Lots" BackColor="Red" ForeColor="Wheat" Font-Size="Large"></asp:Label>

                </div>
<iframe id="myIframe" height="800" width="1551" runat="server" />
                    <br />
                    <br />
                                                      

            </div>

            <!-- End List of Button Forms -->
            <%--</div>--%>
        </div>
    </section>
</asp:Content>
