using System;
using NUnit.Framework;
using Model;
using Repository;

namespace BankServiceTest
{
    public class AccountTest
    {
        private TransactionRepository transactionRepository;
        private Account account;

        [SetUp]
        public void SetUp()
        {
            transactionRepository = new TransactionRepository();
            account = new Account( transactionRepository );
        }

        [Test]
        public void MakeDeposit()
        {
            account.Deposit(500);

            Assert.AreEqual(
                transactionRepository.GetTransactions()[0].PrintOutput(),
                new Transaction(500, DateTime.Now).PrintOutput());
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

        [Test]
        public void AccountPrintStatement()
        {
            var account = new Account(
                new TransactionRepository());

            account.Deposit(1000);

            String result = account.PrintStatement();

            Assert.AreEqual( // this test might depend on OS because of the DateTime!
                result,
                "<i>1</i>Date || Amount || Balance " + "<i>2</i>" + DateTime.Now.ToString("dd/MM/yyyy") + " || 1000 || 1000");

        }
    }
}