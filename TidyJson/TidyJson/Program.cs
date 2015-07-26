using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyJson
{
    public class Program
    {
        static int Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var usage = options.GetUsage();
                Console.WriteLine(usage);

                return -1;
            }

            var factory = new StreamFactory(options);
            var cleaner = new Cleaner(factory);

            cleaner.Clean();

            return 0;
        }
    }
}
