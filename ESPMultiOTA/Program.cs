using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Zeroconf;

namespace ESPMultiOTA
{
    internal class Program
    {


        class TestClass
        {

            static void Main(string[] args)
            {
                List<string> devices = new List<string>();

                var task = ZeroconfResolver.ResolveAsync("_arduino._tcp.local.", TimeSpan.FromSeconds(7));
                task.Wait();

                Console.WriteLine("Found:");

                foreach (var res in task.Result)
                {
                    Console.WriteLine("-" + res.IPAddress);
                    devices.Add(res.IPAddress);
                }

                Console.WriteLine("Flashing to " + devices.Count + " devices:");

                if (args.Length == 0)
                {
                    Console.WriteLine("No File to flash");
                    return;
                }
                else
                {
                    foreach (var ip in devices)
                    {
                        Flash(args[0], ip);
                    }
                }
            }

            static void Flash(string file, string ip)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Flashing to: " + ip);
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python3.exe";
                start.Arguments = string.Format("-I {0} -i \"{1}\" -f \"{2}\"", @"C:\Users\Joshua\AppData\Local\Arduino15\packages\esp8266\hardware\esp8266\3.0.2\tools\espota.py", ip, file);
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                    }
                }
            }
        }
    }
}
