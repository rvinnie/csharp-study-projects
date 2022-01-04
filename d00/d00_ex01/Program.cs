using System.IO;

static int GetMin(int a, int b, int c)
{
	int min = (a < b && a < c) ? a : (b < a && b < c) ? b : c;
	return (min);
}

static string Capitalize(string str)
{
	str = str.Trim();
	return (str[0].ToString().ToUpper() + str.Substring(1).ToLower());
}

static int LevenshteinDistance(string s1, string s2, int m, int n)
{
	if (m == 0 && n == 0)
		return (0);
	else if (m == 0 && n > 0)
		return (n);
	else if (m > 0 && n == 0)
		return (m);
	return (
			GetMin(
					LevenshteinDistance(s1, s2, m, n - 1) + 1,
					LevenshteinDistance(s1, s2, m - 1, n) + 1,
					LevenshteinDistance(s1, s2, m - 1, n - 1) + (s1[m-1] == s2[n-1] ? 0 : 1)
			)
	);
}

static bool ClarifyName(string crtName)
{
	Console.WriteLine($">Did you mean “{crtName}”? Y/N");
	var ans = Console.ReadLine();
	if (String.IsNullOrEmpty(ans))
		return (false);
	ans = ans.Trim().ToUpper();
	if (ans.Equals("Y"))
		return (true);
	return (false);

}

static bool FindInDictionary(string uName, string path, int code)
{
	bool ret = false;
	using (var stream = new StreamReader(path))
	{
		while (!stream.EndOfStream)
		{
			var crtName = stream.ReadLine();
			if (String.IsNullOrEmpty(crtName))
				break;
			if (LevenshteinDistance(crtName, uName, crtName.Length, uName.Length) == code)
            {
				if (code == 0 || ClarifyName(crtName))
                {
					Console.WriteLine($">Hello, {crtName}!");
					ret = true;
					break;
				}
			}
		}
	}
	return (ret);
}

const string path = "../../../us_names.txt";

Console.WriteLine(">Enter name:");
var	uName = Console.ReadLine();
if (String.IsNullOrEmpty(uName))
	Console.WriteLine("Something went wrong. Check your input and retry.");
else
{
	uName = Capitalize(uName);
	if (!FindInDictionary(uName, path, 0))
	{
		if (!FindInDictionary(uName, path, 1))
			Console.WriteLine("Your name was not found.");
	}
}
