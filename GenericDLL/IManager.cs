using System.Collections.Generic;
using GenericDLL.Entities;

namespace GenericDLL
{
    public interface IManager<T> where T : Entity
    {
        /// <summary>
        /// Returns a list with all available
        /// </summary>
        /// <returns>List</returns>
        List<T> Get();

        /// <summary>
        /// Create a t using the incoming
        /// Person
        /// </summary>
        /// <param name="t"></param>
        /// <returns>T</returns>
        T Create(T t);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// Gets a single t by finding the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Updates a t I like documenting stuff so funny..
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update(T t);
    }
}
