using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolutionHash
{
    public class HashProject
    {
        public HashProject(HashSolution solution, string name, string projectFile)
        {
            Solution = solution;
            Name = name;
            ProjectFile = projectFile;
            ProjectDirectory = Path.Combine(Solution.SolutionDirectory, Path.GetDirectoryName(projectFile));

            foreach (var line in System.IO.File.ReadAllLines(Path.Combine(Solution.SolutionDirectory, projectFile)))
            {
                var ma = FileRe.Match(line);
                if (ma.Success)
                {
                    var hf = new HashFile(this, ma.Groups["FileName"].Value, ma.Groups["Type"].Value);
                    Files.Add(hf);
                }
            }
            var sb = new StringBuilder();
            foreach (var hf in Files.OrderBy(f => f.Name))
                sb.Append(hf.Hash);
            Hash = HashHelper.HashObject(sb.ToString());
        }

        public HashSolution Solution { get; }
        public string Name { get; }
        public string ProjectFile { get; }
        public string ProjectDirectory { get; }
        public List<HashFile> Files { get; } = new List<HashFile>();
        public string Hash { get; }

        readonly static Regex FileRe = new Regex(@"<(?<Type>(Compile)|(None)|(Content)) Include=""(?<FileName>.*)""");
    }
}
