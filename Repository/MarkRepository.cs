using StARKS.Database_Context;
using StARKS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StARKS.Repository
{
    /// <summary>
    /// The Mark Repository.
    /// </summary>
    public class MarkRepository : IMarkRepository
    {
        /// <summary>
        /// Db context.
        /// </summary>
        private readonly DBContext db = new DBContext();

        /// <summary>
        /// Getting data about mark using linq.
        /// (from mark in db.Marks
        /// where mark.Markid == "id"
        /// select mark).FirstOrDefault();
        /// SQL: SELECT * FROM db.Marks
        /// WHERE MarkId = 'id';
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mark GetMark(int id)
        {
            return db.Marks.FirstOrDefault(m => m.MarkId == id);
        }

        /// <summary>
        /// Getting list of all marks using linq.
        /// (from mark in db.Marks select mark).ToList();
        /// SQL: SELECT * FROM db.Marks
        /// </summary>
        /// <returns></returns>
        public List<Mark> GetMarks()
        {
            return db.Marks.ToList();
        }

        /// <summary>
        /// The Saving information about Mark.
        /// </summary>
        /// SQL: INSERT INTO db.Marks (StudentId, CourseId, Value)
        /// VALUES(value1, value2, value3);
        /// <param name="course"></param>
        public void Save(Mark mark)
        {
            db.Marks.Add(mark);
            db.SaveChanges();
        }

        /// <summary>
        /// The deleting information about mark.
        /// SQL: DELETE FROM db.Marks WHERE condition;
        /// </summary>
        /// <param name="mark"></param>
        public void Delete(Mark mark)
        {
            db.Marks.Remove(mark);
            db.SaveChanges();
        }

        /// <summary>
        /// The updating information about mark.
        /// SQL: UPDATE db.Marks
        /// SET StudentId = value1, CourseId = value2, Value = value3
        /// WHERE condition;
        /// </summary>
        /// <param name="mark"></param>
        public void Update(Mark mark)
        {
            db.Marks.Update(mark);
            db.SaveChanges();
        }
    }
}
