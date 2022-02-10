using System.Diagnostics;

Console.WriteLine("Fix audiodg priorty and affinity");

Process[] processes = Process.GetProcessesByName("audiodg");

if (processes.Length == 0)
    Console.WriteLine("audiodg not found");
else
{
    long AffinityMask = 0x0002;

    foreach (Process process in processes)
    {
        if (process.PriorityClass == ProcessPriorityClass.High)
            Console.WriteLine("Priority already set to High");
        else
        {
            process.PriorityClass = ProcessPriorityClass.High;
            Console.WriteLine("Priority set to High");
        }


        if (process.ProcessorAffinity.ToInt64() != AffinityMask)
        {
            process.ProcessorAffinity = (IntPtr)AffinityMask;
            Console.WriteLine($"Affinity set to CPU {AffinityMask}");
        }
        else
            Console.WriteLine($"Affinity already set to CPU {AffinityMask}");
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();