using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Data.Objects;

namespace EcoManagementService
{
    public partial class EcoManagementService : ServiceBase
    {
        private static Timer timer;
        
        
        public EcoManagementService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("EcoSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "EcoSource", "EcoLog");
            }
            EcoLog.Source = "EcoSource";
            EcoLog.Log = "EcoLog";
        }

        protected override void OnStart(string[] args)
        {
            EcoManagement ecomgmt = new EcoManagement();
            EcoLog.WriteEntry("Service Started.");

           
           
            // Create a timer with a ten second interval.
            timer = new System.Timers.Timer(ecomgmt.intervalCalc());

            // Hook up the Elapsed event for the timer.
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //timer.Interval = 1000;


            timer.Enabled = true;
            GC.KeepAlive(timer);
        }

        protected override void OnStop()
        {
            EcoLog.WriteEntry("Service Stopped.");

        }

        protected override void OnContinue()
        {
            EcoLog.WriteEntry("Service Resumed.");
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            EcoManagementService eco = new EcoManagementService();
            EcoManagement ecomgmt = new EcoManagement();

            ObjectResult<GetWorkstationsToBePoweredOFF_Result> listToPowerOFF;// = new ObjectResult<GetWorkstationsToBePoweredOFF_Result>();
            ObjectResult<GetWorkstationsToBePoweredON_Result> listToPowerON;// = new ObjectResult<GetWorkstationsToBePoweredON_Result>();
            
            listToPowerOFF = ecomgmt.getWorkStationsToPowerOFF();
            listToPowerON = ecomgmt.getWorkStationsToPowerON();

            if (DateTime.Now.Minute == 55)
            {
                eco.EcoLog.WriteEntry(string.Format("The EcoManagement Service woke up at {0}", e.SignalTime));

                //Clean the whitelist table once per day
                if (DateTime.Now.Hour == 03)
                {
                    ecomgmt.cleanWhiteList();
                    eco.EcoLog.WriteEntry(string.Format("Cleaned the Whitelist at {0}", DateTime.Now));
                }


                //Call the power on method
                foreach (GetWorkstationsToBePoweredON_Result w in listToPowerON)
                {

                    //Pass the workstation object to the the power on method
                    ecomgmt.powerONMachine(w);
                    //Write an entry on the Event Log with the workstation's details
                    eco.EcoLog.WriteEntry(string.Format("Sent WOL signal to the {0} Workstation: {1} MAC: {2}", w.OSName, w.Name, w.MAC_Address));


                }

                //Call the propper power off method dependending on the Workstation's OS
                foreach (GetWorkstationsToBePoweredOFF_Result w in listToPowerOFF)
                {
                    if (w.OSName == "Windows")
                    {
                        //Pass the workstation object to the the poweroff method
                        ecomgmt.powerOFFWindowsMachine(w);
                        //Write an entry on the Event Log with the workstation's details
                        eco.EcoLog.WriteEntry(string.Format("Sent shutdown signal to the {0} Workstation: {1} MAC: {2}", w.OSName, w.Name, w.MAC_Address));
                    }

                    else
                    {
                        //Pass the workstation object to the the poweroff method
                        //Commented out until we discuss the "ROOT" user situation
                        //ecomgmt.powerOFFUnixMachine(w);
                        //Write an entry on the Event Log with the workstation's details
                        //eco.EcoLog.WriteEntry(string.Format("Sent shutdown signal to the {0} Workstation: {1} MAC: {2}", w.OSName, w.Name, w.MAC_Address));
                    }

                }
            }
           
           //Calculate the new timer interval
           timer.Interval = ecomgmt.intervalCalc();
            

            eco.EcoLog.WriteEntry(string.Format("New interval {0}", timer.Interval.ToString()));
            
        }
    }
}
