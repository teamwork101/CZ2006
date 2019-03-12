<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Timercountdown.aspx.cs" Inherits="CPManageApp.UI.Timercountdown" %>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            </asp:UpdatePanel>
                <%-- <asp:Label ID = "lblTimer" runat="server" /> --%>
                <%-- <span id="timerLabel" runat="server">59</span> --%>
            <asp:Label ID="lblTimer" runat="server" />
            <br />
            <asp:Label ID = "Label1" runat="server" visible="false" Text="Times Up"/>
            <div style="display: none;">
                <asp:Button runat="server" type="button" id="timerEnd" OnClick="Timer_Ends" />
            </div>
    <%-- <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"> --%>
    
    <%-- </asp:Timer> --%>
         
   

            <br />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Cancel" />
         
   

        </div>
    </section>
    <script type="text/javascript">
        function countdown() {
            countdown_text = document.getElementById("BodyContent_lblTimer").innerHTML;
            if (countdown_text === ' ') {
                return
            }
            var time_left = countdown_text.split(":")
            hours = parseInt(time_left[0]);
            minutes = parseInt(time_left[1]);
            seconds = parseInt(time_left[2]);
            seconds -= 1;
            if (seconds < 0) {
                minutes -= 1;
                seconds = 59;
            }
            if (minutes < 0) {
                hours -= 1;
                minutes = 59;
            }
            if (!(hours == 0 && minutes == 0 && seconds == 0)) {
                document.getElementById("BodyContent_lblTimer").innerHTML = hours + ":" + minutes + ":" + seconds;
                setTimeout("countdown()", 1000);
            } else {
                var button = document.getElementById("BodyContent_timerEnd");

                button.click();
            }
        }

        setTimeout("countdown()", 1000);
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function show() {
            if (confirm('Are you sure you want to stop the timer?')) {
                window.location.replace('SetTimer.aspx');
            }
        }
    </script>
</asp:Content>

