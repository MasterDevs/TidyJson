using System;
using System.IO;

namespace TidyJson
{
    public class StreamFactory
    {
        private readonly Options _options;
        private readonly Lazy<Stream> _outputStream;
        private readonly Lazy<Stream> _inputStream;

        public StreamFactory(Options options)
        {
            _options = options ?? options;

            _outputStream = new Lazy<Stream>(GetOutputStream);
            _inputStream = new Lazy<Stream>(GetInputStream);
        }

        public Stream InputStream { get { return _inputStream.Value; } }
        public Stream OutputStream { get { return _outputStream.Value; } }

        private Stream GetInputStream()
        {
            if (_options.Clipboard)
            {
              

            }

            return Console.OpenStandardInput();
        }

        private Stream GetOutputStream()
        {
            if (null != _options.OutputFile)
            {
                return new FileStream(_options.OutputFile, FileMode.Create);
            }

            return Console.OpenStandardOutput();
        }
    }
}
