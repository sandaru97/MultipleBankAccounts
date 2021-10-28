using System;

namespace Task6._2
{
    public class Account
    {
        public double _balance;
        public string _name;
        public string Name
        {
            get => _name;

        }

        public Account(string name, double balance)
        {
            _name = name;
            _balance = balance;
        }
        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;

                return true;
            }
            return false;
        }
        public bool Withdraw(double amount)
        {
            if (amount <= this._balance)
            {
                _balance -= amount;

                return true;
            }
            return false;
        }
        public void Print()
        {
            Console.WriteLine("NAME: " + _name + "BALANCE: " + _balance);
        }
    }
}