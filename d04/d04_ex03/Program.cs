using d04_ex03.Models;

namespace d04_ex03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IdentityUser? user1 = TypeFactory<IdentityUser>.CreateWithConstructor();
            IdentityUser? user2 = TypeFactory<IdentityUser>.CreateWithActivator();
            if (user1 == user2)
                Console.WriteLine("user1 == user2");
            else
                Console.WriteLine("user1 != user2"); 
            // Are not equal because they compare by reference.
            Console.WriteLine();

            IdentityRole? role1 = TypeFactory<IdentityRole>.CreateWithConstructor();
            IdentityRole? role2 = TypeFactory<IdentityRole>.CreateWithActivator();
            if (role1 == role2)
                Console.WriteLine("role1 == role2");
            else
                Console.WriteLine("role1 != role2"); 
            // Are not equal because they compare by reference.
            Console.WriteLine();

            IdentityUser? userWithName = TypeFactory<IdentityUser>.CreateWithParameters(
                new object[] { "Ivan" });
            Console.WriteLine(userWithName);
        }
    }
}