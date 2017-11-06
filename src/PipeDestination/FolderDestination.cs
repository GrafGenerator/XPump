using System.IO;

namespace XPump
{
    internal sealed class FolderDestination : StreamBasedDestination
    {
        private readonly FileMode _fileMode;
        private readonly DirectoryInfo _info;

        public FolderDestination(DirectoryInfo info, FileMode fileMode)
        {
            _info = info;
            _fileMode = fileMode;
            ShouldCloseStream = true;
        }

        protected override Stream GetDestinationStream(string name)
        {
            return new FileStream(Path.Combine(_info.FullName, name), _fileMode, FileAccess.Write);
        }

        protected override void OnPostSave(Stream stream)
        {
        }
    }
}