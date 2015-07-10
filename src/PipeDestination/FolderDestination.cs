using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPump.PipeDestination
{
	internal sealed class FolderDestination: StreamBasedDestination
	{
		private readonly DirectoryInfo _info;
		private readonly FileMode _fileMode;

		public FolderDestination(DirectoryInfo info, FileMode fileMode)
		{
			_info = info;
			_fileMode = fileMode;
			_shouldCloseStream = true;
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
