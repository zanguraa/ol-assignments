namespace Assignments.ExtensionFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2020, 2, 27);
            DateTime now = DateTime.Now;
            DateTime compareDate = date.DateTimeMin(now);
            DateTime compareDateMax = date.DateTimeMax(now);
            Console.WriteLine("min" + compareDate);
            Console.WriteLine("max" + compareDateMax);
            DateTime firstDayOfMonth = date.BeginingOfMonth();
            DateTime lastDayOfMonth = date.EndOfMonth();
            Console.WriteLine($"the first day of month: {firstDayOfMonth}");
            Console.WriteLine($"the last day of this month: {lastDayOfMonth}");




            //Console.WriteLine("Hello, World!");
            //var number = "01.2020";
            //string stringExample = "extension functions";
            //number.IsNumber();
            //Console.WriteLine($"Is number or not: {number.IsNumber()} ");
            //Console.WriteLine($"Is Date or not: {number.IsDate()}");

            //string[] stringArrayExample = stringExample.ToWords();
            //foreach ( string words in stringArrayExample )
            //{
            //    Console.WriteLine( words );
            //}

            //var hash = stringExample.CalculateHash();
            //Console.WriteLine($"This is HASH256: {hash}");
            //string filePath = @"C:\Users\Zangura\Downloads\newCreated\tests.txt";
            //stringExample.SaveToFile(filePath);
            //Console.WriteLine($"File saved successfully at: {filePath}");

            //double percent = 3.9;
            //Console.WriteLine(percent.ToPercent());
            //Console.WriteLine($"rounded to down: {percent.RoundDown()}");
            //Console.WriteLine($"to decimal: {percent.ToDecimal()}");
            //double numb = 23;
            //bool compare = numb.IsGreater( 233 );
            //bool compareLess = numb.IsLess(233);
            //Console.WriteLine(compare);
            //Console.WriteLine(compareLess);
        }
    }
}