
using System;


namespace Class_2
{
    class Program
    {
        static void Main()
        {
            TaskManager manager = new TaskManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(Messages.TASK_MANAGER_HEADER);
                Console.WriteLine(Messages.OPTION_ADD_TASK);
                Console.WriteLine(Messages.OPTION_MARK_TASK_COMPLETED);
                Console.WriteLine(Messages.OPTION_VIEW_TASKS);
                Console.WriteLine(Messages.OPTION_EXIT);
                Console.Write(Messages.SELECT_OPTION);

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter the task description: ");
                        string description = Console.ReadLine();
                        manager.AddTask(description);
                        break;
                    case "2":
                        Console.Write("Enter the task ID to mark as completed: ");
                        try
                        {
                            int taskId = int.Parse(Console.ReadLine());
                            manager.MarkTaskCompleted(taskId);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid number.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("The number entered is too large or too small.");
                        }
                        break;
                    case "3":
                        manager.ViewTasks();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}