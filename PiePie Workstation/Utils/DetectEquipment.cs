using System.Management;
using System.Collections.Generic;

namespace PiePie_Workstation.Utils
{
    public static class DetectEquipment
    {
        public static List<string> GetCPUNames()
        {
            List<string> CPUNames = new List<string>();
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                CPUNames.Add(mo["Name"].ToString().TrimEnd());
            }
            mos.Dispose();
            return CPUNames;
        }

        public static List<string> GetGPUNames()
        {
            List<string> GPUNames = new List<string>();
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_VideoController");
            foreach (ManagementObject mo in mos.Get())
            {
                GPUNames.Add(mo["Name"].ToString().TrimEnd());
            }
            mos.Dispose();
            return GPUNames;
        }
    }
}
