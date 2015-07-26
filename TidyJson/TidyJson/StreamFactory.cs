using Clippy;
using System;
using System.IO;

namespace TidyJson
{
    public class StreamFactory
    {
        private readonly Lazy<TextReader> _inputReader;
        private readonly Options _options;
        private readonly Lazy<TextWriter> _outputWriter;

        public StreamFactory(Options options)
        {
            _options = options ?? options;

            _inputReader = new Lazy<TextReader>(GetInputReader);
            _outputWriter = new Lazy<TextWriter>(GetOutputWriter);
        }

        public TextReader InputReader { get { return _inputReader.Value; } }
        public TextWriter OutputWriter { get { return _outputWriter.Value; } }

        private TextReader GetInputReader()
        {
            if (_options.Clipboard)
            {
                return new ClipboardReader();
            }

            return new StreamReader(Console.OpenStandardInput());
        }

        private TextWriter GetOutputWriter()
        {
            if (_options.Clipboard)
            {
                return new ClipboardWriter();
            }
            if (null != _options.OutputFile)
            {
                return new StreamWriter(_options.OutputFile, false);
            }

            return new StreamWriter(Console.OpenStandardOutput());
        }
    }
}