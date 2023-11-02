namespace Assignments.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 0, 1, 5, 76, 234, 678 };
            var target = 76;
            Console.WriteLine("");
           int result = BinarySearch(array, target);
            if (result != -1)
            {
                Console.WriteLine($"Element {target} found at index {result}.");
            }
            else
            {
                Console.WriteLine($"{target} not found in the array!");

            }
        }

       public static int BinarySearch(int[] array, int target)
        {
           int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}