using System;
using System.IO;

namespace XPump
{
    internal abstract class StreamBasedDestination : IPipeStreamDestination
    {
        protected bool ShouldCloseStream = true;


        public void Save(Stream source, string name)
        {
            var stream = GetDestinationStream(name);
            var context = ShouldCloseStream ? (IDisposable) stream : new DisposableStub();

            try
            {
                SaveInternal(source, stream);
                OnPostSave(stream);
            }
            finally
            {
                if (ShouldCloseStream) context.Dispose();
            }
        }

        protected abstract Stream GetDestinationStream(string name);
        protected abstract void OnPostSave(Stream stream);

        private void SaveInternal(Stream source, Stream destination)
        {
            source.CopyTo(destination);
        }


        private struct DisposableStub : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}