using d00_5.Models;

namespace d00_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer("Alex", 1);
            var customer2 = new Customer("Alex", 1);
            Console.WriteLine(customer1.GetHashCode());
            Console.WriteLine(customer2.GetHashCode());
            Console.WriteLine(customer1 == customer2);
        }
    }
}