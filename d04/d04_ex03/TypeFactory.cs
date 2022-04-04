using System.Reflection;

namespace d04_ex03
{
    public static class TypeFactory<T> where T : class
    {
        public static T? CreateWithConstructor()
        {
            Type type = typeof(T);
            ConstructorInfo? constructor = type.GetConstructor(Type.EmptyTypes);
            T? instance = (T?)constructor?.Invoke(null);
            Console.WriteLine($"Object \"{type.Name}\" created using constructor.");
            return instance;
        }

        public static T? CreateWithActivator()
        {
            Type type = typeof(T);
            Console.WriteLine($"Object \"{type.Name}\" created using activator.");
            return (T?)Activator.CreateInstance(type);
        }

        public static T? CreateWithParameters(object[] parameters)
        {
            Type type = typeof(T);
            Console.WriteLine($"Object \"{type.Name}\" with parameters created using activator.");
            return (T?)Activator.CreateInstance(type, parameters);
        }
    }
}
