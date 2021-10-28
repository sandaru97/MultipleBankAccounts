using System;
namespace Task6._2
{
    public class WithdrawTransaction
    {
        private Account _account;
        private double _amount;
        public bool _executed = false;
        public bool _success = false;
        public bool _reversed = false;
        public WithdrawTransaction(Account account, double amount)
        {
            this._account = account;
            this._amount = amount;
        }
        public void print()
        {
            Console.WriteLine("WITHDRAW DETAILS");
            Console.WriteLine("****");
            Console.WriteLine("Account :" + this._account._name);
            Console.WriteLine("Ammount :" + this._amount);
            Console.WriteLine("Executed :" + this._executed);
            Console.WriteLine("Success :" + this._success);
            Console.WriteLine("Reversed :" + this._reversed);
        }
        public void execute()
        {
            if (_executed == true)
            {
                throw new System.InvalidOperationException("insufficuant funds");

            }
            this._executed = true;
            _success = this._account.Withdraw(this._amount);
            //{
            // this. = true;
            //}
        }
        public void Rollback()
        {
            if (this._success == true && this._reversed != true)
            {
                this._account.Deposit(_amount);
                this._reversed = true;
            }
            else
            {
                throw new System.InvalidOperationException("Transaction not finalised or already reversed");
            }
        }

    }
}