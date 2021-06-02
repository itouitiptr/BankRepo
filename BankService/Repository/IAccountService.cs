using System;

namespace Repository
{
    public interface IAccountService {
        void Deposit(int amount);
        void Withdraw(int amount);
        String PrintStatement();
    }
}