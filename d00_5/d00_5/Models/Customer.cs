namespace d00_5.Models
{
	class Customer
	{
		public string Name { get; private set; }
		public int Number { get; private set; }
		public int Cart { get; private set; }

		public Customer(string name, int number)
		{
			Name = name ?? "No name";
			Number = number;
		}

		public void FillCart(int maxSize)
		{
			if (maxSize < 1)
				return;
			var rand = new Random();
			Cart = rand.Next(1, maxSize + 1);
		}

		public override string ToString() => $"[{Number}] {Name}";

		public override bool Equals(object? obj) => (obj is Customer other) && (this == other);

		public override int GetHashCode() => Name.GetHashCode() + Number.GetHashCode();

		public static bool operator ==(Customer c1, Customer c2)
		{
			return (c1.Name == c2.Name) && (c1.Number == c2.Number);
		}

		public static bool operator !=(Customer c1, Customer c2)
		{
			return !(c1 == c2);
		}
	}
}
