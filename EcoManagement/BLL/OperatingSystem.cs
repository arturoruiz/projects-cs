using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace BLL
{
    partial class OperatingSystem
    {
        private EcoManagementEntities ecomanagementContext;
        
        public ObjectSet<OperatingSystem> load()
        {
            ecomanagementContext = new EcoManagementEntities();

            var operatingSystems = ecomanagementContext.OperatingSystems;

           /* var operatingSystems = (OperatingSystem) from os in ecomanagementContext.OperatingSystems
                                              select new
                                            {
                                                ID = os.ID,
                                                OSName = os.OSName,
                                                IsActive = os.IsActive
                                            };*/

            return operatingSystems;


        }
    
    }
}
