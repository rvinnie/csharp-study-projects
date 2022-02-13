using d02_ex01.Configuration;

namespace d02_ex01
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            int firstPriority = 0;
            int secondPriority = 0;
            bool argValidCondition =    args.Length == 4 &&
                                        Int32.TryParse(args[1], out firstPriority) &&
                                        Int32.TryParse(args[3], out secondPriority);

            if (!argValidCondition)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                return;
            }
            try
            {
                JsonSource jsonSource = new JsonSource(args[0], firstPriority);
                YamlSource yamlSource = new YamlSource(args[2], secondPriority);
                var sources = new List<IConfigurationSource>() { jsonSource, yamlSource };
                var configuration = new Configuration.Configuration(sources);
                Console.WriteLine(configuration);
            }
            catch (IOException)
            {
                Console.WriteLine("Unable to open source file.");
            }
        }
    }
}