using StARKS.Database_Context;
using StARKS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StARKS.Repository
{
    /// <summary>
    /// The Course Repository
    /// </summary>
    public class CourseRepository : ICourseRepository
    {
        /// <summary>
        /// Db context.
        /// </summary>
        private readonly DBContext db = new DBContext();

        /// <summary>
        /// Getting data about course using linq.
        /// (from course in db.Courses
        /// where course.CourseId == "id"
        /// select course).FirstOrDefault();
        /// SQL: SELECT * FROM db.Courses
        /// WHERE CourseId = 'id';
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course GetCourse(int id)
        {
            return db.Courses.FirstOrDefault(m => m.CourseId == id);
        }

        /// <summary>
        /// Getting list of all courses using linq.
        /// (from course in db.Courses select course).ToList();
        /// SQL: SELECT * FROM db.Courses
        /// </summary>
        /// <returns></returns>
        public List<Course> GetCourses()
        {
            return db.Courses.ToList();
        }

        /// <summary>
        /// The Saving information about course.
        /// </summary>
        /// SQL: INSERT INTO db.Courses (Name, Code, Description)
        /// VALUES(value1, value2, value3);
        /// <param name="course"></param>
        public void Save(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        /// <summary>
        /// The Deleting course information.
        /// SQL: DELETE FROM db.Courses WHERE condition;
        /// </summary>
        /// <param name="course"></param>
        public void Delete(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        /// <summary>
        /// The Updating information about course.
        /// SQL: UPDATE db.Courses
        /// SET Name = value1, Code = value2,...
        /// WHERE condition;
        /// </summary>
        /// <param name="course"></param>
        public void Update(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
        }
    }
}
