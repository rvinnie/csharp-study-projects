using d04_ex02.Models;
using d04_ex02.ConsoleSetter;
using System.Reflection;

namespace d04_ex02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var setter = new ConsoleSetter.ConsoleSetter();

            var user = new IdentityUser();
            setter.SetValues(user);
            Console.WriteLine(user);
            Console.WriteLine();

            var role = new IdentityRole();
            setter.SetValues(role);
            Console.WriteLine(role);
        }
    }
}