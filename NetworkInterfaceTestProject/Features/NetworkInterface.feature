Feature: NetworkInterface
As user I can:
- set new IPv4 address to network interface,

@SetIPv4Address
Scenario: Setting new IP address to network interface
	Given <NetworkInterfaceName> is enabled
	When <IPv4Address> is set with <Mask> on <NetworkInterfaceName>
	And The ping command is sent to <NetworkInterfaceName> with <IPAddress>
	Then The ping command replies successfully
Examples: 
| NetworkInterfaceName | Mask          | IPv4Address  | IPAddress   |
| Ethernet             | 255.255.255.0 | 192.168.0.15 | 192.168.0.7 |

