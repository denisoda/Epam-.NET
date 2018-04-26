using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Exceptions;
using BLL.Interface.Exceptions;
using BLL.Mappers;
using BLL.Repositories;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.Factories;
using NUnit.Framework;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
namespace BLL.Tests
{
    [TestFixture]
    class BankAccountServiceTests
    {
        [Test]
        [TestCase(1, "Novik Ilya", 0, 0, TypeBankAccount.Base)]
        [TestCase(2, "Sasha White", 0, 0, TypeBankAccount.Golden)]
        [TestCase(3, "John Snow", 0, 0, TypeBankAccount.Platinum)]
        [TestCase(4, "Hacyto Yorokatcy", 0, 0, TypeBankAccount.Base)]
        public void BankAccountServiceTest_Add_BankAccount_Succed(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type)
        {
            Mock<ICalculatorBonusPoints> mockBonusPointsToWithfraw = new Mock<ICalculatorBonusPoints>();
            mockBonusPointsToWithfraw
                .Setup(m => m.GetBonusPoints(It.IsAny<BankAccount>(), It.IsAny<Decimal>()))
                .Returns<BankAccount, decimal>((bankAccount, amount) => bankAccount.BonusPointsWithdraw);

            Mock<ICalculatorBonusPoints> mockBonusPointsToDeposit = new Mock<ICalculatorBonusPoints>();
            mockBonusPointsToDeposit
                .Setup(m => m.GetBonusPoints(It.IsAny<BankAccount>(), It.IsAny<Decimal>()))
                .Returns<BankAccount, decimal>((bankAccount, amount) => bankAccount.BonusPointsDeposit);

            Mock<IBankAccountFactory> mockBankAccountFactory = new Mock<IBankAccountFactory>();
            mockBankAccountFactory
                .Setup(m => m.GetInstance(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<TypeBankAccount>()))
                .Returns<int, string, decimal, int, TypeBankAccount>((idF, nameF, balanceF, bonus, typeF) => GetInstance(idF, nameF, balanceF, bonus, typeF, mockBonusPointsToWithfraw.Object, mockBonusPointsToDeposit.Object));

            BankAccountMapper mapper = new BankAccountMapper(mockBankAccountFactory.Object);
            Mock<IBankAccountStorage> mockBankAccountStorage = new Mock<IBankAccountStorage>();
            mockBankAccountStorage
                .Setup(m => m.Load())
                .Returns(() =>
                {
                    return new List<AccountDTO>();
                });
            mockBankAccountStorage
                .Setup(m => m.Save(It.IsAny<IEnumerable<AccountDTO>>()));

            IBankAccountService service = new BankAccountService(mockBankAccountStorage.Object, mapper);

            service.Add(new BaseAccount(1, name, balance, bonusPoints));
            Assert.AreEqual(1, service.Count());
        }

        public BankAccount GetInstance(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type, ICalculatorBonusPoints toDeposit, ICalculatorBonusPoints toWithdraw)
        {
            switch (type)
            {
                case TypeBankAccount.Base:
                    return new BaseAccount(id, name, balance, bonusPoints, toWithdraw, toDeposit);

                case TypeBankAccount.Golden:
                    return new GoldAccount(id, name, balance, bonusPoints, toWithdraw, toDeposit);

                case TypeBankAccount.Platinum:
                    return new PlatinumAccount(id, name, balance, bonusPoints, toWithdraw, toDeposit);

                default:
                    return new BaseAccount(id, name, balance, bonusPoints, toWithdraw, toDeposit);
            }
        }
    }
}
