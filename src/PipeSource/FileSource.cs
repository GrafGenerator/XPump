using System.IO;
using System.Xml.Linq;

namespace XPump
{
    internal sealed class FileSource : IPipeSource
    {
        private readonly FileInfo _info;

        public FileSource(FileInfo info)
        {
            _info = info;
        }

        public XDocument GetDocument()
        {
            return XDocument.Load(_info.FullName);
        }

        public string Name => Path.GetFileNameWithoutExtension(_info.FullName);
    }
}