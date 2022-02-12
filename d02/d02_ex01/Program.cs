namespace d02_ex01
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                return;
            }

            string.TryParse(args[0])

        }
    }
}