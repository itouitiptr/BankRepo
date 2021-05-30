using System;
using Bank;
using NUnit.Framework;
using NSubstitute;

namespace BankTest
{
    [TestFixture]
    public class PrintTest
    {
        private readonly IConsole console = Substitute.For<IConsole>();
        private readonly IDate date = Substitute.For<IDate>();

        [Test]
        public void AccountPrintStatement()
        {
            var account = new Account(
                new TransactionRepository(), date, console);

            date.Now().Returns(new DateTime(2012, 01, 10));
            account.Deposit(1000);

            date.Now().Returns(new DateTime(2012, 01, 13));
            account.Deposit(2000);

            date.Now().Returns(new DateTime(2012, 01, 14));
            account.Withdraw(500);

            account.PrintStatement();

            Assert.AreEqual(
                account.CurrentBalance,
                2500);

            Received.InOrder(() =>
            {
                console.Received().PrintLine("<i>1</i>Date || Amount || Balance ");
                console.Received().PrintLine("<i>2</i>14/01/2012 || -500 || 2500");
                console.Received().PrintLine("<i>3</i>13/01/2012 || 2000 || 3000");
                console.Received().PrintLine("<i>4</i>10/01/2012 || 1000 || 1000");
            });
        }
    }

    
}
