using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using BLL.Exceptions;
using DAL.Interface.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Repositories
{
    /// <summary>
    /// Implementation a service to work with <see cref="BankAccount"/>.
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        #region Private fields

        private readonly List<BankAccount> listBankAccounts;
        private readonly IBankAccountStorage bankAccountStorage;
        private readonly BankAccountMapper bankAccountMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountService"/> class by instance of factory of storage.
        /// </summary>
        /// <param name="bankAccountStorage">The storage.</param>
        /// <param name="bankAccountFactory">The factory of bank accounts.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="bankAccountStorage"/> is null.
        /// <paramref name="bankAccountFactory"/> is null.
        /// </exception>
        public BankAccountService(IBankAccountStorage bankAccountStorage, BankAccountMapper bankAccountMapper)
        {
            if (bankAccountStorage is null)
            {
                throw new ArgumentNullException(nameof(bankAccountStorage));
            }

            if (bankAccountMapper is null)
            {
                throw new ArgumentNullException(nameof(bankAccountMapper));
            }

            this.bankAccountStorage = bankAccountStorage;
            this.bankAccountMapper = bankAccountMapper;
            this.listBankAccounts = this.bankAccountStorage.Load().Select(m => this.bankAccountMapper.ToBankAccount(m)).ToList();
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

        public IEnumerator<BankAccount> GetEnumerator()
        {
            return this.listBankAccounts.GetEnumerator();
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
            this.bankAccountStorage.Save(this.listBankAccounts.Select(m => this.bankAccountMapper.ToAccount(m)));
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
