namespace Assignments.VowelOrNot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Please Enter letter: ");
            var userResponse = Console.ReadLine();
            if (char.TryParse(userResponse, out letter))
            {
                Console.WriteLine(CheckVowelOrNot(letter));
            }  
        }
        static bool CheckVowelOrNot(char letter)
        {
            int[] vowelChars = { 'a', 'e', 'i', 'o', 'u', 'ა', 'ე', 'ი', 'ო', 'უ' };
           if (vowelChars.Contains(letter))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}