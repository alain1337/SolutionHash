using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHash
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var sln = new HashSolution(@"C:\Users\abart\OneDrive\Source\Reporter\Server\Server.sln");
            sw.Stop();
            
            foreach (var project in sln.Projects)
            {
                Console.WriteLine($"{project.Name}");
                foreach (var file in project.Files)
                    Console.WriteLine($"\t{file.Name,-40} {file.Hash}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Solution hash: {sln.Hash}");
            Console.WriteLine($"({sw.Elapsed} elapsed, hashed {sln.Projects.SelectMany(p => p.Files).Count()} files)");
        }
    }
}
