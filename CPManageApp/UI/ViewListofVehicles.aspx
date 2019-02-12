<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewListofVehicles.aspx.cs" Inherits="CPManageApp.UI.ViewListofVehicles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Java Script List -->
    <link href="Layout/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <script src="Layout/vendor/jquery/jquery.min.js"></script>
    <script src="Layout/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- CSS Styles-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <br />
            <h2>Vehicles You Currently Own :<asp:Label ID="lblSession" runat="server" Visible="False"></asp:Label>
            </h2>

            <!-- Add Button to Add Vehicle-->
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <br />
                    <asp:Button Style="margin-left: 0px;" class="btn btn-success" runat="server" Text="Add New Vehicle" ID="btn_AddVehicle" OnClick="btn_AddVehicle_Click"  CausesValidation="false"/>
                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" Text="Back" />
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- Start Modal To Add Vehicle-->
            <div class="table-responsive">

                <asp:UpdatePanel ID="upd_tblVehicle" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Repeater ID="rpv_tblVehicle" runat="server" >
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Vehicle No</th>
                                        <th>Vehicle Type</th>
                                        <th>Delete</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>

                                    <td>
                                        <%# Eval("vehicleNo") %> 
                                    </td>
                                    <td>
                                        <%# Eval("vehicleType") %> 
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btn_deleteVehicle" runat="server" CssClass="btn btn-danger" OnClick="btn_deleteVehicle_Click" Text="Delete" CommandArgument='<%# Eval("username") +";"+  Eval("vehicleNo") %>'>
                                                        <span class="fa fa-times"></span>&nbsp;Delete
                                        </asp:LinkButton>
                                    </td>


                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table> 
                            </FooterTemplate>
                        </asp:Repeater>

                    </ContentTemplate>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btn_createModal" runat="server" />
                        <asp:AsyncPostBackTrigger ControlID="btn_deleteModal" runat="server" />


                    </Triggers>

                </asp:UpdatePanel>

            </div>


            <!-- Modal Create for Add Vehicle Page -->
            <div class="modal fade" id="md_Create" tabindex="-1" role="dialog" aria-labelledby="md_Create_Label">
                <div class="modal-dialog" role="document">

                    <div class="modal-content">

                        <div class="modal-header">

                            <h4 class="modal-title" id="md_Create_Label">Create Vehicle</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        </div>


                        <div class="modal-body">

                            <asp:UpdatePanel ID="upd_create" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <div class="form-group">

                                        <asp:Label runat="server">Vehicle No :</asp:Label>
                                        <asp:TextBox runat="server" Style="margin-left: 0px" CssClass="form-control" ID="txt_createModalVehicleNo" MaxLength="24" PlaceHolder="Enter Your Vehicle No" CausesValidation="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvVehicleNo" runat="server" ControlToValidate="txt_createModalVehicleNo" ValidationGroup="create" ErrorMessage="Please Enter Your Vehicle Number" CausesValidation="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">


                                        <asp:Label runat="server">Vehicle Type: </asp:Label>

                                        <%--<asp:TextBox runat="server" Style="margin-left: 0px" CssClass="form-control" ID="txt_createModalVehicleType" MaxLength="48"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlVehicleType" runat="server" CssClass="form-control" ValidationGroup="create">
                                            <asp:ListItem Text="Select Vehicle Type" Value="0" />
                                            <asp:ListItem Text="Car" Value="1" />
                                            <asp:ListItem Text="Lorry" Value="2" />
                                            <asp:ListItem Text="Motorcycle" Value="3" />
                                            <asp:ListItem Text="Van" Value="4" />
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator Display="Dynamic" ID="rfvVehicleType" runat="server" ControlToValidate="ddlVehicleType"  InitialValue="0" ValidationGroup="create" ErrorMessage="Please Select A Valid Vehicle Type" CausesValidation="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <div class="modal-footer">

                            <asp:Button runat="server" class="btn btn-primary" ID="btn_createModal" Text="Save" OnClick="btn_createModal_Click" ValidationGroup="create" CausesValidation="true"/>

                        </div>

                    </div>
                </div>
            </div>
            <!-- End Modal To Add Vehicle-->

            <!-- Start Modal To Remove Vehicle-->
            <div class="modal fade" id="md_Delete" tabindex="-1" role="dialog" aria-labelledby="md_Delete_Label">
                <div class="modal-dialog" role="document">

                    <div class="modal-content">

                        <div class="modal-header">

                            <h4 class="modal-title" id="md_Delete_Label">Delete Vehicle</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>

                        </div>

                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upd_delete">
                                <ContentTemplate>
                                    <div class="form-group">

                                        <asp:Label runat="server" ID="lbl_deleteModalLabel">Are you sure you want to delete this particular vehicle? </asp:Label>

                                    </div>


                                </ContentTemplate>

                            </asp:UpdatePanel>


                        </div>

                        <div class="modal-footer">

                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btn_deleteModal" runat="server" CssClass="btn btn-danger" OnClick="btn_deleteModal_Click" Text="Delete" CommandArgument='<%# Eval("username") +";"+  Eval("vehicleNo") %>' CausesValidation="false" />
                            <%--<span class="fa fa-times"></span>&nbsp;Delete--%>
                        </div>

                    </div>
                </div>

            </div>
            <!-- End Modal To Remove Vehicle-->

        </div>
    </section>

</asp:Content>
