using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XPump.Transforms
{
	public sealed class XsdValidateTransform: IXmlTransform
	{
		private readonly string[] _xsdFilePaths;

		public XsdValidateTransform(params string[] xsdFilePaths)
		{
			_xsdFilePaths = xsdFilePaths;
		}

		public XDocument Process(XDocument source)
		{
			var schemas = new XmlSchemaSet();

			foreach (var xsdFile in _xsdFilePaths)
				schemas.Add("", XmlReader.Create(xsdFile));

			var hasErrors = false;
			source.Validate(schemas, (o, e) => hasErrors = true);

			return hasErrors ? null : source;
		}
	}
}
