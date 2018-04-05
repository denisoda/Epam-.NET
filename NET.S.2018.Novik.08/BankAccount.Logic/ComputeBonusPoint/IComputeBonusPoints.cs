using System;

namespace BankAccount.Logic.ComputeBonusPoint
{
    public interface IComputeBonusPoints
    {
        int GetBonusPoints(BankAccount account, decimal amount);
    }
}
