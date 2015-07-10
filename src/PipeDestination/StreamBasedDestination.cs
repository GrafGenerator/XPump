using System;
using System.IO;

namespace XPump.PipeDestination
{
	internal abstract class StreamBasedDestination: IPipeStreamDestination
	{
		protected bool _shouldCloseStream = true;

		protected abstract Stream GetDestinationStream(string name);
		protected abstract void OnPostSave(Stream stream);


		public void Save(Stream source, string name)
		{
			var stream = GetDestinationStream(name);
			var context = _shouldCloseStream ? (IDisposable)stream : new DisposableStub();

			try
			{
				SaveInternal(source, stream);
				OnPostSave(stream);
			}
			finally
			{
				if (_shouldCloseStream) context.Dispose();
			}
		}

		private void SaveInternal(Stream source, Stream destination)
		{
			source.CopyTo(destination);
		}



		private struct DisposableStub : IDisposable
		{
			public void Dispose(){}
		}
	}
}
