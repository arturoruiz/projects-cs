using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;

namespace EcoManagementServiceTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EcoManagement eco = new EcoManagement();
           //// eco.getWorkStationsToPowerOFF();
            //eco.powerOFFWindowsMachine();
           // eco.powerONWorstation();

          // MessageBox.Show(eco.str);

            //EcoManagementService eco = new EcoManagementService();
            EcoManagement ecomgmt = new EcoManagement();

            ObjectResult<GetWorkstationsToBePoweredOFF_Result> listToPowerOFF;// = new ObjectResult<GetWorkstationsToBePoweredOFF_Result>();
            ObjectResult<GetWorkstationsToBePoweredON_Result> listToPowerON;// = new ObjectResult<GetWorkstationsToBePoweredON_Result>();
            
            listToPowerOFF = ecomgmt.getWorkStationsToPowerOFF();
            listToPowerON = ecomgmt.getWorkStationsToPowerON();

            
            
                //eco.EcoLog.WriteEntry(string.Format("The EcoManagement Service woke up at {0}", e.SignalTime));

                //Clean the whitelist table once per day
                /*if (DateTime.Now.Hour == 03)
                {
                    ecomgmt.cleanWhiteList();
                    eco.EcoLog.WriteEntry(string.Format("Cleaned the Whitelist at {0}", DateTime.Now));
                }
            */

                //Call the power on method
                foreach (GetWorkstationsToBePoweredON_Result w in listToPowerON)
                {

                    //Pass the workstation object to the the power on method
                    ecomgmt.powerONMachine(w);
                    //Write an entry on the Event Log with the workstation's details
                    //eco.EcoLog.WriteEntry(string.Format("Sent WOL signal to the {0} Workstation: {1} MAC: {2}", w.OSName, w.Name, w.MAC_Address));


                }

                //Call the propper power off method dependending on the Workstation's OS
                foreach (GetWorkstationsToBePoweredOFF_Result w in listToPowerOFF)
                {
                    if (w.OSName == "Windows")
                    {
                        //Pass the workstation object to the the poweroff method
                        ecomgmt.powerOFFWindowsMachine(w);
                        //Write an entry on the Event Log with the workstation's details
                      //  eco.EcoLog.WriteEntry(string.Format("Sent shutdown signal to the {0} Workstation: {1} MAC: {2}", w.OSName, w.Name, w.MAC_Address));
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
           //timer.Interval = ecomgmt.intervalCalc();
            

            //eco.EcoLog.WriteEntry(string.Format("New interval {0}", timer.Interval.ToString()));
            
        }

        }
    

