using Newtonsoft.Json.Linq;

namespace TidyJson
{
    public class Cleaner
    {
        private StreamFactory _stramFactory;

        public Cleaner(StreamFactory streamFactory)
        {
            _stramFactory = streamFactory;
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
            using (var reader = _stramFactory.InputReader)
            {
                return reader.ReadToEnd();
            }
        }

        private void Write(string output)
        {
            using (var writer = _stramFactory.OutputWriter)
            {
                writer.Write(output);
            }
        }
    }
}