using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolutionHash
{
    public class HashSolution
    {
        public HashSolution(string solutionFile)
        {
            SolutionFile = solutionFile;
            SolutionDirectory = Path.GetDirectoryName(SolutionFile);
            foreach (var line in System.IO.File.ReadAllLines(solutionFile))
            {
                var ma = ProjectRe.Match(line);
                if (ma.Success)
                {
                    var hashProject = new HashProject(this, ma.Groups["Name"].Value, ma.Groups["ProjectFile"].Value);
                    Projects.Add(hashProject);
                }
            }
            var sb = new StringBuilder();
            foreach (var project in Projects.OrderBy(p => p.ProjectFile))
                sb.Append(project.Hash);
            Hash = HashHelper.HashObject(sb.ToString());
        }

        public string SolutionFile { get; }
        public string SolutionDirectory { get; }
        public List<HashProject> Projects { get; } = new List<HashProject>();
        public string Hash { get; }

        readonly static Regex ProjectRe = new Regex(@"^Project\(""{(?<TypeGuid>.*)}""\) = ""(?<Name>.*)"", ""(?<ProjectFile>.*)"", ");
    }
}
