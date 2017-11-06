using System;
using System.IO;
using System.Xml.Linq;

namespace XPump
{
    internal class PipeResult : IPipeResult
    {
        public XDocument Document { get; set; }
        public Stream Stream { get; set; }
        public Exception Exception { get; set; }
        public bool Success { get; set; }
    }
}