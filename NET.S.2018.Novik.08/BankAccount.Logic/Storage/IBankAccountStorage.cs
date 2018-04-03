using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Logic.Storage
{
    public interface IBankAccountStorage
    {
        IEnumerable<BankAccount> Load();

        void Save(IEnumerable<BankAccount> items);
    }
}
