using System.Collections;

namespace d02_ex01.Configuration
{
    public class JsonSource : IConfigurationSource
    {
        public string PathToFile { get; set; }

        public int Priority { get; set; }

        public JsonSource(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public Hashtable ParseValueFromFile()
        {
            return new Hashtable();
        }
    }
}
