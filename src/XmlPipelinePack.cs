using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XPump
{
	internal sealed class XmlPipelinePack
	{
		private List<IXmlTransform> _transforms;
		private List<IPipeDestination> _destinations;

		public IEnumerable<FileInfo> Files;
		public IEnumerable<IXmlTransform> Transforms { get { return _transforms; } }
		public IEnumerable<IPipeDestination> Destinations { get { return _destinations; } }
		public Func<string, string> NameTransform;

		public XmlPipelinePack(IEnumerable<FileInfo> files)
		{
			Files = files;
			_transforms = new List<IXmlTransform>();
		}

		public void AppendTransform(IXmlTransform transform)
		{
			_transforms.Add(transform);
		}

		public void AppendDestination(IPipeDestination destination)
		{
			_destinations.Add(destination);
		}
	}
}
