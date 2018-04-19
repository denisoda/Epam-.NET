using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using BLL.Factories;
using NUnit.Framework;
using Moq;
using System;

namespace BLL.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        [TestCase(1, "Novik Ilya", 0, 0, TypeBankAccount.Base)]
        public void BankAccountTest_Withdraw_BaseAccount(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type)
        {
            Mock<ICalculatorBonusPoints> mockBonusPointsToWithfraw = new Mock<ICalculatorBonusPoints>();
            mockBonusPointsToWithfraw
                .Setup(m => m.GetBonusPoints(It.IsAny<BankAccount>(), It.IsAny<Decimal>()))
                .Returns<BankAccount, decimal>((bankAccount, amount) => bankAccount.BonusPointsWithdraw);

            Mock<ICalculatorBonusPoints> mockBonusPointsToDeposit = new Mock<ICalculatorBonusPoints>();
            mockBonusPointsToDeposit
                .Setup(m => m.GetBonusPoints(It.IsAny<BankAccount>(), It.IsAny<Decimal>()))
                .Returns<BankAccount, decimal>((bankAccount, amount) => bankAccount.BonusPointsDeposit);

            //Mock<IBankAccountFactory> mockBankAccountFactory = new Mock<IBankAccountFactory>();
            //mockBankAccountFactory
            //    .Setup(m => m.GetInstance(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<TypeBankAccount>()))
            //    .Returns<int, string, decimal, int, TypeBankAccount>((id, name, balance, bonus, type) => CalculateBankAccount(id, name, balance, bonus, type, mockBonusPointsToWithfraw.Object, mockBonusPointsToDeposit.Object));


            IBankAccountFactory factory = new BankAccountFactory()
            {
                ToDeposit = mockBonusPointsToDeposit.Object,
                ToWithdraw = mockBonusPointsToWithfraw.Object
            };

            BankAccount account = factory.GetInstance(id, name, balance, bonusPoints, type);
            account.DepositMoney(1000);

            Assert.AreEqual(1000, account.Balance);
            Assert.AreEqual(account.BonusPointsDeposit, account.BonusPoints);
        }
    }
}
