using System;

namespace Bank
{
    public interface IAccountService {
        void Deposit(int amount);
        void Withdraw(int amount);
        void PrintStatement();
    }
}