using System;
using System.Collections.Generic;
namespace Task6._2
{
    public class Bank
    {
        List <Account> _accounts=new List<Account>();
        public Bank(){}
        public void AddAccount(Account account){
            _accounts.Add(account);
        }
        public Account GetAccount(string name){
            //for each account in _accounts{}
            foreach(Account account in _accounts){
                if(account._name==name){
                    return account;
                }
            }
                            return null;

        }
        public void executeTransaction(TransfrTransaction transaction){
            transaction.execute();
        }
        public void executeTransaction(WithdrawTransaction transaction){
            transaction.execute();
        }
        public void executeTransaction(DepositTransaction transaction){
            transaction.execute();
        }

    }
}