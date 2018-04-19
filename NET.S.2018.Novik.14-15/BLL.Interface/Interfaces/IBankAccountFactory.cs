using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountFactory
    {
        BankAccount GetInstance(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type);
    }
}
