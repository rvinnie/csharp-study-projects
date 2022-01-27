using d00_5.Extensions;

namespace d00_5.Models
{
	class Store
	{
		public Storage StoreStorage { get; private set; }
		public List<CashRegister> StoreCashRegisters { get; private set; }

		public Store (int storageSize, int countCashRegisters)
		{
			StoreStorage = new Storage(storageSize);
			StoreCashRegisters = new List<CashRegister>();
			for (int i = 0; i < countCashRegisters; i++)
			{
				StoreCashRegisters.Add(new CashRegister((i + 1).ToString()));
			}
		}

		public void OpenStore(List<Customer> customers, bool choiceCustomers)
		{
			while (IsOpen())
			{
				int customerCapacity = 7;
				foreach (var customer in customers)
				{
					if (StoreStorage.CountProducts >= customerCapacity)
					{
						customer.FillCart(customerCapacity);
						StoreStorage.CountProducts -= customer.Cart;
					}
					else if (StoreStorage.CountProducts > 0)
					{
						customer.FillCart(StoreStorage.CountProducts);
						StoreStorage.CountProducts -= customer.Cart;
					}
					else
						break;
					CashRegister chosenCashRegister;
					if (choiceCustomers)
						chosenCashRegister = customer.CRWithMinCustomers(StoreCashRegisters);
					else
						chosenCashRegister = customer.CRWithMinProducts(StoreCashRegisters);
					chosenCashRegister.AddCustomerInQueue(customer);
					Console.Write(customer + " with " + customer.Cart + " products");
					Console.WriteLine(" chose " + chosenCashRegister);
					Console.WriteLine("Current count of customers is "
							+ chosenCashRegister.CustomersQueue.Count);
					Console.WriteLine("Current count of products is "
							+ chosenCashRegister.CountOfProducts);
					Console.WriteLine();
				}
			}
			foreach (var cashRegister in StoreCashRegisters)
			{
				Console.WriteLine(cashRegister.ToString() + " - "
					+ cashRegister.CustomersQueue.Count + " customers");
			}
		}

		public bool IsOpen() => !StoreStorage.IsEmpty();
	}
}
