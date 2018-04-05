using System;
using System.Collections.Generic;

namespace BankAccount.Logic.Services
{
    public interface IBankAccountService
    {
        void Add(BankAccount account);

        void Remove(BankAccount account);

        void Save();
    }
}
