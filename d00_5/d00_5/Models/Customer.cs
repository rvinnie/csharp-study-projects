namespace d00_5.Models
{
    public class Customer
    {
        private Customer() { }

        public string Name { get; private set; }
        public int Number { get; private set; }


        public Customer(string name, int number) {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            if (Name == null)
                return "NA";
            return $"[{Number}] {Name}";
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            Customer c = (Customer) obj;
            return (this.Name == c.Name && this.Number == c.Number);
        }

        public override int GetHashCode() => Name.GetHashCode() + Number.GetHashCode();

        public static bool operator ==(Customer c1, Customer c2) => (c1.Name == c2.Name && c1.Number == c2.Number);

        public static bool operator != (Customer c1, Customer c2) => !(c1 == c2);
    }
}
