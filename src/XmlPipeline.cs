using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace XPump
{
	public class XmlPipeline: IXmlPipeline
	{
		public IXmlPipelineMediator Source(IEnumerable<string> files)
		{
			return Source(files.Select(path => new FileInfo(path)));
		}

		public IXmlPipelineMediator Source(IEnumerable<FileInfo> files)
		{
			return new XmlPipelineMediator(files);
		}
	}
}
