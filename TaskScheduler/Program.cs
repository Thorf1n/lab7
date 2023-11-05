namespace TaskScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(ExecuteTask, () => Console.ReadLine(), task => { });

            while (true)
            {
                var task = scheduler.InitializeTaskFromConsole();
                Console.WriteLine("Enter task priority:");
                if (int.TryParse(Console.ReadLine(), out int priority))
                {
                    scheduler.AddTask(task, priority);
                }
                else
                {
                    Console.WriteLine("Invalid priority. Task not added.");
                }

                Console.WriteLine("Do you want to execute the next task? (y/n)");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }

                scheduler.ExecuteNext();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ExecuteTask(string task)
        {
            Console.WriteLine($"Executing task: {task}");
        }
    }
}