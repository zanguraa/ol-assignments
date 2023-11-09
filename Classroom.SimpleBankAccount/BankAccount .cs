using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.SimpleBankAccount
{
    internal class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal balance)
        {
            if (balance < 0)
            {
                throw new ArgumentException("Can not be less then zero");
            }
            this.Balance = balance;
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            { throw new ArgumentException("Can not be less then zero"); }
            Balance += amount;
            Console.WriteLine($"Depositing: {amount}...");
            Console.WriteLine($"New balance is: ${Balance}");
        }
        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"Attempting to withdraw: {amount}...");

            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be less than zero");
            }
            else if (amount > Balance)
            {
                throw new ArgumentException("Insufficient funds. Transaction denied.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawing ${amount}...");
                Console.WriteLine($"New balance is ${Balance}");
                Console.WriteLine();
                Console.WriteLine($"Current balance is ${Balance}");
            }
        }
    }
}
