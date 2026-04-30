namespace Task_Scheduler_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_Scheduler_System scheduler = new Task_Scheduler_System();

            // Add normal tasks
            scheduler.AddTask("Backup Database");
            scheduler.AddTask("Clean Logs");
            scheduler.AddTask("Backup Database"); // duplicate

            // Add priority tasks
            scheduler.AddPriorityTask(1, "Critical Security Patch");
            scheduler.AddPriorityTask(2, "System Update");

            // Show all tasks
            scheduler.ShowAllTasks();

            // Execute normal tasks
            scheduler.ExecuteTasks();

            // Execute priority tasks
            scheduler.ExecutePriorityTasks();

            // Undo last executed task
            scheduler.Undo();
            scheduler.Undo();
        }
    }
}
