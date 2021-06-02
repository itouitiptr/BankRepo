using System.Collections.Generic;
using Model;

namespace Repository
{
    public class TransactionRepository
    {
        private readonly List<Transaction> transactions =  new List<Transaction>();
        
        public void AddDeposit(Transaction deposit)
        {
            this.transactions.Add(deposit);
        }

        public void AddWithdrawal(Transaction withdrawal)
        {
            this.transactions.Add(withdrawal);
        }

        public List<Transaction> GetTransactions()
        {
            return this.transactions;
        }
    }
}