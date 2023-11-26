using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.TaskTracker
{
    internal class TaskTracker
    {
        public Dictionary<string, Task> tasks = new Dictionary<string, Task>();

        public void AddTask(string taskName, string taskStatus)
        {
            Task newTask = new Task { TaskName = taskName, TaskStatus = taskStatus };
            tasks.Add(taskName, newTask);
        }
    }
}
