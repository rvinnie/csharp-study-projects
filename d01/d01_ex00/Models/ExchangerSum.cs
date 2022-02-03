namespace d01.Models
{
	public readonly struct ExchangerSum
	{
		public readonly double Sum { get; }
		public readonly string Currency { get; }

		public ExchangerSum(string source) : this()
		{
			string[] parsedSource = source.Split(" ");
			if (parsedSource.Count() != 2
				|| !Double.TryParse(parsedSource[0], out double res))
				throw new ArgumentException();
			Currency = parsedSource[1];
			Sum = res;
		}

		public ExchangerSum(double sum, string currency)
		{
			Sum = sum;
			Currency = currency;
		}

		public override string ToString() => $"{Sum:N2} {Currency}";
	}
}
