using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetworkInterfaceTestProject.Helpers
{
    public class IPAdressHelper
    {
        public void SetIPAddress(string networkInterface,string ipAdress, string maskAddress)
        {
            var adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var networkCollection = adapterConfig.GetInstances();

            foreach (ManagementObject item in networkCollection)
            {

                if (item["Description"].ToString().Contains(networkInterface))
                {
                    try
                    {
                        ManagementBaseObject newAddress = item.GetMethodParameters("EnableStatic");
                        newAddress["IPAddress"] = new string[] { ipAdress };
                        newAddress["SubnetMask"] = new string[] { maskAddress };

                        var cal1 = item.InvokeMethod("EnableStatic", newAddress, null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }

            }
        }
    }
}
