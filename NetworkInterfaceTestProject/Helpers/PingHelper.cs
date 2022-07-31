using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetworkInterfaceTestProject.Helpers
{
    public class PingHelper
    {
        private List<string> _outputList;
        public PingHelper()
        {
            _outputList = new List<string>();
        }
       
        public void PingFromNetworkInterface(string source, string ipAddress)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ping",
                    Arguments = $"{ipAddress} -S {source}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            Thread.Sleep(4000);

            process.Start();
            

            while (!process.StandardOutput.EndOfStream)
            {
                _outputList.Add(process.StandardOutput.ReadLine());
            };
        }

        public bool CheckIfPingCmdRun(string source, string ipAddress)
        {
            return _outputList.Where(x => x.Contains($"Pinging {ipAddress} from {source}")).Any();
        }

        public int CheckIfPingSuccess()
        {
            string line = string.Empty;
            foreach (var item in _outputList)
            {
                if(item.Contains("Destination host unreachable"))
                {
                    return -1;
                }
                if (item.Contains("Packets:"))
                {
                    line = item;
                }
            }

            Regex rg = new Regex(@"\b(Lost = )(\d)", RegexOptions.IgnoreCase);
            Match matches = rg.Match(line);
            return Convert.ToInt16(matches.Groups[2].Value);
        }

    }
}
