using System.IO;
using NUnit.Framework;
using Tests.Helpers;
using XPump;

namespace Tests
{
    [TestFixture]
    public class ManualRunFixture
    {
        [Test]
        public void SmokeTest()
        {
            var pipeline = new XmlPipeline();

            pipeline
                .Source(PipeSource.Files(new[] {Path.Combine(TestPath.InputTestFilesFolder, @"xml\test1.xml")}))
                .Pipe(new XsdValidateTransform(Path.Combine(TestPath.InputTestFilesFolder, @"xsd\schema1.xsd")))
                .Destination(PipeDestination.Folder(TestPath.OutputTestFilesFolder), s => s + "_out.xml")
                .Pump(false);
        }
    }
}