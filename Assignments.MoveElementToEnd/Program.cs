
namespace Assignments.MoveElementToEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 };
            var toMove = 2;
            MoveElementToEnd(toMove, array);

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        static void MoveElementToEnd(int toMove, List<int> array)
        {

            // Implement logic to move element to the end of the list
            int indexElement = array.RemoveAll(x => x == toMove);
            // Find the index of the element
           for (int i = 0; i < indexElement; i++)
            {
                array.Add(toMove);
            }
            
        }
    }
}