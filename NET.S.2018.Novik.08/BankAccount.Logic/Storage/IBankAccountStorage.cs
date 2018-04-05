using System;
using System.Collections.Generic;

namespace BankAccount.Logic.Storage
{
    public interface IBankAccountStorage
    {
        string Path { get; }

        IEnumerable<BankAccount> Load();

        void Save(IEnumerable<BankAccount> items);
    }
}
