using System.Globalization;
using d01.Models;

namespace d01
{
	class Program
	{
		public const string ERROR_MSG = "Ошибка ввода. Проверьте входные данные и повторите запрос.";

		static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine(ERROR_MSG);
				return;
			}

			try
			{
				Exchanger exchanger = new Exchanger(args[1]);
				List<ExchangerSum> convertedCurrency = new List<ExchangerSum>();
				var sourceCurrency = new ExchangerSum(args[0]);
				var convertedCurrencies = exchanger.Exchange(sourceCurrency);
				Console.WriteLine("Сумма в исходной валюте: " + sourceCurrency);
				foreach (var element in convertedCurrencies)
				{
					Console.WriteLine("Сумма в " + element.Currency + ": " + element);
				}
			}
			catch
			{
				Console.WriteLine(ERROR_MSG);
			}
		}
	}
}