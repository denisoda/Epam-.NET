using BankAccount.Logic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BankAccount.Logic.Storage
{
    public class BankAccountStorageBinary : IBankAccountStorage
    {
        #region Private fields

        private string _path;
        private IBankAccountFactory _bankAccountFactory;

        #endregion

        #region Constructors

        public BankAccountStorageBinary(string path, IBankAccountFactory bankAccountFactory)
        {
            this.Path = path;
            this.BankAccountFactory = bankAccountFactory;
        }

        #endregion

        #region Properties

        public string Path
        {
            get
            {
                return this._path;
            }

            private set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArithmeticException($"{nameof(value)} must be not empty");
                }

                this._path = value;
            }
        }

        private IBankAccountFactory BankAccountFactory
        {
            get
            {
                return this._bankAccountFactory;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._bankAccountFactory = value;
            }
        }

        #endregion

        #region Public methods

        public IEnumerable<BankAccount> Load()
        {
            List<BankAccount> listLoadBankAccounts = new List<BankAccount>();

            using (Stream stream = File.Open(this.Path, FileMode.OpenOrCreate))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        int id = binaryReader.ReadInt32();
                        string holderName = binaryReader.ReadString();
                        decimal balance = binaryReader.ReadDecimal();
                        int bonusPoints = binaryReader.ReadInt32();
                        TypeBankAccount typeBankAccount = (TypeBankAccount)binaryReader.ReadInt32();
                        BankAccount account = this.BankAccountFactory.GetInstance(id, holderName, balance, bonusPoints, typeBankAccount);

                        listLoadBankAccounts.Add(account);
                    }
                }
            }

            return listLoadBankAccounts;
        }

        public void Save(IEnumerable<BankAccount> items)
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
