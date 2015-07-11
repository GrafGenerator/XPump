using System;
using System.Xml.Linq;
using XPump;

namespace Tests.Helpers
{
	internal sealed class DummyXmlTransform: IXmlTransform
	{
		private readonly Action _action;

		public DummyXmlTransform(Action action = null)
		{
			_action = action;
		}

		public XDocument Process(XDocument source)
		{
			if (_action != null) _action();
			return source;
		}
	}
}
