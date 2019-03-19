using StARKS.Entities;
using System.Collections.Generic;

namespace StARKS.Repository
{
    /// <summary>
    /// The ICourse Repository.
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Getting Course by id..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Course GetCourse(int id);

        /// <summary>
        /// Getting Courses.
        /// </summary>
        /// <returns></returns>
        List<Course> GetCourses();

        /// <summary>
        /// Saving Course.
        /// </summary>
        /// <param name="course"></param>
        void Save(Course course);

        /// <summary>
        /// Deleting Course.
        /// </summary>
        /// <param name="course"></param>
        void Delete(Course course);

        /// <summary>
        /// Updating Course.
        /// </summary>
        /// <param name="course"></param>
        void Update(Course course);
    }
}
