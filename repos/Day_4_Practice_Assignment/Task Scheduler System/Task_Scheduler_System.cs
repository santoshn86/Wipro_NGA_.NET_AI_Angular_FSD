using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Scheduler_System
{
    internal class Task_Scheduler_System
    {
        // Store all tasks
        private List<string> allTasks = new List<string>();

        // Ensure unique tasks
        private HashSet<string> uniqueTasks = new HashSet<string>();

        // FIFO execution
        private Queue<string> taskQueue = new Queue<string>();

        // Undo (LIFO)
        private Stack<string> undoStack = new Stack<string>();

        // Priority-based tasks (sorted by priority)
        private SortedDictionary<int, string> priorityTasks = new SortedDictionary<int, string>();

        // Add Task
        public void AddTask(string task)
        {
            if (!uniqueTasks.Add(task))
            {
                Console.WriteLine($"Duplicate task ignored: {task}");
                return;
            }

            allTasks.Add(task);
            taskQueue.Enqueue(task);

            Console.WriteLine($"Task added: {task}");
        }

        // Add Priority Task
        public void AddPriorityTask(int priority, string task)
        {
            if (!uniqueTasks.Add(task))
            {
                Console.WriteLine($"Duplicate task ignored: {task}");
                return;
            }

            priorityTasks[priority] = task;
            allTasks.Add(task);

            Console.WriteLine($"Priority Task added: {task} (Priority: {priority})");
        }

        // Execute Normal Tasks (FIFO)
        public void ExecuteTasks()
        {
            Console.WriteLine("\nExecuting Tasks (FIFO):");
            while (taskQueue.Count > 0)
            {
                string task = taskQueue.Dequeue();
                Console.WriteLine($"Executed: {task}");
                undoStack.Push(task);
            }
        }

        // Execute Priority Tasks (sorted order)
        public void ExecutePriorityTasks()
        {
            Console.WriteLine("\nExecuting Priority Tasks:");
            foreach (var task in priorityTasks)
            {
                Console.WriteLine($"Executed (Priority {task.Key}): {task.Value}");
                undoStack.Push(task.Value);
            }
        }

        // Undo Last Task
        public void Undo()
        {
            if (undoStack.Count == 0)
            {
                Console.WriteLine("No task to undo.");
                return;
            }

            string lastTask = undoStack.Pop();
            Console.WriteLine($"Undo Task: {lastTask}");
        }

        // Show All Tasks
        public void ShowAllTasks()
        {
            Console.WriteLine("\nAll Tasks:");
            foreach (var task in allTasks)
            {
                Console.WriteLine(task);
            }
        }
    }

}
