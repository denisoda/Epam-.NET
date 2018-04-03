using BankAccount.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Logic
{
    public abstract class BankAccount
    {
        #region Private fields

        private int _id;
        private string _name;
        private decimal _balance;
        private int _bonusPoints;

        #endregion

        #region Constuctors

        public BankAccount(int id, string name, decimal balance, int bonusPoints)
        {
            this.Id = id;
            this.Name = name;
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// The identifier of the bank account.
        /// </summary>
        public int Id
        {
            get
            {
                return this.Id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this.Id = value;
            }
        }

        /// <summary>
        /// The holder of the bank account.
        /// </summary>
        public string Name
        {
            get
            {
                return this.Name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(value)}");
                }

                this.Name = value;
            }
        }

        /// <summary>
        /// Size of money on a bank account.
        /// </summary>
        public decimal Balance
        {
            get
            {
                return this.Balance;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this.Balance = value;
            }
        }

        /// <summary>
        /// The bank account's bonus points
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return this.BonusPoints;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this.BonusPoints = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Withdraw money from the bank balance.
        /// </summary>
        /// <param name="amount">Amount to withdraw.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="amount"/> less than 0.
        /// </exception>
        /// <exception cref="NotEnoughMoneyException">
        /// <paramref name="amount"/> greater than there is on a balance .
        /// </exception>
        public void WithdrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            if (amount > this.Balance)
            {
                throw new NotEnoughMoneyException(nameof(amount));
            }

            this.Balance = this.Balance - amount;
            int bonusResidual = this.BonusPoints - this.CalculateBonusPointsWithdraw(amount);
            this.BonusPoints = bonusResidual > 0 ? bonusResidual : 0;
        }

        /// <summary>
        /// Withdraw money from the bank balance.
        /// </summary>
        /// <param name="amount">Amount to deposit.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="amount"/> less than 0.
        /// </exception>
        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            this.Balance = this.Balance + amount;
            this.BonusPoints = this.BonusPoints + this.CalculateBonusPointsDeposit(amount);
        }

        #endregion

        #region Protected methods

        protected abstract int CalculateBonusPointsWithdraw(decimal amount);

        protected abstract int CalculateBonusPointsDeposit(decimal amount);

        #endregion
    }
}
