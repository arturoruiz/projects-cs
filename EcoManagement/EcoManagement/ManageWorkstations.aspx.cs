using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace EcoManagement
{
    public partial class ManageWorkstations : System.Web.UI.Page
    {
        private EcoManagementEntities ecomanagementContext;

        List<BLL.OperatingSystem> osl = new List<BLL.OperatingSystem>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
                            
                BLL.OperatingSystem os = new BLL.OperatingSystem();
                
                foreach (BLL.OperatingSystem o in os.load()) {
                    osl.Add(o);
                
                
            }
            
            ecomanagementContext = new EcoManagementEntities();

            if (gvWorkstations.Rows.Count == 0)
            {
                btnInsert.Visible = false;
            }

        }

        protected void ddlBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {

            //ddlBuilding.Items[0].Selected = true;
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);
            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            ddlClassroom.DataSource = classroom.load(buildingID);

            ddlClassroom.DataBind();

            /*
            // Get the department ID.
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);

            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            gvClassrooms.DataSource = classroom.load(buildingID);
            gvClassrooms.DataBind();*/
        }

        protected void ddlBuilding_DataBound(object sender, EventArgs e)
        {
            ddlBuilding.Items[0].Selected = true;
            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);
            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            ddlClassroom.DataSource = classroom.load(buildingID);

            ddlClassroom.DataBind();
            btnInsert.Visible = true;


        }

        protected void ddlClassroom_DataBound(object sender, EventArgs e)
        {
            ddlClassroom.Items[0].Selected = true;
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Workstation workstation = new Workstation();


            // Bind the GridView control to the courseInfo collection.
            gvWorkstations.DataSource = workstation.load(classroomID);

            gvWorkstations.DataBind();
            //btnInsert.Visible = true;
        }

        protected void ddlClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Workstation workstation = new Workstation();


            // Bind the GridView control to the courseInfo collection.
            gvWorkstations.DataSource = workstation.load(classroomID);

            gvWorkstations.DataBind();
            //btnInsert.Visible = true;
        }
        
        
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.gvWorkstations.ShowFooter = true;
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Workstation workstation = new Workstation();


            // Bind the GridView control to the courseInfo collection.
            gvWorkstations.DataSource = workstation.load(classroomID);

            gvWorkstations.DataBind();
            btnInsert.Visible = true;
            
        }

        protected void GridView1_OnRowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox n = this.gvWorkstations.Controls[0].Controls[0].FindControl("txtWorkstationName") as TextBox;
                TextBox mac = this.gvWorkstations.Controls[0].Controls[0].FindControl("txtMAC") as TextBox;
                DropDownList o = this.gvWorkstations.Controls[0].Controls[0].FindControl("ddlOS") as DropDownList;

                Workstation w = new Workstation();
                w.add(n.Text, mac.Text, Convert.ToInt32(ddlClassroom.SelectedValue), 0, Convert.ToInt32(o.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";
                

                // Bind the GridView control to the courseInfo collection.
                gvWorkstations.DataSource = w.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWorkstations.DataBind();
                this.gvWorkstations.ShowFooter = false;
                btnInsert.Visible = true;
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox n = this.gvWorkstations.FooterRow.FindControl("txtWorkstationName") as TextBox;
                TextBox mac = this.gvWorkstations.FooterRow.FindControl("txtMACAddress") as TextBox;
                DropDownList o = this.gvWorkstations.FooterRow.FindControl("ddlOS") as DropDownList;

                Workstation w = new Workstation();
                w.add(n.Text, mac.Text, Convert.ToInt32(ddlClassroom.SelectedValue), 0, Convert.ToInt32(o.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";
                

                // Bind the GridView control to the courseInfo collection.
                gvWorkstations.DataSource = w.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWorkstations.DataBind();
                this.gvWorkstations.ShowFooter = false;
                btnInsert.Visible = true;
            }

        }        

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            
            //Set the edit index.
            gvWorkstations.EditIndex = e.NewEditIndex;
            
            //Bind data to the GridView control.
            // Get the classroomID ID.
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Workstation workstation = new Workstation();


            // Bind the GridView control to the courseInfo collection.
            gvWorkstations.DataSource = workstation.load(classroomID);

            gvWorkstations.DataBind();


        }

        protected void gvWorkstations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           
            gvWorkstations.EditIndex = -1;
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Workstation workstation = new Workstation();


            // Bind the GridView control to the courseInfo collection.
            gvWorkstations.DataSource = workstation.load(classroomID);

            gvWorkstations.DataBind();
        }

        protected void gvWorkstations_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
              TextBox n = this.gvWorkstations.Rows[gvWorkstations.EditIndex].Cells[0].FindControl("txtWorkstationName") as TextBox;
              TextBox mac = this.gvWorkstations.Rows[gvWorkstations.EditIndex].Cells[0].FindControl("txtMACAddress") as TextBox;
              DropDownList o = this.gvWorkstations.Rows[gvWorkstations.EditIndex].Cells[0].FindControl("ddlOS") as DropDownList;
              RequiredFieldValidator rfvName = this.gvWorkstations.Rows[gvWorkstations.EditIndex].Cells[0].FindControl("rfvClassroomName") as RequiredFieldValidator;
              RequiredFieldValidator rfvMac = this.gvWorkstations.Rows[gvWorkstations.EditIndex].Cells[0].FindControl("rfvMAC") as RequiredFieldValidator;
              RegularExpressionValidator revMac = this.gvWorkstations.Rows[gvWorkstations.EditIndex].Cells[0].FindControl("revMAC") as RegularExpressionValidator;
              rfvName.Validate();
              rfvMac.Validate();
              revMac.Validate();

              if (rfvName.IsValid && rfvMac.IsValid && revMac.IsValid)
            {
                Workstation w = new Workstation();
                w.edit(Convert.ToInt32(e.Keys[0].ToString()), n.Text, mac.Text, Convert.ToInt32(ddlClassroom.SelectedValue), 0, Convert.ToInt32(o.SelectedValue));

                lblText.Text = "<br />Record modified successfully<br />";
                gvWorkstations.EditIndex = -1;
                gvWorkstations.DataSource = w.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWorkstations.DataBind();

                this.gvWorkstations.ShowFooter = false;
                btnInsert.Visible = true;
            
            }
              
        }

        protected void gvWorkstations_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                    // Retrieve the underlying data item. In this example
                    // the underlying data item is a DataRowView object. 
                   // Workstation rowView = (Workstation)e.Row.DataItem;
                    string[] str  = e.Row.DataItem.ToString().Split('=');

                    // Retrieve the state value for the current row. 
                    String OSID = str[7].Trim('}',' ');

                    if (e.Row.RowState == DataControlRowState.Edit)
                    {
                        // Preselect the DropDownList control with the state value
                        // for the current row.                   

                        // Retrieve the DropDownList control from the current row. 
                        DropDownList list = (DropDownList)e.Row.FindControl("ddlos");

                        // Find the ListItem object in the DropDownList control with the 
                        // state value and select the item.
                        ListItem item = list.Items.FindByValue(OSID);
                        list.SelectedIndex = list.Items.IndexOf(item);
                    }

                    else
                    {

                        Label osid = e.Row.Cells[9].FindControl("Label3") as Label;

                        int OpertaingSystemID = Convert.ToInt32(OSID);

                        foreach (BLL.OperatingSystem os in osl)
                        {
                            if (os.ID == OpertaingSystemID)
                            {
                                osid.Text = os.OSName;
                            }
                        }
                    }
                 
        
            }
        }

        
            

        protected void gvWorkstations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Workstation workstation = new Workstation();

         





            workstation.delete(Convert.ToInt32(e.Keys[0].ToString()));

                
                gvWorkstations.EditIndex = -1;
                gvWorkstations.DataSource = workstation.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWorkstations.DataBind();

                
                btnInsert.Visible = true;

            
        }
        }

       
    }
