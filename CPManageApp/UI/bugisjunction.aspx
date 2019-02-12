<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bugisjunction.aspx.cs" Inherits="CPManageApp.UI.Layout2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageMap ID="ImageMap1" runat="server" Height="1064px" Width="2063px" ImageUrl="bugisjunction2.jpg"
                    HotSpotMode="PostBack">
               </asp:ImageMap>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" Interval="10000"  Enabled="True" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text=""
                        Style="z-index: 100; left: 421px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=""
                        Style="z-index: 100; left: 493px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text=""
                        Style="z-index: 100; left: 577px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text=""
                        Style="z-index: 100; left: 674.5px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text=""
                        Style="z-index: 100; left: 747.5px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text=""
                        Style="z-index: 100; left: 856px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text=""
                        Style="z-index: 100; left: 925px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text=""
                        Style="z-index: 100; left: 995.5px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                     <asp:Label ID="Label9" runat="server" Text=""
                        Style="z-index: 100; left: 1074.5px; position: absolute; top: 368px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Text=""
                        Style="z-index: 100; left: 1335px; position: absolute; top: 394.5px; height: 19px; width: 29px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Text=""
                        Style="z-index: 100; left: 1747px; position: absolute; top: 299px; height: 19px; width: 29px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label12" runat="server" Text=""
                        Style="z-index: 100; left: 1749px; position: absolute; top: 363.5px; height: 19px; width: 29px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Text=""
                         Style="z-index: 100; left: 421px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Blue" Visible="true"></asp:Label>
                     <asp:Label ID="Label14" runat="server" Text=""
                         Style="z-index: 100; left: 492.55px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Blue" Visible="true"></asp:Label>
                    <asp:Label ID="Label15" runat="server" Text=""
                        Style="z-index: 100; left: 671.3px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text=""
                        Style="z-index: 100; left: 745.5px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label17" runat="server" Text=""
                        Style="z-index: 100; left: 843px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label18" runat="server" Text=""
                        Style="z-index: 100; left: 918.5px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Text=""
                        Style="z-index: 100; left: 995.2px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label20" runat="server" Text=""
                        Style="z-index: 100; left: 1076.6px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label21" runat="server" Text=""
                        Style="z-index: 100; left: 1148.6px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label22" runat="server" Text=""
                        Style="z-index: 100; left: 1218px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label23" runat="server" Text=""
                        Style="z-index: 100; left: 1292.7px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label24" runat="server" Text=""
                        Style="z-index: 100; left: 1364.5px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label25" runat="server" Text=""
                        Style="z-index: 100; left: 1484px; position: absolute; top: 501px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label26" runat="server" Text=""
                        Style="z-index: 100; left: 1669px; position: absolute; top: 470px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label27" runat="server" Text=""
                        Style="z-index: 100; left: 184px; position: absolute; top: 720px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label28" runat="server" Text=""
                        Style="z-index: 100; left: 271px; position: absolute; top: 720px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label29" runat="server" Text=""
                        Style="z-index: 100; left: 350px; position: absolute; top: 720px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label30" runat="server" Text=""
                        Style="z-index: 100; left: 436.5px; position: absolute; top: 720px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label31" runat="server" Text=""
                        Style="z-index: 100; left: 511.7px; position: absolute; top: 720px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label32" runat="server" Text=""
                        Style="z-index: 100; left: 594px; position: absolute; top: 717px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label33" runat="server" Text=""
                        Style="z-index: 100; left: 670px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label34" runat="server" Text=""
                        Style="z-index: 100; left: 743px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label35" runat="server" Text=""
                        Style="z-index: 100; left: 821.8px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label36" runat="server" Text=""
                        Style="z-index: 100; left: 1087.5px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label37" runat="server" Text=""
                        Style="z-index: 100; left: 1169.5px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label38" runat="server" Text=""
                        Style="z-index: 100; left: 1242.5px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label39" runat="server" Text=""
                        Style="z-index: 100; left: 1399px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label40" runat="server" Text=""
                        Style="z-index: 100; left: 1472.5px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label41" runat="server" Text=""
                        Style="z-index: 100; left: 1553.5px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                    <asp:Label ID="Label42" runat="server" Text=""
                        Style="z-index: 100; left: 1634.5px; position: absolute; top: 711px; height: 29px; width: 19px;" BackColor="Green" Visible="true"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>