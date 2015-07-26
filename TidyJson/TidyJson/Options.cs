using CommandLine;
using CommandLine.Text;

namespace TidyJson
{
    public class Options
    {
        [Option('c',
            "clipboard",
            Required = false,
            MutuallyExclusiveSet = "input",
            HelpText = "Read input from the clipboard and write output back out to the clipboard")]
        public bool Clipboard { get; set; }

        [Option('i',
            "inputFile",
            Required = false,
            MutuallyExclusiveSet = "input",
            HelpText = "JSON input file")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output file")]
        public string OutputFile { get; set; }

        [Option('v',
            "verbose",
            Required = false,
            HelpText = "Include detailed information in the output")]
        public bool Verbose { get; set; }

        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}