using System;
using System.Xml.Linq;
using System.IO;

namespace XPump
{
	internal struct PipeResult: IPipeResult
	{
		public XDocument Document { get; set; }
		public Stream Stream { get; set; }
		public Exception Exception { get; set; }
		public bool Success { get; set; }
	}
}
