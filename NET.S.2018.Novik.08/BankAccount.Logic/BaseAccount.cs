using System;
using BankAccount.Logic.ComputeBonusPoint;

namespace BankAccount.Logic
{
    /// <summary>
    /// Implementation bank account with base graduation.
    /// </summary>
    public class BaseAccount : BankAccount
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier of bank account.</param>
        /// <param name="name">The name of a holder.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonusPoint">Bonus points.</param>
        public BaseAccount(int id, string name, decimal balance, int bonusPoint)
            : base(id, name, balance, bonusPoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier of bank account.</param>
        /// <param name="name">The name of a holder.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonusPoint">Bonus points.</param>
        /// <param name="computeToWithdraw">Strategy to compute bonus points to withdraw.</param>
        /// <param name="computeToDeposit">Strategy to compute bonus points to deposit.</param>
        public BaseAccount(int id, string name, decimal balance, int bonusPoint, IComputeBonusPoints computeToWithdraw, IComputeBonusPoints computeToDeposit)
            : base(id, name, balance, bonusPoint, computeToWithdraw, computeToDeposit)
        {
        }

        #endregion

        #region Public properties

        public override int BonusPointsDeposit { get; protected set; } = 6;

        public override int BonusPointsWithdraw { get; protected set; } = 6;

        public override TypeBankAccount Type { get; } = TypeBankAccount.Base;

        #endregion
    }
}
