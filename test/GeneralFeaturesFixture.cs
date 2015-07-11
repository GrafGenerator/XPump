using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using XPump;
using Tests.Helpers;

namespace Tests
{
	[TestFixture]
    public class GeneralFeaturesFixture
    {
		[Test]
		public void Test_Immediate_Pumping_All()
		{
			var log = new List<string>();

			var result = new XmlPipeline()
				.Source(new[] { new DummyXmlSource() })
				.Pipe(new DummyXmlTransform())
				.Destination(new DummyXmlDestination(name => log.Add(name)))
				.Pump(false);

			Assert.That(log.ToArray(), Is.EqualTo(new[] { "dummy-source" }));
		}

		[Test]
		public void Test_Lazy_Pumping()
		{
			var log = new List<string>();

			var results = new XmlPipeline()
				.Source(new[] { new DummyXmlSource("-1"), new DummyXmlSource("-2"), new DummyXmlSource("-3") })
				.Pipe(new DummyXmlTransform())
				.Destination(new DummyXmlDestination(name => log.Add(name)))
				.Pump();

			Assert.That(log.ToArray(), Is.EqualTo(new string[0]));

			var expected = new[] { "dummy-source-1", "dummy-source-2", "dummy-source-3" };
			var i = 1;
			foreach (var result in results)
			{
				Assert.That(log.ToArray(), Is.EqualTo(expected.Take(i++)));
			}
		}

		[Test]
		public void Test_Pumping_Stages()
		{
			var flagPipe = false;
			var flagDest = false;

			var result = new XmlPipeline()
				.Source(new[] { new DummyXmlSource() })
				.Pipe(new DummyXmlTransform(() => flagPipe = true))
				.Destination(new DummyXmlDestination(_ => flagDest = true))
				.Pump(false);

			Assert.That(flagPipe, Is.True);
			Assert.That(flagDest, Is.True);
		}
    }
}
