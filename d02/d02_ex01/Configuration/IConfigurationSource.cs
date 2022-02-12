using System.Collections;

namespace d02_ex01.Configuration
{
    public interface IConfigurationSource
    {
        public string PathToFile { get; set; }

        public int Priority { get; set; }

        public Hashtable ParseValueFromFile();
    }
}