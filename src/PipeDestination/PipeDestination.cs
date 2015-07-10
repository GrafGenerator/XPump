using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPump.PipeDestination
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
