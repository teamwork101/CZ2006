<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Timercountdown.aspx.cs" Inherits="CPManageApp.UI.Timercountdown" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function show()
        {
            if(confirm('Are you sure you want to stop the timer?'))
            {
                window.location.replace('SetTimer.aspx');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            </asp:UpdatePanel>
                <asp:Label ID = "lblTimer" runat="server" />
            <br />
            <asp:Label ID = "Label1" runat="server" visible="false" Text="Times Up"/>
    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
    
    </asp:Timer>
         
   

            <br />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Cancel" />
         
   

        </div>
    </section>
</asp:Content>

