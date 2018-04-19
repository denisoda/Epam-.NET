using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface ICalculatorBonusPoints
    {
        int GetBonusPoints(BankAccount account, decimal amount);
    }
}
