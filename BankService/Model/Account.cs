using System;
using System.Collections.Generic;
using Repository;

namespace Model
{
    public class Account : IAccountService {

        private readonly TransactionRepository allTransactions;
        private int _balance = 0;
        public int Balance
        {
            get
            {
                foreach (var transaction in allTransactions.GetTransactions())
                {
                    _balance += transaction.Amount;
                }
                return _balance;
            }
        }

        public Account(TransactionRepository allTransactions)
        {
            this.allTransactions = allTransactions;
        }

        public void Deposit(int amount){
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit must be positive");
            }
            var deposit = new Transaction(amount, DateTime.Now);
            this.allTransactions.AddDeposit(deposit);
        }
        public void Withdraw(int amount){
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            var withdrawal = new Transaction(-amount, DateTime.Now);
            this.allTransactions.AddWithdrawal(withdrawal);
        }
        public String PrintStatement(){
            String statement = "<i>1</i>Date || Amount || Balance ";
            foreach(String stm in this.FormatTransactions()){
                statement += stm;
            }
            return statement;
        }

        private List<string> FormatTransactions()
        {
            int balance = 0;
            List<Transaction> transactions = this.allTransactions.GetTransactions();
            List<string> formattedTransactions = new List<string>();
            int counter = transactions.Count + 1;

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
                formattedTransactions.Add(
                    $"<i>{counter}</i>{transaction.PrintOutput()} || {balance}");
                counter = counter - 1; 
            }

            formattedTransactions.Reverse();

            return formattedTransactions;
        }
    }
}