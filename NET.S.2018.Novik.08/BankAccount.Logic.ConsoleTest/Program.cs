using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Logic.Services;
using BankAccount.Logic.Factories;

namespace BankAccount.Logic.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                (new Program()).DoSomething();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DoSomething()
        {
            var accountFactory = new BankAccountFactory();
            var storageFactory = new BankAccountStorageFactory();
            var bankService = new BankAccountService(storageFactory);

            //AddAccountsToService(bankService, accountFactory);
            Console.WriteLine(bankService);
        }

        public void AddAccountsToService(IBankAccountService bankService, IBankAccountFactory accountFactory)
        {
            BankAccount account1 = accountFactory.GetInstance(1, "Khenichi Samura", 0, 0, TypeBankAccount.Base);
            BankAccount account2 = accountFactory.GetInstance(2, "Novik Ilya", 2000, 0, TypeBankAccount.Golden);
            BankAccount account3 = accountFactory.GetInstance(3, "Robert Martin", 0, 0, TypeBankAccount.Golden);

            account3.DepositMoney(1000);
            
            bankService.Add(account1);
            bankService.Add(account2);
            bankService.Add(account3);

            bankService.Save();
        }
    }
}
