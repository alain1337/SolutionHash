using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHash
{
    public class HashFile
    {
        public HashFile(HashProject project, string name)
        {
            Project = project;
            Name = name;
            Hash = HashHelper.HashFile(Path.Combine(project.ProjectDirectory, Name));
        }

        public HashProject Project { get; }
        public string Name { get; }
        public string Hash { get; }
    }
}
