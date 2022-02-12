using System.Collections;

namespace d02_ex01.Configuration
{
    public class Configuration
    {
        public Hashtable Params { get; set; }
        public List<IConfigurationSource> Sources { get; init; }
        public Configuration (List<IConfigurationSource> sources)
        {
            Params = new Hashtable();
        }
    }
}
