using System;

namespace SimpleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                playWithAccount();          
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
                Console.ReadKey();
            }
        }


        static public void playWithAccount()
        {
            Console.WriteLine("Enter your name:");
            var Name  = Console.ReadLine();
            Console.WriteLine("Enter the amount of your first deposit: ");
            int Money = int.Parse(Console.ReadLine());
            BankAccount bankAccount = new BankAccount(Name, Money);
            do
            {
                
                bankAccount.DisplayInfo();
                int selection = int.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter deposit amount: ");
                    int deposit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Deposit description (If empty, press Enter)");
                    string depoDescr = Console.ReadLine();
                    bankAccount.MakeDeposit(deposit, DateTime.Now, depoDescr);

                } else if (selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter withdraw amount: ");
                    int withdraw = int.Parse(Console.ReadLine());
                    Console.WriteLine("Withdraw description (If empty, press Enter)");
                    string withDescr = Console.ReadLine();
                    bankAccount.MakeWithdraw(withdraw, DateTime.Now, withDescr);

                } else if (selection == 3)
                {
                    Console.Clear();
                    Console.WriteLine(bankAccount.Balance);

                } else if (selection == 4)
                {
                    Console.Clear();
                    bankAccount.ListTransactionHistory();

                } else if (selection == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter credit amount: ");
                    int cre = int.Parse(Console.ReadLine());
                    Console.WriteLine("Credit description (If empty, press Enter)");
                    string creDescr = Console.ReadLine();
                    bankAccount.Credit(cre, DateTime.Now, creDescr);

                } else if (selection == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Enter credit payment amount: ");
                    int payment = int.Parse(Console.ReadLine());
                    Console.WriteLine("Payment description (If empty, press Enter)");
                    string paymDescr = Console.ReadLine();
                    bankAccount.creditPayment(payment, DateTime.Now, paymDescr);
                } else if (selection == 7)
                {
                    bankAccount.showCredit();
                }
                else if (selection == 8)
                {
                    break;
                }
            } while(true);
        }

    }
}
