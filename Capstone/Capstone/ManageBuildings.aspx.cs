using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Capstone
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                //var capstoneContext = new BLL.CapstoneEntities();

                //Bind the grid view to the collection of Course objects
                // that are related to the selected Department object.
                //this.gvBuildings.DataSource = capstoneContext.Buildings;
                //this.gvBuildings.DataBind();

                // Hide the columns that are bound to the navigation properties on Course.
                //gvBuildings.Columns["ID"].Visible = false;
                //.Columns["IsActive"].Visible = false;
                

                //this.gvBuildings.AllowUserToDeleteRows = false;
                //this.gvBuildings.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}