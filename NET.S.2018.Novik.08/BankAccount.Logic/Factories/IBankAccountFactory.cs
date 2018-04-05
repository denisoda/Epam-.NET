using System;

namespace BankAccount.Logic.Factories
{
    public interface IBankAccountFactory
    {
        BankAccount GetInstance(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type);
    }
}
