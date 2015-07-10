using System;
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

		public void Pump()
		{
			var engine = new TransformEngine(_pack);
			engine.Transform();
		}
	}
}
