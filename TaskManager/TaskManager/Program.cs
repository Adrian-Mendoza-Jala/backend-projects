
namespace TaskManager
{
    public class Program
    {
        public static void Main()
        {
            var taskManager = new ConcurrentTaskManager();

            taskManager.AddTask(() => Console.WriteLine("Task 1"));
            taskManager.AddTask(() => Console.WriteLine("Task 2"));
            taskManager.AddTask(() => Console.WriteLine("Task 3"));
            taskManager.AddTask(() => Console.WriteLine("Task 4"));
            taskManager.AddTask(() => Console.WriteLine("Task 5"));

            taskManager.ExecuteTasks();
        }
    }
}