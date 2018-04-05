using BankAccount.Logic.Storage;
using System;

namespace BankAccount.Logic.Factories
{
    public interface IBankAccountStorageFactory
    {
        IBankAccountStorage GetInstance();
    }
}
