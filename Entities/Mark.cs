using System.ComponentModel.DataAnnotations.Schema;

namespace StARKS.Entities
{
    /// <summary>
    /// The student mark.
    /// </summary>
    public class Mark
    {
        /// <summary>
        /// Gets or sets the Mark Id.
        /// </summary>
        /// <value>
        /// The Mark Id.
        /// </value>
        public int MarkId { get; set; }

        /// <summary>
        /// Gets or sets the Course Id.
        /// </summary>
        /// <value>
        /// The Course Id.
        /// </value>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the Course.
        /// </summary>
        /// <value>
        /// The Course.
        /// </value>
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the Student Id.
        /// </summary>
        /// <value>
        /// The Student Id.
        /// </value>
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the Student.
        /// </summary>
        /// <value>
        /// The Student.
        /// </value>
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        /// <value>
        /// The Value.
        /// </value>
        public int? Value { get; set; }
    }
}
