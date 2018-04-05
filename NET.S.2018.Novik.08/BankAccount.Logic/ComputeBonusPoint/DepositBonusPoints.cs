using System;

namespace BankAccount.Logic.ComputeBonusPoint
{
    public class DepositBonusPoints : IComputeBonusPoints
    {
        public int GetBonusPoints(BankAccount account, decimal amount)
        {
            return account.BonusPointsDeposit;
        }
    }
}
