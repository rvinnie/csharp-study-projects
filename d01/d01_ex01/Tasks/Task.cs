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
			if (DateTime.TryParse(dueDate, out DateTime dueDateFromParse))
				dueDateRes = dueDateFromParse;

			TaskPriority priorityRes = TaskPriority.Normal;
			bool isConvertedToPriority = Enum.TryParse(typeof(TaskPriority), priority, out object? priorityFromParse);
			if (isConvertedToPriority && priorityFromParse != null
				&& Enum.IsDefined(typeof(TaskPriority), (TaskPriority)priorityFromParse))
				priorityRes = (TaskPriority)priorityFromParse;

			return new Task(title, (TaskType)typeRes, summary, dueDateRes, priorityRes);
		}

		public void SetDone()
        {
			if (State != TaskState.Wontdo)
				State = TaskState.Done;
		}

		public void SetWontdo()
        {
			if (State != TaskState.Done)
				State = TaskState.Wontdo;
		}

        public override string ToString()
        {
			string ret = $"{Title}\n[{Type}] [{State}]\nPriority: {Priority}";
			if (DueDate != null)
				ret += $", Due till {DueDate:MM/dd/yyyy}";
			ret += "\n";
			if (!string.IsNullOrEmpty(Summary))
				ret += $"{Summary}\n";
			return ret;
		}
	}
}
