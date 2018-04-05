using BankAccount.Logic.Exceptions;
using BankAccount.Logic.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount.Logic.Services
{
    /// <summary>
    /// Implementation a service to work with <see cref="BankAccount"/>.
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        #region Private fields

        private readonly List<BankAccount> listBankAccounts;
        private IBankAccountStorageFactory bankAccountStorageFactory;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountService"/> class by instance of factory of storage.
        /// </summary>
        /// <param name="bankAccountStorageFactory">The factory of storage.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="bankAccountStorageFactory"/> is null.
        /// </exception>
        public BankAccountService(IBankAccountStorageFactory bankAccountStorageFactory)
        {
            if (bankAccountStorageFactory is null)
            {
                throw new ArgumentNullException(nameof(bankAccountStorageFactory));
            }

            this.bankAccountStorageFactory = bankAccountStorageFactory;
            this.listBankAccounts = bankAccountStorageFactory.GetInstance().Load().ToList();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add a bank account to the service.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="account"/> is null.
        /// </exception>
        /// <exception cref="BankAccountAlreadyExistsException">
        /// <paramref name="book"/> exists in the service.
        /// </exception>
        /// <param name="account">The bank account to add.</param>
        public void Add(BankAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (this.IsExists(account))
            {
                throw new BankAccountAlreadyExistsException($"{nameof(account)} already exists");
            }

            this.listBankAccounts.Add(account);
        }

        /// <summary>
        /// Remove the bank account from this service.
        /// </summary>
        /// <exception cref="BankAccountNotFoundException">
        /// <paramref name="account"/> does not exist in the service.
        /// </exception>
        /// <param name="account">The bank account to remove.</param>
        public void Remove(BankAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!this.IsExists(account, out int index))
            {
                throw new BankAccountNotFoundException($"{nameof(account)} already exists");
            }

            this.listBankAccounts.RemoveAt(index);
        }

        /// <summary>
        /// Save the service in the storage.
        /// </summary>
        public void Save()
        {
            this.bankAccountStorageFactory.GetInstance().Save(this.listBankAccounts);
        }

        /// <summary>
        /// Converts <see cref="BankAccountService"/> states of this instance to its equvalent string representation.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string result = string.Empty;

            foreach (var item in this.listBankAccounts)
            {
                result += item + "\n";
            }

            return result;
        }

        #endregion

        #region Private methods

        private bool IsExists(BankAccount accountToFind)
        {
            bool result = false;

            foreach (var bankAccount in this.listBankAccounts)
            {
                if (bankAccount.Equals(accountToFind))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool IsExists(BankAccount accountToFind, out int index)
        {
            bool result = false;
            index = -1;

            for (int i = 0; i < this.listBankAccounts.Count; i++)
            {
                if (this.listBankAccounts[i].Equals(accountToFind))
                {
                    result = true;
                    index = i;
                    break;
                }
            }

            return result;
        }

        #endregion
    }
}
