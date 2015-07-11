using System;
using System.Collections.Generic;
using System.Linq;
using XPump.Engine;

namespace XPump
{
	public class XmlPipelineActuator: IXmlPipelineActuator
	{
		private readonly XmlPipelinePack _pack;

		internal XmlPipelineActuator(XmlPipelinePack pack)
		{
			_pack = pack;
		}

		public IEnumerable<IPipeResult> Pump(bool lazy = true)
		{
			return lazy ? PumpLazy() : PumpAll();
		}

		private IEnumerable<IPipeResult> PumpLazy()
		{
			var engine = new TransformEngine(_pack);

			return _pack.Sources.Select(source => engine.Transform(source));
		}

		private IEnumerable<IPipeResult> PumpAll()
		{
			var engine = new TransformEngine(_pack);

			return _pack.Sources.Select(source => engine.Transform(source)).ToList();
		}
	}
}
