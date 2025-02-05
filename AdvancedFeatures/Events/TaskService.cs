using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Events
{
    public class TaskService
    {
        //Task Created
        public delegate void TaskCreatedEventHandler(object source, EventArgs args);
        public event TaskCreatedEventHandler TaskCreated;

        //Task completed
        public delegate void TaskCompletedEventHandler(object source, EventArgs args);
        public event TaskCompletedEventHandler TaskCompleted;
        public void PrepareTask(Task order)
        {
            Console.WriteLine($"Preparing your task '{order.Title}', please wait...");
            Thread.Sleep(4000);
            OnTaskCreated();
        }

        public void CompleteTask(Task task)
        {
            Console.WriteLine($"Task {task.Title} completed.");
            Thread.Sleep(4000);
            OnTaskCompleted();
        }

        protected virtual void OnTaskCompleted()
        {
            Console.WriteLine("Task completed;");
            if (TaskCompleted != null)
                TaskCompleted(this, null);
        }

        protected virtual void OnTaskCreated()
        {
            Console.WriteLine("Task created;");
            if (TaskCreated != null)
                TaskCreated(this, null);
        }
    }
}
