using System;
namespace Task6._2{
    public class TransfrTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private double _amount;
        public bool _executed = false;
        public bool _success = false;
        public bool _reversed = false;
        public TransfrTransaction(Account toAccount, Account formAccount, double amount)
        {
            _fromAccount = formAccount;
            _toAccount = toAccount;
            this._amount = amount;
            _deposit = new DepositTransaction(toAccount, _amount);
            _withdraw = new WithdrawTransaction(formAccount, _amount);
            //_withdraw.execute();
        }
        public void print()
        {
            Console.WriteLine("TRANSFER DETAILS");
            Console.WriteLine("****");
            Console.WriteLine("FROM :" + this._fromAccount._name);
            Console.WriteLine("TO :" + this._toAccount._name);

            Console.WriteLine("Ammount :" + this._amount);
            Console.WriteLine("Executed :" + this._executed);
            //Console.WriteLine("Success :" + this._success);
            Console.WriteLine("Reversed :" + this._reversed);
            _deposit.print();
            _withdraw.print();
        }
        public void execute()
        {
            bool depositOkay;
            bool withdrawOkay;
            if (_executed == true)
            {
                throw new System.InvalidOperationException("Transfer already executed");
            }
            else
            {
                _executed = true;

                _withdraw.execute();

               /// withdrawOkay = _withdraw._success;

                if (_withdraw._success != true)
                {
                    _withdraw.Rollback();

                    throw new System.InvalidOperationException("CAnnot withdraw");
                    // return;
                }
                _deposit.execute();
                //depositOkay = _deposit._success;
                //depositOkay = _deposit._success;
                if (_deposit._success != true)
                {
                    throw new System.InvalidOperationException("Cannot deposit");
                    _withdraw.Rollback();
                }
            }
            if (_deposit._success && _withdraw._success)
            {
                this._success = true;
            }
        }
        public void Rollback()
        {
            if (_success)
            {
                _withdraw.Rollback();
                _deposit.Rollback();
            }
            else
            {
                throw new System.InvalidOperationException("Cannot roll bacxk transfer");
            }
        }
    }
}