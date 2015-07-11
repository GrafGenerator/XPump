using System;
using System.Xml.Linq;
using XPump;

namespace Tests.Helpers
{
	internal sealed class DummyXmlDestination: IPipeCustomDestination
	{
		private readonly Action<string> _action;

		public DummyXmlDestination(Action<string> action = null)
		{
			_action = action;
		}

		public void Save(XDocument source, string name)
		{
			if (_action != null) _action(name);
		}
	}
}
