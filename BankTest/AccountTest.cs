using System;
using Bank;
using NUnit.Framework;

namespace BankTest
{
    [TestFixture]
    public class AccountTest
    {
        private TransactionRepository transactionRepository;
        private Account account;

        [SetUp]
        public void SetUp()
        {
            IDate date = new DatePrinter();
            transactionRepository = new TransactionRepository();
            account = new Account( transactionRepository, date, new Printer());
        }

        [Test]
        public void MakeDeposit()
        {
            account.Deposit(500);

            Assert.AreEqual(
                transactionRepository.GetTransactions()[0].PrintOutput(),
                new Transaction(500, DateTime.Today).PrintOutput());
        }

        [Test]
        public void MakeWithdrawal()
        {
            Assert.Throws<System.InvalidOperationException>(delegate { account.Withdraw(200); });

            account.Deposit(200);
            account.Withdraw(200);

            Assert.AreEqual(
                transactionRepository.GetTransactions()[1].PrintOutput(),
                new Transaction(-200, DateTime.Today).PrintOutput());
        }
    }
}
