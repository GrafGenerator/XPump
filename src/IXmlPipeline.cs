using System;
using System.IO;

namespace XPump
{
	public interface IXmlPipeline
	{
		IXmlPipelineMediator Source(string[] files);
		IXmlPipelineMediator Source(FileInfo[] files);
	}

	public interface IXmlPipelineMediator
	{
		IXmlPipelineMediator Pipe(IXmlTranform transform);

		IxmlPipelineActuator Destination(string directory);
		IxmlPipelineActuator Destination(DirectoryInfo directory);

		IxmlPipelineActuator Destination(string directory, Func<FileInfo, string> fileNameTransform);
		IxmlPipelineActuator Destination(DirectoryInfo directory, Func<FileInfo, string> fileNameTransform);
	}

	public interface IXmlPipelineActuator
	{
		void Pump();
	}
}
