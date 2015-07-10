﻿using System.Linq;

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
			var transformsList = _pack.Transforms.ToList();
			var destinations = _pack.Destinations.ToList();

			foreach (var source in sources)
			{
				var workDoc = source.GetDocument();
				foreach (var transform in transforms)
				{
					var tmpDoc = transform.Transform(workDoc);
					workDoc = tmpDoc;
				}

				foreach (var destination in destinations)
				{
					var streamDestination = destination as IPipeStreamDestination;
					if (streamDestination != null)
					{
						var tmpStream = new MemoryStream();
						workDoc.Save(tmpStream);
						streamDestination.Save(tmpStream, source.Name);
					}

					var customDestination = destination as IPipeCustomDestination;
					if (customDestination != null)
					{
						customDestination.Save(workDoc, source.Name);
					}
				}
			}
		}


	}
}