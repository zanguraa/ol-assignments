namespace Classroom.SimpleBankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var account = new BankAccount(2000);
            account.Deposit(767);

        }

    }
}