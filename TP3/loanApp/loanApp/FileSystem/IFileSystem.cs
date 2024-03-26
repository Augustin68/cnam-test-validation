
namespace LoanApp
{
    public interface IFileSystem
    {
        void WriteAllText(string path, string content);
        bool Exists(string path);
    }
}
