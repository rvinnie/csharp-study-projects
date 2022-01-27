using d00_5.Models;

namespace d00_5.Extensions
{
	static class CustomerExtensions
	{
		public static CashRegister CRWithMinCustomers(this Customer _, List<CashRegister> cashRegisters)
		{
			CashRegister bestCR = cashRegisters[0];
			foreach (var cashRegister in cashRegisters)
			{
				if (cashRegister.CustomersQueue.Count < bestCR.CustomersQueue.Count)
					bestCR = cashRegister;
			}
			return bestCR;
		}

		public static CashRegister CRWithMinProducts(this Customer _, List<CashRegister> cashRegisters)
		{
			CashRegister bestCR = cashRegisters[0];
			int minCountProducts = Int32.MaxValue;
			foreach (var cashRegister in cashRegisters)
			{
				int crtCountProducts = 0;
				foreach (var customer in cashRegister.CustomersQueue)
					crtCountProducts += customer.Cart;
				if (crtCountProducts < minCountProducts)
				{
					minCountProducts = crtCountProducts;
					bestCR = cashRegister;
				}
			}
			return bestCR;
		}
	}
}
