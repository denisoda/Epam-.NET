﻿using System;

namespace BankAccount.Logic.Exceptions
{
    public class BankAccountAlreadyExistsException : Exception
    {
        public BankAccountAlreadyExistsException()
        {
        }

        public BankAccountAlreadyExistsException(string message)
            : base(message)
        {
        }

        public BankAccountAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
