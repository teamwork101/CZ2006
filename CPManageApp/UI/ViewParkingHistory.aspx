<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewParkingHistory.aspx.cs" Inherits="CPManageApp.UI.ViewParkingHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <h2>View Parking History<asp:Label ID="lblSession" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSessionV" runat="server" Visible="False"></asp:Label>
            </h2>
            <br />

            <!--Start of Top Layer -->
            <div class="form-row align-items-center">
                  <div class="form-group col-md-3">
                <asp:Label ID="lblVehicleType" runat="server" Text="Select Your Vehicle:"></asp:Label>
                        <asp:DropDownList ID="ddlUserVehicle" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlUserVehicle_SelectedIndexChanged" >
                        </asp:DropDownList>
                      </div>
                <!--Month -->
                <div class="form-group col-md-3">
                  
                    <asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="true">
                        <asp:ListItem Text="Jan" Value="0" />
                        <asp:ListItem Text="Feb" Value="1" />
                        <asp:ListItem Text="Mar" Value="2" />
                        <asp:ListItem Text="Apr" Value="3" />
                        <asp:ListItem Text="May" Value="4" />
                        <asp:ListItem Text="Jun" Value="5" />
                        <asp:ListItem Text="Jul" Value="6" />
                        <asp:ListItem Text="Aug" Value="7" />
                        <asp:ListItem Text="Sep" Value="8" />
                        <asp:ListItem Text="Oct" Value="9" />
                        <asp:ListItem Text="Nov" Value="10" />
                        <asp:ListItem Text="Dec" Value="11" />
                    </asp:DropDownList>
                </div>

                <!--Year -->
                <div class="form-group col-md-3">
                    <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" AutoPostBack="true">
                        <asp:ListItem Text="2018" Value="0" />
                        <asp:ListItem Text="2019" Value="1" />
                        <asp:ListItem Text="2020" Value="2" />
                        <asp:ListItem Text="2021" Value="3" />
                        <asp:ListItem Text="2022" Value="4" />
                        <asp:ListItem Text="2023" Value="5" />
                        <asp:ListItem Text="2024" Value="6" />
                        <asp:ListItem Text="2025" Value="7" />
                        <asp:ListItem Text="2026" Value="8" />
                        <asp:ListItem Text="2027" Value="9" />
                        <asp:ListItem Text="2028" Value="10" />
                        <asp:ListItem Text="2029" Value="11" />
                    </asp:DropDownList>
                </div>


            </div>
            <!--End of Top Layer -->

            <br />
            <!--Start of Grid View -->
            <asp:GridView ID="gvParkingHistory" runat="server" Cssclass="table table-striped table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="gvParkingHistory_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="recordID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="username" HeaderText="Username" Visible="False" />
                    <asp:BoundField DataField="vehicleNo" HeaderText="Vehicle No." />
                    <asp:TemplateField HeaderText="Carpark Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("carparkID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="entryDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Entry Date" />
                    <asp:BoundField DataField="entryTime" DataFormatString="{0:t}" HeaderText="Entry Time" />
                    <asp:BoundField DataField="exitDate" DataFormatString="{0:d}" HeaderText="Exit Date" />
                    <asp:BoundField DataField="exitTime" DataFormatString="{0:t}" HeaderText="Exit Time" />
                    <asp:BoundField DataField="totalCost" DataFormatString="{0:C}" HeaderText="Total Cost" />
                </Columns>

            </asp:GridView>
            <!--End of Grid View -->

            <br />
            <!--Start of Buttons -->
            <asp:Button class="btn btn-danger" runat="server" Text="Back" ID="btn_back" CausesValidation="false" OnClick="btn_back_Click"/>
            <!--End of Buttons -->
        </div>
    </section>
</asp:Content>
