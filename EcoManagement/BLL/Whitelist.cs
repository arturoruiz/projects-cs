using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
namespace BLL
{
    partial class Whitelist
    {

        private EcoManagementEntities ecomanagementContext;

        public void add(string reason, DateTime start, DateTime end, int createdBy, int workstationID)
        {
           ecomanagementContext = new EcoManagementEntities();
           var whitelist = CreateWhitelist(0, start, end, reason, createdBy, true);

           ecomanagementContext.Whitelists.AddObject(whitelist);
           ecomanagementContext.SaveChanges();

           Workstation workstation = new Workstation();
           workstation.addWhitelist(whitelist.ID, workstationID);

           

        }
        public void edit(int id, string reason, DateTime start, DateTime end, int createdBy, int workstationID)
        {
            ecomanagementContext = new EcoManagementEntities();
            Whitelist whitelist = new Whitelist();

            whitelist.ID = id;
            whitelist.Reason = reason;
            whitelist.Start = start;
            whitelist.End = end;
            whitelist.CreatedBy = createdBy;
            whitelist.IsActive = true;

            ecomanagementContext.Whitelists.AddObject(whitelist);
            ecomanagementContext.ObjectStateManager.ChangeObjectState(whitelist, System.Data.EntityState.Modified);
            ecomanagementContext.SaveChanges();
            
            Workstation workstation = new Workstation();
            workstation.editWhitelist(whitelist.ID, workstationID);

        }
        public void delete(int id)
        {
            ecomanagementContext = new EcoManagementEntities();
            Whitelist whitelist = (from w in ecomanagementContext.Whitelists
                                 where w.ID == id
                                 select w).First();

            whitelist.IsActive = false;
            ecomanagementContext.SaveChanges();


        }
        public ObjectQuery load()
        {
            ecomanagementContext = new EcoManagementEntities();

            var whitelists = (ObjectQuery)from w in ecomanagementContext.Whitelists
                                         where w.IsActive == true
                                         select new
                                         {
                                             ID = w.ID,
                                             Start = w.Start,
                                             End = w.End,
                                             Reason = w.Reason,
                                             CreatedBy = w.CreatedBy,
                                             IsActive = w.IsActive
                                         };

            return whitelists;


        }
    }
}
