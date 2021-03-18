using System;

namespace SW04_EnviromentKlasse {
    class Program {
        static void Main(string[] args) {
            SystemInformation sysinfo = new SystemInformation();
            Console.WriteLine("Current Directory".PadRight(25,'.')+": "+sysinfo.current_directory);
            Console.WriteLine("is 64 bit".PadRight(25, '.') + ": " + sysinfo.is64bit);
            Console.WriteLine("os version".PadRight(25, '.') + ": " + sysinfo.os_Version);
            Console.WriteLine("processor count".PadRight(25, '.') + ": " + sysinfo.Processor_count);
            Console.WriteLine("runtime min".PadRight(25, '.') + ": " + sysinfo.runtime_min);
            Console.WriteLine("clr version".PadRight(25, '.') + ": " + sysinfo.clr_version);
            Console.WriteLine("logical drives".PadRight(25, '.') + ": " + sysinfo.logical_drives);
            Console.WriteLine($"Value of enviroment variable {sysinfo.env_var}:\n {sysinfo.enviroment_var_value}");
        }
    }
}
