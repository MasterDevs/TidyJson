using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyJson
{
    public class Cleaner
    {
        private Options _options;

        public Cleaner(Options options)
        {
            _options = options;
        }

        public void Clean()
        {
            var dirtyJson = Read();

            var cleanJson = CleanJson(dirtyJson);
            Write(cleanJson);

        }

        private string CleanJson(string dirtyJson)
        {
            var jobject = JToken.Parse(dirtyJson);
            var cleanJson = jobject.ToString();
            return cleanJson;
        }

        private string Read()
        {
            using (var stream = Console.OpenStandardInput())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
