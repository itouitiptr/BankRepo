using System;
using System.Collections.Generic;

namespace Bank
{
    public class Account : IAccountService {

        private readonly TransactionRepository allTransactions;
        private readonly IDate date;
        private readonly IConsole console;

        public int CurrentBalance
        {
            get
            {
                int balance = 0;
                foreach (var transaction in allTransactions.GetTransactions())
                {
                    balance += transaction.Amount;
                }

                return balance;
            }
        }

        public Account(TransactionRepository allTransactions, IDate date, IConsole console)
        {
            this.allTransactions = allTransactions;
            this.date = date;
            this.console = console;
        }

        public void Deposit(int amount){
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit must be positive");
            }
            var deposit = new Transaction(amount, this.date.Now());
            this.allTransactions.AddDeposit(deposit);
        }
        public void Withdraw(int amount){
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal must be positive");
            }
            if (CurrentBalance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            var withdrawal = new Transaction(-amount, this.date.Now());
            this.allTransactions.AddWithdrawal(withdrawal);
        }
        public void PrintStatement(){
            this.console.PrintLine("<i>1</i>Date || Amount || Balance ");
            this.PrintTransactions();
        }

        private void PrintTransactions()
        {
            List<Transaction> transactions = this.allTransactions.GetTransactions();

            var formattedTransactions =
                this.FormatTransactions(transactions);

            foreach (var formattedTransaction in formattedTransactions)
            {
                this.console.PrintLine(formattedTransaction);
            }
        }

        private List<string> FormatTransactions(List<Transaction> transactions)
        {
            int balance = 0;
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