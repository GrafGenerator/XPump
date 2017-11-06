using System;

namespace XPump
{
    public class XmlPipelineMediator : IXmlPipelineMediator
    {
        private readonly XmlPipelinePack _pack;

        internal XmlPipelineMediator(XmlPipelinePack pack)
        {
            _pack = pack;
        }


        public IXmlPipelineMediator Pipe(IXmlTransform transform)
        {
            _pack.AppendTransform(transform);
            return new XmlPipelineMediator(_pack);
        }

        public IXmlPipelineActuator Destination(IPipeDestination destination)
        {
            return Destination(destination, null);
        }

        public IXmlPipelineActuator Destination(IPipeDestination destination,
            Func<string, string> documentNameTransform)
        {
            _pack.AppendDestination(destination);
            _pack.NameTransform = documentNameTransform;

            return new XmlPipelineActuator(_pack);
        }
    }
}