namespace d01.Models
{
	public readonly struct ExchangerRate
	{
		public readonly double Rate { get; }
		public readonly string FromCurrency { get; }
		public readonly string ToCurrency { get; }

		public ExchangerRate(string fromCurrency, string rateLine) : this()
		{
			FromCurrency = fromCurrency;
			string[] parsedRateLine = rateLine.Split(":");
			if (parsedRateLine.Count() != 2
				|| !Double.TryParse(parsedRateLine[1], out double res))
				throw new ArgumentException();
			ToCurrency = parsedRateLine[0];
			Rate = res;
		}
	}
}
