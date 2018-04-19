using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using System;

namespace BLL.Mappers
{
    /// <summary>
    /// Provides methods to cast the <see cref="AccountDTO"/> into the <see cref="BankAccount"/> and back.
    /// </summary>
    public class BankAccountMapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountMapper"/> class.
        /// </summary>
        /// <param name="bankAccountFactory">Bank accounts's factory.</param>
        public BankAccountMapper(IBankAccountFactory bankAccountFactory)
        {
            if (bankAccountFactory is null)
            {
                throw new ArgumentNullException();
            }

            this.BankAccountFactory = bankAccountFactory;
        }

        #endregion

        #region Properties

        public IBankAccountFactory BankAccountFactory { get; set; }

        #endregion

        #region Public methods

        public AccountDTO ToAccount(BankAccount bankAccountToCast)
        {
            return new AccountDTO()
            {
                Id = bankAccountToCast.Id,
                HolderName = bankAccountToCast.HolderName,
                Balance = bankAccountToCast.Balance,
                BonusPoints = bankAccountToCast.BonusPoints,
                Type = (int)bankAccountToCast.Type
            };
        }

        public BankAccount ToBankAccount(AccountDTO accountDTOToCast)
        {
            return this.BankAccountFactory.GetInstance(accountDTOToCast.Id, accountDTOToCast.HolderName, accountDTOToCast.Balance,
                accountDTOToCast.BonusPoints, (TypeBankAccount)accountDTOToCast.Type);
        }

        #endregion

    }
}
