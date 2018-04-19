using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DAL.Repositories
{
    /// <summary>
    /// Provieds methods to work with a repository based on binary file.
    /// </summary>
    public class BankAccountStorageBinary : IBankAccountStorage
    {
        #region Private fields

        private string _path;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountStorageBinary"/> class.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="path"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="path"/> is empty.
        /// </exception> 
        public BankAccountStorageBinary(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (path == string.Empty)
            {
                throw new ArithmeticException($"{nameof(path)} must be not empty");
            }

            this._path = path;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Path to the file that use to memory the information.
        /// </summary>
        public string Path
        {
            get
            {
                return this._path;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Load sequence of the <see cref="AccountDTO"/> from file.
        /// </summary>
        /// <returns>The sequence of the <see cref="AccountDTO"/>.</returns>
        public IEnumerable<AccountDTO> Load()
        {
            List<AccountDTO> listLoadBankAccounts = new List<AccountDTO>();

            using (Stream stream = File.Open(this.Path, FileMode.OpenOrCreate))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    while (binaryReader.PeekChar() > -1)
                    {

                        AccountDTO account = new AccountDTO()
                        {
                            Id = binaryReader.ReadInt32(),
                            HolderName = binaryReader.ReadString(),
                            Balance = binaryReader.ReadDecimal(),
                            BonusPoints = binaryReader.ReadInt32(),
                            Type = binaryReader.ReadInt32()
                        };

                        listLoadBankAccounts.Add(account);
                    }
                }
            }

            return listLoadBankAccounts;
        }

        /// <summary>
        /// Save sequence of the <see cref="AccountDTO"/> to the storage.
        /// </summary>
        /// <param name="items">The sequence of  the <see cref="AccountDTO"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="items"/> is null.
        /// </exception>
        public void Save(IEnumerable<AccountDTO> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            using (Stream stream = File.Open(this.Path, FileMode.Truncate))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var account in items)
                    {
                        binaryWriter.Write(account.Id);
                        binaryWriter.Write(account.HolderName);
                        binaryWriter.Write(account.Balance);
                        binaryWriter.Write(account.BonusPoints);
                        binaryWriter.Write((int)account.Type);
                    }
                }
            }
        }

        #endregion

    }
}
