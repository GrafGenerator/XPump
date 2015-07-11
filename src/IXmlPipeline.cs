using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace XPump
{
	public interface IXmlPipeline
	{
		IXmlPipelineMediator Source(IEnumerable<IPipeSource> sources);
	}

	public interface IXmlPipelineMediator
	{
		IXmlPipelineMediator Pipe(IXmlTransform transform);

		IXmlPipelineActuator Destination(IPipeDestination destination);
		IXmlPipelineActuator Destination(IPipeDestination destination, Func<string, string> documentNameTransform);
	}

	public interface IXmlPipelineActuator
	{
		IEnumerable<IPipeResult> Pump(bool lazy = true);
	}

	public interface IXmlTransform
	{
		XDocument Process(XDocument source);
	}


	public interface IPipeSource
	{
		string Name { get; }
		XDocument GetDocument();
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



	public interface IPipeResult
	{
		XDocument Document { get; }
		Stream Stream { get; }
		Exception Exception { get; }
		bool Success { get; }
	}
}
