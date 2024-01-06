using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace TaskManager
{
    public class ConcurrentTaskManager
    {
        private ConcurrentQueue<Action> taskQueue = new ConcurrentQueue<Action>();

        public void AddTask(Action task)
        {
            taskQueue.Enqueue(task);
        }

        public void ExecuteTasks()
        {
            Parallel.ForEach(taskQueue, (task) =>
            {
                try
                {
                    task.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            });
        }
    }

}
