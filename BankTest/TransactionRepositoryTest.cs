using System;
using System.Collections.Generic;
using Bank;
using NUnit.Framework;

namespace BankTest
{
    [TestFixture]
    class TransactionRepositoryTest
    {
        [Test]
        public void AddDeposit()
            {
                var repository = new TransactionRepository();

                var transaction = new Transaction(500, DateTime.Today);
                
                repository.AddDeposit(transaction);
                
                Assert.That(repository.GetTransactions().Contains(transaction));
            }

            [Test]
            public void AddWithdrawal()
            {
                var repository = new TransactionRepository();

                var transaction = new Transaction(-1300, DateTime.Today);

                repository.AddWithdrawal(transaction);

                Assert.That(repository.GetTransactions().Contains(transaction));

            }
        }

    
}
