using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank
{
    class BankAccount
    {
        private List<Transaction> AllTransactions = new List<Transaction>();

        private static UInt32 accountNumberSeed = 23232323;
        public UInt32 Number { get; }
        public string Owner { get; set; }
        private decimal credit;
        private decimal balance;

        public decimal Balance
        {
            get {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed++;
            Console.WriteLine($"Created new account with balance: {initialBalance}");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"{amount} has been deposited.");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You cannot deposit a negative amount.");
            }

            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);

        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"{amount} has been paid out.");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You cannot withdraw a negative amount");
            } else if (amount > balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Insufficient balance in the account.");
            }
            Transaction withdraw = new Transaction(-amount, date, note);
            AllTransactions.Add(withdraw);

        }

        public void ListTransactionHistory()
        {
            Console.WriteLine("Amount         Date          Description");
            foreach (var Transaction in AllTransactions)
            {
                Console.Write(Transaction.Amount + "  ");
                Console.Write(Transaction.Date + "  ");
                Console.WriteLine(Transaction.Note);
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\nSelect action: 1 - Deposit, 2 - Withdraw, 3 - Balance, 4 - Transaction history, 5 - Credit, 6 - Credit payment, 7 - Actual credit, 8 - Exit");
        }
        public void Credit(decimal amount, DateTime date, string note)
        {


            if (amount > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The maximum amount of credit is: 1000");
            }
            else if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount of credit must not be negative");
            }
            Console.WriteLine($"Amount {amount} has been added to balance.");
            Transaction creditt = new Transaction(amount, date, note);
                AllTransactions.Add(creditt);
                credit += amount;
            
        }
    
        public void creditPayment(decimal amount, DateTime date, string note)
        {
            if (amount > credit)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount of credit is less than the amount paid");
            }
            else if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount deposited must not be negative");
            }
              Console.WriteLine($"Amount {amount} has been deposited.");
              Transaction credpay = new Transaction(amount = -amount, date, note);
                AllTransactions.Add(credpay);
            credit -= amount;

        }
        public void showCredit()
        {
            Console.WriteLine(credit);
        }
    }
}
