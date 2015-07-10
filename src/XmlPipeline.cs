using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace XPump
{
	public class XmlPipeline: IXmlPipeline
	{
		public IXmlPipelineMediator Source(IEnumerable<IPipeSource> sources)
		{
			var pack = new XmlPipelinePack(sources);

			return new XmlPipelineMediator(pack);
		}
	}
}
