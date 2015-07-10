using System;

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
			throw new NotImplementedException();
		}
	}
}
