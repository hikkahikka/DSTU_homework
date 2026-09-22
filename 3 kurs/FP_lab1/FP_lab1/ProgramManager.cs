using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab1
{
    public class ProgramManager
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Input 1 to IPv4Address\nInput 2 to IPv4CIDR\nInput 0 to exit");
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "0":
                        return;
                    case "1":
                        IPv4AddressTest();
                        break;
                    case "2":
                        IPv4CidrTest();
                        break;
                    default:
                        Console.WriteLine("Incorrect choice!");
                        break;
                }
            }
        }
        private void IPv4AddressTest()
        {
            Console.Write("Input IP address (example, 192.168.1.15): ");
            string input = Console.ReadLine();

            try
            {
                IPv4Address ip = IPv4Address.Parse(input);
                Console.WriteLine($"Address: {ip}");
                Console.WriteLine($"Raw uint: {ip.Raw}");
                Console.Write("Bytes:");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"[{i}] = {ip[i]} ");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void IPv4CidrTest()
        {
            Console.Write("Input CIDR (example, 192.168.1.50/24): ");
            string input = Console.ReadLine();

            try
            {
                IPv4Cidr cidr = IPv4Cidr.Parse(input);
                Console.WriteLine($"CIDR: {cidr}");
                Console.WriteLine($"Network: {cidr.Network}");
                Console.WriteLine($"Mask: {cidr.Mask}");
                Console.WriteLine($"Broadcast: {cidr.Broadcast}");
                Console.WriteLine($"HostCount: {cidr.HostCount}");
                Console.Write("Input IP address to check contains: ");
                string testIpStr = Console.ReadLine();
                IPv4Address testIp = IPv4Address.Parse(testIpStr);
                bool contains = cidr.Contains(testIp);
                if (contains)
                {
                    Console.WriteLine($"-> IP {testIp} IS PART of network {cidr}");
                }
                else
                {
                    Console.WriteLine($"-> IP {testIp} IS NOT PART of network {cidr}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
