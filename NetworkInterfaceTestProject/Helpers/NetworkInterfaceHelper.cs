using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkInterfaceTestProject.Helpers
{
    public class NetworkInterfaceHelper
    {
        private readonly NetworkInterface[] adapters;

        public NetworkInterfaceHelper()
        {
            adapters = NetworkInterface.GetAllNetworkInterfaces();
        }

        public bool CheckNetworkInterfaceExist(string networkInterface)
        {
            return adapters.Where(x => x.Name.Equals(networkInterface)).Any();
        }

        public IEnumerable<NetworkInterface> GetDataOfNetworkInterface(string networkInterface)
        {
            return adapters.Where(x => x.Name.Equals(networkInterface));
        }

        public IEnumerable<UnicastIPAddressInformation> CheckIPv46Address(IEnumerable<NetworkInterface> networkInterfaces, string ipAddressFamily = "InterNetwork")
        {
            return networkInterfaces.FirstOrDefault().GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily.ToString().Equals(ipAddressFamily));
        }

        public string GetIPAddress(IEnumerable<UnicastIPAddressInformation> unicastIPAddressInformation)
        {
            return unicastIPAddressInformation.FirstOrDefault().Address.ToString();
        }

        public bool CheckIPAdressExist(IEnumerable<NetworkInterface> networkInterfaces, string ipAddress)
        {
            return networkInterfaces.FirstOrDefault().GetIPProperties().UnicastAddresses.Where(x => x.Address.ToString().Contains(ipAddress)).Any();
        }
    }
}
