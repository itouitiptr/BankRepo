using System;

namespace Model
{
    public class Transaction
    {
        public int Amount { get; }
        private DateTime date { get; }

        public Transaction(int amount, DateTime date)
        {
            this.Amount = amount;
            this.date = date;
        }

        public string PrintOutput()
        {
            return $"{this.date.ToString("dd/MM/yyyy")} {"||"} {this.Amount}";
        }
    }
}