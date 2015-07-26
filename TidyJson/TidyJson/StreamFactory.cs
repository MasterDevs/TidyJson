using System;
using System.IO;

namespace TidyJson
{
    public class StreamFactory
    {
        private readonly Options _options;

        public StreamFactory(Options options)
        {
            _options = options ?? options;
        }

        public Stream GetOutputStream()
        {
            if (null != _options.OutputFile)
            {
                return new FileStream(_options.OutputFile, FileMode.Create);
            }

            return Console.OpenStandardOutput();
        }
    }
}
