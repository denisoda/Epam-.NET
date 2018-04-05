using System;

namespace BankAccount.Logic.Factories
{
    /// <summary>
    /// The factory <see cref="BankAccount"/>.
    /// </summary>
    public class BankAccountFactory : IBankAccountFactory
    {
        /// <summary>
        /// Create an instance <see cref="BankAccount"/>.
        /// </summary>
        /// <param name="id">The identifier of bank account.</param>
        /// <param name="name">The name of a holder.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonusPoints">Bonus points.</param>
        /// <param name="type">Wich type of <see cref="BankAccount"/> need to create.</param>
        /// <returns>An instance of <see cref="BankAccount"/>.</returns>
        public BankAccount GetInstance(int id, string name, decimal balance, int bonusPoints, TypeBankAccount type)
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
