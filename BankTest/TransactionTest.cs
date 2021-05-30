using System;
using Bank;
using NUnit.Framework;

namespace BankTest
{
    [TestFixture]
    class TransactionTest
    {
        [Test]
        public void FormatDepositTransaction()
        {
            var transaction = new Transaction(500, new DateTime(2021, 1, 1));

            Assert.AreEqual(
                "01/01/2021 || 500",
                transaction.PrintOutput());
        }

        [Test]
        public void FormatWithdrawTransaction()
        {
            var transaction = new Transaction(-500, new DateTime(2021, 1, 1));

            Assert.AreEqual(
                "01/01/2021 || -500",
                transaction.PrintOutput());
        }
    }
}
