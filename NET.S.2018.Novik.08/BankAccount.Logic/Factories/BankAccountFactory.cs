using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Logic.Factories
{
    /// <summary>
    /// The factory of bank accounts.
    /// </summary>
    public class BankAccountFactory
    {
        public BankAccount GetBankAccount(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type)
        {
            switch (type)
            {
                case TypeBankAccount.Base:
                    return new BaseAccount(id, name, balance, bonusPoints);
                    break;

                case TypeBankAccount.Golden:
                    return new GoldAccount(id, name, balance, bonusPoints);
                    break;

                case TypeBankAccount.Platinum:
                    return new PlatinumAccount(id, name, balance, bonusPoints);
                    break;

                default:
                    return new BaseAccount(id, name, balance, bonusPoints);
            }
        }
    }
}
