using d01.Models;

namespace d01
{
	class Exchanger
	{
		public List<ExchangerRate> RateList { get; private set; }
		public List<string> KnownCurrencies { get; private set; }

		public Exchanger(string pathToRates)
		{
			RateList = new List<ExchangerRate>();
			KnownCurrencies = new List<string>();
			foreach (var fullFileName in Directory.GetFiles(pathToRates))
			{
				string fileName = Path.GetFileNameWithoutExtension(fullFileName);
				KnownCurrencies.Add(fileName);
				string[] lines = File.ReadAllLines(fullFileName);
				foreach (var line in lines)
				{
					RateList.Add(new ExchangerRate(fileName, line));
				}
			}
		}

		public IEnumerable<ExchangerSum> Exchange(ExchangerSum currencyToChange)
		{
			if (!KnownCurrencies.Contains(currencyToChange.Currency))
				throw new ArgumentException();
			return ExchangeIterator(currencyToChange);
		}

		public IEnumerable<ExchangerSum> ExchangeIterator(ExchangerSum currencyToChange)
		{
			foreach (var rate in RateList)
			{
				if (rate.FromCurrency == currencyToChange.Currency)
					yield return new ExchangerSum(currencyToChange.Sum * rate.Rate, rate.ToCurrency);
			}
		}
	}
}
