using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Management;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Timers;
using System.Net.Sockets;


namespace EcoManagementService
{
    class EcoManagement
    {
        
        public double intervalCalc()
        {
           
            Timer timer = new Timer();
                                     
                int minutes = DateTime.Now.Minute;
                int adjust = 55 - (DateTime.Now.Minute % 60);
                if (adjust <= 0) { adjust += 60; } 
                timer.Interval = adjust * 60 * 1000;
               
            return timer.Interval;
        }



        public ObjectResult<GetWorkstationsToBePoweredOFF_Result> getWorkStationsToPowerOFF()
        {


            EcoManagementEntities eco = new EcoManagementEntities();
            ObjectResult<GetWorkstationsToBePoweredOFF_Result> workstationList;

            workstationList = eco.GetWorkstationsToBePoweredOFF();

            return workstationList;


        }
        public ObjectResult<GetWorkstationsToBePoweredON_Result> getWorkStationsToPowerON()
        {


            EcoManagementEntities eco = new EcoManagementEntities();
            ObjectResult<GetWorkstationsToBePoweredON_Result> workstationList;

            workstationList = eco.GetWorkstationsToBePoweredON();

            return workstationList;


        }

        public void powerONMachine(GetWorkstationsToBePoweredON_Result workstation){

            //Construct the packet
            Byte[] datagram = new byte[102];

            //Trailer of 6 FF packets
            for (int i = 0; i <= 5; i++)
            {
                datagram[i] = 0xff;
            }

            //Prepare the MacAddress entry for convertion
            string[] macDigits = null;
            if (workstation.MAC_Address.Contains("-"))
            {
                macDigits = workstation.MAC_Address.Split('-');
            }
            else
            {
                macDigits = workstation.MAC_Address.Split(':');
            }

            /*if (macDigits.Length != 6)
            {
                throw new ArgumentException("Incorrect MAC address supplied!");
            }*/

            //Repeat 16 time the MAC address (which is 6 bytes) 
            int start = 6;
            for (int i = 0; i < 16; i++)
            {
                for (int x = 0; x < 6; x++)
                {
                    datagram[start + i * 6 + x] = (byte)Convert.ToInt32(macDigits[x], 16);
                }
            }          

            // Now we have the packet data, so we just need to send it inside UDP packet. For this purpose the UdpClient class from System.Net.Sockets will come handy:
            //Send the packet to broadcast address 
            UdpClient client = new UdpClient();
            client.Connect(System.Net.IPAddress.Broadcast, 7); //Any UDP port will work, but 7 is my lucky number ... 
            client.Send(datagram, datagram.Length);
        
        }
        
        public void powerOFFWindowsMachine(GetWorkstationsToBePoweredOFF_Result workstation) {
        

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "shutdown.exe";
            proc.StartInfo.Arguments = @"-s -t 600 -m " + workstation.Name;
            proc.Start();
            


            /*  try
              {
                  const string computerName = "pc"; // computer name or IP address

                  ConnectionOptions options = new ConnectionOptions();
                  options.EnablePrivileges = true;
                  // To connect to the remote computer using a different account, specify these values:
                  options.Username = "arturoruiz";
                  options.Password = "123456";
                  // options.Authority = "ntlmdomain:DOMAIN";

                  ManagementScope scope = new ManagementScope(
                    "\\\\" + computerName + "\\root\\CIMV2", options);
                  scope.Connect();

                  SelectQuery query = new SelectQuery("Win32_OperatingSystem");
                  ManagementObjectSearcher searcher =
                      new ManagementObjectSearcher(scope, query);

                  foreach (ManagementObject os in searcher.Get())
                  {
                      // Obtain in-parameters for the method
                      ManagementBaseObject inParams =
                          os.GetMethodParameters("Win32Shutdown");

                      // Add the input parameters.
                      inParams["Flags"] = 2;

                      // Execute the method and obtain the return values.
                      ManagementBaseObject outParams =
                          os.InvokeMethod("Win32Shutdown", inParams, null);
                  }
              }
              catch (ManagementException err)
              {
                 // MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
              }
              catch (System.UnauthorizedAccessException unauthorizedErr)
              {
                  //MessageBox.Show("Connection error (user name or password might be incorrect): " + unauthorizedErr.Message);
              }
              */

        }

        public void powerOFFUnixMachine(GetWorkstationsToBePoweredOFF_Result workstation) {

            /*var connectionInfo = new KeyboardInteractiveConnectionInfo("129.21.70.249", 22, "christianpichardo");

            connectionInfo.AuthenticationPrompt += delegate(object sender, AuthenticationPromptEventArgs e)
            {
                foreach (var prompt in e.Prompts)
                {
                    if (prompt.Request.Equals("Password:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        prompt.Response = "123456";
                    }
                }
            };

            var ssh = new SshClient(connectionInfo);
            
                ssh.Connect();
                var cmd = ssh.RunCommand("who");
                //return cmd.Result;
            */





            var connectionInfo = new KeyboardInteractiveConnectionInfo("129.21.70.249", 22, "root");
            //var sshClient = new SshClient("129.21.70.249", "christianpichardo", "123456"); //name, username, password

            connectionInfo.AuthenticationPrompt += delegate(object sender, AuthenticationPromptEventArgs e)
            {
                foreach (var prompt in e.Prompts)
                {
                    if (prompt.Request.Equals("Password:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        prompt.Response = "root";
                    }
                }
            };

            var sshClient = new SshClient(connectionInfo);
            sshClient.Connect();

            var cmd = sshClient.RunCommand("shutdown -h +1 'Shutting down soon!'");
            var output = cmd.Result;
            sshClient.Disconnect();




        }

        public void cleanWhiteList() {
            EcoManagementEntities eco = new EcoManagementEntities();
            eco.CleanWhitelist();
        
        }

    }
}

