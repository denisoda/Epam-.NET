using BLL.Interface.Interfaces;
using BLL.Interface.Entities;

namespace BLL.BusinessModels
{
    public class DepositBonusPoints : ICalculatorBonusPoints
    {
        public int GetBonusPoints(BankAccount account, decimal amount)
        {
            return account.BonusPointsDeposit;
        }
    }
}
