using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;

namespace CPManageApp.UI
{
    public partial class ViewListofVehicles : System.Web.UI.Page
    {
        BLLVehicle VehicleBizLayer = new BLLVehicle();

        // Instantiate the script here
        String openCreateModalScript, closeCreateModalScript, openUpdateModalScript, closeUpdateModalScript, openDeleteModalScript, closeDeleteModalScript, openLoadingIconScript, closeLoadingIconScript, openChangePictureModalScript, closeChangePictureModalScript, openFailureIconScript, closeFailureIconScript;

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHomepage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            openCreateModalScript = @"$('#md_Create').modal('show');";
            closeCreateModalScript = "$('#md_Create').modal('hide');";


            openUpdateModalScript = @"$('#md_Update').modal('show')";
            closeUpdateModalScript = "$('#md_Update').modal('hide')";

            openDeleteModalScript = "$('#md_Delete').modal('show')";
            closeDeleteModalScript = "$('#md_Delete').modal('hide')";

            if (!this.IsPostBack)
            {
                //lblSession.Text = "angiekoh28"; //to change it to Session["username"].ToString();
                lblSession.Text = Session["login"].ToString();
                BindVehicleInfo();
            }

        }

        private void BindVehicleInfo()
        {
            //Access Business Layer to Data Layer
            rpv_tblVehicle.DataSource = VehicleBizLayer.getAllVehicles(lblSession.Text);
            rpv_tblVehicle.DataBind();
        }

        protected void btn_AddVehicle_Click(object sender, EventArgs e)
        {
            // Display the modal when the user clicked the button
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", openCreateModalScript, true);
        }


        //Upon Clicking the Delete button in the Add Vehicle Page
        protected void btn_deleteVehicle_Click(object sender, EventArgs e)
        {
            // Display the modal when the user clicked the button
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", openDeleteModalScript, true);

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);


            // Store the string into array
            string[] arg = new string[2];
            arg = button.CommandArgument.ToString().Split(';');

            //Create a Session for the Button
            Session["vehicleNo"] = arg[1];


            //bind the result
            this.BindVehicleInfo();

            // Display it to the modal
            lbl_deleteModalLabel.Text = "Do you want to delete Vehicle " + Session["vehicleNo"].ToString() + "?";

            // Refresh the delete panel
            upd_delete.Update();
        }

        // Activate this code if the create button is pressed
        protected void btn_createModal_Click(object sender, EventArgs e)
        {

            // Get all the variable from the database
            string vehicleNo = txt_createModalVehicleNo.Text;
            string vehicleType = ddlVehicleType.SelectedItem.Text;

            // Validate the controls
            Page.Validate("create");
            if (!Page.IsValid)
            {
                upd_create.Update();
                rfvVehicleType.ErrorMessage = "Please Select A Valid Vehicle Type!";
                rfvVehicleNo.ErrorMessage = "Please Enter Your Vehicle Number";
                return;
            }

            bool result = VehicleBizLayer.addVehicle(lblSession.Text, vehicleNo, vehicleType);

            //Reset the form to empty
            txt_createModalVehicleNo.Text = "";
            ddlVehicleType.SelectedIndex = 0;


            if (result == true)
            {
                // Refresh the table
                BindVehicleInfo();
                // Use Javascript to close the modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", closeCreateModalScript, true);
            }

            else if (result == false)
            {
                // Refresh the table
                BindVehicleInfo();

                // Use Javascript to close the modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", closeCreateModalScript, true);

            }

        }


        // Activate this code if the delete button is pressed
        protected void btn_deleteModal_Click(object sender, EventArgs e)
        {

            // Delete the vehicle info from the database

            //Call in the remove Vehicle biz layer
            VehicleBizLayer.removeVehicle(lblSession.Text, Session["vehicleNo"].ToString());

            //Remove the Session["vehicleNo"] value
            Session.Remove("vehicleNo");

            // Refresh the table
            BindVehicleInfo();

            // Use Javascript to close the modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", closeDeleteModalScript, true);
        }
    }
}