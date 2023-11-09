namespace Classroom.SimpleBankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount(2000);
            Console.WriteLine($"Initializing new bank account with a balance of ${account.Balance} ");
            Console.WriteLine();
            Console.WriteLine();
            account.Deposit(767);
            Console.WriteLine();
            Console.WriteLine();
            account.Withdraw(2900);

        }

    }
}