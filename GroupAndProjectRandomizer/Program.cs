namespace GroupAndProjectRandomizer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    enum Project
    {
        BankingSystem,
        EmployeeBonusManagement,
        BudgetingAndExpenseTracker,
        FeatureVotingSystem
    }

    class Program
    {
        static void Main()
        {
            List<string> people = new List<string>
            {
                "Avtandil Achelashvili",
                "Gaga Demetrashvili",
                "Giorgi Mshvildadze",
                "Dachi Lekborashvili",
                "Valeri Zanguri",
                "Zura Iakobashvili",
                "Irakli Svanidze",
                "Luka Karzhalovi",
                "Luka Makharadze",
                "Mate Tsaava",
                "Mikheil Gelenidze",
                "Nino Dautashvili",
                "Shota Medzvelia",
                "Shota Khizanishvili",
                "Jaba Chkheidze",
                "Sopio Papiashvili"
            };

            Console.WriteLine("Enter the size of each group (2 or 3):");
            int groupSize;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out groupSize) && (groupSize == 2 || groupSize == 3))
                    break;
                else
                    Console.WriteLine("Invalid input. Please enter 2 or 3.");
            }

            Random random = new Random();
            people = people.OrderBy(x => random.Next()).ToList();

            List<List<string>> groups = new List<List<string>>();
            int remainingPeople = people.Count;

            while (remainingPeople > 0)
            {
                int currentGroupSize = (remainingPeople > groupSize || remainingPeople == groupSize) ? groupSize : remainingPeople;
                List<string> group = people.Take(currentGroupSize).ToList();
                groups.Add(group);

                people = people.Skip(currentGroupSize).ToList();
                remainingPeople -= currentGroupSize;
            }

            AssignProjectsToGroups(groups);
            DisplayGroups(groups);
        }

        static void AssignProjectsToGroups(List<List<string>> groups)
        {
            Project[] projects = (Project[])Enum.GetValues(typeof(Project));
            Random random = new Random();

            projects = projects.OrderBy(x => random.Next()).ToArray();

            int projectsAssigned = 0;
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].Add($"Project: {projects[projectsAssigned]}");
                projectsAssigned++;

                if (projectsAssigned == projects.Length)
                {
                    projects = projects.OrderBy(x => random.Next()).ToArray();
                    projectsAssigned = 0;
                }
            }
        }

        static void DisplayGroups(List<List<string>> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"Group {i + 1}:");

                foreach (var person in groups[i])
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine();
            }
        }
    }
}
