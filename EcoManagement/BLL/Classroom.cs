using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace BLL
{
   partial class Classroom
    {

       private EcoManagementEntities ecomanagementContext;

       public void add(string name, int buildingID)
       {
           ecomanagementContext = new EcoManagementEntities();
           var c = CreateClassroom(0,name,buildingID, true);

           ecomanagementContext.Classrooms.AddObject(c);
           ecomanagementContext.SaveChanges();


       }
       public void edit(int id, string name, int buildingID)
       {
           ecomanagementContext = new EcoManagementEntities();
           Classroom classroom = new Classroom();
           
          
           classroom.Name = name;
           classroom.BuildingID = buildingID;
           classroom.ID = id;
           classroom.IsActive = true;

           ecomanagementContext.Classrooms.AddObject(classroom);
           ecomanagementContext.ObjectStateManager.ChangeObjectState(classroom, System.Data.EntityState.Modified);
           ecomanagementContext.SaveChanges();


       }
       public ObjectQuery load(int buildingID)
       {
           ecomanagementContext = new EcoManagementEntities();
           //Classroom classroom = new Classroom();


           var classrooms = (ObjectQuery)from c in ecomanagementContext.Classrooms
                            where c.Building.ID == buildingID
                            select new
                            {
                                ID = c.ID,
                                Name = c.Name,
                                BuildingID = c.BuildingID,
                                IsActive = c.IsActive
                            };

           return classrooms;


       }
   }
}
