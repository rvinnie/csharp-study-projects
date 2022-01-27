using d00_5.Models;

namespace d00_5
{
    class Program
    {
        static List<Customer> createCustomers()
		{
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Alex", 1));
            customers.Add(new Customer("Mike", 2));
            customers.Add(new Customer("Dima", 3));
            customers.Add(new Customer("Ben", 4));
            customers.Add(new Customer("John", 5));
            customers.Add(new Customer("Diana", 6));
            customers.Add(new Customer("Bob", 7));
            customers.Add(new Customer("Bill", 8));
            customers.Add(new Customer("Ann", 9));
            customers.Add(new Customer("Rose", 10));
            return customers;
        }

        static void Main(string[] args)
        {
            List<Customer> customers = createCustomers();
            var store1 = new Store(40, 3);
            var store2 = new Store(40, 3);
			Console.WriteLine("~~~ Simulation of queues in the store ~~~\n");
            Console.WriteLine("[ First test ]");
            Console.WriteLine("Customer chose the queue by the number of people in the queue\n");
            store1.OpenStore(customers, true);
			Console.WriteLine();
            Console.WriteLine("[ Second test ]");
			Console.WriteLine("Customer chose the queue by the number of products in the queue\n");
            store2.OpenStore(customers, false);

        }
    }
}