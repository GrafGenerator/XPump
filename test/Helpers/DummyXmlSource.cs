using System.Xml.Linq;
using XPump;

namespace Tests.Helpers
{
	internal sealed class DummyXmlSource: IPipeSource
	{
		private readonly string _name;

		public DummyXmlSource(string name = "")
		{
			_name = name;
		}

		public string Name
		{
			get { return "dummy-source" + _name; }
		}

		public XDocument GetDocument()
		{
			var doc = new XDocument();
			var child1 = new XElement("child1", "content");
			var child2 = new XElement("child2", "content");
			var root = new XElement("rootElement");
			root.Add(child1, child2);

			doc.Add(root);

			return doc;
		}
	}
}
