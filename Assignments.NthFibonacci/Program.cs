namespace Assignments.NthFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 12;
            Console.WriteLine(CalculateFibonacci(num));
        }

        static int CalculateFibonacci (int fibonacci)
        {
            if (fibonacci == 0)
            {
                return 0;
            }
            else if (fibonacci == 1)
            {
                return 1;
            }
            else
            {
                int first = 0; int second = 1; int third = 0;

                for(int i = 2; i < fibonacci; i++)
                {
                    third = first + second; first = second; second = third;
                }
                return third;
            }
        }
    }
}