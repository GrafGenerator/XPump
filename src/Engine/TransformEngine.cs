using System;
using System.IO;
using System.Linq;

namespace XPump.Engine
{
	internal sealed class TransformEngine
	{
		private readonly XmlPipelinePack _pack;

		public TransformEngine(XmlPipelinePack pack)
		{
			_pack = pack;
		}

		public void Transform()
		{
			var sources = _pack.Sources.ToList();
			var transforms = _pack.Transforms.ToList();
			var destinations = _pack.Destinations.ToList();
			var nameTransform = _pack.NameTransform ?? (Func<string, string>)(s => s);

			foreach (var source in sources)
			{
				var workDoc = source.GetDocument();
				foreach (var transform in transforms)
				{
					if (workDoc == null) break;
					var tmpDoc = transform.Process(workDoc);
					workDoc = tmpDoc;
				}

				// transforming failed
				if (workDoc == null) continue;

				foreach (var destination in destinations)
				{
					var name = nameTransform(source.Name);

					var streamDestination = destination as IPipeStreamDestination;
					if (streamDestination != null)
					{
						var tmpStream = new MemoryStream();
						workDoc.Save(tmpStream);
						tmpStream.Position = 0;
						streamDestination.Save(tmpStream, name);
					}

					var customDestination = destination as IPipeCustomDestination;
					if (customDestination != null)
					{
						customDestination.Save(workDoc, name);
					}
				}
			}
		}


	}
}
