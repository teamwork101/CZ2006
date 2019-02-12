<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="313@somerset.aspx.cs" Inherits="CPManageApp.UI.Layout1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageMap ID="ImageMap1" runat="server" Height="1064px" Width="2063px" ImageUrl="313@somerset.jpg"
                    HotSpotMode="PostBack">
               </asp:ImageMap>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" Interval="10000" Enabled="True" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text=""
                        Style="z-index: 100; left: 420px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=""
                        Style="z-index: 100; left: 492.5px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text=""
                        Style="z-index: 100; left: 577px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text=""
                        Style="z-index: 100; left: 675px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text=""
                        Style="z-index: 100; left: 748px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text=""
                        Style="z-index: 100; left: 857px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text=""
                        Style="z-index: 100; left: 926px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text=""
                        Style="z-index: 100; left: 997px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                     <asp:Label ID="Label9" runat="server" Text=""
                        Style="z-index: 100; left: 1076px; position: absolute; top: 375px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Text=""
                        Style="z-index: 100; left: 1446px; position: absolute; top: 402.5px; height: 19px; width: 29px;" BackColor="Red" Visible="true"></asp:Label>
                     <asp:Label ID="Label11" runat="server" Text=""
                         Style="z-index: 100; left: 492.55px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Blue" Visible="true"></asp:Label>
                    <asp:Label ID="Label12" runat="server" Text=""
                        Style="z-index: 100; left: 671.5px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Blue" Visible="true"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Text=""
                        Style="z-index: 100; left: 746.5px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Text=""
                        Style="z-index: 100; left: 844px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label15" runat="server" Text=""
                        Style="z-index: 100; left: 920px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text=""
                        Style="z-index: 100; left: 996.5px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label17" runat="server" Text=""
                        Style="z-index: 100; left: 1078.6px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label18" runat="server" Text=""
                        Style="z-index: 100; left: 1150.6px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Text=""
                        Style="z-index: 100; left: 1220px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label20" runat="server" Text=""
                        Style="z-index: 100; left: 1295.7px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label21" runat="server" Text=""
                        Style="z-index: 100; left: 1367.8px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label22" runat="server" Text=""
                        Style="z-index: 100; left: 1487.55px; position: absolute; top: 505px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label23" runat="server" Text=""
                        Style="z-index: 100; left: 1673px; position: absolute; top: 475px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label24" runat="server" Text=""
                        Style="z-index: 100; left: 173px; position: absolute; top: 718px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label25" runat="server" Text=""
                        Style="z-index: 100; left: 264px; position: absolute; top: 718px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label26" runat="server" Text=""
                        Style="z-index: 100; left: 349px; position: absolute; top: 747px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label27" runat="server" Text=""
                        Style="z-index: 100; left: 436px; position: absolute; top: 747px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label28" runat="server" Text=""
                        Style="z-index: 100; left: 512px; position: absolute; top: 747px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label29" runat="server" Text=""
                        Style="z-index: 100; left: 594px; position: absolute; top: 745px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label30" runat="server" Text=""
                        Style="z-index: 100; left: 670px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label31" runat="server" Text=""
                        Style="z-index: 100; left: 901px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label32" runat="server" Text=""
                        Style="z-index: 100; left: 979.5px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label33" runat="server" Text=""
                        Style="z-index: 100; left: 1094px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label34" runat="server" Text=""
                        Style="z-index: 100; left: 1171.5px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label35" runat="server" Text=""
                        Style="z-index: 100; left: 1245px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label36" runat="server" Text=""
                        Style="z-index: 100; left: 1402px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label37" runat="server" Text=""
                        Style="z-index: 100; left: 1475.5px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label38" runat="server" Text=""
                        Style="z-index: 100; left: 1557.5px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                    <asp:Label ID="Label39" runat="server" Text=""
                        Style="z-index: 100; left: 1638.5px; position: absolute; top: 712px; height: 29px; width: 19px;" BackColor="Red" Visible="true"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
