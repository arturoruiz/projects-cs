using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EcoManagement
{
    public partial class ManageBuildings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (gvBuildings.Rows.Count == 0) {
                btnInsert.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.gvBuildings.ShowFooter = true;

        }

        protected void GridView1_OnRowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox n = this.gvBuildings.Controls[0].Controls[0].FindControl("txtBuildingName") as TextBox;
                

                Building b = new Building();
                b.add(n.Text);
                lblText.Text = "<br />Record inserted successfully<br />";
                gvBuildings.DataBind(); // rebind the dat
                this.gvBuildings.ShowFooter = false;
                btnInsert.Visible = true;
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox n = this.gvBuildings.FooterRow.FindControl("txtBuildingName") as TextBox;
                

                Building b = new Building();
                b.add(n.Text);
                lblText.Text = "<br />Record inserted successfully<br />";
                gvBuildings.DataBind(); // rebind the data
            }
        }
    }
}