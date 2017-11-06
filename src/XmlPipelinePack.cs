using System;
using System.Collections.Generic;

namespace XPump
{
    internal sealed class XmlPipelinePack
    {
        private readonly List<IPipeDestination> _destinations;
        private readonly List<IXmlTransform> _transforms;
        public Func<string, string> NameTransform;

        public IEnumerable<IPipeSource> Sources;

        public XmlPipelinePack(IEnumerable<IPipeSource> sources)
        {
            Sources = sources;
            _transforms = new List<IXmlTransform>();
            _destinations = new List<IPipeDestination>();
        }

        public IEnumerable<IXmlTransform> Transforms => _transforms;
        public IEnumerable<IPipeDestination> Destinations => _destinations;

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