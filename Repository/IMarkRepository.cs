using StARKS.Entities;
using System.Collections.Generic;

namespace StARKS.Repository
{
    /// <summary>
    /// The IMark Repository.
    /// </summary>
    public interface IMarkRepository
    {
        /// <summary>
        /// Getting Mark by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Mark GetMark(int id);

        /// <summary>
        /// Getting Marks.
        /// </summary>
        /// <returns></returns>
        List<Mark> GetMarks();

        /// <summary>
        /// Saving Mark.
        /// </summary>
        /// <param name="student"></param>
        void Save(Mark student);

        /// <summary>
        /// Deleting Mark.
        /// </summary>
        /// <param name="student"></param>
        void Delete(Mark student);

        /// <summary>
        /// Updating Mark.
        /// </summary>
        /// <param name="student"></param>
        void Update(Mark student);
    }
}
