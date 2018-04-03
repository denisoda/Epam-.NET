using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Logic
{
    /// <summary>
    /// Implementation bank account with gold graduation.
    /// </summary>
    public class GoldAccount : BankAccount
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier of bank account.</param>
        /// <param name="name">The name of a holder.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonusPoint">Bonus points.</param>
        public GoldAccount(int id, string name, decimal balance, int bonusPoint)
            : base(id, name, balance, bonusPoint)
        {
        }

        #endregion

        protected override int CalculateBonusPointsDeposit(decimal amount)
        {
            return 10;
        }

        protected override int CalculateBonusPointsWithdraw(decimal amount)
        {
            return 0;
        }
    }
}
