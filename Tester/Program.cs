using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int inc = int.Parse(Console.ReadLine());
            
            using (StreamWriter sw = new StreamWriter("data.txt"))
            {
                sw.AutoFlush = true;
                for (int i = start; i <= end; i += inc)
                {
                    var proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "alg.exe",
                            Arguments = $"-2 {i} 1",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                    proc.Start();
                    while (!proc.StandardOutput.EndOfStream)
                        sw.WriteLine(proc.StandardOutput.ReadLine());
                    Console.SetCursorPosition(0, 4);
                    Console.Write(i);
                    //inc += inc / 2;
                }
            } 
        }
    }
}
