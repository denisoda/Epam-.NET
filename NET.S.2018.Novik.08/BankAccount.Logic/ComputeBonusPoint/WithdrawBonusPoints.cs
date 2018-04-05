using System;

namespace BankAccount.Logic.ComputeBonusPoint
{
    public class WithdrawBonusPoints : IComputeBonusPoints
    {
        public int GetBonusPoints(BankAccount account, decimal amount)
        {
            return account.BonusPointsWithdraw;
        }
    }
}
