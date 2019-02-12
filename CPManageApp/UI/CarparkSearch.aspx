<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="CarparkSearch.aspx.cs" Inherits="CPManageApp.UI.CarparkSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <h2>Carpark Search</h2>
            <br />

            <!--Start of Top Layer -->
            <div class="form-row align-items-center">

                <!--Region -->
                <div class="form-group col-md-3">
                    <asp:Label ID="lblRegion" runat="server" Text="Select Region:"></asp:Label>
                    <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="All" Value="0" />
                        <asp:ListItem Text="East" Value="1" />
                        <asp:ListItem Text="South" Value="2" />
                        <asp:ListItem Text="West" Value="3" />
                        <asp:ListItem Text="North" Value="4" />
                        <asp:ListItem Text="Central" Value="5" />
                        <asp:ListItem Text="Orchard" Value="6" />
                        <asp:ListItem Text="CBD" Value="7" />
                    </asp:DropDownList>
                </div>

                <!--Mall Name Search-->
                <div class="form-group col-md-3">
                    <asp:Label ID="lblMallName" runat="server" Text="Mall Name"></asp:Label>
                    <asp:TextBox ID="txtMallName" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                </div>

                <!--Search Button-->
                <div class="form-group col-md-3">
                    <br />
                   <asp:Button class="btn btn-danger " runat="server" Text="Search" ID="btn_SearchMall" CausesValidation="false" OnClick="btn_SearchMall_Click"/>
                </div>

            </div>
            <!--End of Top Layer -->
            <br />

            <!--Start of Data List of Shopping Mall-->
            <asp:ListView ID="LVShoppingMall" runat="server" DataKeyNames="carparkId" GroupItemCount="3" OnItemDataBound="LVShoppingMall_ItemDataBound" Style="text-align: center" CellPadding="10" OnPagePropertiesChanging="LVShoppingMall_PagePropertiesChanging">
                 <AlternatingItemTemplate>
                <td runat="server" style="">
                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# string.Format("CarparkView.aspx?carparkName={0}",Eval("carparkId"))%>' runat="server" Style="text-decoration: none; color: black;">
                        <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl='<%# "~\\UI\\MallImages\\" + Eval("image") %>' Width="300px"/>
                        <br />
                       <asp:Label ID="lblMallName" runat="server" Text='<%# Eval("carparkName") %>'></asp:Label>
                            <br />
                        <asp:Label ID="lblMallId" runat="server" Text='<%# Eval("carparkId") %>' Visible="False" />
                        <br />
                    </asp:HyperLink></td></AlternatingItemTemplate><EmptyDataTemplate>
                <table runat="server" style="">
                    <tr runat="server">
                        <td runat="server">Empty List.</td></tr></table></EmptyDataTemplate><EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>

            <ItemTemplate>
                <td runat="server" style="">
                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# string.Format("CarparkView.aspx?carparkName={0}",Eval("carparkId"))%>' runat="server" Style="text-decoration: none; color: black;">
                        <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl='<%# "~\\UI\\MallImages\\" + Eval("image") %>' Width="300px"/>
                        <br />
                       <asp:Label ID="lblMallName" runat="server" Text='<%# Eval("carparkName") %>'></asp:Label>
                            <br />
                        <asp:Label ID="lblMallId" runat="server" Text='<%# Eval("carparkId") %>' Visible="False" />
                        <br />
                    </asp:HyperLink></td></ItemTemplate><LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="LVShoppingMall" PageSize="12">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <td runat="server" style="">
                        <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl='<%# "~\\UI\\MallImages\\" + Eval("image") %>' Width="300px"/>
                        <br />
                       <asp:Label ID="lblMallName" runat="server" Text='<%# Eval("carparkName") %>'></asp:Label><br /><asp:Label ID="lblMallId" runat="server" Text='<%# Eval("carparkId") %>' Visible="False" />
                        <br />
                    </td>
            </SelectedItemTemplate>
            </asp:ListView>
            <!--End of Data List of Shopping Mall-->

        </div>
    </section>
</asp:Content>
