using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyJson
{
    public class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var usage = options.GetUsage();
                Console.WriteLine(usage);
            }

            var cleaner = new Cleaner(options);

            cleaner.Clean();
        }
    }
}
