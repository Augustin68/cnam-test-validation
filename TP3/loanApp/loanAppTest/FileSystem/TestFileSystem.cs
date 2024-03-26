using LoanApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppTest
{
    internal class TestFileSystem : IFileSystem
    {
        public Dictionary<string, string> fileSystem = new Dictionary<string, string>();
        public void WriteAllText(string path, string content)
        {
            fileSystem.Add(path, content);
        }

        public bool Exists(string path)
        {
            return fileSystem.ContainsKey(path);
        }
    }
}
