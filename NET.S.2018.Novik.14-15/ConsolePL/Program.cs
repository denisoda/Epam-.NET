using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Exceptions;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private readonly IKernel kernel = new NinjectConfig().Kernel;
        private IBankAccountFactory accountFactory;
        private IBankAccountService bankService;
        static void Main(string[] args)
        {
            try
            {
                (new Program()).DoSomething();
            }
            catch (NotEnoughMoneyException NotMoneyExp)
            {
                Console.WriteLine(NotMoneyExp.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DoSomething()
        {
            this.accountFactory = kernel.Get<IBankAccountFactory>();
            this.bankService = kernel.Get<IBankAccountService>();

            Console.WriteLine("1 - Create new bank account");
            Console.WriteLine("2 - Deposit");
            Console.WriteLine("3 - Withdraw");
            Console.WriteLine("4 - Get info about some account");
            while(true)
            {
                var choice = Console.ReadKey();
                if (ConsoleKey.D1 == choice.Key)
                {

                }
            }

            //AddAccountsToService(bankService, accountFactory);
            Console.WriteLine(bankService);
        }

        public void AddAccountsToService(IBankAccountService bankService, IBankAccountFactory accountFactory)
        {
            var generatorId = this.kernel.Get<IGeneratorId>();
            
            BankAccount account1 = accountFactory.GetInstance(generatorId.GenerateId(0), "Khenichi Samura", 0, 0, TypeBankAccount.Base);
            BankAccount account2 = accountFactory.GetInstance(generatorId.GenerateId(1), "Novik Ilya", 2000, 0, TypeBankAccount.Golden);
            BankAccount account3 = accountFactory.GetInstance(generatorId.GenerateId(2), "Robert Martin", 0, 0, TypeBankAccount.Golden);

            account3.DepositMoney(1000);
            
            bankService.Add(account1);
            bankService.Add(account2);
            bankService.Add(account3);

            bankService.Save();
        }
    }
}
