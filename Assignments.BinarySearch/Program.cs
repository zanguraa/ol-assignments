namespace Assignments.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 0, 1, 5, 76, 234, 678 };
            var target = 75;
            Console.WriteLine("");
            Console.WriteLine(BinarySearch(array, target));
        }

        static int BinarySearch(int[] array, int target)
        {
            if (!array.Contains(target))
            {
                return -1;
            }
            else
            {
                var index = Array.IndexOf(array, target);
                return index;
            }
        }
    }
}