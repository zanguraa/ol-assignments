namespace Classroom.GradeAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your grades separated by commas: ");
            var userGrades = Console.ReadLine();
            var gradesArray = userGrades.Split(",", StringSplitOptions.RemoveEmptyEntries);


            var gradeSum = 0;

            foreach ( var gradeString in gradesArray )
            {
                var parsedGrade = int.TryParse(gradeString, out var grade );

                gradeSum += grade;
            }
           
            var gradeAvvarage = gradeSum / gradesArray.Length;

            Console.WriteLine(gradeAvvarage.ToString());
           
        }
    }
}