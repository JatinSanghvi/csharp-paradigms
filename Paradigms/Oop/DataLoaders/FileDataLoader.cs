namespace Paradigms.Oop
{
    using System.IO;

    internal sealed class FileDataLoader : IDataLoader
    {
        private readonly string path;

        public FileDataLoader(string path)
        {
            this.path = path;
        }

        public string LoadData()
        {
            return File.ReadAllText(this.path);
        }
    }
}
