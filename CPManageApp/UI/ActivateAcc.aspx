<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="ActivateAcc.aspx.cs" Inherits="CPManageApp.UI.ActivateAcc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="py-5">
      <div class="container">
         <div class="span8">
                        <h2 class="title"><span>Activate Account</span></h2>
                        <div class="contact_form">
                            <div id="note"></div>
                            <div id="fields">

                                <div class="form-control">

                                <div class="form-group">
                                <asp:Label ID="lblActivateMsg" runat="server" TextMode="MultiLine"></asp:Label>
                                <label for="ActivationCode">Activation Code:</label>
                                <asp:TextBox runat="server" class="span13" type="text" ID="txtActivationCode" placeholder="" required="" MaxLength="50" Cssclass="form-control"/>
                                <asp:Label ID="lblErrActivationCode" runat="server" ForeColor="#ff0000"></asp:Label>
                                </div>

                                <div class="form-group">
                                <div class="clear"></div>
                                <input type="reset" class="btn btn-secondary" value="Clear" />
                                <asp:Button runat="server" ID="btnActivateAcc" type="submit" Cssclass="btn btn-primary" value="ActivateAcc" Text="Activate Account" OnClick="btnActivateAcc_Click" />
                                &nbsp <asp:Button ID="btnResendActivationCode" runat="server" Text="Resend Activation Code" CssClass="btn btn-dark" OnClick="btnResendActivationCode_Click"/>
                                    <div class="clear"></div>
                                </div>

                                </div>
                            </div>
                        </div>
                    </div>
      </div>
    </section>

</asp:Content>
