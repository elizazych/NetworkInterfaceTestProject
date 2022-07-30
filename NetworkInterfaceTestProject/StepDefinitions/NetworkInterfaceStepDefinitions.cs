using System;
using NetworkInterfaceTestProject.StepExtensions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NetworkInterfaceTestProject.StepDefinitions
{
    [Binding]
    public class NetworkInterfaceStepDefinitions
    {
        private NetworkInterfaceExtension _networkInterfaceExtension;

        public NetworkInterfaceStepDefinitions(NetworkInterfaceExtension networkInterfaceExtension)
        {
            _networkInterfaceExtension = networkInterfaceExtension;
        }

        [Given(@"(.*) is enabled")]
        public void GivenNetworkInterfaceNameIsEnabled(string networkInterface)
        {
            Assert.IsTrue(_networkInterfaceExtension.NetworkInterfaceIsEnabled(networkInterface));
        }

        [When(@"(.*) is set with (.*) on (.*)")]
        public void WhenIPvAddressIsSetWithMaskOnNetworkInterfaceName(string ipAddress, string maskAddress, string networkInterface)
        {
            _networkInterfaceExtension.SetIPAddressOnNetworkInterface(ipAddress, maskAddress, networkInterface);
            Assert.IsTrue(_networkInterfaceExtension.CheckIfIPAddressIsSet(networkInterface, ipAddress));
        }

        [When(@"The ping command is sent to (.*) with (.*)")]
        public void WhenThePingCommandIsSentToNetworkInterfaceNameToIPAddress(string networkInterface, string ipAddress)
        {
           string source = _networkInterfaceExtension.GetIpAddress(networkInterface);
           Assert.IsTrue(_networkInterfaceExtension.StartPingProccess(ipAddress, source));
        }

        [Then(@"The ping command replies successfully")]
        public void ThenThePingCommandRepliesSuccessfully()
        {
            Assert.IsTrue(_networkInterfaceExtension.CheckPingSuccess());
        }
    }
}
