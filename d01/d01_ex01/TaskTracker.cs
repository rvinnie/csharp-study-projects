using d01_ex01.Tasks;

namespace d01_ex01
{
    public class TaskTracker
    {
        private List<Tasks.Task> _taskList;

        public TaskTracker()
        {
            _taskList = new List<Tasks.Task>();
        }

        public void AddTask()
        {
            try
            {
                var newTask = Tasks.Task.CreateTask();
                _taskList.Add(newTask);
                Console.WriteLine(newTask);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            }
        }

        public void ListTasks()
        {
            if (!_taskList.Any())
            {
                Console.WriteLine("Список задач пока пуст.");
                return;
            }

            foreach (var task in _taskList)
                Console.WriteLine(task);
        }

        public void ChangeState(TaskState state)
        {   
            try
            {
                Console.WriteLine("Введите заголовок");
                string? title = Console.ReadLine();
                if (String.IsNullOrEmpty(title))
                    throw new ArgumentNullException();

                var task = _taskList.Find(item => item.Title == title);
                if (task == null)
                    throw new ArgumentOutOfRangeException();

                switch (state)
                {
                    case TaskState.Done:
                        task.SetDone();
                        break;
                    case TaskState.Wontdo:
                        task.SetWontdo();
                        break;
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
            }
        }

    }
}
