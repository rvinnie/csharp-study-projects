using System;
using System.Reflection;
using d04_ex02.Models;
using d04_ex02.Attributes;
using System.ComponentModel;

namespace d04_ex02.ConsoleSetter
{
    public class ConsoleSetter
    {
        private T? GetAttribute<T>(PropertyInfo property) where T : class
        {
            foreach (var attr in property.GetCustomAttributes())
            {
                if (attr is T propAttribute)
                {
                    return propAttribute;
                }
            }
            return null;
        }

        public void SetValues<T>(T input) where T : class
        {
            Type type = typeof(T);
            Console.WriteLine($"Let's set {type.Name}!");
            foreach (var prop in type.GetProperties(BindingFlags.Instance 
                        | BindingFlags.Public))
            {
                if (GetAttribute<NoDisplayAttribute>(prop) == null)
                {
                    string description;
                    var descriptionAttribute = GetAttribute<DescriptionAttribute>(prop);
                    if (descriptionAttribute != null)
                        description = descriptionAttribute.Description;
                    else
                        description = prop.Name;
                    Console.WriteLine($"Set {description}:");

                    string? value = Console.ReadLine();
                    var defaultValueAttribute = GetAttribute<DefaultValueAttribute>(prop);
                    if (string.IsNullOrEmpty(value))
                        value = defaultValueAttribute?.Value?.ToString();
                    prop.SetValue(input, value);
                }
            }
            Console.WriteLine("We've set our instance!");
        }
    }
}
