using CommandLine;
using CommandLine.Text;

namespace TidyJson
{
    public class Options
    {
        [Option('o', "output", Required = false, HelpText = "File to save the ouput")]
        public string OutputFile { get; set; }
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}