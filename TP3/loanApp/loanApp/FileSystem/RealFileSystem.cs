using System.IO;

namespace LoanApp
{
    public class RealFileSystem : IFileSystem
    {
        public void WriteAllText(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
