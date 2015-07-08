using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace XPump
{
	public class XmlPipelineMediator: IXmlPipelineMediator
	{
		private readonly IEnumerable<FileInfo> _files;

		public XmlPipelineMediator(IEnumerable<FileInfo> files)
		{
			_files = files;
		}



		public IXmlPipelineMediator Pipe(IXmlTransform transform)
		{
			throw new NotImplementedException();
		}

		public IXmlPipelineActuator Destination(string directory)
		{
			return Destination(directory, null);
		}

		public IXmlPipelineActuator Destination(DirectoryInfo directory)
		{
			return Destination(directory, null);
		}

		public IXmlPipelineActuator Destination(string directory, Func<FileInfo, string> fileNameTransform)
		{
			throw new NotImplementedException();
		}

		public IXmlPipelineActuator Destination(DirectoryInfo directory, Func<FileInfo, string> fileNameTransform)
		{
			throw new NotImplementedException();
		}
	}
}
