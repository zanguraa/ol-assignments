namespace GroupAndProjectRandomizer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

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

            Random random = new Random();
            people = people.OrderBy(x => random.Next()).ToList();

            List<List<string>> groups = new List<List<string>>();
            for (int i = 0; i < people.Count; i += 2)
            {
                List<string> group = people.Skip(i).Take(2).ToList();
                groups.Add(group);
            }

            DisplayGroups(groups);

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