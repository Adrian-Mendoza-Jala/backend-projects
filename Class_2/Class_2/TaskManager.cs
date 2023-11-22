using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Class_2
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(string description)
        {
            tasks.Add(new Task(description));
            Console.WriteLine("Task added.");
        }

        public void MarkTaskCompleted(int taskId)
        {
            if (taskId > 0 && taskId <= tasks.Count)
            {
                tasks[taskId - 1].IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        public void ViewTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsCompleted ? "X" : " ";
                Console.WriteLine($"{i + 1}. [{status}] {tasks[i].Description}");
            }
        }
    }
}
