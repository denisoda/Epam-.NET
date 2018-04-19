namespace DAL.Interface.DTO
{
    /// <summary>
    /// Represents the entity to work in  the <see cref="DAL.Interface.Interfaces.IBankAccountStorage"/>.
    /// </summary>
    public class AccountDTO
    {
        #region Public properties

        /// <summary>
        /// The identifier of the bank account.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The holder of the bank account.
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// Size of money on a bank account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// The bank account's bonus points
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// The type of the bank account.
        /// </summary>
        public int Type { get; set; }

        #endregion
    }
}
