using BLL.Interface.Interfaces; 

namespace BLL.BusinessModels
{
    /// <summary>
    /// Provieds the method that generators ID.
    /// </summary>
    public class GeneratorId : IGeneratorId
    {
        /// <summary>
        /// Gets id.
        /// </summary>
        /// <returns>Integer.</returns>
        public int GenerateId(int lastId)
        {
            return lastId++;
        }
    }
}
