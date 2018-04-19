using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Repositories;
using BLL.BusinessModels;
using BLL.Factories;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;
using System;

namespace DependencyResolver
{
    public class NinjectConfig
    {
        public readonly IKernel Kernel;

        public NinjectConfig()
        {
            this.Kernel = new StandardKernel();
            this.Kernel.Bind<IBankAccountStorage>().To<BankAccountStorageBinary>().WithConstructorArgument("1.txt");
            this.Kernel.Bind<IBankAccountFactory>().To<BankAccountFactory>()
                .WithPropertyValue("ToWithdraw", new WithdrawBonusPoints()).WithPropertyValue("ToDeposit", new DepositBonusPoints()); 
            this.Kernel.Bind<IBankAccountService>().To<BankAccountService>();
            this.Kernel.Bind<IGeneratorId>().To<GeneratorId>();
            this.Kernel.Bind<ICalculatorBonusPoints>().To<WithdrawBonusPoints>();
        }       
    }
}
