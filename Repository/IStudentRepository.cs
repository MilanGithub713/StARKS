using StARKS.Entities;
using System.Collections.Generic;

namespace StARKS.Repository
{
    /// <summary>
    /// The IStudent Repository.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Getting Student by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudent(int id);

        /// <summary>
        /// Getting Students.
        /// </summary>
        /// <returns></returns>
        List<Student> GetStudents();

        /// <summary>
        /// Saving Student.
        /// </summary>
        /// <param name="student"></param>
        void Save(Student student);

        /// <summary>
        /// Deleting Student.
        /// </summary>
        /// <param name="student"></param>
        void Delete(Student student);

        /// <summary>
        /// Updating Student.
        /// </summary>
        /// <param name="student"></param>
        void Update(Student student);

        /// <summary>
        /// Getting Students Marks.
        /// </summary>
        /// <returns></returns>
        List<Student> GetStudentsMarks();
    }
}
