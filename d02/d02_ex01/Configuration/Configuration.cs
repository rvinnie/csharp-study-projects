using System.Collections;
using System.Linq;

namespace d02_ex01.Configuration
{
    public class Configuration
    {
        public Hashtable Params { get; set; }

        public List<IConfigurationSource> Sources { get; init; }

        public Configuration (List<IConfigurationSource> sources)
        {
            Params = new Hashtable();
            Sources = sources.OrderByDescending(x => x.Priority).ToList();
            foreach (var source in Sources)
            {
                var hashtable = source.ParseValueFromFile();
                foreach (DictionaryEntry dictionaryEntry in hashtable)
                {
                    if (!Params.ContainsKey(dictionaryEntry.Key))
                    {
                        Params.Add(dictionaryEntry.Key, dictionaryEntry.Value);
                    }
                }
            }
        }

        public override string ToString()
        {
            string answer = "Configuration\n";
            ArrayList keys = new ArrayList(Params.Keys);
            keys.Sort();
            foreach (var key in Params.Keys)
            {
                answer += $"{key}: {Params[key]}\n";
            }
            return answer;
        }
    }
}
