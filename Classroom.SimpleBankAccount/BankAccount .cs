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
           if(amount < 0)
            { throw new ArgumentException("Can not be less then zero"); }
            Balance += amount;
            Console.WriteLine($"Depositing: {amount}");
            Console.WriteLine($"New balance is: ${Balance}");
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            Console.WriteLine();
        }

    }
}
