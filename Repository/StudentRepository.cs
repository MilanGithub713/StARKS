using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StARKS.Database_Context;
using StARKS.Entities;

namespace StARKS.Repository
{
    /// <summary>
    /// The Student repository.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        /// <summary>
        /// The Db context.
        /// </summary>
        private readonly DBContext db = new DBContext();

        /// <summary>
        /// The getting information about student by id.
        /// Getting data about student using linq.
        /// (from student in db.Students
        /// where student.StudentId == "id"
        /// select student).FirstOrDefault();
        /// SQL: SELECT * FROM db.Students
        /// WHERE StudentId = 'id';
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            return db.Students.FirstOrDefault(m => m.StudentId == id);
        }

        /// <summary>
        /// The getting students.
        /// (from student in db.Students select student).ToList();
        /// SQL: SELECT * FROM db.Students
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        /// <summary>
        /// The getting students marks.
        /// (from stud in db.Students
        /// select stud).Include(ord => ord.Marks).ToList();
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentsMarks()
        {
            return db.Students.Include(o => o.Marks).ToList();
        }

        /// <summary>
        /// The saving information about student.
        /// SQL: INSERT INTO db.Students (FirstName, LastName, City,...)
        /// VALUES(value1, value2, value3, ...);
        /// </summary>
        /// <param name="student"></param>
        public void Save(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        /// <summary>
        /// The updating information about student.
        /// SQL: UPDATE db.Students
        /// SET FirstName = value1, LastName = value2,...
        /// WHERE condition;
        /// </summary>
        /// <param name="student"></param>
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }

        /// <summary>
        /// The deleting informaiton about student.
        /// </summary>
        /// SQL: DELETE FROM db.Students WHERE condition;
        /// <param name="student"></param>
        public void Delete(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
