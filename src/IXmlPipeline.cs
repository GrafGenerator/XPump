using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

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

		IXmlPipelineActuator Destination(IPipeDestination destination);
		IXmlPipelineActuator Destination(IPipeDestination destination, Func<FileInfo, string> documentNameTransform);
	}

	public interface IXmlPipelineActuator
	{
		void Pump();
	}

	public interface IXmlTransform
	{
		// todo: define necessary items
	}

	public interface IPipeDestination { }

	public interface IPipeStreamDestination: IPipeDestination
	{
		void Save(Stream source, string name);
	}

	public interface IPipeCustomDestination : IPipeDestination
	{
		void Save(XDocument source, string name);
	}
}
