using BankAccount.Logic.Storage;
using System;

namespace BankAccount.Logic.Factories
{
    public class BankAccountStorageFactory : IBankAccountStorageFactory
    {
        public IBankAccountStorage GetInstance()
        {
            return new BankAccountStorageBinary("storage.dat", new BankAccountFactory());
        }
    }
}
