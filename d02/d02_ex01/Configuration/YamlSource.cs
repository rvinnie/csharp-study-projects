using System.Collections;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace d02_ex01.Configuration
{
    public class YamlSource : IConfigurationSource
    {
        public string PathToFile { get; set; }

        public int Priority { get; set; }

        public YamlSource(string pathToFile, int priority)
        {
            PathToFile = pathToFile;
            Priority = priority;
        }

        public Hashtable ParseValueFromFile()
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            string yamlCode = File.ReadAllText(PathToFile);
            Hashtable parameters = deserializer.Deserialize<Hashtable>(yamlCode);
            return parameters;
        }
    }
}
