using DAL.Interface.DTO;
using System.Collections.Generic;


namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Represents a storage.
    /// </summary>
    public interface IBankAccountStorage
    {
        /// <summary>
        /// Path to the file.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Load sequence of the <see cref="AccountDTO"/> from file.
        /// </summary>
        /// <returns>The sequence of the <see cref="AccountDTO"/>.</returns>
        IEnumerable<AccountDTO> Load();

        /// <summary>
        /// Save sequence of the <see cref="AccountDTO"/> to the storage.
        /// </summary>
        /// <param name="items">The sequence of  the <see cref="AccountDTO"/>.</param>
        void Save(IEnumerable<AccountDTO> items);
    }
}
