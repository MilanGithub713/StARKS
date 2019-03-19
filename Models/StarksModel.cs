using StARKS.Entities;
using System.Collections.Generic;


namespace StARKS.Models
{
    /// <summary>
    /// The StARKS model.
    /// </summary>
    public class StarksModel
    {
        /// <summary>
        /// Gets or sets the Students.
        /// </summary>
        /// <value>
        /// The list of Students.
        /// </value>
        public List<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets the Courses.
        /// </summary>
        /// <value>
        /// The list of Courses.
        /// </value>
        public List<Course> Courses { get; set; }

        /// <summary>
        /// Gets or sets the Student Marks.
        /// </summary>
        /// <value>
        /// The list of Student Marks.
        /// </value>
        public List<Student> StudentMarks { get; set; }
    }
}
