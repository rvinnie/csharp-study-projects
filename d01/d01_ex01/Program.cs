using d01_ex01.Tasks;
using System.Globalization;

public class Program
{
	public static void Main()
	{
		CultureInfo.CurrentCulture = new CultureInfo("en-US", useUserOverride: false);
		var task = d01_ex01.Tasks.Task.CreateTask();
		Console.ReadLine();
	}
}