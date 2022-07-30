using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkInterfaceTestProject.Helpers;

namespace NetworkInterfaceTestProject.StepExtensions
{
    public class NetworkInterfaceExtension
    {
        private readonly NetworkInterfaceHelper _networkInterfaceHelper;
        private readonly IPAdressHelper _adressHelper;
        private readonly PingHelper _pingHelper;
        public NetworkInterfaceExtension()
        {
            _networkInterfaceHelper = new NetworkInterfaceHelper();
            _adressHelper = new IPAdressHelper();
            _pingHelper = new PingHelper();
        }

        public bool NetworkInterfaceIsEnabled(string networkInterface)
        {
            return _networkInterfaceHelper.CheckNetworkInterfaceExist(networkInterface);
        }

        public void SetIPAddressOnNetworkInterface(string ipAddress, string maskAddress, string networkInterface)
        {
            _adressHelper.SetIPAddress(networkInterface, ipAddress, maskAddress);
        }


        public bool CheckIfIPAddressIsSet(string networkInterface, string ipAddress)
        {
            var networkInterfaces = _networkInterfaceHelper.GetDataOfNetworkInterface(networkInterface);
            return _networkInterfaceHelper.CheckIPAdressExist(networkInterfaces, ipAddress);
        }

        public string GetIpAddress(string networkInterface)
        {
            var networkInterfaces = _networkInterfaceHelper.GetDataOfNetworkInterface(networkInterface);
            var networkInterfaceAddresses = _networkInterfaceHelper.CheckIPv46Address(networkInterfaces);
            return _networkInterfaceHelper.GetIPAddress(networkInterfaceAddresses);
        }

        public bool StartPingProccess(string ipAddress, string source)
        {
            _pingHelper.PingFromNetworkInterface(source, ipAddress);
            return _pingHelper.CheckIfPingCmdRun(source, ipAddress);
        }

        public bool CheckPingSuccess()
        {
            int result = _pingHelper.CheckIfPingSuccess();
            return result == 0;
        }
        
    }
}
