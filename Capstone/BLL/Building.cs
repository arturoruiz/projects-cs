using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace BLL
{
    partial class Building
    {

        private CapstoneEntities capstoneContext;

        public void add(string name)
        {
            capstoneContext = new CapstoneEntities();
            var b = CreateBuilding(0, name, true);

            capstoneContext.Buildings.AddObject(b);
            capstoneContext.SaveChanges();

            
        }
    }
}