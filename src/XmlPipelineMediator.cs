using System;
using System.IO;

namespace XPump
{
	public class XmlPipelineMediator: IXmlPipelineMediator
	{
		public IXmlPipelineMediator Pipe(IXmlTranform transform)
		{
			throw new NotImplementedException();
		}

		public IxmlPipelineActuator Destination(string directory)
		{
			return Destination(directory, null);
		}

		public IxmlPipelineActuator Destination(DirectoryInfo directory)
		{
			return Destination(directory, null);
		}

		public IxmlPipelineActuator Destination(string directory, Func<FileInfo, string> fileNameTransform)
		{
			throw new NotImplementedException();
		}

		public IxmlPipelineActuator Destination(DirectoryInfo directory, Func<FileInfo, string> fileNameTransform)
		{
			throw new NotImplementedException();
		}
	}
}
