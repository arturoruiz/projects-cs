using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EcoManagement
{
    public partial class ManageClassrooms : System.Web.UI.Page
    {
        private EcoManagementEntities ecomanagementContext;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ecomanagementContext = new EcoManagementEntities();

            if (gvClassrooms.Rows.Count == 0)
            {
                btnInsert.Visible = false;
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.gvClassrooms.ShowFooter = true;
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);
            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            gvClassrooms.DataSource = classroom.load(buildingID);
            gvClassrooms.DataBind();
            btnInsert.Visible = true;

        }

        protected void GridView1_OnRowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox n = this.gvClassrooms.Controls[0].Controls[0].FindControl("txtClassroomName") as TextBox;
                DropDownList d = this.gvClassrooms.Controls[0].Controls[0].FindControl("ddlBuildingsEmpty") as DropDownList;

                Classroom c = new Classroom();
                c.add(n.Text, Convert.ToInt32(d.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";
                


                // Bind the GridView control to the courseInfo collection.
                gvClassrooms.DataSource = c.load(Convert.ToInt32(this.ddlBuilding.SelectedValue));
                gvClassrooms.DataBind();
                this.gvClassrooms.ShowFooter = false;
                btnInsert.Visible = true;
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox n = this.gvClassrooms.FooterRow.FindControl("txtClassroomName") as TextBox;


                Classroom c = new Classroom();
                c.add(n.Text, Convert.ToInt32(this.ddlBuilding.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";
                gvClassrooms.DataSource = c.load(Convert.ToInt32(this.ddlBuilding.SelectedValue));
                gvClassrooms.DataBind();
                this.gvClassrooms.ShowFooter = false;
                btnInsert.Visible = true;
            }
            
        }

        protected void ddlBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the department ID.
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);

            // Select course information based on department ID.
            Classroom classroom = new Classroom();

           
            // Bind the GridView control to the courseInfo collection.
            gvClassrooms.DataSource = classroom.load(buildingID);
            gvClassrooms.DataBind();
        }

       

        protected void ddlBuilding_DataBound(object sender, EventArgs e)
        {
            ddlBuilding.Items[0].Selected = true;
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);
            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            gvClassrooms.DataSource = classroom.load(buildingID);
            gvClassrooms.DataBind();
            btnInsert.Visible = true;

       
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            gvClassrooms.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            // Get the department ID.
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);

            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            gvClassrooms.DataSource = classroom.load(buildingID);
            gvClassrooms.DataBind();
            
            
        }

        protected void gvClassrooms_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClassrooms.EditIndex = -1;
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);

            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            gvClassrooms.DataSource = classroom.load(buildingID);
            gvClassrooms.DataBind();
        }

        protected void gvClassrooms_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox n = this.gvClassrooms.Rows[gvClassrooms.EditIndex].Cells[0].FindControl("txtName") as TextBox;
            DropDownList d = this.gvClassrooms.Rows[gvClassrooms.EditIndex].Cells[0].FindControl("ddlBuildingsEdit") as DropDownList;
            RequiredFieldValidator rfv = this.gvClassrooms.Rows[gvClassrooms.EditIndex].Cells[0].FindControl("rfvClassroomName") as RequiredFieldValidator;
            rfv.Validate();

            if (rfv.IsValid)
            {
                Classroom classroom = new Classroom();
                classroom.edit(Convert.ToInt32(e.Keys[0].ToString()), n.Text, Convert.ToInt32(d.SelectedValue));

                lblText.Text = "<br />Record modified successfully<br />";
                gvClassrooms.EditIndex = -1;
                gvClassrooms.DataSource = classroom.load(Convert.ToInt32(ddlBuilding.SelectedValue));
                gvClassrooms.DataBind();

                this.gvClassrooms.ShowFooter = false;
                btnInsert.Visible = true;
            }
        }

      

        

        
    }
}