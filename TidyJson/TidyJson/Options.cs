using CommandLine;
using CommandLine.Text;

namespace TidyJson
{
    public class Options
    {
        [Option('o', "output", Required = false, HelpText = "File to save the ouput")]
        public string OutputFile { get; set; }

        [Option('c', 
            "clipboard", 
            Required = false, 
            MutuallyExclusiveSet = "input",
            HelpText = "Read input from the clipboard and write output back out to the clipboard")]
        public bool Clipboard { get; set; }

        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}