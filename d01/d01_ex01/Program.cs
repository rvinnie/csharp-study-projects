using d01_ex01;
using d01_ex01.Tasks;
using System.Globalization;

public class Program
{
	public static void LaunchTracker(TaskTracker tracker)
    {
		bool stop = false;
		Console.WriteLine("TaskTracker команды: [ add, list, done, wontdo, quit ]");
		while (!stop)
		{
			string command = Console.ReadLine() ?? "";
			switch (command)
            {
				case "add":
					tracker.AddTask();
					break;
				case "list":
					tracker.ListTasks();
					break;
				case "done":
					tracker.ChangeState(TaskState.Done);
					break;
				case "wontdo":
					tracker.ChangeState(TaskState.Wontdo);
					break;
				case "q":
				case "quit":
					stop = true;
					break;
				default:
                    Console.WriteLine("Ошибка ввода\nTaskTracker команды: add, list, done, wontdo, quit");
					break;
			}
        }
    }

	public static void Main()
	{
		CultureInfo.CurrentCulture = new CultureInfo("en-US", useUserOverride: false);

		var tracker = new TaskTracker();
		LaunchTracker(tracker);
	}
}