using System;
using System.IO;
using System.Collections.Generic;

namespace XPump
{
	public interface IXmlPipeline
	{
		IXmlPipelineMediator Source(IEnumerable<string> files);
		IXmlPipelineMediator Source(IEnumerable<FileInfo> files);
	}

	public interface IXmlPipelineMediator
	{
		IXmlPipelineMediator Pipe(IXmlTransform transform);

		IXmlPipelineActuator Destination(string directory);
		IXmlPipelineActuator Destination(DirectoryInfo directory);

		IXmlPipelineActuator Destination(string directory, Func<FileInfo, string> fileNameTransform);
		IXmlPipelineActuator Destination(DirectoryInfo directory, Func<FileInfo, string> fileNameTransform);
	}

	public interface IXmlPipelineActuator
	{
		void Pump();
	}

	public interface IXmlTransform
	{
		// todo: define necessary items
	}
}
