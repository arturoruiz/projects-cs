using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace EcoManagement
{
    public partial class ManageWhitelists : System.Web.UI.Page
    {
        //private EcoManagementEntities ecomanagementContext;
        public int editKey;
        //List<BLL.Classroom> cl = new List<BLL.Classroom>();


        protected void Page_Load(object sender, EventArgs e)
        {
            /*ecomanagementContext = new EcoManagementEntities();

            BLL.Classroom classroom = new BLL.Classroom();

            foreach (BLL.Classroom c in ecomanagementContext.Classrooms)
            {
                cl.Add(c);

            }*/



           

            Whitelist whitelist = new Whitelist();
            // Bind the GridView control to the courseInfo collection.
            gvWhitelists.DataSource = whitelist.load();
            gvWhitelists.DataBind();
            
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
            ddlWorkstation.DataSource = workstation.load(classroomID);

            ddlWorkstation.DataBind();
            //btnInsert.Visible = true;
             
        }

        protected void ddlClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Workstation workstation = new Workstation();


            // Bind the GridView control to the courseInfo collection.
            ddlWorkstation.DataSource = workstation.load(classroomID);

            ddlWorkstation.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //this.gvWhitelists.ShowFooter = true;
            divForm.Visible = true;
            /*Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Schedule schedule = new Schedule();

            
            // Bind the GridView control to the courseInfo collection.
            gvWhitelists.DataSource = schedule.load(classroomID);

            gvWhitelists.DataBind();
            btnInsert.Visible = true;*/

        }

        protected void GridView1_OnRowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox r = this.gvWhitelists.Controls[0].Controls[0].FindControl("txtReason") as TextBox;
                TextBox po = this.gvWhitelists.Controls[0].Controls[0].FindControl("from") as TextBox;
                TextBox pd = this.gvWhitelists.Controls[0].Controls[0].FindControl("to") as TextBox;
                DropDownList dotw = this.gvWhitelists.Controls[0].Controls[0].FindControl("ddlDayOfTheWeek") as DropDownList;

                Schedule schedule = new Schedule();
                schedule.add(r.Text, Convert.ToDateTime(po.Text), Convert.ToDateTime(pd.Text), dotw.SelectedValue, Convert.ToInt32(ddlClassroom.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";


                // Bind the GridView control to the courseInfo collection.
                gvWhitelists.DataSource = schedule.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWhitelists.DataBind();
                this.gvWhitelists.ShowFooter = false;
                btnInsert.Visible = true;
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox r = this.gvWhitelists.FooterRow.FindControl("txtClassroomName") as TextBox;
                TextBox po = this.gvWhitelists.FooterRow.FindControl("from") as TextBox;
                TextBox pd = this.gvWhitelists.FooterRow.FindControl("to") as TextBox;
                DropDownList dotw = this.gvWhitelists.Controls[0].Controls[0].FindControl("ddlDayOfTheWeek") as DropDownList;

                Schedule schedule = new Schedule();
                schedule.add(r.Text, Convert.ToDateTime(po.Text), Convert.ToDateTime(pd.Text), dotw.SelectedValue, Convert.ToInt32(ddlClassroom.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";


                // Bind the GridView control to the courseInfo collection.
                gvWhitelists.DataSource = schedule.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWhitelists.DataBind();
                this.gvWhitelists.ShowFooter = false;
                btnInsert.Visible = true;
            }

        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {

            Label reason = this.gvWhitelists.Rows[e.NewEditIndex].Cells[0].FindControl("lblReason") as Label;
            Label start = this.gvWhitelists.Rows[e.NewEditIndex].Cells[0].FindControl("lblStart") as Label;
            Label end = this.gvWhitelists.Rows[e.NewEditIndex].Cells[0].FindControl("lblEnd") as Label;
            
            lbl.Text = gvWhitelists.DataKeys[e.NewEditIndex].Value.ToString();

            txtReason.Text = reason.Text;
            from.Text = start.Text;
            to.Text = end.Text;


            /*
             * Int32 buildingID = Convert.ToInt32(ddlBuilding.SelectedValue);
            // Select course information based on department ID.
            Classroom classroom = new Classroom();

            
            // Bind the GridView control to the courseInfo collection.
            ddlClassroomEdit.DataSource = classroom.load(buildingID);
            ddlClassroomEdit.DataBind();
            ddlClassroomEdit.SelectedIndex = ddlClassroom.SelectedIndex;
            */
            divForm.Visible = true;
            divWhitelist.Visible = true;
            btnInsert.Visible = false;

            /*//Bind data to the GridView control.
            // Get the classroomID ID.
            Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Schedule schedule = new Schedule();


            // Bind the GridView control to the courseInfo collection.
            gvWhitelists.DataSource = schedule.load(classroomID);

            gvWhitelists.DataBind();*/



        }

        protected void gvWhitelists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvWhitelists.EditIndex = -1;
            //Int32 classroomID = Convert.ToInt32(ddlClassroom.SelectedValue);
            // Select course information based on department ID.
            Whitelist whitelist = new Whitelist();
            // Bind the GridView control to the courseInfo collection.
            gvWhitelists.DataSource = whitelist.load();
            gvWhitelists.DataBind();
        }

        protected void gvWhitelists_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            /*TextBox n = this.gvWhitelists.Rows[e.RowIndex].Cells[0].FindControl("txtWorkstationName") as TextBox;
            TextBox mac = this.gvWhitelists.Rows[e.RowIndex].Cells[0].FindControl("txtMACAddress") as TextBox;
            DropDownList o = this.gvWhitelists.Rows[e.RowIndex].Cells[0].FindControl("ddlOS") as DropDownList;
            RequiredFieldValidator rfvName = this.gvWhitelists.Rows[e.RowIndex].Cells[0].FindControl("rfvClassroomName") as RequiredFieldValidator;
            RequiredFieldValidator rfvMac = this.gvWhitelists.Rows[e.RowIndex].Cells[0].FindControl("rfvMAC") as RequiredFieldValidator;
            RegularExpressionValidator revMac = this.gvWhitelists.Rows[e.RowIndex].Cells[0].FindControl("revMAC") as RegularExpressionValidator;
            rfvName.Validate();
            rfvMac.Validate();
            revMac.Validate();

            if (rfvName.IsValid && rfvMac.IsValid && revMac.IsValid)
            {
                Workstation w = new Workstation();
                w.edit(Convert.ToInt32(e.Keys[0].ToString()), n.Text, mac.Text, Convert.ToInt32(ddlClassroom.SelectedValue), 0, Convert.ToInt32(o.SelectedValue));

                lblText.Text = "<br />Record modified successfully<br />";
                gvWhitelists.EditIndex = -1;
                gvWhitelists.DataSource = w.load(Convert.ToInt32(this.ddlClassroom.SelectedValue));
                gvWhitelists.DataBind();

                this.gvWhitelists.ShowFooter = false;
                btnInsert.Visible = true;

            }*/

        }

        protected void gvWhitelists_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            
             if (e.Row.RowType == DataControlRowType.DataRow)
            {
               Label startW = e.Row.Cells[6].FindControl("lblStart") as Label;
               Label endW = e.Row.Cells[6].FindControl("lblEnd") as Label;


               startW.Text = Convert.ToDateTime(startW.Text).ToString("MM/dd/yyyy");
               endW.Text = Convert.ToDateTime(endW.Text).ToString("MM/dd/yyyy");
                 /*string[] str = e.Row.DataItem.ToString().Split(',');
                string[] strC = str[3].Split('=');
                String ClassroomID = strC[1].Trim(' ');

                Label classroomid = e.Row.Cells[6].FindControl("lblClassroomID") as Label;

                int ClassRoomID = Convert.ToInt32(ClassroomID);

                foreach (BLL.Classroom classroom in cl)
                {
                    if (classroom.ID == ClassRoomID)
                    {
                        classroomid.Text = classroom.Name;
                    }
                }
            */
            }
             



        }




        protected void gvWhitelists_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Whitelist whitelist = new Whitelist();

            whitelist.delete(Convert.ToInt32(e.Keys[0].ToString()));


            gvWhitelists.EditIndex = -1;
            gvWhitelists.DataSource = whitelist.load();
            gvWhitelists.DataBind();


            btnInsert.Visible = true;


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Whitelist whitelist = new Whitelist();
            if (divWhitelist.Visible != true)
            {

                whitelist.add(txtReason.Text, Convert.ToDateTime(from.Text), Convert.ToDateTime(to.Text), 0, Convert.ToInt32(ddlWorkstation.SelectedValue));
                lblText.Text = "<br />Record inserted successfully<br />";

                divForm.Visible = false;
                txtReason.Text = "";
                from.Text = "";
                to.Text = "";
                
            }
            else
            {

                whitelist.edit(Convert.ToInt32(lbl.Text), txtReason.Text, Convert.ToDateTime(from.Text), Convert.ToDateTime(to.Text), 0, Convert.ToInt32(ddlWorkstation.SelectedValue));
                lblText.Text = "<br />Record modified successfully<br />";
                divForm.Visible = false;
                divWhitelist.Visible = false;
                lbl.Text = "";
                gvWhitelists.EditIndex = -1;
            }

            // Bind the GridView control to the courseInfo collection.
            gvWhitelists.DataSource = whitelist.load();
            gvWhitelists.DataBind();
            btnInsert.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divForm.Visible = false;
            txtReason.Text = "";
            from.Text = "";
            to.Text = "";
            //ddlDayOfTheWeek.SelectedIndex = 0;
        }
    }
}