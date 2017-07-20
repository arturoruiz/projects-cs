using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    partial class Building
    {

        private EcoManagementEntities ecomanagementContext;

        public void add(string name)
        {
            ecomanagementContext = new EcoManagementEntities();
            var b = CreateBuilding(0, name, true);

            ecomanagementContext.Buildings.AddObject(b);
            ecomanagementContext.SaveChanges();


        }
    }
}
