using System.IO;
using System.Linq;

namespace XPump
{
	public class XmlPipeline: IXmlPipeline
	{
		public IXmlPipelineMediator Source(string[] files)
		{
			return Source(files.Select(path => new FileInfo(path)));
		}

		public IXmlPipelineMediator Source(FileInfo[] files)
		{
			return new XmlPipelineMediator(files);
		}
	}
}
