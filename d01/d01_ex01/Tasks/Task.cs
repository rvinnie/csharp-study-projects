namespace d01_ex01.Tasks
{
	public class Task
	{
		public string Title { get; }
		public string? Summary { get; }
		public DateTime? DueDate { get; private set; }
		public TaskType Type { get; private set; }
		public TaskPriority Priority { get; private set; }
		public TaskState State { get; private set; }

		public Task (string title, TaskType type, string? summary = null,
			DateTime? dueDate = null, TaskPriority priority = TaskPriority.Normal)
		{
			Title = title;
			Summary = summary;
			Type = type;
			DueDate = dueDate;
			Priority = priority;
			State = TaskState.New;
		}

		public static Task CreateTask()
		{
			string? title;
			string? summary;
			string? dueDate;
			string? type;
			string? priority;

			Console.WriteLine("Введите заголовок");
			title = Console.ReadLine();
			Console.WriteLine("Введите описание");
			summary = Console.ReadLine();
			Console.WriteLine("Введите срок");
			dueDate = Console.ReadLine();
			Console.WriteLine("Введите тип");
			type = Console.ReadLine();
			Console.WriteLine("Установите приоритет");
			priority = Console.ReadLine();

			if (String.IsNullOrEmpty(title))
				throw new ArgumentException("Wrong title");
			if (!Enum.TryParse(typeof(TaskType), type, out object? typeRes))
				throw new ArgumentException("Wrong type");
			if (typeRes == null || !Enum.IsDefined(typeof(TaskType), (TaskType)typeRes))
				throw new ArgumentException("Wrong type");

			DateTime? dueDateRes = null;
			bool isConvertedToData = DateTime.TryParse(dueDate, out DateTime dueDateFromParse);
			if (isConvertedToData)
				dueDateRes = dueDateFromParse;
			if (!isConvertedToData && dueDate != null)
				throw new ArgumentException("Wrong dueDate");

			TaskPriority priorityRes = TaskPriority.Normal;
			bool isConvertedToPriority = Enum.TryParse(typeof(TaskPriority), priority, out object? priorityFromParse);
			if (isConvertedToPriority && priorityFromParse != null
				&& Enum.IsDefined(typeof(TaskPriority), (TaskPriority)priorityFromParse))
				priorityRes = (TaskPriority)priorityFromParse;
			if (!isConvertedToPriority && priority != null)
				throw new ArgumentException("Wrong priority");

			return new Task(title, (TaskType)typeRes, summary, dueDateRes, priorityRes);
		}
	}
}
