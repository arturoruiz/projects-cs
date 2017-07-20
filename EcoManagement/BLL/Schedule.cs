using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace BLL
{
    partial class Schedule
    {
        private EcoManagementEntities ecomanagementContext;

        public void add(string reason, DateTime powerOn, DateTime powerDown,string dayOfTheWeek, int classroomID)
        {
            ecomanagementContext = new EcoManagementEntities();            
            var schedule = CreateSchedule(0, powerOn, powerDown, dayOfTheWeek, reason, classroomID, true);

            ecomanagementContext.Schedules.AddObject(schedule);
            ecomanagementContext.SaveChanges();


        }
        public void edit(int id, string reason, DateTime powerOn, DateTime powerDown, string dayOfTheWeek, int classroomID)
        {
            ecomanagementContext = new EcoManagementEntities();
            Schedule schedule = new Schedule();

            schedule.ID = id;
            schedule.Reason = reason;
            schedule.PowerOn = powerOn;
            schedule.PowerDown = powerDown;
            schedule.DayOfTheWeek = dayOfTheWeek;
            schedule.IsActive = true;
            schedule.ClassroomID = classroomID;
            

            ecomanagementContext.Schedules.AddObject(schedule);
            ecomanagementContext.ObjectStateManager.ChangeObjectState(schedule, System.Data.EntityState.Modified);
            ecomanagementContext.SaveChanges();


        }
        public void delete(int id)
        {
            ecomanagementContext = new EcoManagementEntities();
            Schedule schedule = (from s in ecomanagementContext.Schedules
                                       where s.ID == id
                                       select s).First();

            schedule.IsActive = false;
            ecomanagementContext.SaveChanges();


        }
        public ObjectQuery load(int classroomID)
        {
            ecomanagementContext = new EcoManagementEntities();

            var schedules = (ObjectQuery)from s in ecomanagementContext.Schedules
                                         where s.Classroom.ID == classroomID && s.IsActive == true
                                         select new
                                         {
                                             ID = s.ID,
                                             Reason = s.Reason,
                                             PowerOn = s.PowerOn,
                                             ClassroomID = s.ClassroomID,
                                             PowerDown = s.PowerDown,
                                             IsActive = s.IsActive,
                                             DayOFTheWeek = s.DayOfTheWeek
                                         };

            return schedules;


        }
    }
}
