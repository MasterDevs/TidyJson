using System;

namespace TidyJson
{
    public class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {
            var options = new Options();
            try
            {

                if (!CommandLine.Parser.Default.ParseArguments(args, options))
                {
                    var usage = options.GetUsage();
                    Console.WriteLine(usage);

                    return -1;
                }

                var factory = new StreamFactory(options);
                var cleaner = new Cleaner(factory);

                cleaner.Clean();
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine("Error formatting JSON");
                if (options.Verbose)
                {
                    Console.Error.WriteLine(ex);
                }
                else
                {
                    Console.Error.WriteLine(ex.Message);
                }
                return -1;
            }

            return 0;
        }
    }
}