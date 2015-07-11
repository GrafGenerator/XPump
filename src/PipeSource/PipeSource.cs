using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XPump
{
	public static class PipeSource
	{
		public static IEnumerable<IPipeSource> Files(IEnumerable<string> files)
		{
			return files.Select(file => new FileSource(new FileInfo(file)));
		}

		public static IEnumerable<IPipeSource> Files(IEnumerable<FileInfo> files)
		{
			return files.Select(file => new FileSource(file));
		}
	}
}
