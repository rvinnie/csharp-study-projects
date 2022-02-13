using System.Collections;
using System.Text.Json;

namespace d02_ex01.Configuration
{
    public class JsonSource : IConfigurationSource
    {
        public string PathToFile { get; set; }

        public int Priority { get; set; }

        public JsonSource(string pathToFile, int priority)
        {
            PathToFile = pathToFile;
            Priority = priority;
        }

        public Hashtable ParseValueFromFile()
        {
            Hashtable parameters;
            using (var fs = new FileStream(PathToFile, FileMode.Open))
            {
                parameters = JsonSerializer.Deserialize<Hashtable>(fs) ?? new Hashtable();
            }
            return parameters;
        }
    }
}
