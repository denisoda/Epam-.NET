using BLL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Implementation bank account with platinum graduation.
    /// </summary>
    public class PlatinumAccount : BankAccount
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier of bank account.</param>
        /// <param name="name">The name of a holder.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonusPoint">Bonus points.</param>
        public PlatinumAccount(int id, string name, decimal balance, int bonusPoint)
            : base(id, name, balance, bonusPoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier of bank account.</param>
        /// <param name="name">The name of a holder.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonusPoint">Bonus points.</param>
        /// <param name="computeToWithdraw">Strategy to compute bonus points to withdraw.</param>
        /// <param name="computeToDeposit">Strategy to compute bonus points to deposit.</param>
        public PlatinumAccount(int id, string name, decimal balance, int bonusPoints,
            ICalculatorBonusPoints computeToWithdraw, ICalculatorBonusPoints computeToDeposit)
            : base(id, name, balance, bonusPoints, computeToWithdraw, computeToDeposit)
        {
        }

        #endregion

        #region Public properties

        public override int BonusPointsDeposit { get; protected set; } = 2;

        public override int BonusPointsWithdraw { get; protected set; } = 1;

        public override TypeBankAccount Type { get; } = TypeBankAccount.Platinum;

        #endregion
    }
}
