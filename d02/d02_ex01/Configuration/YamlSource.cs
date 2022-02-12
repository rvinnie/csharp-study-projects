using System.Collections;

namespace d02_ex01.Configuration
{
    public class YamlSource : IConfigurationSource
    {
        public string PathToFile { get; set; }

        public int Priority { get; set; }

        public YamlSource(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public Hashtable ParseValueFromFile()
        {
            return new Hashtable();
        }
    }
}
