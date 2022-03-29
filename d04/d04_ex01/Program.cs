using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace d04_ex01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var defaultHttpContext = new DefaultHttpContext();
            Console.WriteLine($"Old Response value: {defaultHttpContext.Response}");

            Type type = typeof(DefaultHttpContext);
            defaultHttpContext.GetType()
                              .GetField("_response", BindingFlags.Instance | BindingFlags.NonPublic)?
                              .SetValue(defaultHttpContext, null);

            Console.WriteLine($"New Response value: {defaultHttpContext.Response}");
        }
    }
}
