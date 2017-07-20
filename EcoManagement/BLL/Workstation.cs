using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace BLL
{
    partial class Workstation
    {
        private EcoManagementEntities ecomanagementContext;

        public void add(string name, string MACAddress,int classroomID, int admin, int OSID)
        {
            ecomanagementContext = new EcoManagementEntities();
            var workstation = CreateWorkstation(0, name,MACAddress, classroomID, admin, true, OSID);

            ecomanagementContext.Workstations.AddObject(workstation);
            ecomanagementContext.SaveChanges();


        }
        public void edit(int id, string name, string MACAddress, int classroomID, int admin, int OSID)
        {
            ecomanagementContext = new EcoManagementEntities();
            Workstation workstation = new Workstation();


            workstation.ID = id;
            workstation.Name = name;
            workstation.MAC_Address = MACAddress;
            workstation.ClassroomID = classroomID;
            workstation.Admin = 0;
            workstation.IsActive = true;
            workstation.WhitelistID = null;
            workstation.OSID = OSID;

            ecomanagementContext.Workstations.AddObject(workstation);
            ecomanagementContext.ObjectStateManager.ChangeObjectState(workstation, System.Data.EntityState.Modified);
            ecomanagementContext.SaveChanges();


        }
        public void delete(int id)
        {
            ecomanagementContext = new EcoManagementEntities();
            Workstation workstation = (from w in ecomanagementContext.Workstations
                                        where w.ID == id
                                        select w).First();

            workstation.IsActive = false;            
            ecomanagementContext.SaveChanges();


        }
        public ObjectQuery load(int classroomID)
        {
            ecomanagementContext = new EcoManagementEntities();
            
            var workstations = (ObjectQuery)from w in ecomanagementContext.Workstations
                                          where w.Classroom.ID == classroomID
                                          where w.IsActive == true
                                          select new
                                          {
                                              ID = w.ID,
                                              Name = w.Name,
                                              MAC_Address = w.MAC_Address,
                                              ClassroomID = w.ClassroomID,
                                              Admin = w.Admin,                                             
                                              IsActive = w.IsActive,
                                              OSID = w.OSID
                                          };

            return workstations;


        }
        public void addWhitelist(int whitelistID, int workstationID)
        {
            ecomanagementContext = new EcoManagementEntities();
            Workstation workstation = (from w in ecomanagementContext.Workstations
                                       where w.ID == workstationID
                                       select w).First();

            workstation.WhitelistID = whitelistID;
            ecomanagementContext.SaveChanges();


        }
        public void editWhitelist(int whitelistID, int workstationID)
        {
            ecomanagementContext = new EcoManagementEntities();
            Workstation workstationOld = (from w in ecomanagementContext.Workstations
                                       where w.WhitelistID == whitelistID
                                       select w).First();

            workstationOld.WhitelistID = null;

            Workstation workstationNew = (from w in ecomanagementContext.Workstations
                                          where w.ID == workstationID
                                       select w).First();
            workstationNew.WhitelistID = whitelistID;
            ecomanagementContext.SaveChanges();


        }
    }
}
