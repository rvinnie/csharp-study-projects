namespace d00_5.Models
{
	class CashRegister
	{
		public string Name { get; private set; }

		public Queue<Customer> CustomersQueue { get; private set; }

		public int CountOfProducts { get; private set; }

		public void AddCustomerInQueue(Customer customer)
		{
			CustomersQueue.Enqueue(customer);
			CountOfProducts += customer.Cart;
		}

		public CashRegister(string name)
		{
			CustomersQueue = new Queue<Customer>();
			Name = name;
		}

		public override string ToString() => $"CashRegister \"{Name}\"";

		public override bool Equals(object? obj) => (obj is CashRegister other) && (this == other);

		public override int GetHashCode() => Name.GetHashCode();

		public static bool operator ==(CashRegister c1, CashRegister c2)
		{
			return c1.Name == c2.Name;
		}

		public static bool operator !=(CashRegister c1, CashRegister c2)
		{
			return !(c1 == c2);
		}
	}
}
