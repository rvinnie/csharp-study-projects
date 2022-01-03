System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US", false);

static double GetPercents(double sum, double rate, DateTime date)
{
    var countDaysofYear = DateTime.IsLeapYear(date.Year) ? 366 : 365;
    var lastDate = date.AddMonths(-1);
    var countDaysofTerm = DateTime.DaysInMonth(lastDate.Year, lastDate.Month);
    return (sum * rate * countDaysofTerm / (100 * countDaysofYear));
}

static double GetCommonPay(double rate, int term, double sum)
{
    var rateM = rate / 12 / 100;
    return (sum * rateM * Math.Pow((1 + rateM), term) / (Math.Pow((1 + rateM), term) - 1));
}

double sum = 0;
double rate = 0;
int term = 0;

if (args.Length != 3
    || !(double.TryParse(args[0], out sum)
    && double.TryParse(args[1], out rate)
    && Int32.TryParse(args[2], out term)
    ))
    Console.WriteLine("Something went wrong. Check your input and retry.");

double commonPay = GetCommonPay(rate, term, sum);
var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

for (var i = 1; i < term + 1; i++)
{
    date = date.AddMonths(1);

    double percents = GetPercents(sum, rate, date);
    double crtDebt = commonPay - percents;
    sum -= crtDebt;

    if (i == term)
    {
        crtDebt += sum;
        commonPay += sum;
        sum -= sum;
    }

    Console.Write($"{i}\t{date.ToString("d"), 10}\t{commonPay:N2}\t{crtDebt:N2}\t{percents:N2}\t{sum:N2}\n");
}
