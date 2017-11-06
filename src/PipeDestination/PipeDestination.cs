using System.IO;

namespace XPump
{
    public static class PipeDestination
    {
        public static IPipeDestination Folder(string path)
        {
            return Folder(new DirectoryInfo(path));
        }

        public static IPipeDestination Folder(DirectoryInfo info)
        {
            return new FolderDestination(info, FileMode.Create);
        }
    }
}