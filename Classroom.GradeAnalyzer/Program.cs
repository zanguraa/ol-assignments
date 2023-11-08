namespace Classroom.GradeAnalyzer
{
    internal class Program
    {
        static int gradeAverage;      
        static void Main(string[] args)
        {
            AverageGradeCalculator();
            LetterGradeCalculator();
        }
        public static void AverageGradeCalculator()
        {
            Console.WriteLine("Enter your grades separated by commas: ");
            var userGrades = Console.ReadLine();
            var gradesArray = userGrades.Split(",", StringSplitOptions.RemoveEmptyEntries);


            var gradeSum = 0;

            foreach (var gradeString in gradesArray)
            {
                var parsedGrade = int.TryParse(gradeString, out var grade);
                gradeSum += grade;
            }
             gradeAverage = gradeSum / gradesArray.Length;
            Console.WriteLine($"Average Grade: {gradeAverage.ToString()}");
        }
        public static void LetterGradeCalculator() 
        {
        switch (gradeAverage / 10)
            {
                case 10: case 9: Console.WriteLine("Letter grade: A"); break;
                case 8: Console.WriteLine("Letter grade: B"); break;
                case 7: Console.WriteLine("Letter grade: C"); break;
                case 6: Console.WriteLine("Letter grade: D"); break;
                default: Console.WriteLine("Letter grade: F"); break;
            }
        }
    }
}