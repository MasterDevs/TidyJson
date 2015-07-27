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
            HelpText = "Read JSON from clipboard and write it back to the clipboard")]
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
            var help = new HelpText
            {
                Copyright = new CopyrightInfo("MasterDevs", 2015),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true,
            };
            help.AddPreOptionsLine("Usage: tidyJson [OPTIONS]");
            help.AddPreOptionsLine("Uses standard in and standard out if input or output not supplied");
            help.AddPostOptionsLine("Examples:");
            help.AddPostOptionsLine("    echo {json:'value'} | tidyJson");
            help.AddPostOptionsLine("        Read JSON from standard input and write it to standard output");
            help.AddPostOptionsLine(string.Empty);
            help.AddPostOptionsLine("    tidyJson -c");
            help.AddPostOptionsLine("        Read JSON from clipboard and write it back to the clipboard");
            help.AddPostOptionsLine(string.Empty);
            help.AddPostOptionsLine("    tidyJson -f myOutput.json");
            help.AddPostOptionsLine("        Read JSON from standard input and write it to the file myOutput.json");
            help.AddPostOptionsLine(string.Empty);
            help.AddPostOptionsLine("    tidyJson -i myInput.json");
            help.AddPostOptionsLine("        Read JSON from the file myInput.Json and write it to standard output");
            help.AddPostOptionsLine(string.Empty);
            help.AddPostOptionsLine("    tidyJson -i myInput.json -f myOutput.json");
            help.AddPostOptionsLine("        Read JSON from the file myInput.Json and write it to the file myOutput.json");

            help.AddOptions(this);
            return help;

            //return HelpText.AutoBuild(this,
            //  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
