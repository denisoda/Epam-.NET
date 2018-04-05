using BankAccount.Logic.Exceptions;
using BankAccount.Logic.ComputeBonusPoint;
using System;

namespace BankAccount.Logic
{
    public abstract class BankAccount : IEquatable<BankAccount>
    {
        #region Private fields

        private int _id;
        private string _holderName;
        private decimal _balance;
        private int _bonusPoints;
        private IComputeBonusPoints _computeBonusPointsToWithdraw = new WithdrawBonusPoints();
        private IComputeBonusPoints _computeBonusPointsToDeposit = new DepositBonusPoints();

        #endregion

        #region Constuctors

        public BankAccount(int id, string holderName, decimal balance, int bonusPoints)
        {
            this.Id = id;
            this.HolderName = holderName;
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
        }

        public BankAccount(int id, string holderName, decimal balance, int bonusPoints, IComputeBonusPoints computeToWithdraw, IComputeBonusPoints computeToDeposit)
            : this(id, holderName, balance, bonusPoints)
        {
            this.ComputeBonusPointsToDeposit = computeToDeposit;
            this.ComputeBonusPointsToWithdraw = computeToWithdraw;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Strategy to compute bonus points to withdraw.
        /// </summary>
        public IComputeBonusPoints ComputeBonusPointsToWithdraw
        {
            get
            {
                return this._computeBonusPointsToWithdraw;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._computeBonusPointsToWithdraw = value;
            }
        }

        /// <summary>
        /// Strategy to compute bonus points to deposit.
        /// </summary>
        public IComputeBonusPoints ComputeBonusPointsToDeposit
        {
            get
            {
                return this._computeBonusPointsToDeposit;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._computeBonusPointsToDeposit = value;
            }
        }

        /// <summary>
        /// The identifier of the bank account.
        /// </summary>
        public int Id
        {
            get
            {
                return this._id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this._id = value;
            }
        }

        /// <summary>
        /// The holder of the bank account.
        /// </summary>
        public string HolderName
        {
            get
            {
                return this._holderName;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)}");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this._holderName = value;
            }
        }

        /// <summary>
        /// Size of money on a bank account.
        /// </summary>
        public decimal Balance
        {
            get
            {
                return this._balance;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this._balance = value;
            }
        }

        /// <summary>
        /// The bank account's bonus points
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return this._bonusPoints;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)}  must be greater than 0");
                }

                this._bonusPoints = value;
            }
        }

        public abstract int BonusPointsWithdraw { get; protected set; }

        public abstract int BonusPointsDeposit { get; protected set; }

        public abstract TypeBankAccount Type { get; protected set; }

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
            int bonusResidual = this.BonusPoints - this.ComputeBonusPointsToWithdraw.GetBonusPoints(this, amount);
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
            this.BonusPoints = this.BonusPoints + this.ComputeBonusPointsToDeposit.GetBonusPoints(this, amount);
        }

        /// <summary>
        /// Returns a value indicating  wheter this instance is equal to a specified object instance.
        /// </summary>
        /// <param name="obj">A object instance to compare with this instance.</param>
        /// <returns>
        /// <see cref="true"/> if the specified  object instance is equal to the current object instance; otherwise, <see cref="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((BankAccount)obj);
        }

        /// <summary>
        /// Returns a value indicating  wheter this instance is equal to a specified <see cref="Book"/> instance.
        /// by property <see cref="BankAccount.Id"/>.
        /// </summary>
        /// <param name="other">A <see cref="BankAccount"/> instance to compare with this <see cref="BankAccount"/> instance.</param>
        /// <returns>
        /// <see cref="true"/> if the specified <see cref="BankAccount"/> instance is equal to the current <see cref="BankAccount"/> instance; otherwise, <see cref="false"/>.
        /// </returns>
        public bool Equals(BankAccount other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            if (this.Id == other.Id)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Return numeric representation this book instance.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Converts <see cref="BankAccount"/> states of this instance to its equvalent string representation.
        /// </summary>
        /// <returns>The string representation <see cref="BankAccount"/>.</returns>
        public override string ToString()
        {
            return $"[Id: {this.Id};\n HolderName: {this.HolderName}; " +
                $"\n Balance: {this.Balance}; \n BonusPoints: {this.BonusPoints};]";
        }

        #endregion
    }
}
