namespace Classroom.TaskTracker
{
    internal class Program
    {
        private static string userChoice = "";
        private static TaskTracker _taskTracker = new TaskTracker();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Task Tracker");
                Welcome();
                UserChoice();
                if (userChoice == "4")
                {
                    break;
                }
            }

        }

        private static void Welcome()
        {
            Console.WriteLine("\nSelect an option: \n");
            Console.WriteLine("1. Add Task\r\n2. Update Task Status\r\n3. View All Tasks\r\n4. Exit ");
            userChoice = Console.ReadLine();
        }

        private static void UserChoice()
        {
            switch (userChoice)
            {
                case "1": AddTask(); break;
                case "2": UpdateTask(); break;
                case "3": ViewAllTask(); break;
            }
        }

        private static void AddTask()
        {
            Console.WriteLine("Enter task description: ");
            var userEnteredTask = Console.ReadLine();
            string defaultStatus = "pending";
            Console.WriteLine($"Task {userEnteredTask} added with status {defaultStatus}.");
            _taskTracker.AddTask(userEnteredTask, defaultStatus);
        }
        private static void UpdateTask()
        {
            Console.WriteLine("Enter task description to update: ");
            var userUpdatedTask = Console.ReadLine();
            Console.WriteLine("Enter new status: ");
            string updatedTask = Console.ReadLine();
            _taskTracker.UpdateTask(userUpdatedTask, updatedTask);
        }
        private static void ViewAllTask()
        {
            _taskTracker.PrintTasks();
        }
    }
}