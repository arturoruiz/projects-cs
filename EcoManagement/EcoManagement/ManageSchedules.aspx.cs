using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EcoManagement
{
    public partial class ManageSchedules : System.Web.UI.Page
    {
        private EcoManagementEntities ecomanagementContext;
        public int editKey;
        List<BLL.Classroom> cl = new List<BLL.Classroom>();


        protected void Page_Load(object sender, EventArgs e)
        {
            ecomanagementContext = new EcoManagementEntities();

            BLL.Classroom classroom = new BLL.Classroom();

            foreach (BLL.Classroom c in ecomanagementContext.Classrooms)
            {
                cl.Add(c);

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
            Schedule schedule = new Schedule();


            // Bind the GridView control to the courseInfo collection.
            gvSchedules.DataSource = schedule.load(classroomID);

            gvSchedules.DataBind();
            //btnInsert.Visible = true;
        }

        protected void ddlClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Schedule schedule = new Schedule();


            // Bind the GridView control to the courseInfo collection.
            gvSchedules.DataSource = schedule.load(classroomID);

            gvSchedules.DataBind();
            //btnInsert.Visible = true;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //this.gvSchedules.ShowFooter = true;
            divForm.Visible = true;
            /*Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Schedule schedule = new Schedule();

            
            // Bind the GridView control to the courseInfo collection.
            gvSchedules.DataSource = schedule.load(classroomID);

            gvSchedules.DataBind();
            btnInsert.Visible = true;*/

        }

        protected void GridView1_OnRowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox r = this.gvSchedules.Controls[0].Controls[0].FindControl("txtReason") as TextBox;
                TextBox po = this.gvSchedules.Controls[0].Controls[0].FindControl("timepicker_start") as TextBox;
                TextBox pd = this.gvSchedules.Controls[0].Controls[0].FindControl("timepicker_end") as TextBox;               
                DropDownList dotw = this.gvSchedules.Controls[0].Controls[0].FindControl("ddlDayOfTheWeek") as DropDownList;

                Schedule schedule = new Schedule();
                schedule.add(r.Text, Convert.ToDateTime(po.Text), Convert.ToDateTime(pd.Text), dotw.SelectedValue, Convert.ToInt32(ddlClassroom.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";


                // Bind the GridView control to the courseInfo collection.
                gvSchedules.DataSource = schedule.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvSchedules.DataBind();
                this.gvSchedules.ShowFooter = false;
                btnInsert.Visible = true;
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox r = this.gvSchedules.FooterRow.FindControl("txtClassroomName") as TextBox;
                TextBox po = this.gvSchedules.FooterRow.FindControl("timepicker_start") as TextBox;
                TextBox pd = this.gvSchedules.FooterRow.FindControl("timepicker_end") as TextBox;
                DropDownList dotw = this.gvSchedules.Controls[0].Controls[0].FindControl("ddlDayOfTheWeek") as DropDownList;
                
                Schedule schedule = new Schedule();
                schedule.add(r.Text, Convert.ToDateTime(po.Text), Convert.ToDateTime(pd.Text), dotw.SelectedValue, Convert.ToInt32(ddlClassroom.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";

                
                // Bind the GridView control to the courseInfo collection.
                gvSchedules.DataSource = schedule.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvSchedules.DataBind();
                this.gvSchedules.ShowFooter = false;
                btnInsert.Visible = true;
            }

        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {

            

            Label r = this.gvSchedules.Rows[e.NewEditIndex].Cells[0].FindControl("lblReason") as Label;
            Label po = this.gvSchedules.Rows[e.NewEditIndex].Cells[0].FindControl("lblPoweredOn") as Label;
            Label pd = this.gvSchedules.Rows[e.NewEditIndex].Cells[0].FindControl("lblPowerDown") as Label;
            Label dotw = this.gvSchedules.Rows[e.NewEditIndex].Cells[0].FindControl("lblDayOfTheWeek") as Label;
            lbl.Text = gvSchedules.DataKeys[e.NewEditIndex].Value.ToString();
           
            txtReason.Text = r.Text;
            timepicker_start.Text = po.Text;
            timepicker_end.Text = pd.Text;
            ddlDayOfTheWeek.SelectedValue = dotw.Text;

            Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);
            // Select course information based on department ID.
            Classroom classroom = new Classroom();


            // Bind the GridView control to the courseInfo collection.
            ddlClassroomEdit.DataSource = classroom.load(buildingID);            
            ddlClassroomEdit.DataBind();
            ddlClassroomEdit.SelectedIndex = ddlClassroom.SelectedIndex;
            
            divForm.Visible = true;
            divClassroom.Visible = true;
            btnInsert.Visible = false;

            /*//Bind data to the GridView control.
            // Get the classroomID ID.
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Schedule schedule = new Schedule();


            // Bind the GridView control to the courseInfo collection.
            gvSchedules.DataSource = schedule.load(classroomID);

            gvSchedules.DataBind();*/
            


        }

        protected void gvSchedules_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvSchedules.EditIndex = -1;
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Schedule schedule = new Schedule();


            // Bind the GridView control to the courseInfo collection.
            gvSchedules.DataSource = schedule.load(classroomID);

            gvSchedules.DataBind();
        }

        protected void gvSchedules_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            /*TextBox n = this.gvSchedules.Rows[e.RowIndex].Cells[0].FindControl("txtWorkstationName") as TextBox;
            TextBox mac = this.gvSchedules.Rows[e.RowIndex].Cells[0].FindControl("txtMACAddress") as TextBox;
            DropDownList o = this.gvSchedules.Rows[e.RowIndex].Cells[0].FindControl("ddlOS") as DropDownList;
            RequiredFieldValidator rfvName = this.gvSchedules.Rows[e.RowIndex].Cells[0].FindControl("rfvClassroomName") as RequiredFieldValidator;
            RequiredFieldValidator rfvMac = this.gvSchedules.Rows[e.RowIndex].Cells[0].FindControl("rfvMAC") as RequiredFieldValidator;
            RegularExpressionValidator revMac = this.gvSchedules.Rows[e.RowIndex].Cells[0].FindControl("revMAC") as RegularExpressionValidator;
            rfvName.Validate();
            rfvMac.Validate();
            revMac.Validate();

            if (rfvName.IsValid && rfvMac.IsValid && revMac.IsValid)
            {
                Workstation w = new Workstation();
                w.edit(Convert.ToInt32(e.Keys[0].ToString()), n.Text, mac.Text, Convert.ToInt32(ddlClassroom.SelectedValue), 0, Convert.ToInt32(o.SelectedValue));

                lblText.Text = "<br />Record modified successfully<br />";
                gvSchedules.EditIndex = -1;
                gvSchedules.DataSource = w.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvSchedules.DataBind();

                this.gvSchedules.ShowFooter = false;
                btnInsert.Visible = true;

            }*/

        }

        protected void gvSchedules_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string[] str = e.Row.DataItem.ToString().Split(',');
                string[] strC = str[3].Split('=');
                String ClassroomID = strC[1].Trim(' ');
                
                Label classroomid = e.Row.Cells[6].FindControl("lblClassroomID") as Label;

                Label powerOn = e.Row.Cells[6].FindControl("lblPoweredOn") as Label;
                Label powerDown = e.Row.Cells[6].FindControl("lblPowerDown") as Label;

                
                powerOn.Text = Convert.ToDateTime(powerOn.Text).ToString("hh:mm tt");//string.Format("hh:mm", powerOn.Text);
                powerDown.Text = Convert.ToDateTime(powerDown.Text).ToString("hh:mm tt");

                int ClassRoomID = Convert.ToInt32(ClassroomID);

                     foreach (BLL.Classroom classroom in cl)
                     {
                         if (classroom.ID == ClassRoomID)
                         {
                             classroomid.Text = classroom.Name;
                         }
                     }
            }


            
        }




        protected void gvSchedules_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Schedule schedule = new Schedule();

            schedule.delete(Convert.ToInt32(e.Keys[0].ToString()));


            gvSchedules.EditIndex = -1;
            gvSchedules.DataSource = schedule.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
            gvSchedules.DataBind();


            btnInsert.Visible = true;


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule(); 
            if (divClassroom.Visible != true)
            {
               
                schedule.add(txtReason.Text, Convert.ToDateTime(timepicker_start.Text), Convert.ToDateTime(timepicker_end.Text), ddlDayOfTheWeek.SelectedValue, Convert.ToInt32(ddlClassroom.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";
            }
            else
            {

                schedule.edit(Convert.ToInt32(lbl.Text), txtReason.Text, Convert.ToDateTime(timepicker_start.Text), Convert.ToDateTime(timepicker_end.Text), ddlDayOfTheWeek.SelectedValue, Convert.ToInt32(ddlClassroomEdit.SelectedValue));
                lblText.Text = "<br />Record modified successfully<br />";
                divForm.Visible = false;
                divClassroom.Visible = false;
                lbl.Text = "";
                gvSchedules.EditIndex = -1;
            }

            // Bind the GridView control to the courseInfo collection.
            gvSchedules.DataSource = schedule.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
            gvSchedules.DataBind();
            btnInsert.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divForm.Visible = false;
            txtReason.Text = "";
            timepicker_start.Text = "";
            timepicker_end.Text = "";
            ddlDayOfTheWeek.SelectedIndex = 0;
        }

       
    }
}