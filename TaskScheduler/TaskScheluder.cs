

namespace TaskScheduler
{
    public class TaskScheduler<TTask, TPriority>
    {
        private readonly SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
        private readonly TaskExecution<TTask> taskExecutor;
        private readonly Func<TTask> taskInitializer;
        private readonly Action<TTask> taskResetter;

        public delegate void TaskExecution<TTask>(TTask task);

        public TaskScheduler(TaskExecution<TTask> executor, Func<TTask> initializer, Action<TTask> resetter)
        {
            taskExecutor = executor;
            taskInitializer = initializer;
            taskResetter = resetter;
        }

        public void AddTask(TTask task, TPriority priority)
        {
            if (!taskQueue.ContainsKey(priority))
            {
                taskQueue[priority] = new Queue<TTask>();
            }
            taskQueue[priority].Enqueue(task);
        }

        public void ExecuteNext()
        {
            if (taskQueue.Count > 0)
            {
                var highestPriority = taskQueue.Keys.GetEnumerator().Current;
                var nextTask = taskQueue[highestPriority].Dequeue();
                taskExecutor(nextTask);
                taskResetter(nextTask);
            }
            else
            {
                Console.WriteLine("No tasks to execute.");
            }
        }

        public TTask InitializeTaskFromConsole()
        {
            Console.WriteLine("Enter task:");
            return taskInitializer();
        }

        public void ResetTask(TTask task)
        {
            taskResetter(task);
        }
    }
}
