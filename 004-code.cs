using System;
namespace Task6._2{
    public class DepositTransaction
    {
        private Account _account;
        private double _amount;
        public bool _executed = false;
        public bool _success = false;
        public bool _reversed = false;
        public DepositTransaction(Account account, double amount)
        {
            this._account = account;
            this._amount = amount;
        }
        public void print()
        {
            Console.WriteLine("DEPOSIT DETAILS");
            Console.WriteLine("****");
            Console.WriteLine("Account :" + this._account._name);
            Console.WriteLine("Ammount :" + this._amount);
            Console.WriteLine("Executed :" + this._executed);
            Console.WriteLine("Success :" + this._success);
            Console.WriteLine("Reversed :" + this._reversed);
        }
        public void execute()
        {
            //this._account._balance += this._amount;
            if (this._executed == true)
            {
                throw new System.InvalidOperationException("Transaction already attempted");

            }
            /*if (this._account._balance < this._amount)
            {
                throw new System.InvalidOperationException("Insufficiant funds");
            }*/
            bool withdrawOkay = this._account.Deposit(this._amount);
            if (withdrawOkay == true)
            {
                this._success = true;
            }
            this._executed = true;
        }
        public void Rollback()
        {
            if (this._success == true && this._reversed != true)
            {
                this._account.Deposit(this._amount);
                this._reversed = true;
            }
            else
            {
                throw new System.InvalidOperationException("Transaction not finalised or already reversed");
            }
        }
    }
}