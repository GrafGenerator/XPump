using System;
using System.Collections.Generic;
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

		public IPipeResult Transform(IPipeSource source)
		{
			var transforms = _pack.Transforms.ToList();
			var destinations = _pack.Destinations.ToList();
			var nameTransform = _pack.NameTransform ?? (Func<string, string>)(s => s);

			var result = new PipeResult() { Success = true };

			try
			{
				var workDoc = source.GetDocument();
				foreach (var transform in transforms)
				{
					if (workDoc == null) break;
					var tmpDoc = transform.Process(workDoc);
					workDoc = tmpDoc;
				}

				// transforming failed
				if (workDoc == null)
				{
					result.Success = false;
					return result;
				}

				result.Document = workDoc;

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

						tmpStream.Position = 0;
						result.Stream = tmpStream;
					}

					var customDestination = destination as IPipeCustomDestination;
					if (customDestination != null)
					{
						customDestination.Save(workDoc, name);
					}
				}
			}
			catch (Exception ex)
			{
				result.Exception = ex;
				result.Success = false;
			}

			return result;
		}


	}
}
