using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountService : IEnumerable<BankAccount>
    {
        void Add(BankAccount account);

        void Remove(BankAccount account);

        void Save();
    }
}
