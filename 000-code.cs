using System;

namespace Task6._2
{
    class Program
    {
        public enum Option{
            Add,
            Find,
            Deposit,
            Transfer,
            Withdraw,
            Exit
        }
        static void DoWithdraw(Bank bank)
        {
           // Console.WriteLine("enter accoubnt name");
            Account account = findAccount(bank);
            //bool result = false;
            Console.WriteLine("Enter withdraw amount : ");
            double amount = Convert.ToDouble(Console.ReadLine());
            WithdrawTransaction withdrawObj = new WithdrawTransaction(account, amount);
            bank.executeTransaction(withdrawObj);
            //withdrawObj.execute();
            //withdrawObj.print();
            /*result = account.Withdraw(amount);
            if (result == true)
            {
                Console.WriteLine("Success!!");
            }
            else
            {
                Console.WriteLine("FAILED!!!");
            }*/
        }
        static void doTransfer(Bank bank)
        {
            Console.WriteLine("from acount:");

            Account fromAccount = findAccount(bank);
            Console.WriteLine("to acount:");
            Account toAccount = findAccount(bank);

            Console.WriteLine("transfer amount :");
            double amount = Convert.ToDouble(Console.ReadLine());
            TransfrTransaction transaction = new TransfrTransaction(toAccount, fromAccount, amount);
            //transaction.execute();
            //transaction.print();
            bank.executeTransaction(transaction);
        }
        static void DoDeposit(Bank bank)
        {
            //bool result;
            //Console.WriteLine("Enter account name");
            //string accountName = Console.ReadLine();
            Account account = findAccount(bank);
            Console.WriteLine("Enter deposit amount : ");
            double amount = Convert.ToDouble(Console.ReadLine());
            // account.Deposit(amount);
            DepositTransaction depositObj = new DepositTransaction(account, amount);
            //depositObj.execute();
            //depositObj.print();
            bank.executeTransaction(depositObj);
            /* result = account.Deposit(amount);
             if (result == true)
             {
                 Console.WriteLine("Success!!");
             }
             else
             {
                 Console.WriteLine("FAILED!!!");
             }*/
        }
        static public Account findAccount(Bank bank)
        {
            Console.WriteLine("enter account name");
            string accountName = Console.ReadLine();
            Account accontResult = bank.GetAccount(accountName);
            if (accontResult == null)
            {
                Console.WriteLine("account not found");
            }
            return accontResult;
        }
        static public void doAddAccount(Bank bank)
        {
            Console.WriteLine("NAME:");
            string name = Console.ReadLine();
            Console.WriteLine("BALANCE:");

            double balance = Convert.ToInt32(Console.ReadLine());
            Account newAccount = new Account(name, balance);
            bank.AddAccount(newAccount);
        }
        static public Option DisplayMenu()
        {
            Console.WriteLine("BANK SYSTEM");
            Console.WriteLine("*****");
            Console.WriteLine("1. Add account");
            Console.WriteLine("2. find Account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. withdraw");
            Console.WriteLine("6. Exit");
           // var result = ;
           var result= Convert.ToInt32(Console.ReadLine());
            //Option return=new Option();
            return (Option)(result-1);
            //return return;
        }
        static void Main(string[] args)
        {
            Bank commonw = new Bank();
            Option userInput;

            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case Option.Add:
                        doAddAccount(commonw);
                        break;
                    case Option.Find:
                        findAccount(commonw);
                        break;
                    case Option.Deposit:
                        DoDeposit(commonw);
                        break;
                    case Option.Transfer:
                        doTransfer(commonw);
                        break;
                    case Option.Withdraw:
                        DoWithdraw(commonw);
                        break;
                }
            } while (userInput != Option.Exit);
            commonw.GetAccount("1").Print();
            commonw.GetAccount("2").Print();

            //commonw.ToString();
            //Console.WriteLine("Hello World!");
        }
    }
}
